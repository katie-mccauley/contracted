using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using contracted.Models;
using contracted.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace contracted.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContractorController : ControllerBase
  {
    private readonly ContractorService _cs;

    public ContractorController(ContractorService cs)
    {
      _cs = cs;
    }

    [HttpGet("{contractId}/companies")]
    public ActionResult<List<CompanyViewModel>> GetCompaniesByContractorId(int contractId)
    {
      try
      {
        List<CompanyViewModel> companies = _cs.GetCompaniesByContractorId(contractId);
        return Ok(companies);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<List<Contractor>> GetAll()
    {
      try
      {
        List<Contractor> contract = _cs.GetAll();
        return Ok(contract);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{contractId}")]

    public ActionResult<Contractor> GetById(int contractId)
    {
      try
      {

        return Ok(_cs.GetById(contractId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]

    public async Task<ActionResult<Contractor>> Create([FromBody] Contractor contractorData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Contractor contractor = _cs.Create(contractorData);
        return Created($"api/contractor/{contractor.Id}", contractor);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{contractId}")]
    [Authorize]
    public async Task<ActionResult<string>> Remove(int contractId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_cs.Remove(contractId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{contractId}")]
    [Authorize]
    public async Task<ActionResult<Contractor>> Update([FromBody] Contractor contractorData, int contractId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        contractorData.Id = contractId;
        return Ok(_cs.Update(contractorData));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);

      }
    }

  }
}