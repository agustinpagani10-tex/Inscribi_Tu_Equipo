using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Inscribi_Tu_Equipo.BE;

namespace Inscribi_Tu_Equipo.FE
{
    public partial class Form1 : Form
    {
        private readonly JugadorServicio servicio = new JugadorServicio();
        private int jugadorSeleccionado;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboPuesto.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
            cboLesionado.SelectedIndex = 0;
            Listar(servicio.ListarTodos());
        }

        private Jugador LeerFormulario()
        {
            int numero;
            if (!int.TryParse(txtNumeroCamiseta.Text.Trim(), out numero))
                throw new ArgumentException("Ingrese un número de camiseta válido.");
            return new Jugador
            {
                Id = jugadorSeleccionado,
                Equipo = txtEquipo.Text.Trim(),
                Nombre = txtJugador.Text.Trim(),
                Puesto = Convert.ToString(cboPuesto.SelectedItem),
                NumeroCamiseta = numero,
                Estado = Convert.ToString(cboEstado.SelectedItem),
                Lesionado = Convert.ToString(cboLesionado.SelectedItem) == "Sí"
            };
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Ejecutar(delegate { servicio.Agregar(LeerFormulario()); }, "Jugador agregado correctamente.");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Ejecutar(delegate { servicio.Actualizar(LeerFormulario()); }, "Jugador actualizado correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Ejecutar(delegate
            {
                if (jugadorSeleccionado == 0) throw new ArgumentException("Seleccione un jugador de la grilla.");
                servicio.Eliminar(jugadorSeleccionado);
            }, "Jugador eliminado correctamente.");
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            Ejecutar(delegate
            {
                if (jugadorSeleccionado == 0) throw new ArgumentException("Seleccione un jugador de la grilla.");
                servicio.Desactivar(jugadorSeleccionado);
            }, "Jugador desactivado correctamente.");
        }

        private void btnBuscar_Click(object sender, EventArgs e) { Listar(servicio.Buscar(txtBusqueda.Text)); }
        private void btnListarTodos_Click(object sender, EventArgs e) { Listar(servicio.ListarTodos()); }
        private void btnListarActivos_Click(object sender, EventArgs e) { Listar(servicio.ListarActivos()); }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            jugadorSeleccionado = 0; txtEquipo.Clear(); txtJugador.Clear(); txtNumeroCamiseta.Clear(); txtBusqueda.Clear();
            cboPuesto.SelectedIndex = 0; cboEstado.SelectedIndex = 0; cboLesionado.SelectedIndex = 0; dgvJugadores.ClearSelection();
        }

        private void dgvJugadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvJugadores.Rows[e.RowIndex].DataBoundItem == null) return;
            Jugador jugador = (Jugador)dgvJugadores.Rows[e.RowIndex].DataBoundItem;
            jugadorSeleccionado = jugador.Id; txtEquipo.Text = jugador.Equipo; txtJugador.Text = jugador.Nombre; txtNumeroCamiseta.Text = jugador.NumeroCamiseta.ToString();
            cboPuesto.SelectedItem = jugador.Puesto; cboEstado.SelectedItem = jugador.Estado; cboLesionado.SelectedItem = jugador.Lesionado ? "Sí" : "No";
        }

        private void Listar(List<Jugador> lista)
        {
            dgvJugadores.DataSource = null;
            dgvJugadores.DataSource = lista;
            if (dgvJugadores.Columns["Id"] != null) dgvJugadores.Columns["Id"].Visible = false;
            if (dgvJugadores.Columns["Activo"] != null) dgvJugadores.Columns["Activo"].HeaderText = "Activo";
            if (dgvJugadores.Columns["NumeroCamiseta"] != null) dgvJugadores.Columns["NumeroCamiseta"].HeaderText = "Nº camiseta";
        }

        private void Ejecutar(Action accion, string mensaje)
        {
            try
            {
                accion(); Listar(servicio.ListarTodos()); btnLimpiar_Click(null, EventArgs.Empty); MessageBox.Show(mensaje, "Inscripción", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void lblEquipo_Click(object sender, EventArgs e)
        {

        }
    }
}
