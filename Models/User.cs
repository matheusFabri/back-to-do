using System.ComponentModel.DataAnnotations.Schema;

namespace AtletaBackend.Models;
public class User
{
    public string? Id { get; set; }
    public string Nome { get; set; } = "";
    public int Idade { get; set; } = 0;
    public string CPF { get; set; } = "";

    [InverseProperty("User")]
    public IList<Tarefa> Records { get; } = new List<Tarefa>();
}
