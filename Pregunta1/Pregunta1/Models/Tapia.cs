using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Web.Mail;
using System.Web.Mvc;

namespace Pregunta1.Models
{
    public enum Places
    { 
      SantaCruz = 1,
      Montero,
      Concepcion,
      Warnes,
      Porongo
    };
    public class Tapia
    {
        [Key]
       
        public int TapiaID { get; set; }
        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(24, MinimumLength = 2)]
       
        public string FriendofTapia { get; set; }
        [Required]
       
        public Places place { get; set; }
        //Validacion de correos
        [DataType(DataType.EmailAddress, ErrorMessage = "Email no valido")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
    }
}