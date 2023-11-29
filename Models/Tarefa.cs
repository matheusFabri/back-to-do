namespace AtletaBackend.Models;
public class Tarefa
{
    public string? Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Time { get; set; } = "";
    public bool Done { get; set; }
    public User? User { get; set; }
    public string? UserId { get; set; }
}
