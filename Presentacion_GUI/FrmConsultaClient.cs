using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion_GUI
{
    public partial class FrmConsultaClient : Form
    {
        public FrmConsultaClient()
        {
            InitializeComponent();
        }

        void cargar(string filtro)
        {
            List<Entidad.Cliente> clientes = new Logica.ServicioClientes().Consultar();
            dgvClientes.Rows.Clear();
            foreach (var item in clientes)
            {
                if (item.Nombre.StartsWith(filtro))
                {
                    dgvClientes.Rows.Add(item.IdCliente, item.Nombre); ;
                }

            }

        }
        private void grillaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEnlace_Click(object sender, EventArgs e)
        {
            BindingSource enlace = new BindingSource();
            enlace.DataSource = new Logica.ServicioClientes().Consultar();
            grillaClientes.DataSource = enlace;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            cargar("");
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            Entidad.Cliente cliente = new Entidad.Cliente();
            cliente.IdCliente = dgvClientes.Rows[fila].Cells[0].Value.ToString();
            cliente.Nombre = dgvClientes.Rows[fila].Cells[1].Value.ToString();
            ver(cliente);
        }
        void ver(Entidad.Cliente cliente)
        {
            FrmClientes fCliente = new FrmClientes(cliente);
            fCliente.ShowDialog();
        }
        private void verClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int fila = dgvClientes.CurrentRow.Index;
            Entidad.Cliente cliente = new Entidad.Cliente();
            cliente.IdCliente = dgvClientes.Rows[fila].Cells[0].Value.ToString();
            cliente.Nombre = dgvClientes.Rows[fila].Cells[1].Value.ToString();
            ver(cliente);

        }
    }
}
