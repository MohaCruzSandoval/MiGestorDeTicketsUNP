using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiGestorDeTicketsUNP.Models;

namespace MiGestorDeTicketsUNP.ViewModels
{
    public class TicketsViewModels
    {

        public Tickets Ticket { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public List<Responsable> Responsables { get; set; }

        public List<Status> Estados { get; set; }
    }
}