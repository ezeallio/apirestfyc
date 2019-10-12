using System;
using System.Collections.Generic;
using System.Linq;
using APIRestNetCore.Models;

namespace APIRestNetCore.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class PersonaServicio
    {
        static List<Persona> personas = new List<Persona>() {
            new Persona { dni = 39670211, nombre = "Ezequiel", apellido = "Allio"},
            new Persona { dni = 00000001, nombre = "Mirtha", apellido = "Legrand" },
            new Persona { dni = 12345678, nombre = "Pepe", apellido = "Sanchez" },
            new Persona { dni = 87654321, nombre = "Paco", apellido = "Romero" }
        };

        /// <summary>
        /// 
        /// </summary>
        public static void agregar(Persona p)
        {
            personas.Add(p);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Persona> obtenerTodos()
        {
            return personas.Any() ? personas : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public static Persona obtenerPersona(int dni)
        {
            return personas.FirstOrDefault(x=>x.dni == dni);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dni"></param>
        public static Boolean eliminarPersona(int dni)
        {
            return personas.Remove(personas.FirstOrDefault(x => x.dni == dni));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Boolean modificarPersona(Persona p)
        {
            int pos = personas.FindIndex(x => x.dni == p.dni);
            if (pos == -1)
                return false;

            personas[pos] = p;
            return true;
        }
    }
}