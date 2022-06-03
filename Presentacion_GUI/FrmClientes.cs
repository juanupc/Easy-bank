using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Entidad;

namespace Presentacion_GUI
{
    public partial class FrmClientes : Form
    {
        ServicioClientes Sc = new ServicioClientes();
        Cliente cliente = new Cliente();
        public FrmClientes()
        {
            InitializeComponent();
        }
        public FrmClientes(Entidad.Cliente cliente)
        {
            InitializeComponent();
            verCliente(cliente);
        }
        void verCliente(Entidad.Cliente cliente)
        {
            if (cliente != null)
            {
                TxtIdClientes.Text = cliente.IdCliente;
                TxtNombreCliente.Text = cliente.Nombre;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar(TxtIdClientes.Text);
        }
        void Buscar(string id)
        {
            ServicioClientes sc = new ServicioClientes();
            Cliente cliente;
            cliente = sc.BuscarID(id);
            if(cliente == null)
            {
                MessageBox.Show("No se encuentra el cliente en nuestro sistema");
                return;
            }
                Ver(cliente);
            

        }
        void Ver(Cliente cliente)
        {
            TxtIdClientes.Text = cliente.IdCliente;
            TxtNombreCliente.Text = cliente.Nombre;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
          TxtIdClientes.Clear();
          TxtNombreCliente.Clear();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardar();

        }

        void guardar()
        {
            
             cliente.IdCliente = TxtIdClientes.Text;
             cliente.Nombre = TxtNombreCliente.Text;

            string mensaje;
            mensaje = Sc.Guardar(cliente);

            MessageBox.Show(mensaje);
        }
        private void btnenlace_clientes_Click(object sender, EventArgs e)
        {
            Lista_de_Clientes frm_1 = new Lista_de_Clientes();
            frm_1.Show();
        }
    }
}
