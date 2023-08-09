namespace MiGestorDeTicketsUNP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tickets
    {
        public int id { get; set; }

        public DateTime FechaInicio { get; set; }

        public int idEstado { get; set; }

        public int idUsuario { get; set; }

        public int? idResponsable { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public string Solucion { get; set; }

        public virtual Responsable Responsable { get; set; }

        public virtual Status Status { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
