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
        private List<Empleado_Ventas> empleado_Ventas;

        public PantallaPrincipal(Usuario usuario, Login.Login login)
        {
            InitializeComponent();
            this.listaCliente = new List<Cliente>();
            this.empleado_Ventas = new List<Empleado_Ventas>();
            this.lstBoxVisor.Items.Clear();
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
            this.DeserializarClientes("../../../Data/clientes.json");
            this.CrearYguardar1EmpleadoPrueba("../../../Data/empleadosVentas.json");

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
            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblPanel.Text = "Pedidos";

        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblPanel.Text = "Vendedores";
            this.CargarVisorVendedores();

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblPanel.Text = "Clientes";
            this.CargarVisorClientes();

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

        public void DeserializarClientes(string ruta)
        {
            this.lstBoxVisor.Items.Clear();
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(ruta))
                {
                    string json_str = sr.ReadToEnd();

                    List<Cliente> listaClientes = (List<Cliente>)System.Text.Json.JsonSerializer.Deserialize(json_str, typeof(List<Cliente>));
                    this.listaCliente = listaClientes;


                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private void SerializarClientes(string ruta)
        {
            this.lstBoxVisor.Items.Clear();
            try
            {

                JsonSerializerOptions opciones = new JsonSerializerOptions();
                opciones.WriteIndented = true;
                string obj_json = JsonSerializer.Serialize(this.listaCliente, typeof(List<Cliente>), opciones);

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(ruta))
                {
                    sw.WriteLine(obj_json);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void CargarVisorClientes()
        {
            foreach (Cliente c in this.listaCliente)
            {
                this.lstBoxVisor.Items.Add(c);
            }
        }

        private void CargarVisorVendedores()
        {
            foreach (Empleado_Ventas c in this.empleado_Ventas)
            {
                this.lstBoxVisor.Items.Add(c);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            FrmAgregarCliente frmCliente = new FrmAgregarCliente();
            frmCliente.ShowDialog();

            if (frmCliente.res == DialogResult.OK)
            {
                Cliente cli = frmCliente.cliente;
                this.listaCliente.Add(cli);
                this.SerializarClientes("../../../Data/clientes.json");
                this.CargarVisorClientes();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int indexList = this.lstBoxVisor.SelectedIndex;
            if (indexList != -1)
            {

                FrmAgregarCliente frm = new FrmAgregarCliente(this.listaCliente[indexList]);
                frm.ShowDialog();
                if (frm.res == DialogResult.OK)
                {
                    this.listaCliente[indexList] = frm.cliente;
                    this.SerializarClientes("../../../Data/clientes.json");
                    this.CargarVisorClientes();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indexList = this.lstBoxVisor.SelectedIndex;
            if (indexList != -1)
            {
                Cliente cli = this.listaCliente[indexList];
                DialogResult ResBoton = MessageBox.Show($"Estas seguro de borrar el cliente:{cli.nombre} ? ", "Atencion! ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); ;

                if (ResBoton == DialogResult.OK)
                {
                    this.listaCliente.RemoveAt(indexList);
                    this.SerializarClientes("../../../Data/clientes.json");
                    this.CargarVisorClientes();
                }
            }
        }


        private void CrearYguardar1EmpleadoPrueba(string ruta)
        {
            this.lstBoxVisor.Items.Clear();
            try
            {
                JsonSerializerOptions opciones = new JsonSerializerOptions();
                opciones.WriteIndented = true;
                Empleado_Ventas ev = new(this.listaCliente[0], "Lucas", 2000, 3010, new List<Producto>(), Experiencia.Intermedio);
                MessageBox.Show(ev.ToString());
                string obj_json = JsonSerializer.Serialize(ev, typeof(Empleado_Ventas), opciones);

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(ruta))
                {
                    sw.WriteLine(obj_json);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private void SerializarEmpleadosVentas(string ruta)
        {
            this.lstBoxVisor.Items.Clear();
            try
            {

                JsonSerializerOptions opciones = new JsonSerializerOptions();
                opciones.WriteIndented = true;
                string obj_json = JsonSerializer.Serialize(this.listaCliente, typeof(List<Empleado_Ventas>), opciones);

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(ruta))
                {
                    sw.WriteLine(obj_json);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }


}
