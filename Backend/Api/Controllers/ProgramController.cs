using Api.Data;
using Api.DTOs;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{

    public class ProgramController : BaseApiController
    {

        private readonly AppDbContext _context;

        public ProgramController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProgramDto>>> GetJaps()
        {

            var japs =  _context.Japs.AsQueryable();

            var lista = japs.Select(x => new ProgramDto
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();

            return lista;


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Entities.Program>> GetJapById(int id)
        {
            return await _context.Japs.SingleOrDefaultAsync(x => x.Id == id);
        }



        
    }
}
