using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capta.Models
{
  public class Client
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public string Gender { get; set; }
    public int IdClientType { get; set; }
    public int IdClientSituation { get; set; }

    [ForeignKey("IdClientType")]
    public ClientType ClientType { get; set; }

    [ForeignKey("IdClientSituation")]
    public ClientSituation ClientSituation { get; set; }
  }

  public class ClientCreateDTO
  {
    public string Name { get; set; }
    public string Document { get; set; }
    public string Gender { get; set; }
    public int IdClientType { get; set; }
    public int IdClientSituation { get; set; }
  }

  public class ClientUpdateDTO
  {
    public string? Name { get; set; }
    public string? Document { get; set; }
    public string? Gender { get; set; }
    public int? IdClientType { get; set; }
    public int? IdClientSituation { get; set; }
  }
}
