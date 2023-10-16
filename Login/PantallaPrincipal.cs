using Login;
using Sistema_Tienda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class PantallaPrincipal : Form
    {
        private Usuario usuario;
        private Login.Login login;


        public PantallaPrincipal(Usuario usuario, Login.Login login)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.login = login;
        }

        private void lblPerfil_Click(object sender, EventArgs e)
        {

        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
            this.lblNombre.Text = this.usuario.nombre;
            this.lblCorreo.Text = this.usuario.correo;
            this.lblPerfil.Text = this.usuario.perfil;

            switch (this.usuario.perfil)
            {
                case "vendedor":
                    this.btnTransportes.Enabled = false;
                    this.btnVendedores.Enabled = false;
                    this.btnVendedores.BackColor = Color.Gray;
                    this.btnTransportes.BackColor = Color.Gray;
                    break;

                case "supervisor":
                    this.btnTransportes.Enabled = false;
                    this.btnTransportes.BackColor = Color.Gray;
                    break;

                case "envios":
                    this.btnClientes.Enabled = false;
                    this.btnClientes.BackColor = Color.Gray;
                    this.btnVendedores.Enabled = false;
                    this.btnVendedores.BackColor = Color.Gray;
                    break;


                default: break;


            }
        }

        private void PantallaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {

            this.login.Show();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.login.TxtBoxClave = "";
            this.login.TxtBoxCorreo = "";
            MessageBox.Show("Cerrando sesion...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblPanel.Text = "Pedidos";

        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblPanel.Text = "Vendedores";

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblPanel.Text = "Clientes";
            this.Deserializar("../../../Data/clientes.json");
        }

        private void btnTransportes_Click(object sender, EventArgs e)
        {
            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblPanel.Text = "Transportes";

        }


        private void switchearHome()
        {
            this.imgHome.Visible = false;
            this.imgPanel.Visible = true;
            this.lblControl.Visible = true;
            this.btnCrear.Visible = true;
            this.btnEditar.Visible = true;
            this.btnEliminar.Visible = true;
            this.lstBoxVisor.Visible = true;
            this.lstBoxVisor.Items.Clear();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.imgHome.Visible = true;
            this.imgPanel.Visible = false;
            this.lblControl.Visible = false;
            this.btnCrear.Visible = false;
            this.btnEditar.Visible = false;
            this.btnEliminar.Visible = false;
            this.lstBoxVisor.Visible = false;
            this.lblPanel.Visible = false;
            this.lstBoxVisor.Items.Clear();
        }

        private void Deserializar(string ruta)
        {
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(ruta))
                {
                    string json_str = sr.ReadToEnd();

                    List<Cliente> aux = (List<Cliente>)System.Text.Json.JsonSerializer.Deserialize(json_str, typeof(List<Cliente>));


                    foreach (Cliente c in aux)
                    {
                        this.lstBoxVisor.Items.Add(c);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
