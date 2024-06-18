using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Context;
using SuperHeroApi.Models;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly HeroDbContext _context;
        private readonly IConfiguration _configuration;

        public HeroiController(HeroDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Heroi>> GetAll()
        {
            return _context.Heroi.AsNoTracking().Where(h => h.Id <= 7).ToList();
        }
        [HttpGet("{id:int}")]
        public ActionResult<Heroi> GetOne(int id)
        {
            var hero = _context.Heroi.AsNoTracking().FirstOrDefault(h => h.Id == id);
            if (hero == null) return NotFound("Cadastro não encontrado! Tente novamente...");

            return Ok(hero);
        }
        [HttpPost]
        public ActionResult CadastrarHeroi(Heroi heroi)
        {
            if (heroi == null) return BadRequest("Cadastro está nulo! Tente novamente...");

            _context.Heroi.Add(heroi);
            _context.SaveChanges();
            return Ok(heroi);
        }
        [HttpPut("{id:int}")]
        public ActionResult AtualizarHeroi(int id, Heroi heroi)
        {
            if (heroi.Id != id) return BadRequest("Atualização inválida...");

            _context.Heroi.Entry(heroi).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(heroi);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeletarHeroi(int id) {
            Console.WriteLine("Configuração: " + _configuration["chaveTeste:chaveUnica"]);

            var heroiASerDeletado = _context.Heroi.AsNoTracking().FirstOrDefault(h=>h.Id == id);

            if (heroiASerDeletado == null) return NotFound();

            _context.Heroi.Remove(heroiASerDeletado);
            _context.SaveChanges();

            return Ok("Heroi deletado!");
        }
    }
}
