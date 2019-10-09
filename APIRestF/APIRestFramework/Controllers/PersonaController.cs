using APIRestFramework.Models;
using APIRestFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIRestFramework.Controllers
{
    /// <summary>
    /// Ejemplo de persona
    /// </summary>
    public class PersonaController : ApiController
    {
        /// <summary>
        /// Mostrar lista de personas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Persona> GetPersonas()
        {
            List<Persona> personas = PersonaServicio.obtenerTodos();

            if (personas == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("No se registra ninguna persona dada de alta en la lista"),
                    ReasonPhrase = "Lista vacía"
                };

                throw new HttpResponseException(response);
            }

            return personas;
        }

        /// <summary>
        /// Buscar persona por DNI
        /// </summary>
        /// <param name="dni">Identificador</param>
        /// <response code="200">Persona encontrada</response>
        /// <response code="404">La persona no existe</response>
        /// <returns>Persona en base al DNI</returns>
        public IHttpActionResult GetPersona(int dni)
        {
            var persona = PersonaServicio.obtenerPersona(dni);

            if (persona == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("No existe una persona registrada con el dni " + dni  +" en la lista"),  
                    ReasonPhrase = "Persona no encontrada"
                };

                throw new HttpResponseException(response);
            }
            
            return Ok(persona);
        }

        /// <summary>
        /// Agregar persona en la lista
        /// </summary>
        /// <param name="p">Persona</param>
        /// <returns>Persona agregada</returns>
        public IHttpActionResult PostPersona(Persona p)
        {
            PersonaServicio.agregar(p);
            return Ok(p);
        }

        /// <summary>
        /// Eliminar persona de la lista
        /// </summary>
        /// <param name="dni">Identificador</param>
        /// <returns>Persona eliminada de la lista</returns>
        public IHttpActionResult DeletePersona(int dni)
        {
            if (!PersonaServicio.eliminarPersona(dni))
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("No se eliminó la persona con el dni " + dni + " porque no existe en la lista"),
                    ReasonPhrase = "Error al eliminar"
                };

                throw new HttpResponseException(response);
            }

            return Ok("Persona eliminada exitosamente");
        }

        /// <summary>
        /// Modificar persona en la lista
        /// </summary>
        /// <param name="p">Persona a modificar</param>
        /// <returns></returns>
        public IHttpActionResult PutPersona(Persona p)
        {
            if (!PersonaServicio.modificarPersona(p))
            {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("No se modificó la persona con el dni " + p.dni + " porque no existe en la lista"),
                    ReasonPhrase = "Error al modificar"
                };

                throw new HttpResponseException(response);
            }

            return Ok(p);
        }
    }
}
