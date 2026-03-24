using ApiPersonas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private List<Persona> personas;

        public PersonasController()
        {
            this.personas = new List<Persona>
            {
                new Persona
                {
                    IdPersona = 1,
                    Nombre = "Lucia",
                    Email = "lucia@gmail.com",
                    Edad = 22
                },
                new Persona
                {
                    IdPersona = 2,
                    Nombre = "Jorge",
                    Email = "jorge@gmail.com",
                    Edad = 23
                },
                new Persona
                {
                    IdPersona = 3,
                    Nombre = "Alberto",
                    Email = "alberto@gmail.com",
                    Edad = 21
                },
                new Persona
                {
                    IdPersona = 4,
                    Nombre = "Alex",
                    Email = "alex@gmail.com",
                    Edad = 24
                }
            };
        }

        [HttpGet]
        public ActionResult<List<Persona>> Get()
        {
            return this.personas;
        }

        [HttpGet("{id}")]
        public ActionResult<Persona> Find(int id)
        {
            return this.personas.FirstOrDefault(p => p.IdPersona == id);
        }

    }
}
