using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DynamoPost.Models;
using DynamoPost.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DynamoPost.Controllers
{
    public class PersonajesController : Controller
    {
        PersonajesServiceDynamodb ServiceDynamo;

        public PersonajesController(PersonajesServiceDynamodb serviceDynamo)
        {
            this.ServiceDynamo = serviceDynamo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.ServiceDynamo.GetPersonajes());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Personaje personaje, String incluirdes, String ojos, String pelo, bool villano)
        {
            if (incluirdes != null)
            {
                personaje.Descripcion = new Descripcion();
                personaje.Descripcion.Ojos = ojos;
                personaje.Descripcion.Villano = villano;
            }

            await this.ServiceDynamo.CreatePersonaje(personaje);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            //Buscamos al personaje:
            Personaje personaje = await this.ServiceDynamo.FindPersonaje(id);
            return View(personaje);
        }

      
        public async Task<IActionResult> Delete(int id)
        {
            Personaje personaje =
            await this.ServiceDynamo.FindPersonaje(id);
            await this.ServiceDynamo.DeletePersonaje(id);
            return RedirectToAction("index");
        }


    }
}
