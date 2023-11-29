namespace AtletaBackend.Models;
public class User
{
    public string? Id { get; set; }
    public string Nome { get; set; } = "";
    public int Idade { get; set; } = 0;
    public string CPF { get; set; } = "";

    public IList<Tarefa> Records { get; set; } = new List<Tarefa>();
}
