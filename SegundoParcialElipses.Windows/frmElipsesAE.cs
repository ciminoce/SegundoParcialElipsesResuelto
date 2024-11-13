using SegundoParcialElipses.Datos;
using SegundoParcialElipses.Entidades;

namespace SegundoParcialElipses.Windows
{
    public partial class frmElipsesAE : Form
    {
        private Elipse? elipse;
        private readonly RepositorioElipses? _repo;
        public frmElipsesAE(RepositorioElipses? repo)
        {
            InitializeComponent();
            _repo = repo;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosCombo(ref cboColores);
            if (elipse != null)
            {
                txtSemiejeMayor.Text = elipse.SemiEjeMayor.ToString();
                txtSemiejeMenor.Text = elipse.SemiEjeMenor.ToString();
                switch (elipse.TipoBorde)
                {
                    case Borde.Solido:
                        rbtSolido.Checked = true;
                        break;
                    case Borde.Punteado:
                        rbtPunteado.Checked = true;
                        break;
                    case Borde.Rayado:
                        rbtRayado.Checked = true;
                        break;
                    case Borde.Doble:
                        rbtDoble.Checked = true;
                        break;
                }
                cboColores.SelectedItem = elipse.ColorElipse;
            }
        }

        private void CargarDatosCombo(ref ComboBox cbo)
        {
            cbo.DataSource = Enum.GetValues(typeof(ColorElipse));
            cbo.SelectedIndex = 0;
        }

        public Elipse? GetElipse()
        {
            return elipse;
        }

        public void SetElipse(Elipse elipse)
        {
            this.elipse = elipse;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (elipse is null)
                {
                    elipse = new Elipse();
                }
                elipse.SemiEjeMayor=int.Parse(txtSemiejeMayor.Text);
                elipse.SemiEjeMenor = int.Parse(txtSemiejeMenor.Text);
                elipse.ColorElipse=(ColorElipse)cboColores.SelectedItem!;
                if (rbtSolido.Checked)
                    elipse.TipoBorde = Borde.Solido;
                else if (rbtPunteado.Checked)
                    elipse.TipoBorde = Borde.Punteado;
                else if (rbtRayado.Checked)
                    elipse.TipoBorde = Borde.Rayado;
                else
                    elipse.TipoBorde = Borde.Doble;
                DialogResult= DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!int.TryParse(txtSemiejeMayor.Text, out int sM) ||
                sM<=0)
            {
                valido = false;
                errorProvider1.SetError(txtSemiejeMayor, "Semieje Mayor mal ingresado");
            }
            if (!int.TryParse(txtSemiejeMenor.Text, out int sm) ||
    sm <= 0 || sm>=sM)
            {
                valido = false;
                errorProvider1.SetError(txtSemiejeMenor, "Semieje Menor mal ingresado");
            }
            if (_repo!.Existe(sM, sm))
            {
                valido = false;
                errorProvider1.SetError(txtSemiejeMayor, "Elipse existente!!!");
            }
            return valido;
        }
    }
}
