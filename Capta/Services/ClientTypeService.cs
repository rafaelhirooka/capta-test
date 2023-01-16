using Capta.Data;
using Capta.Models;
using Microsoft.EntityFrameworkCore;

namespace Capta.Services
{
  public class ClientTypeService
  {
    private readonly CaptaContext _context;
    public ClientTypeService(CaptaContext context) 
    {
      _context = context;
    }
    public async Task<List<ClientType>> GetAllAsync()
    {
      var items = await _context.ClientTypes.ToListAsync();

      return items;
    }
  }
}
