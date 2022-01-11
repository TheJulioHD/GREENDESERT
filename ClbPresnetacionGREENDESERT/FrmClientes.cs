using ClbModGREENDESERT;
using ClbModGreenDesertv2;
using ClbNegGREENDESERT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClbPresnetacionGREENDESERT
{
    public partial class FrmClientes : Form
    {
        ClsNegCliente objNegCliente = new ClsNegCliente();
        private bool editar = false;
        public FrmClientes()
        {
            InitializeComponent();
            mostrar();
        }

        private void mostrar()
        {
            ClsNegCliente objNegClientes = new ClsNegCliente();
            dgvClientes.DataSource = objNegClientes.Cargar(@"Server=DESKTOP-PKU45LG\SQLEXPRESS;DataBase=GREENDESERT;Integrated Security=true");


        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (editar==false)
            {
                ClsModCliente objmodcliente = new ClsModCliente();

                var noclie = Convert.ToInt32(txtNoCliente.Text);

                objmodcliente.no_cliente = noclie;
                objmodcliente.nombre = txtname.Text;
                objmodcliente.apellido = txtapellido.Text;
                objmodcliente.direccion = txtdireccion.Text;
                objNegCliente.agregar(@"Server=DESKTOP-PKU45LG\SQLEXPRESS;DataBase=GREENDESERT;Integrated Security=true", objmodcliente, out ClsModResultado objModResultado);

                mostrar();
                limpiar();
            }
            if (editar==true)
            {
                ClsModCliente objmodcliente = new ClsModCliente();

                var noclie = Convert.ToInt32(txtNoCliente.Text);

                objmodcliente.no_cliente = noclie;
                objmodcliente.nombre = txtname.Text;
                objmodcliente.apellido = txtapellido.Text;
                objmodcliente.direccion = txtdireccion.Text;
                objNegCliente.Actualizar(@"Server=DESKTOP-PKU45LG\SQLEXPRESS;DataBase=GREENDESERT;Integrated Security=true", objmodcliente, out ClsModResultado objModResultado);
                mostrar();
                
                editar = false; 
            }
           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                editar = true;
                txtNoCliente.Text = dgvClientes.CurrentRow.Cells["no_cliente"].Value.ToString();
                txtname.Text = dgvClientes.CurrentRow.Cells["nombre"].Value.ToString();
                txtapellido.Text = dgvClientes.CurrentRow.Cells["apellido"].Value.ToString();
                txtdireccion.Text = dgvClientes.CurrentRow.Cells["direccion"].Value.ToString();
            }  
        }

        public void limpiar()
        {
            txtNoCliente.Clear();
            txtname.Clear();
            txtapellido.Clear();
            txtdireccion.Clear();
            editar = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
