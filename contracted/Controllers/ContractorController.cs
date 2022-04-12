using System.Collections.Generic;
using contracted.Models;
using contracted.Services;
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

  }
}