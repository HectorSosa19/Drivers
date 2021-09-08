using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidad;
using CapaNegocio;
namespace Choferes_Base_de_datos_
{
    public partial class Viajes : Form
    {
        private string idRuta;
        private bool Editarse = false;
        E_Choferes objEntidad = new E_Choferes();
        N_Choferes objNegocio = new N_Choferes();
        public Viajes()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Form formulario1 = new Choferes();
            formulario1.Show();
            this.Hide();
        }
        public void mostrarBuscarTabla(string buscar)
        {
            N_Choferes objNegocio = new N_Choferes();
            tablaViajes.DataSource = objNegocio.ListarChoferes(buscar);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Viajes_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
        }
        public void mostrarBuscarTabla2(string buscar)
        {
            N_Choferes objNegocio = new N_Choferes();
            tablaViajes.DataSource = objNegocio.ListarAutobuses(buscar);
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (tablaViajes.SelectedRows.Count > 0)
            {
                Editarse = true;

                txtEstado.Text = tablaViajes.CurrentRow.Cells[14].Value.ToString();
                
            }
            else
            {
                MessageBox.Show("Selecciona una fila para saber que chofer esta disponible");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            mostrarBuscarTabla2("");
        }
    }
}
