using System;

namespace Inscribi_Tu_Equipo.BE
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Equipo { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public int NumeroCamiseta { get; set; }
        public string Estado { get; set; }
        public bool Lesionado { get; set; }
        public bool Activo { get; set; }
    }
}
