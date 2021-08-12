using System;
using System.Collections.Generic;
using System.Text;

namespace APIREST
{
    public class Persona
    {
        public int Id { get; set; }
        public int PersonaID { get; set; }
        public string Contacto { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public int TipoSesion { get; set; }
        public bool PrimeraSesion { get; set; }
        public string TokenSubscription { get; set; }
    }

}
