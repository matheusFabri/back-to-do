using AtletaApi.Models;
using AtletaBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UserBackend.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    public UserController(ApplicationDbContext db) =>
        this.db = db;

    // GET: api/User
    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        if (db.Users == null)
            return NotFound();

        return db.Users;
    }

    // GET: api/User/5
    [HttpGet("{id}")]
    public ActionResult<User> GetId(string id)
    {
        var obj = db.Users.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound();

        return obj;
    }

    [HttpGet]
    [Route("tarefas/{id}")]
    public ActionResult<IList<Tarefa>> GetTarefasByUserId(string id)
    {

        var tarefas = db.Tarefas.Where(p => p.UserId == id).ToList();

        // tarefas.ToList().ForEach(p => p.User.Records.Clear());

        return tarefas;
    }


    [HttpGet]
    [Route("/api/user/autenticado")]

    public ActionResult<User> GetUserAuth()
    {
        var usuario = db.Users.FirstOrDefault(x => x.Nome == User.Identity.Name);
        if (db.Users == null)
            return NotFound();

        return usuario;
    }
    // POST: api/User
    [HttpPost]
    public ActionResult<User> Post(User obj)
    {
        if (string.IsNullOrWhiteSpace(obj.Id))
            obj.Id = Guid.NewGuid().ToString();

        db.Users.Add(obj);
        db.SaveChanges();

        return Ok();
    }

    // PUT: api/User/5
    [HttpPut("{id}")]
    public IActionResult Put(string id, User obj)
    {
        if (id != obj.Id)
            return BadRequest();

        db.Users.Update(obj);
        db.SaveChanges();

        return NoContent();
    }

    // DELETE: api/User/5
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (db.Users == null)
            return NotFound();

        var obj = db.Users.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound();

        db.Users.Remove(obj);
        db.SaveChanges();

        return NoContent();
    }

    private readonly ApplicationDbContext db;
}
