using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SuperHerosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly DataContext context;

        public ComicsController(DataContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Comics>>> Get()
        {

            return Ok(await context.Comics.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Comics>> Get(int id)
        {
            var hero = await context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("Comics not found");
            return Ok(await context.Comics.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Comics>>> AddHero(Comics comics)
        {
            context.Comics.Add(comics);
            await context.SaveChangesAsync();
            return Ok(await context.Comics.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Comics>>> UpdateHero(Comics request)
        {
            var dbcomic = await context.Comics.FindAsync(request.Id);
            if (dbcomic == null)
                return BadRequest("Comic not found");

            dbcomic.Id = request.Id;
            dbcomic.Title = request.Title;
            dbcomic.DateOfRelease = request.DateOfRelease;

            await context.SaveChangesAsync();
            return Ok(await context.SuperHeroes.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Comics>>> Delete(int id)
        {
            var dbcomic = await context.Comics.FindAsync(id);
            if (dbcomic == null)
                return BadRequest("Comic not found");
            context.Comics.Remove(dbcomic);
            await context.SaveChangesAsync();
            return Ok(await context.Comics.ToListAsync());
        }
    }
}
