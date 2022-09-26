using Api.Data;
using Api.DTOs;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{

    public class JapController : BaseApiController
    {

        private readonly AppDbContext _context;

        public JapController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<JapDto>>> GetJaps()
        {

            var japs =  _context.Japs.AsQueryable();

            var lista = japs.Select(x => new JapDto
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();

            return lista;


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JAP>> GetJapById(int id)
        {
            return await _context.Japs.SingleOrDefaultAsync(x => x.Id == id);
        }



        
    }
}
