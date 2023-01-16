using Capta.Data;
using Capta.Models;
using Microsoft.EntityFrameworkCore;

namespace Capta.Services
{
  public class ClientService
  {
    private readonly CaptaContext _context;
    public ClientService(CaptaContext context) 
    {
      _context = context;
    }
    public async Task<List<Client>> GetAllAsync()
    {
      var clients = await _context.Clients.ToListAsync();

      return clients;
    }

    public async Task<Client> StoreAsync(Client client)
    {
      var newItem = new Client
      {
        Name = client.Name,
        Cpf = client.Cpf,
        Gender = client.Gender,
        IdClientSituation = client.IdClientSituation,
        IdClientType = client.IdClientType,
      };

      _context.Clients.Add(newItem);

      await _context.SaveChangesAsync();

      return newItem;
    }

    public async Task<Client> UpdateAsync(int id, ClientUpdateDTO client)
    {
      var existingItem = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);

      if (existingItem is null) throw new ApplicationException("Item not found");

      existingItem.Cpf = client.Cpf ?? existingItem.Cpf;
      existingItem.Name = client.Name ?? existingItem.Name;
      existingItem.IdClientType = client.IdClientType ?? existingItem.IdClientType;
      existingItem.IdClientSituation = client.IdClientSituation ?? existingItem.IdClientSituation;
      existingItem.Gender = client.Gender ?? existingItem.Gender;

      _context.Entry(existingItem).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return existingItem;
    }

    public async Task DeleteAsync(int id)
    {
      var existingItem = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);

      if (existingItem is null) throw new ApplicationException("Item not found");

      _context.Remove(existingItem);

      await _context.SaveChangesAsync();
    }
  }
}
