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
    public partial class Rutas : Form
    {
        private string idRuta;
        private bool Editarse = false;
        E_Choferes objEntidad = new E_Choferes();
        N_Choferes objNegocio = new N_Choferes();
        public Rutas()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void mostrarBuscarTabla(string buscar)
        {
            N_Choferes objNegocio = new N_Choferes();
            tablaRutas.DataSource = objNegocio.ListarRuta(buscar);
        }
        private void Rutas_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
        }
        private void Limpiar()
        {
            Editarse = false;
            
            txtruta.Text = "";
            txtruta.Focus();
        }
        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Form formulario = new Autobuses();

            formulario.Show();
            this.Hide();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (tablaRutas.SelectedRows.Count > 0)
            {
                Editarse = true;
                
                txtruta.Text = tablaRutas.CurrentRow.Cells[11].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (tablaRutas.SelectedRows.Count > 0)
            {
                objEntidad.IdRutas = Convert.ToInt32(tablaRutas.CurrentRow.Cells[10].Value.ToString());
                objNegocio.EliminandoRutas(objEntidad);
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
                    objEntidad.IdRutas = Convert.ToInt32(txtidRuta.Text);
                    objEntidad.Nombre_de_ruta = txtruta.Text.ToUpper();
                    objNegocio.InsertandoRuta(objEntidad);
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
                        
                        objEntidad.Nombre_de_ruta = txtruta.Text.ToUpper();
                        objNegocio.InsertandoRuta(objEntidad);
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text);
        }

        private void tablaRutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    

