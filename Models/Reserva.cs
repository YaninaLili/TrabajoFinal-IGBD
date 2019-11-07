using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrabajoFinal_IGBD.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="DNI")]
        public int DNI { get; set; }
        

        [Required]
        [Display(Name="Nombre")]
        public string Nombre { get; set; }
        
        [Required]
        [Display(Name="Apellido")]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name="Correo")]
        public string Correo { get; set; }
        
        [Required]
        [Display(Name="Celular")]
        public int Celular { get; set; }
        
        public DateTime Fecha { get; set; }
        public Habitacion Habitacion { get; set; }
        public int HabitacionId { get; set; }
        public Reserva() {
            Fecha = DateTime.Now;
        }
      
    }
}