using System;
using System.Collections.Generic;
using System.Text;

namespace APIREST
{
    public class Keyword
    {
        public int Id { get; set; } = 0;
        public int KeywordId { get; set; } = 0;
        public string KeyString { get; set; }
        public int PaginaId { get; set; } = 0;
        public int TipoPagina { get; set; } = 0;

    }
}
