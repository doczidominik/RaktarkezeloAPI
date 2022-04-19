using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaktarkezeloAPI.DTOs;
using RaktarkezeloAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaktarkezeloAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaktarkezeloController : ControllerBase
    {
        private raktarkezeloContext context;

        public RaktarkezeloController(raktarkezeloContext context)
        {
            this.context = context;
        }

        private TermekDTO ConvertTermekToDTO(termek termek)
        {
            if (termek == null)
            {
                return null;
            }
            return new TermekDTO(termek.id, termek.termekcsoportID, termek.raktarID, termek.ar, termek.afakulcs,
                                   termek.termekneve, termek.raktarkeszlet);
        }

        private TermekcsoportDTO ConvertTermekcsoportToDTO(termekcsoport termekcsoport)
        {
            if (termekcsoport == null)
            {
                return null;
            }
            return new TermekcsoportDTO(termekcsoport.id, termekcsoport.termekcsoportnev);
        }

        //GET: api/Raktarkezelo/termekek
        [HttpGet]
        [Route("termekek")]
        public List<TermekDTO> GetTermekek()
        {
            List<termek> termekek = context.termek.OrderBy(x => x.id).ToList();

            List<TermekDTO> termekekDTOs = termekek.Select(t => ConvertTermekToDTO(t)).ToList();
            return termekekDTOs;
        }



        // PUT: api/Raktarkezelo/termekek/csokkentes
       
        //[EnableCors("AllowMethod")]
        [HttpPut("{id:int}")]
        [Route("termekek/csokkentes/{id}")]
        public async Task<IActionResult> TermekCsokkentes(int id)
        {
            var dbTermek = await context.termek.FindAsync(id);
            if (id != dbTermek.id)
            {
                return BadRequest("Nem jó az id");
            }

            dbTermek.raktarkeszlet = dbTermek.raktarkeszlet - 1;
            context.Entry(dbTermek).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(dbTermek);
        }

        [HttpPut("{id:int}")]
        [Route("termekek/noveles/{id}")]
        public async Task<IActionResult> TermekNoveles(int id)
        {
            var dbTermek = await context.termek.FindAsync(id);
            if (id != dbTermek.id)
            {
                return BadRequest("Nem jó az id");
            }

            dbTermek.raktarkeszlet = dbTermek.raktarkeszlet + 1;
            context.Entry(dbTermek).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(dbTermek);
        }

    }
}
