using Login;
using Sistema_Tienda;
using Sistema_Tienda.Empleado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class PantallaPrincipal : Form
    {
        private Usuario usuario;
        private Login.Login login;
        private List<Cliente> listaCliente;
        private List<Empleado_Ventas> listaEmpleadosVentas;
        private List<Empleado_Envios> listaEmpleadosEnvios;
        private string pantalla;

        public PantallaPrincipal(Usuario usuario, Login.Login login)
        {
            InitializeComponent();
            this.listaCliente = new List<Cliente>();
            this.listaEmpleadosVentas = new List<Empleado_Ventas>();
            this.listaEmpleadosEnvios = new List<Empleado_Envios>();
            this.lstBoxVisor.Items.Clear();
            this.usuario = usuario;
            this.login = login;
            this.pantalla = "";
        }

        private void lblPerfil_Click(object sender, EventArgs e)
        {

        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
            this.lblNombre.Text = this.usuario.nombre;
            this.lblCorreo.Text = this.usuario.correo;
            this.lblPerfil.Text = this.usuario.perfil;
            this.lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.listaCliente = ClientesHandler.DeserializarClientes("../../../Data/clientes.json", this.lstBoxVisor);
            this.listaEmpleadosVentas = VendedoresHandler.DeserializarEmpleadosVentas("../../../Data/empleadosVentas.json", this.lstBoxVisor);
            this.listaEmpleadosEnvios = TransportistasHandler.DeserializarEmpleadosEnvios("../../../Data/empleadosTransportes.json", this.lstBoxVisor);

            switch (this.usuario.perfil)
            {
                case "vendedor":
                    this.btnTransportistas.Enabled = false;
                    this.btnVendedores.Enabled = false;
                    this.btnVendedores.BackColor = Color.Gray;
                    this.btnTransportistas.BackColor = Color.Gray;
                    break;

                case "supervisor":
                    this.btnTransportistas.Enabled = false;
                    this.btnTransportistas.BackColor = Color.Gray;
                    break;

                case "envios":
                    this.btnClientes.Enabled = false;
                    this.btnClientes.BackColor = Color.Gray;
                    this.btnVendedores.Enabled = false;
                    this.btnVendedores.BackColor = Color.Gray;
                    this.btnPedidos.Enabled = false;
                    this.btnPedidos.BackColor = Color.Gray;
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
            //this.login.TxtBoxClave = "";
            //this.login.TxtBoxCorreo = "";
            MessageBox.Show("Cerrando sesion...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            this.pantalla = "pedidos";
            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblPanel.Text = "Pedidos";


        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            this.pantalla = "vendedores";
            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblPanel.Text = "Vendedores";
            this.lblInfolstBox.Visible = true;
            VendedoresHandler.CargarVisorVendedores(this.lstBoxVisor, this.listaEmpleadosVentas);


        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.pantalla = "clientes";
            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblPanel.Text = "Clientes";
            this.lblInfolstBox.Visible = false;
            ClientesHandler.CargarVisorClientes(this.listaCliente, this.lstBoxVisor);

        }

        private void btnTransportes_Click(object sender, EventArgs e)
        {
            this.pantalla = "transportes";
            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblInfolstBox.Visible = false;
            this.lblPanel.Text = "Transportes";
            TransportistasHandler.CargarVisorTransportistas(this.lstBoxVisor, this.listaEmpleadosEnvios);

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

        private void btnCrear_Click(object sender, EventArgs e)
        {
            switch (this.pantalla)
            {
                case "clientes":
                    ClientesHandler.CrudCrearVendedor(this.lstBoxVisor, this.listaCliente);
                    break;
                case "vendedores":
                    VendedoresHandler.CrudAgregarVendedores(this.lstBoxVisor,this.listaEmpleadosVentas,this.listaCliente);
                    break;
                case "transportes":
                    TransportistasHandler.CrudAgregarTransportistas(this.lstBoxVisor,this.listaEmpleadosEnvios,this.listaCliente);
                    break;
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            switch (this.pantalla)
            {
                case "clientes":
                    ClientesHandler.CrudEditarVendedor(this.lstBoxVisor, this.listaCliente);
                    break;
                case "vendedores":
                    VendedoresHandler.CrudEditarVendedores(this.lstBoxVisor, this.listaEmpleadosVentas, this.listaCliente);
                    break;
                case "transportes":
                    TransportistasHandler.CrudEditarTransportistas(this.lstBoxVisor,this.listaEmpleadosEnvios, this.listaCliente);
                    break;

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            switch (this.pantalla)
            {
                case "clientes":
                    ClientesHandler.CrudEliminarVendedor(this.lstBoxVisor, this.listaCliente);
                    break;
                case "vendedores":
                    VendedoresHandler.CrudEliminarVendedores(this.lstBoxVisor, this.listaEmpleadosVentas, this.listaCliente);
                    break;
                case "transportes":
                    TransportistasHandler.CrudEliminarTransportistas(this.lstBoxVisor, this.listaEmpleadosEnvios, this.listaCliente);
                    break;
            }

        }

        private void lstBoxVisor_DoubleClick(object sender, EventArgs e)
        {
            if (this.pantalla == "vendedores")
            {
                VendedoresHandler.ExhibirDetalle(this.lstBoxVisor, this.listaEmpleadosVentas);
            }
            if(this.pantalla == "transportes")
            {
                TransportistasHandler.ExhibirDetalle(this.lstBoxVisor, this.listaEmpleadosEnvios);
            }

        }
    }


}
