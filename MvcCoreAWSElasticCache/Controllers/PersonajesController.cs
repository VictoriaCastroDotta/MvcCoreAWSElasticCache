using Microsoft.AspNetCore.Mvc;
using MvcCoreAWSElasticCache.Models;
using MvcCoreAWSElasticCache.Repositories;
using MvcCoreAWSElasticCache.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSElasticCache.Controllers
{
    public class PersonajesController : Controller
    {
        PersonajesRepository repo;
        private ServiceAWSCache service;
        public PersonajesController(PersonajesRepository repo, ServiceAWSCache service)
        {
            this.repo = repo;
            this.service = service;
        }
        public IActionResult Index()
        {
            return View(this.repo.GetPersonajes());
        }

        public IActionResult Details(int id)
        {
            return View(this.repo.FindPersonaje(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Personaje p)
        {
            this.repo.InsertPersonaje(p.Nombre, p.Imagen);
            return RedirectToAction("Index");
        }

        //Devuelve los favoritos utilizando cache
        public IActionResult Favoritos()
        {
            return View(this.service.GetPersonajesCache());
        }

        public IActionResult SeleccionarFavorito(int id)
        {
            //BUSCAMOS AL PERSONAJE EN BASE DE DATOS
            Personaje p = this.repo.FindPersonaje(id);
            //GUARDAMOS EN CACHE:
            this.service.GuardarPersonajes(p);
            ViewData["MENSAJE"] = "Personaje almacenado";
            return RedirectToAction("Index");
        }



    }
}
