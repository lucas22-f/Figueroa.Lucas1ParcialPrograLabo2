using Sistema_Tienda.Empleado;
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
    public partial class FrmEmpleadoDeEnvios : FrmEmpleadoBase
    {

        public Empleado_Envios empl;
        public DialogResult res;
        public FrmEmpleadoDeEnvios()
        {
            InitializeComponent();
        }

        public FrmEmpleadoDeEnvios(Empleado_Envios ev, List<Cliente> listaClientes, Experiencia[] valoresExperiencia) : this()
        {
            base.TxtBoxNombre.Text = ev.Nombre;
            base.TxtBoxDNI.Text = ev.Dni.ToString();
            base.TxtBoxSueldo.Text = ev.Sueldo.ToString();
            base.CmboBoxExp.DataSource = valoresExperiencia;

        }
        public FrmEmpleadoDeEnvios(List<Cliente> listaClientes, Experiencia[] valoresExperiencia) : this()
        {

            base.CmboBoxExp.DataSource = valoresExperiencia;
        }

        public override void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente? clienteSeleccionado = null;
                Pedido? pedido = null;

                if (this.cmbBoxPedido.SelectedIndex != -1)
                {
                    pedido = (Pedido)this.cmbBoxPedido.SelectedItem;
                }
                string experienciaSeleccionada = CmboBoxExp.SelectedItem.ToString();


                Experiencia experienciaEnum;
                if (Enum.TryParse(experienciaSeleccionada, out experienciaEnum))
                {
                    Empleado_Envios ev = new Empleado_Envios(this.TxtBoxNombre.Text,double.Parse(this.TxtBoxSueldo.Text),int.Parse(this.TxtBoxDNI.Text), new Pedido(), experienciaEnum);
                    this.empl = ev;
                    this.res = DialogResult.OK;
                    this.Close();
                    base.Aceptar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Opción no válida.");
                    this.Close();
                }



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
