using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIRestNetCore.Models;
using APIRestNetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIRestNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(PersonaServicio.obtenerTodos());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return PersonaServicio.obtenerPersona(id) == null ? (ActionResult) NotFound("No existe esa persona") : Ok(PersonaServicio.obtenerPersona(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Persona persona)
        {
            return PersonaServicio.agregar(persona) ? (ActionResult) Ok("Persona agregada correctamente.") : BadRequest("Ya existe una persona con ese DNI");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Persona personaNueva)
        {
            return PersonaServicio.modificarPersona(personaNueva) ? Ok($"Persona con DNI {personaNueva.dni} modificada") : (ActionResult)NotFound("No existe esa persona");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return PersonaServicio.eliminarPersona(id) ? Ok($"Persona con DNI {id} eliminada") : (ActionResult)NotFound("No existe esa persona");
        }
    }
}
