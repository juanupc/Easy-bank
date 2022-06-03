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
    public partial class FrmCuentas : Form
    {
       

        public FrmCuentas()
        {
            InitializeComponent();
        }
        ServicioCuenta scuenta = new ServicioCuenta();
        Cuenta cuenta = new Cuenta();
        private void TxtIdClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                var cliente = new ServicioClientes().BuscarID(TxtIdClientes.Text);
                if(cliente != null) {
                 Ver(cliente);
                }
               
            }

        }
        void Ver(Cliente cliente)
        {
            TxtIdClientes.Text = cliente.IdCliente;
            TxtNombreCliente.Text = cliente.Nombre;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        void guardar()
        {
            double ncuenta, nSaldo;
            Cliente cliente;
            string mensaje;
        
            
            cliente = new ServicioClientes().BuscarID(TxtIdClientes.Text);
            
            if (TxtIdClientes.Text == null)
            {
                MessageBox.Show("CLIENTE NO EXISTENTE");
            }
            ncuenta = Convert.ToDouble(txtNumcuenta.Text);
            nSaldo = Convert.ToDouble(TxtSaldo.Text);

            Cuenta cuentaG = new Cuenta(ncuenta,cliente, nSaldo);

            mensaje = scuenta.Guardar(cuentaG);

            MessageBox.Show(mensaje);
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
            if (cliente == null)
            {
                MessageBox.Show("No se encuentra el cliente en nuestro sistema");
                return;
            }
            Ver(cliente);


        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            //{

            //    int indice = e.RowIndex;
            //    if (indice >= 0)
            //    {
            //        txtindice.Text = indice.ToString();
            //        txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
            //        txtcodigo.Text = dgvdata.Rows[indice].Cells["Codigo"].Value.ToString();
            //        txtnombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
            //        txtdescripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();

            //        foreach (OpcionCombo oc in cbocategoria.Items)
            //        {
            //            if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdCategoria"].Value))
            //            {
            //                int indice_combo = cbocategoria.Items.IndexOf(oc);
            //                cbocategoria.SelectedIndex = indice_combo;
            //                break;
            //            }
            //        }
            //        foreach (OpcionCombo oc in cboestado.Items)
            //        {
            //            if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
            //            {
            //                int indice_combo = cboestado.Items.IndexOf(oc);
            //                cboestado.SelectedIndex = indice_combo;
            //                break;
            //            }
            //        }


            //    }

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string columnafiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            //if (dgvdata.Rows.Count > 0)
            //{
            //    foreach (DataGridViewRow row in dgvdata.Rows)
            //    {
            //        if (row.Cells[columnafiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
            //        {
            //            row.Visible = true;
            //        }
            //        else
            //        {
            //            row.Visible = false;
            //        }

            //    }
            //}
        }

        private void btnenlace_Click(object sender, EventArgs e)
        {
            Lista_Cuentas lista = new Lista_Cuentas();
            lista.Show();
        }
    }
}
