using Capta.Models;
using Capta.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capta.Controllers
{
  [Route("api/clients")]
  [ApiController]
  //[Authorize]
  public class ClientsController : ControllerBase
  {
    private readonly ClientService _clientService;
    public ClientsController(ClientService clientService) 
    {
      _clientService = clientService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      try
      {
        var items = await _clientService.GetAllAsync();

        return Ok(items);
      } catch (ApplicationException ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Show(int id)
    {
      try
      {
        var item = await _clientService.GetAsync(id);

        return Ok(item);
      }
      catch (ApplicationException ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Create(Client client)
    {
      try
      {
        var item = await _clientService.StoreAsync(client);

        return Ok(item);
      }
      catch (ApplicationException ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ClientUpdateDTO client)
    {
      try
      {
        var item = await _clientService.UpdateAsync(id, client);

        return Ok(item);
      }
      catch (ApplicationException ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        await _clientService.DeleteAsync(id);

        return NoContent();
      }
      catch (ApplicationException ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
