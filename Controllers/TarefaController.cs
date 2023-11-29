using AtletaApi.Models;
using AtletaBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AtletaBackend.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TarefaController : ControllerBase
{
    public TarefaController(ApplicationDbContext db) =>
        this.db = db;

    // GET: api/Tarefa
    [HttpGet]
    public ActionResult<IEnumerable<Tarefa>> Get()
    {
        if (db.Tarefas == null)
            return NotFound();
        return db.Tarefas;
    }
    // GET: api/Tarefa/5
    [HttpGet("{id}")]
    public ActionResult<Tarefa> GetId(string id)
    {
        var obj = db.Tarefas.FirstOrDefault(x => x.Id == id);
        if (obj == null)
            return NotFound();
        return obj;
    }
    // GET: api/mestre/Tarefa/5
    [HttpGet("mestre/{id}")]
    public ActionResult<IEnumerable<Tarefa>> GetIdMestre(string id)
    {
        var objetos = db.Tarefas.Where(x => x.Id == id);
        if (objetos == null)
            return NotFound();
        return objetos.ToArray();
    }
    // POST: api/Tarefa
    [HttpPost("user/{id}")]
    public ActionResult<Tarefa> Post(Tarefa obj, string id)
    {
        if (string.IsNullOrWhiteSpace(obj.Id))
            obj.Id = Guid.NewGuid().ToString();

        var user = db.Users.FirstOrDefault(x => x.Id == id);

        db.Tarefas.Add(obj);
        user.Records.Add(obj);
        db.SaveChanges();


        return CreatedAtAction(
            nameof(GetId),
            new { id = obj.Id },
            obj
        );
    }
    // PUT: api/Tarefa/5
    [HttpPut("{id}")]
    public IActionResult Put(string id, Tarefa obj)
    {
        if (id != obj.Id)
            return BadRequest();

        db.Tarefas.Update(obj);
        db.SaveChanges();
        return NoContent();
    }
    // DELETE: api/Tarefa/5
    [HttpDelete("{id}/{idUser}")]
    public IActionResult Delete(string id, string idUser)
    {
        var user = db.Users.FirstOrDefault(x => x.Id == idUser);
        if (db.Tarefas == null)
            return NotFound();
        var obj = db.Tarefas.FirstOrDefault(x => x.Id == id);
        if (obj == null)
            return NotFound();

        user.Records.Remove(obj);
        db.Tarefas.Remove(obj);
        db.SaveChanges();
        return NoContent();
    }
    private readonly ApplicationDbContext db;
}