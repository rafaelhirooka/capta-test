using Capta.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capta.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class ClientsController : ControllerBase
  {
    private readonly ClientService _clientService;
    public ClientsController(ClientService clientService) 
    {
      _clientService = clientService;
    }

    
  }
}
