using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComApp.Models
{
    public partial class ComData
    {
        public ComData() { }

        public ComData(string ime, string prezime, string postanskiBroj, string grad, string telefon)
        {
            Ime = ime;
            Prezime = prezime;
            PostanskiBroj = postanskiBroj;
            Grad = grad;
            Telefon = telefon;
        }
    }
}