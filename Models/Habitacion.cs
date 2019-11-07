using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrabajoFinal_IGBD.Models
{
    public class Habitacion
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        public string DescripcionCorta { get; set; }
        public DateTime Fecha { get; set; }
        public Habitacion() {
            Fecha = DateTime.Now;
        }
        public List<Reserva> Reservas {get;set;}
    }
}