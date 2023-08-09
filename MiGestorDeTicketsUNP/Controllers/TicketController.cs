using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiGestorDeTicketsUNP.Models;
using MiGestorDeTicketsUNP.ViewModels;

namespace MiGestorDeTicketsUNP.Controllers
{
    public class TicketController : Controller
    {
        private TicketsContex contex = new TicketsContex();
        // GET: Ticket
        public ActionResult Index()
        {
            var ListaTicket = contex.Tickets;
            return View(ListaTicket);
        }
        [HttpGet]
        public ActionResult Agregar()
        {
            var viewModel = new TicketsViewModels();
          
             viewModel.Responsables = contex.Responsable.ToList();
            viewModel.Usuarios = contex.Usuario.ToList();
           viewModel.Estados = contex.Status.ToList();

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Agregar(Tickets ticket)
        {
            contex.Tickets.Add(ticket);
            
            contex.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detalle(int Id)
        {
            var viewModel = new TicketsViewModels();
            viewModel.Ticket = contex.Tickets.FirstOrDefault(x=>x.id ==Id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Actualizar(int Id)
        {
            var viewModel = new TicketsViewModels();
            viewModel.Ticket = contex.Tickets.FirstOrDefault(x => x.id == Id);
            viewModel.Responsables = contex.Responsable.ToList();
            viewModel.Usuarios = contex.Usuario.ToList();
            viewModel.Estados = contex.Status.ToList();

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Actualizar(Tickets ticket)
        {
           // Console.WriteLine(ticket);
            contex.Entry(ticket).State = System.Data.Entity.EntityState.Modified;

            contex.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Eliminar(int Id)
        {
             var Ticket = contex.Tickets.FirstOrDefault(x => x.id == Id);
            contex.Tickets.Remove(Ticket);
            contex.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}