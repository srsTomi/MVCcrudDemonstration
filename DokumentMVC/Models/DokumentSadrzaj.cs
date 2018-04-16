using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DokumentMVC.Models
{
    public class DokumentSadrzaj
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Unesite Naziv.")]
        [DisplayName("Naziv:")]
        public string Naziv { get; set; }
        public DateTime Datum { get; set; }
        [Required(ErrorMessage = "Unesite Količinu.")]
        [DisplayName("Količina:")]
        public int Kolicina { get; set; }
        [Required(ErrorMessage = "Unesite Tip ulaza.")]
        [DisplayName("Tip ulaza:")]
        public int TipUlaza { get; set; }
    }

    public class DokumentSadrzajContext : DbContext
    {
        public DbSet<DokumentSadrzaj> DokumentSadrzaji
        {
            get;
            set;
        }
    }

}