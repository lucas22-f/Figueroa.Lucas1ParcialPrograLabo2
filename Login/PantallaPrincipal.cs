﻿using Login;
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
        private string pantalla;
        private bool pedidoOperador;

        private List<Cliente> listaCliente;
        private List<Empleado_Ventas> listaEmpleadosVentas;
        private List<Empleado_Envios> listaEmpleadosEnvios;
        private List<Producto> listaDeConjuntosProductos;
        private List<Pedido> listaPedidos;

        public PantallaPrincipal(Usuario usuario, Login.Login login)
        {
            InitializeComponent();
            SistemaTienda cargaSistema = new SistemaTienda();
            this.usuario = usuario;
            this.login = login;
            this.pantalla = "";
            this.pedidoOperador = false;
            this.listaDeConjuntosProductos = ProductosHandler.GenerarListaConjuntoDeProductos();

            this.lstBoxVisor.Items.Clear();
            this.listaCliente = cargaSistema.Clientes;
            this.listaEmpleadosVentas = cargaSistema.EmpleadosVentas;
            this.listaEmpleadosEnvios = cargaSistema.EmpleadosEnvios;
            this.listaPedidos = cargaSistema.Pedidos;

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
            if(!File.Exists("../../../Data/clientes.json")|| !File.Exists("../../../Data/empleadosVentas.json") || !File.Exists("../../../Data/empleadosTransportes.json"))
            {
                MessageBox.Show("Por favor cargue los archivos json;","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
            }
            this.listaCliente = ClientesHandler.DeserializarClientes("../../../Data/clientes.json", this.lstBoxVisor);
            this.listaEmpleadosVentas = VendedoresHandler.DeserializarEmpleadosVentas("../../../Data/empleadosVentas.json", this.lstBoxVisor);
            this.listaEmpleadosEnvios = TransportistasHandler.DeserializarEmpleadosEnvios("../../../Data/empleadosTransportes.json", this.lstBoxVisor);
            this.btnOrdenar.Visible = false;
            this.btnOrdenarDesc.Visible = false;
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
            DialogResult res = MessageBox.Show("Seguro ? ", "Atencion! Cerrar sistema ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            this.pantalla = "pedidos";
            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblPanel.Text = "Creacion de Pedido Actual";
            this.btnCrear.Visible = false;
            this.btnEditar.Visible = false;
            this.btnEliminar.Visible = false;
            this.lblControl.Visible = false;
            
            FrmPedido frmPedido = new FrmPedido(this.listaDeConjuntosProductos, this.listaEmpleadosVentas, this.listaCliente);
            frmPedido.ShowDialog();
            Pedido pe = frmPedido.p;
            this.listaPedidos.Add(pe);
            this.lstBoxVisor.Items.Clear();
            this.lstBoxVisor.Items.Add(frmPedido.p.ToString());
            this.pedidoOperador = true;


        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            if (this.pedidoOperador)
            {
                this.pantalla = "vendedores";
                this.switchearHome();
                this.lblPanel.Visible = true;
                this.lblPanel.Text = "Vendedores";
                this.lblInfolstBox.Visible = true;
                this.btnOrdenar.Visible = true;
                this.btnOrdenarDesc.Visible = true;
                VendedoresHandler.CargarVisorVendedores(this.lstBoxVisor, this.listaEmpleadosVentas);

            }
            else
            {
                MessageBox.Show("Por favor primero crear Pedido para operar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.pantalla = "clientes";
            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblPanel.Text = "Clientes";
            this.lblInfolstBox.Visible = false;
            this.btnOrdenar.Visible = true;
            this.btnOrdenarDesc.Visible = true;
            ClientesHandler.CargarVisorClientes(this.listaCliente, this.lstBoxVisor);

        }

        private void btnTransportes_Click(object sender, EventArgs e)
        {
            if (this.pedidoOperador)
            {
                this.pantalla = "transportes";
                this.switchearHome();
                this.lblPanel.Visible = true;
                this.lblInfolstBox.Visible = false;
                this.lblPanel.Text = "Transportes";
                this.lblInfolstBox.Visible = true;
                this.btnOrdenar.Visible = true;
                this.btnOrdenarDesc.Visible = true;
                TransportistasHandler.CargarVisorTransportistas(this.lstBoxVisor, this.listaEmpleadosEnvios);

            }
            else
            {
                MessageBox.Show("Por favor primero crear Pedido para operar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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
            this.lblInfolstBox.Visible = false;
            this.btnEliminar.Visible = false;
            this.lstBoxVisor.Visible = false;
            this.lblPanel.Visible = false;
            this.btnOrdenarDesc.Visible = false;
            this.btnOrdenar.Visible= false;
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
                    VendedoresHandler.CrudAgregarVendedores(this.lstBoxVisor, this.listaEmpleadosVentas, this.listaCliente, this.listaDeConjuntosProductos);
                    break;
                case "transportes":
                    TransportistasHandler.CrudAgregarTransportistas(this.lstBoxVisor, this.listaEmpleadosEnvios, this.listaCliente, this.listaPedidos);
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
                    VendedoresHandler.CrudEditarVendedores(this.lstBoxVisor, this.listaEmpleadosVentas, this.listaCliente, this.listaDeConjuntosProductos);
                    break;
                case "transportes":
                    TransportistasHandler.CrudEditarTransportistas(this.lstBoxVisor, this.listaEmpleadosEnvios, this.listaCliente, this.listaPedidos);
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
            if (this.pantalla == "transportes")
            {
                TransportistasHandler.ExhibirDetalle(this.lstBoxVisor, this.listaEmpleadosEnvios);
            }

        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (this.pantalla == "vendedores")
            {
                this.lstBoxVisor.Items.Clear();
                this.listaEmpleadosVentas.Sort(Empleado_Ventas.OrdenarPorNombre);
                foreach (var i in this.listaEmpleadosVentas)
                {
                    this.lstBoxVisor.Items.Add(i);
                }
            }
            else if (this.pantalla == "transportes")
            {
                this.lstBoxVisor.Items.Clear();
                this.listaEmpleadosEnvios.Sort(Empleado_Envios.OrdenarPorNombre);
                foreach (var i in this.listaEmpleadosEnvios)
                {
                    this.lstBoxVisor.Items.Add(i);
                }
            }
            else if (this.pantalla == "clientes")
            {
                this.lstBoxVisor.Items.Clear();
                this.listaCliente.Sort(Cliente.OrdenarPorNombre);
                foreach (var i in this.listaCliente)
                {
                    this.lstBoxVisor.Items.Add(i);
                }
            }

        }

        private void btnOrdenarDesc_Click(object sender, EventArgs e)
        {
            if (this.pantalla == "vendedores")
            {
                this.lstBoxVisor.Items.Clear();
                this.listaEmpleadosVentas.Sort(Empleado_Ventas.OrdenarPorNombreDescendente);
                foreach (var i in this.listaEmpleadosVentas)
                {
                    this.lstBoxVisor.Items.Add(i);
                }
            }
            else if (this.pantalla == "transportes")
            {
                this.lstBoxVisor.Items.Clear();
                this.listaEmpleadosEnvios.Sort(Empleado_Envios.OrdenarPorNombreDescendente);
                foreach (var i in this.listaEmpleadosEnvios)
                {
                    this.lstBoxVisor.Items.Add(i);
                }
            }
            else if (this.pantalla == "clientes")
            {
                this.lstBoxVisor.Items.Clear();
                this.listaCliente.Sort(Cliente.OrdenarPorNombreDescendente);
                foreach (var i in this.listaCliente)
                {
                    this.lstBoxVisor.Items.Add(i);
                }
            }
        }
    }


}
