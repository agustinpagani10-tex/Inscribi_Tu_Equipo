using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace Inscribi_Tu_Equipo.BE
{
    public class JugadorServicio
    {
        private readonly string archivo;
        private readonly JavaScriptSerializer serializador = new JavaScriptSerializer();
        private List<Jugador> jugadores;

        public JugadorServicio()
        {
            archivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jugadores.json");
            jugadores = Cargar();
        }

        public List<Jugador> ListarTodos()
        {
            return jugadores.OrderBy(j => j.Id).ToList();
        }

        public List<Jugador> ListarActivos()
        {
            return jugadores.Where(j => j.Activo).OrderBy(j => j.Id).ToList();
        }

        public List<Jugador> Buscar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return ListarTodos();

            texto = texto.Trim();
            return jugadores.Where(j => j.Nombre.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0
                || j.Equipo.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0
                || j.NumeroCamiseta.ToString() == texto).OrderBy(j => j.Id).ToList();
        }

        public void Agregar(Jugador jugador)
        {
            Validar(jugador, null);
            jugador.Id = jugadores.Count == 0 ? 1 : jugadores.Max(j => j.Id) + 1;
            jugador.Activo = true;
            jugadores.Add(jugador);
            Guardar();
        }

        public void Actualizar(Jugador jugador)
        {
            if (jugador == null || jugador.Id <= 0)
                throw new ArgumentException("Seleccione un jugador válido.");

            Jugador existente = jugadores.FirstOrDefault(j => j.Id == jugador.Id);
            if (existente == null)
                throw new InvalidOperationException("El jugador no existe.");

            Validar(jugador, jugador.Id);
            jugador.Activo = existente.Activo;
            jugadores[jugadores.IndexOf(existente)] = jugador;
            Guardar();
        }

        public void Eliminar(int id)
        {
            Jugador jugador = Obtener(id);
            jugadores.Remove(jugador);
            Guardar();
        }

        public void Desactivar(int id)
        {
            Jugador jugador = Obtener(id);
            jugador.Activo = false;
            Guardar();
        }

        private Jugador Obtener(int id)
        {
            Jugador jugador = jugadores.FirstOrDefault(j => j.Id == id);
            if (jugador == null)
                throw new InvalidOperationException("El jugador no existe.");
            return jugador;
        }

        private void Validar(Jugador jugador, int? idExcluir)
        {
            if (jugador == null || string.IsNullOrWhiteSpace(jugador.Equipo) || string.IsNullOrWhiteSpace(jugador.Nombre))
                throw new ArgumentException("Complete el equipo y el nombre del jugador.");
            if (string.IsNullOrWhiteSpace(jugador.Puesto) || string.IsNullOrWhiteSpace(jugador.Estado))
                throw new ArgumentException("Seleccione el puesto y el estado del jugador.");
            if (jugador.NumeroCamiseta < 1 || jugador.NumeroCamiseta > 99)
                throw new ArgumentException("El número de camiseta debe estar entre 1 y 99.");
            if (jugador.Estado != "Titular" && jugador.Estado != "Suplente")
                throw new ArgumentException("El estado debe ser Titular o Suplente.");
            if (jugadores.Any(j => j.Id != idExcluir && j.Activo && j.Equipo.Equals(jugador.Equipo, StringComparison.OrdinalIgnoreCase)
                && j.Nombre.Equals(jugador.Nombre, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException("Ya existe un jugador activo con ese nombre en el equipo.");
            if (jugadores.Any(j => j.Id != idExcluir && j.Activo && j.Equipo.Equals(jugador.Equipo, StringComparison.OrdinalIgnoreCase)
                && j.NumeroCamiseta == jugador.NumeroCamiseta))
                throw new ArgumentException("El número de camiseta ya está ocupado en el equipo.");

            int totalEquipo = jugadores.Count(j => j.Id != idExcluir && j.Activo && j.Equipo.Equals(jugador.Equipo, StringComparison.OrdinalIgnoreCase));
            if (totalEquipo >= 15)
                throw new ArgumentException("El equipo no puede superar los 15 jugadores.");
            int titulares = jugadores.Count(j => j.Id != idExcluir && j.Activo && j.Equipo.Equals(jugador.Equipo, StringComparison.OrdinalIgnoreCase) && j.Estado == "Titular");
            int suplentes = jugadores.Count(j => j.Id != idExcluir && j.Activo && j.Equipo.Equals(jugador.Equipo, StringComparison.OrdinalIgnoreCase) && j.Estado == "Suplente");
            if (jugador.Estado == "Titular" && titulares >= 11)
                throw new ArgumentException("El equipo ya tiene 11 titulares.");
            if (jugador.Estado == "Suplente" && suplentes >= 4)
                throw new ArgumentException("El equipo ya tiene 4 suplentes.");
        }

        private List<Jugador> Cargar()
        {
            if (!File.Exists(archivo))
                return new List<Jugador>();
            try
            {
                return serializador.Deserialize<List<Jugador>>(File.ReadAllText(archivo)) ?? new List<Jugador>();
            }
            catch
            {
                return new List<Jugador>();
            }
        }

        private void Guardar()
        {
            File.WriteAllText(archivo, serializador.Serialize(jugadores));
        }
    }
}
