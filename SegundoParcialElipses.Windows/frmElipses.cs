using SegundoParcialElipses.Datos;
using SegundoParcialElipses.Entidades;

namespace SegundoParcialElipses.Windows
{
    public partial class frmElipses : Form
    {
        private RepositorioElipses? repositorio;
        private int cantidadRegistros;
        private List<Elipse>? elipses;
        public frmElipses()
        {
            InitializeComponent();
            repositorio = new RepositorioElipses();
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmElipsesAE frm = new frmElipsesAE(repositorio) { Text = "Agregar Elipse" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Elipse? elipse = frm.GetElipse();
            try
            {
                if (!repositorio!.Existe(elipse!))
                {
                    repositorio.AgregarElipse(elipse!);
                    DataGridViewRow r = ConstruirFila(dgvDatos);
                    SetearFila(r, elipse!);
                    AgregarFila(r, dgvDatos);
                    MessageBox.Show("Registro agregado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    MessageBox.Show("Registro existente!!!", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Algún error!!!", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void AgregarFila(DataGridViewRow r, DataGridView dgv)
        {
            dgv.Rows.Add(r);
        }

        public void LimpiarGrilla(DataGridView grid)
        {
            grid.Rows.Clear();
        }
        public DataGridViewRow ConstruirFila(DataGridView grid)
        {
            var r = new DataGridViewRow();
            r.CreateCells(grid);
            return r;
        }

        public void SetearFila(DataGridViewRow r, Elipse obj)
        {
            r.Cells[0].Value = obj.SemiEjeMayor;
            r.Cells[1].Value = obj.SemiEjeMenor;
            r.Cells[2].Value = obj.TipoBorde.ToString();
            r.Cells[3].Value = obj.ColorElipse.ToString();
            r.Cells[4].Value = obj.CalcularArea().ToString("N2");
            r.Cells[5].Value = obj.CalcularPerimetro().ToString("N2");

            r.Tag = obj;
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow r = dgvDatos.SelectedRows[0];
            Elipse elipse = (Elipse)r.Tag!;
            DialogResult dr = MessageBox.Show("¿Desea borrar la elipse?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) { return; }
            try
            {
                repositorio!.EliminarElipse(elipse);
                EliminarFila(r, dgvDatos);
                MessageBox.Show("Registro agregado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception)
            {

                MessageBox.Show("Algún error!!!", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void EliminarFila(DataGridViewRow r, DataGridView grid)
        {
            grid.Rows.Remove(r);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow r = dgvDatos.SelectedRows[0];
            Elipse? elipse = (Elipse)r.Tag!;
            frmElipsesAE frm = new frmElipsesAE(repositorio) { Text = "Editar Elipse" };
            frm.SetElipse(elipse);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                elipse = frm.GetElipse();
                SetearFila(r, elipse);
                MessageBox.Show("Registro editado", "Mensaje",
    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {

                MessageBox.Show("Algún error!!!", "Error",
MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tsCboBordes_Click(object sender, EventArgs e)
        {

        }

        private void frmElipses_Click(object sender, EventArgs e)
        {
        }

        private void MostrarDatosGrilla()
        {
            LimpiarGrilla(dgvDatos);
            foreach (var item in elipses!)
            {
                var r = ConstruirFila(dgvDatos);
                SetearFila(r, item);
                AgregarFila(r, dgvDatos);
            }
        }

        private void CargarComboBordes(ref ToolStripComboBox tsCboBordes)
        {
            var listaBordes = Enum.GetValues(typeof(Borde));
            foreach (var item in listaBordes)
            {
                tsCboBordes.Items.Add(item);
            }
            tsCboBordes.DropDownStyle = ComboBoxStyle.DropDownList;
            tsCboBordes.SelectedIndex = 0;

        }

        private void tsCboBordes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bordeSeleccionado = (Borde)tsCboBordes.SelectedItem!;
            elipses = repositorio!.Filtrar(bordeSeleccionado);
            cantidadRegistros=repositorio!.GetCantidad(bordeSeleccionado);
            MostrarDatosGrilla();
            MostrarCantidadRegistros();
        }

        private void área09ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            elipses = repositorio!.OrdenarAsc();
            MostrarDatosGrilla();
        }

        private void área90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            elipses = repositorio!.OrdenarDesc();
            MostrarDatosGrilla();

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            elipses = repositorio!.ObtenerElipses();
            MostrarDatosGrilla();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            repositorio!.GuardarDatos();
            MessageBox.Show("Fin del Programa", "Mensaje",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void frmElipses_Load(object sender, EventArgs e)
        {
            CargarComboBordes(ref tsCboBordes);
            cantidadRegistros = repositorio!.GetCantidad();
            if (cantidadRegistros > 0)
            {
                elipses = repositorio.ObtenerElipses();
                MostrarDatosGrilla();
                MostrarCantidadRegistros();
            }

        }

        private void MostrarCantidadRegistros()
        {
            txtCantidad.Text = cantidadRegistros.ToString();
        }
    }
}
