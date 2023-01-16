using System.ComponentModel.DataAnnotations.Schema;

namespace Capta.Models
{
  public class Client
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Gender { get; set; }
    public int IdClientType { get; set; }
    public int IdClientSituation { get; set; }

    [ForeignKey("IdClientType")]
    public ClientType ClientType { get; set; }

    [ForeignKey("IdClientSituation")]
    public ClientSituation ClientSituation { get; set; }
  }
}
