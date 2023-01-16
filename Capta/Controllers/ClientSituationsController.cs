using Capta.Models;
using Capta.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capta.Controllers
{
  [Route("api/client-situations")]
  [ApiController]
  //[Authorize]
  public class ClientSituationsController : ControllerBase
  {
    private readonly ClientSituationService _clientSituationService;
    public ClientSituationsController(ClientSituationService clientSituationService) 
    {
      _clientSituationService = clientSituationService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      try
      {
        var items = await _clientSituationService.GetAllAsync();

        return Ok(items);
      } catch (ApplicationException ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
