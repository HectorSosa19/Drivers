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
    
    public partial class Choferes : Form
    {
        private string idChoferes,IdRutas,IdAutobuses;
        private bool Editarse = false;
        E_Choferes objEntidad = new E_Choferes();
        N_Choferes objNegocio = new N_Choferes();
        public Choferes()
        {
            InitializeComponent();
        }

        private void Choferes_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
        }
        public void mostrarBuscarTabla(string buscar)
        {
            N_Choferes objNegocio = new N_Choferes();
            tablaChoferes.DataSource = objNegocio.ListarChoferes(buscar);
        }
        private void Limpiar()
        {
            Editarse = false;
            
            txtidautobuses.Text = "";
            txtidrutas.Text = "";
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtcedula.Text = "";
            dateTimePicker1.ResetText();
            txtidautobuses.Focus();
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (tablaChoferes.SelectedRows.Count > 0)
            {
                Editarse = true;
                
                txtidrutas.Text = tablaChoferes.CurrentRow.Cells[10].Value.ToString();
                txtidautobuses.Text = tablaChoferes.CurrentRow.Cells[4].Value.ToString();
                txtnombre.Text = tablaChoferes.CurrentRow.Cells[1].Value.ToString();
                txtapellido.Text = tablaChoferes.CurrentRow.Cells[2].Value.ToString();
                dateTimePicker1.Text = tablaChoferes.CurrentRow.Cells[13].Value.ToString();
                txtcedula.Text = tablaChoferes.CurrentRow.Cells[3].Value.ToString();
                cbestado.Text = tablaChoferes.CurrentRow.Cells[14].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (tablaChoferes.SelectedRows.Count > 0)
            {
                objEntidad.IdChoferes = Convert.ToInt32(tablaChoferes.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EliminandoChoferes(objEntidad);
                MessageBox.Show("Se elimino correctamente");
                mostrarBuscarTabla("");
            }
            else
            {
                MessageBox.Show("Selecciona la fila que deseas eliminar");
            }
        }
    

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            if (Editarse == false)
            {
                try
                {

                    objEntidad.IdRutas = Convert.ToInt32(txtidrutas.Text);
                    objEntidad.IdAutobus = Convert.ToInt32(txtidautobuses.Text);
                    objEntidad.Nombre = txtnombre.Text.ToUpper();
                    objEntidad.Apellido = txtapellido.Text.ToUpper();
                    objEntidad.Fecha_de_nacimiento = dateTimePicker1.Value.Date;
                    objEntidad.Cedula = txtcedula.Text.ToUpper();
                    objEntidad.Estado = cbestado.Text.ToUpper();
                    objNegocio.InsertandoChoferes(objEntidad);
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
                        objEntidad.IdChoferes = Convert.ToInt32(idChoferes);
                        objEntidad.IdRutas = Convert.ToInt32(IdRutas);
                        objEntidad.IdAutobus = Convert.ToInt32(IdAutobuses);
                        objEntidad.Nombre = txtnombre.Text.ToUpper();
                        objEntidad.Apellido = txtapellido.Text.ToUpper();
                        objEntidad.Fecha_de_nacimiento = dateTimePicker1.Value.Date;
                        objEntidad.Cedula = txtcedula.Text.ToUpper();
                        objEntidad.Estado = cbestado.Text.ToUpper();
                        objNegocio.InsertandoChoferes(objEntidad);
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtSiguiente_Click(object sender, EventArgs e)
        {
            Form formulario = new Viajes();
            formulario.Show();
            this.Hide();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Form formulario = new Autobuses();
            formulario.Show();
            this.Hide();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
