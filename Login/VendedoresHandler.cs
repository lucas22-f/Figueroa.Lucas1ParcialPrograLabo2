using Sistema_Tienda;
using Sistema_Tienda.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App
{
    public static class VendedoresHandler
    {
        public static void CargarVisorVendedores(ListBox lstBoxVisor ,List<Empleado_Ventas> listaEmpleadosVentas)
        {
            foreach (Empleado_Ventas c in listaEmpleadosVentas)
            {
                lstBoxVisor.Items.Add(c);
            }
        }


        public static void SerializarEmpleadosVentas(string ruta, ListBox lstBoxVisor, List<Empleado_Ventas> listaEmpleadosVentas)
        {
            lstBoxVisor.Items.Clear();
            try
            {

                JsonSerializerOptions opciones = new JsonSerializerOptions();
                opciones.WriteIndented = true;
                string obj_json = JsonSerializer.Serialize(listaEmpleadosVentas, typeof(List<Empleado_Ventas>), opciones);

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

        public static List<Empleado_Ventas> DeserializarEmpleadosVentas(string ruta, ListBox lstBoxVisor)
        {
            lstBoxVisor.Items.Clear();
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(ruta))
                {
                    string json_str = sr.ReadToEnd();

                    List<Empleado_Ventas> listaEmpl = (List<Empleado_Ventas>)System.Text.Json.JsonSerializer.Deserialize(json_str, typeof(List<Empleado_Ventas>));
                    return  listaEmpl;


                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static void ExhibirDetalle(ListBox lstBoxVisor, List<Empleado_Ventas> listaEmpleadosVentas)
        {
            int indexList = lstBoxVisor.SelectedIndex;
            if (indexList != -1)
            {

                MessageBox.Show(listaEmpleadosVentas[indexList].MostarInfoDetallada(), "Empleado : ");


            }
        }

        public static void CrudAgregarVendedores(ListBox lstBoxVisor, List<Empleado_Ventas> listaEmpleadosVentas,List<Cliente> listaCliente)
        {
            Experiencia[] valoresExperiencia = (Experiencia[])Enum.GetValues(typeof(Experiencia));
            FrmEmpleadoDeVentas frmEmplVent = new FrmEmpleadoDeVentas(listaCliente, valoresExperiencia);
            frmEmplVent.ShowDialog();

            if (frmEmplVent.res == DialogResult.OK)
            {
                Empleado_Ventas empl = frmEmplVent.empl;
                listaEmpleadosVentas.Add(empl);
                VendedoresHandler.SerializarEmpleadosVentas("../../../Data/empleadosVentas.json", lstBoxVisor,listaEmpleadosVentas);
                VendedoresHandler.CargarVisorVendedores(lstBoxVisor, listaEmpleadosVentas);
            }
        }

        public static void CrudEditarVendedores(ListBox lstBoxVisor, List<Empleado_Ventas> listaEmpleadosVentas, List<Cliente> listaCliente)
        {
            int indexListVentas = lstBoxVisor.SelectedIndex;
            if (indexListVentas != -1)
            {
                Experiencia[] valoresExperiencia = (Experiencia[])Enum.GetValues(typeof(Experiencia));
                FrmEmpleadoDeVentas frm = new FrmEmpleadoDeVentas(listaEmpleadosVentas[indexListVentas], listaCliente, valoresExperiencia);
                frm.ShowDialog();
                if (frm.res == DialogResult.OK)
                {
                    listaEmpleadosVentas[indexListVentas] = frm.empl;
                    VendedoresHandler.SerializarEmpleadosVentas("../../../Data/empleadosVentas.json", lstBoxVisor, listaEmpleadosVentas);
                    VendedoresHandler.CargarVisorVendedores(lstBoxVisor, listaEmpleadosVentas);
                }
            }
        }
        public static void CrudEliminarVendedores(ListBox lstBoxVisor, List<Empleado_Ventas> listaEmpleadosVentas, List<Cliente> listaCliente)
        {
            int indexListVen = lstBoxVisor.SelectedIndex;
            if (indexListVen != -1)
            {
                Empleado_Ventas env = listaEmpleadosVentas[indexListVen];
                DialogResult ResBoton = MessageBox.Show($"Estas seguro de borrar el empleado:{env.Nombre} ? ", "Atencion! ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); ;

                if (ResBoton == DialogResult.OK)
                {
                    listaEmpleadosVentas.RemoveAt(indexListVen);
                    VendedoresHandler.SerializarEmpleadosVentas("../../../Data/empleadosVentas.json", lstBoxVisor, listaEmpleadosVentas);
                    VendedoresHandler.CargarVisorVendedores(lstBoxVisor, listaEmpleadosVentas);
                }
            }
        }

    }
}
