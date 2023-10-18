using Sistema_Tienda;
using Sistema_Tienda.Empleado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace App
{
    public partial class FrmEmpleadoDeVentas : FrmEmpleadoBase
    {
        public Empleado_Ventas empl;
        public DialogResult res;
       
        public FrmEmpleadoDeVentas()
        {
            InitializeComponent();
        }

        public FrmEmpleadoDeVentas(Empleado_Ventas ev, List<Cliente> listaClientes, Experiencia[] valoresExperiencia) : this()
        {
            base.TxtBoxNombre.Text = ev.Nombre;
            base.TxtBoxDNI.Text = ev.Dni.ToString();
            base.TxtBoxSueldo.Text = ev.Sueldo.ToString();
            this.cmboBoxCliente.DisplayMember = "Nombre";
            this.cmboBoxCliente.ValueMember = "DNI";
            this.cmboBoxCliente.DataSource = listaClientes;
            base.CmboBoxExp.DataSource = valoresExperiencia;

        }
        public FrmEmpleadoDeVentas(List<Cliente> listaClientes, Experiencia[] valoresExperiencia) : this()
        {
           
            this.cmboBoxCliente.DataSource = listaClientes;
            base.CmboBoxExp.DataSource = valoresExperiencia;
        }


        public override void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente? clienteSeleccionado = null;
                List<Producto>? productos = null;
                if (this.cmboBoxCliente.SelectedIndex != -1)
                {
                    clienteSeleccionado = (Cliente)this.cmboBoxCliente.SelectedItem;
                }
                if (this.cmboBoxProductos.SelectedIndex != -1)
                {
                    productos = (List<Producto>)this.cmboBoxProductos.SelectedItem;
                }

                Empleado_Ventas ev = new Empleado_Ventas(clienteSeleccionado, base.TxtBoxNombre.Text, double.Parse(base.TxtBoxSueldo.Text), int.Parse(base.TxtBoxDNI.Text), productos);

                this.empl = ev;
                this.res = DialogResult.OK;
                this.Close();
                base.Aceptar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Cancelar_Click(object sender, EventArgs e)
        {
            this.res = DialogResult.Cancel;
            this.Close();
            base.Cancelar_Click(sender, e);
        }


    }
}
