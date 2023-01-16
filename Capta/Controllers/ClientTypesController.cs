using Capta.Models;
using Capta.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capta.Controllers
{
  [Route("api/client-types")]
  [ApiController]
  //[Authorize]
  public class ClientTypesController : ControllerBase
  {
    private readonly ClientTypeService _clientTypeService;
    public ClientTypesController(ClientTypeService clientTypeService) 
    {
      _clientTypeService = clientTypeService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      try
      {
        var items = await _clientTypeService.GetAllAsync();

        return Ok(items);
      } catch (ApplicationException ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
