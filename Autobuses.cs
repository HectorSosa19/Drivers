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
    public partial class Autobuses : Form
    {
        private string idAutobus;
        private bool Editarse = false;
        E_Choferes objEntidad = new E_Choferes();
        N_Choferes objNegocio = new N_Choferes();
        public Autobuses()
        {
            InitializeComponent();
        }

        private void EstacionServicio_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
        }
        public void mostrarBuscarTabla(string buscar)
        {
            N_Choferes objNegocio = new N_Choferes();
            tablaAutobuses.DataSource = objNegocio.ListarAutobuses(buscar);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Form formulario = new Choferes();
            
            formulario.Show();
            this.Hide();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Form formulario1 = new Rutas();
            formulario1.Show();
            this.Hide();
        }
        private void Limpiar()
        {
            Editarse = false;
            txtidchoferes.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtPlaca.Text = "";
            TxtColor.Text = "";
            txtAño.Text = "";
            cbEstado.Text = "";
            txtidchoferes.Focus();
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (tablaAutobuses.SelectedRows.Count > 0)
            {
                Editarse = true;
                txtidchoferes.Text = tablaAutobuses.CurrentRow.Cells[0].Value.ToString();
                txtMarca.Text = tablaAutobuses.CurrentRow.Cells[5].Value.ToString();
                txtModelo.Text = tablaAutobuses.CurrentRow.Cells[6].Value.ToString();
                txtPlaca.Text = tablaAutobuses.CurrentRow.Cells[7].Value.ToString();
                TxtColor.Text = tablaAutobuses.CurrentRow.Cells[8].Value.ToString();
                txtAño.Text = tablaAutobuses.CurrentRow.Cells[9].Value.ToString();
                cbEstado.Text = tablaAutobuses.CurrentRow.Cells[14].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            
            if (tablaAutobuses.SelectedRows.Count > 0)
            {
                objEntidad.IdAutobus = Convert.ToInt32(tablaAutobuses.CurrentRow.Cells[4].Value.ToString());
                objNegocio.EliminandoAutobuses(objEntidad);
                MessageBox.Show("Se elimino correctamente");
                mostrarBuscarTabla("");
            }
            else
            {
                MessageBox.Show("Selecciona la fila que deseas eliminar");
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            if (Editarse == false)
            {
                try
                {
                    objEntidad.IdChoferes = Convert.ToInt32(txtidchoferes.Text);
                    objEntidad.Marca = txtMarca.Text.ToUpper();
                    objEntidad.Modelo = txtPlaca.Text.ToUpper();
                    objEntidad.Placa = txtPlaca.Text.ToUpper();
                    objEntidad.Color = TxtColor.Text.ToUpper();
                    objEntidad.Año = Convert.ToInt32(txtAño.Text);
                    objEntidad.Estado = cbEstado.Text.ToUpper();
                    objNegocio.InsertandoAutobuses(objEntidad);
                    MessageBox.Show("Se guardo el registro");
                    mostrarBuscarTabla("");
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
                if (Editarse == true)
                {
                    try
                    {
                        objEntidad.IdChoferes = Convert.ToInt32(txtidchoferes.Text);
                        objEntidad.Marca = txtMarca.Text.ToUpper();
                        objEntidad.Modelo = txtPlaca.Text.ToUpper();
                        objEntidad.Placa = txtPlaca.Text.ToUpper();
                        objEntidad.Color = TxtColor.Text.ToUpper();
                        objEntidad.Año = Convert.ToInt32(txtAño.Text);
                        objEntidad.Estado = cbEstado.Text.ToUpper();
                        objNegocio.InsertandoAutobuses(objEntidad);
                        MessageBox.Show("Se edito el registro");
                        mostrarBuscarTabla("");
                        Limpiar();
                        Editarse = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo editar el registro" + ex);
                    }
                }
            }
        }
    }
}
