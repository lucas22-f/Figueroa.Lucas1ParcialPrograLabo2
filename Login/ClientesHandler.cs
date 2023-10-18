using Sistema_Tienda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App
{
    public static class ClientesHandler
    {
        
        public static List<Cliente> DeserializarClientes(string ruta,ListBox lstBoxVisor)
        {
            List<Cliente>? res = null;
            lstBoxVisor.Items.Clear();
            if (File.Exists(ruta))
            {
                try
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(ruta))
                    {
                        string json_str = sr.ReadToEnd();

                        List<Cliente> listaClientes = (List<Cliente>)System.Text.Json.JsonSerializer.Deserialize(json_str, typeof(List<Cliente>));
                        res = listaClientes;


                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    res = null;
                }
            }

            return res;
            
        }

        public static void SerializarClientes(string ruta , ListBox lstBoxVisor, List<Cliente> listaCliente)
        {
            
                lstBoxVisor.Items.Clear();
                try
                {

                    JsonSerializerOptions opciones = new JsonSerializerOptions();
                    opciones.WriteIndented = true;
                    string obj_json = JsonSerializer.Serialize(listaCliente, typeof(List<Cliente>), opciones);

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

        public static void CargarVisorClientes(List<Cliente> listaCliente, ListBox lstBoxVisor)
        {
            foreach (Cliente c in listaCliente)
            {
                lstBoxVisor.Items.Add(c);
            }
        }

        public static void CrudCrearVendedor(ListBox lstBoxVisor , List<Cliente> listaCliente)
        {
            FrmAgregarCliente frmCliente = new FrmAgregarCliente();
            frmCliente.ShowDialog();

            if (frmCliente.res == DialogResult.OK)
            {
                Cliente cli = frmCliente.cliente;
                listaCliente.Add(cli);
                ClientesHandler.SerializarClientes("../../../Data/clientes.json", lstBoxVisor, listaCliente);
                ClientesHandler.CargarVisorClientes(listaCliente, lstBoxVisor);
            }
        }
        public static void CrudEditarVendedor(ListBox lstBoxVisor, List<Cliente> listaCliente)
        {
            int indexListCli = lstBoxVisor.SelectedIndex;
            if (indexListCli != -1)
            {

                FrmAgregarCliente frm = new FrmAgregarCliente(listaCliente[indexListCli]);
                frm.ShowDialog();
                if (frm.res == DialogResult.OK)
                {
                    listaCliente[indexListCli] = frm.cliente;
                    ClientesHandler.SerializarClientes("../../../Data/clientes.json", lstBoxVisor, listaCliente);
                    //this.SerializarClientes("../../../Data/clientes.json");
                    ClientesHandler.CargarVisorClientes(listaCliente, lstBoxVisor);
                }
            }
        }
        public static void CrudEliminarVendedor(ListBox lstBoxVisor, List<Cliente> listaCliente)
        {
            int indexList = lstBoxVisor.SelectedIndex;
            if (indexList != -1)
            {
                Cliente cli = listaCliente[indexList];
                DialogResult ResBoton = MessageBox.Show($"Estas seguro de borrar el cliente:{cli.nombre} ? ", "Atencion! ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); ;

                if (ResBoton == DialogResult.OK)
                {
                    listaCliente.RemoveAt(indexList);
                    ClientesHandler.SerializarClientes("../../../Data/clientes.json", lstBoxVisor, listaCliente);
                    //this.SerializarClientes("../../../Data/clientes.json");
                    ClientesHandler.CargarVisorClientes(listaCliente, lstBoxVisor);
                }
            }
        }
    }
}
