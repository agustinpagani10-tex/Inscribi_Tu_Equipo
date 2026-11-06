namespace Inscribi_Tu_Equipo.FE
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblEquipo, lblJugador, lblPuesto, lblNumeroCamiseta, lblEstado, lblLesionado, lblBusqueda;
        private System.Windows.Forms.TextBox txtEquipo, txtJugador, txtNumeroCamiseta, txtBusqueda;
        private System.Windows.Forms.ComboBox cboPuesto, cboEstado, cboLesionado;
        private System.Windows.Forms.Button btnAgregar, btnActualizar, btnEliminar, btnDesactivar, btnBuscar, btnLimpiar, btnListarTodos, btnListarActivos;
        private System.Windows.Forms.DataGridView dgvJugadores;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblEquipo = new System.Windows.Forms.Label();
            this.lblJugador = new System.Windows.Forms.Label();
            this.lblPuesto = new System.Windows.Forms.Label();
            this.lblNumeroCamiseta = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblLesionado = new System.Windows.Forms.Label();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.txtEquipo = new System.Windows.Forms.TextBox();
            this.txtJugador = new System.Windows.Forms.TextBox();
            this.txtNumeroCamiseta = new System.Windows.Forms.TextBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cboPuesto = new System.Windows.Forms.ComboBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.cboLesionado = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnListarTodos = new System.Windows.Forms.Button();
            this.btnListarActivos = new System.Windows.Forms.Button();
            this.dgvJugadores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugadores)).BeginInit();
            this.SuspendLayout();

            this.Text = "Inscripción de equipo de fútbol";
            this.ClientSize = new System.Drawing.Size(1100, 620);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.lblEquipo.AutoSize = true;
            this.lblEquipo.Text = "Nombre equipo";
            this.lblEquipo.Location = new System.Drawing.Point(25, 20);
            this.lblJugador.AutoSize = true;
            this.lblJugador.Text = "Nombre jugador";
            this.lblJugador.Location = new System.Drawing.Point(220, 20);
            this.lblPuesto.AutoSize = true;
            this.lblPuesto.Text = "Puesto";
            this.lblPuesto.Location = new System.Drawing.Point(415, 20);
            this.lblNumeroCamiseta.AutoSize = true;
            this.lblNumeroCamiseta.Text = "Nº camiseta";
            this.lblNumeroCamiseta.Location = new System.Drawing.Point(600, 20);
            this.lblEstado.AutoSize = true;
            this.lblEstado.Text = "Estado";
            this.lblEstado.Location = new System.Drawing.Point(755, 20);
            this.lblLesionado.AutoSize = true;
            this.lblLesionado.Text = "Lesionado";
            this.lblLesionado.Location = new System.Drawing.Point(900, 20);
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Text = "Buscar por nombre, equipo o camiseta";
            this.lblBusqueda.Location = new System.Drawing.Point(25, 160);

            this.txtEquipo.Location = new System.Drawing.Point(25, 45);
            this.txtEquipo.Size = new System.Drawing.Size(170, 23);
            this.txtJugador.Location = new System.Drawing.Point(220, 45);
            this.txtJugador.Size = new System.Drawing.Size(175, 23);
            this.txtNumeroCamiseta.Location = new System.Drawing.Point(600, 45);
            this.txtNumeroCamiseta.Size = new System.Drawing.Size(130, 23);
            this.txtBusqueda.Location = new System.Drawing.Point(25, 185);
            this.txtBusqueda.Size = new System.Drawing.Size(280, 23);

            this.cboPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuesto.Items.AddRange(new object[] { "Arquero", "Defensor", "Mediocampo", "Delantero" });
            this.cboPuesto.Location = new System.Drawing.Point(415, 45);
            this.cboPuesto.Size = new System.Drawing.Size(160, 23);
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Items.AddRange(new object[] { "Titular", "Suplente" });
            this.cboEstado.Location = new System.Drawing.Point(755, 45);
            this.cboEstado.Size = new System.Drawing.Size(125, 23);
            this.cboLesionado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLesionado.Items.AddRange(new object[] { "No", "Sí" });
            this.cboLesionado.Location = new System.Drawing.Point(900, 45);
            this.cboLesionado.Size = new System.Drawing.Size(100, 23);

            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Location = new System.Drawing.Point(25, 100);
            this.btnAgregar.Size = new System.Drawing.Size(100, 32);
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Location = new System.Drawing.Point(125, 100);
            this.btnActualizar.Size = new System.Drawing.Size(100, 32);
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(235, 100);
            this.btnEliminar.Size = new System.Drawing.Size(100, 32);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnDesactivar.Text = "Desactivar jugador";
            this.btnDesactivar.Location = new System.Drawing.Point(330, 100);
            this.btnDesactivar.Size = new System.Drawing.Size(100, 32);
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Location = new System.Drawing.Point(320, 183);
            this.btnBuscar.Size = new System.Drawing.Size(100, 32);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Location = new System.Drawing.Point(410, 183);
            this.btnLimpiar.Size = new System.Drawing.Size(100, 32);
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            this.btnListarTodos.Text = "Listar todos";
            this.btnListarTodos.Location = new System.Drawing.Point(510, 183);
            this.btnListarTodos.Size = new System.Drawing.Size(100, 32);
            this.btnListarTodos.Click += new System.EventHandler(this.btnListarTodos_Click);
            this.btnListarActivos.Text = "Listar activos";
            this.btnListarActivos.Location = new System.Drawing.Point(625, 183);
            this.btnListarActivos.Size = new System.Drawing.Size(100, 32);
            this.btnListarActivos.Click += new System.EventHandler(this.btnListarActivos_Click);

            this.dgvJugadores.Location = new System.Drawing.Point(25, 240);
            this.dgvJugadores.Size = new System.Drawing.Size(1040, 340);
            this.dgvJugadores.ReadOnly = true;
            this.dgvJugadores.AllowUserToAddRows = false;
            this.dgvJugadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJugadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJugadores.MultiSelect = false;
            this.dgvJugadores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJugadores_CellClick);

            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblEquipo, this.lblJugador, this.lblPuesto, this.lblNumeroCamiseta, this.lblEstado, this.lblLesionado, this.lblBusqueda, this.txtEquipo, this.txtJugador, this.txtNumeroCamiseta, this.txtBusqueda, this.cboPuesto, this.cboEstado, this.cboLesionado, this.btnAgregar, this.btnActualizar, this.btnEliminar, this.btnDesactivar, this.btnBuscar, this.btnLimpiar, this.btnListarTodos, this.btnListarActivos, this.dgvJugadores });
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

