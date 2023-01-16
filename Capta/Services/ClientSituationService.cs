using Capta.Data;
using Capta.Models;
using Microsoft.EntityFrameworkCore;

namespace Capta.Services
{
  public class ClientSituationService
  {
    private readonly CaptaContext _context;
    public ClientSituationService(CaptaContext context) 
    {
      _context = context;
    }
    public async Task<List<ClientSituation>> GetAllAsync()
    {
      var items = await _context.ClientSituations.ToListAsync();

      return items;
    }
  }
}
