using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using contracted.Models;
using contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace contracted.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {
    private readonly JobsService _js;

    public JobsController(JobsService js)
    {
      _js = js;
    }

    [HttpPost]
    public async Task<ActionResult<Job>> Create([FromBody] Job jobData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Job contractor = _js.Create(jobData);
        return Ok(contractor);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}