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
    public partial class FrmVentas : Form
    {
        ClsNegVentas ObjNegVentas = new ClsNegVentas();
        private bool editar = false;
        private string id = null;

        public FrmVentas()
        {
            InitializeComponent();
            mostrar();
        }

        private void mostrar()
        {
            ClsNegProductos ObjNegProducto = new ClsNegProductos();
            dgvVentas.DataSource = ObjNegProducto.Cargar(@"Server=DESKTOP-PKU45LG\SQLEXPRESS;DataBase=GREENDESERT;Integrated Security=true");


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                ClsModVentas ObjModVentas = new ClsModVentas();

                var idpventas = Convert.ToInt32(txtid.Text);
                var idproducto = Convert.ToInt32(txtproduc.Text);
                var idempleado = Convert.ToInt32(txtEmpleado.Text);
                var idcliente = Convert.ToInt32(txtCliente.Text);
                var fecha = Convert.ToDateTime(dateTimePicker1.Value.Date);

                ObjModVentas.id_venta = idpventas;
                ObjModVentas.id_producto = idproducto;
                ObjModVentas.id_empledo = idempleado;
                ObjModVentas.no_cliente = idcliente;
                ObjModVentas.fecha_de_despacho = fecha;

                ObjNegVentas.agregar(@"Server=DESKTOP-PKU45LG\SQLEXPRESS;DataBase=GREENDESERT;Integrated Security=true", ObjModVentas, out ClsModResultado objModResultado);

                mostrar();
                limpiar();
            }
            if (editar == true)
            {
                ClsModVentas ObjModVentas = new ClsModVentas();
                var idpventas = Convert.ToInt32(txtid.Text);
                var idproducto = Convert.ToInt32(txtproduc.Text);
                var idempleado = Convert.ToInt32(txtEmpleado.Text);
                var idcliente = Convert.ToInt32(txtCliente.Text);


                ObjModVentas.id_venta = idpventas;
                ObjModVentas.id_producto = idproducto;
                ObjModVentas.id_empledo = idempleado;
                ObjModVentas.no_cliente = idcliente;
                ObjModVentas.fecha_de_despacho = dateTimePicker1.Value.Date;
                ObjNegVentas.Actualizar(@"Server=DESKTOP-PKU45LG\SQLEXPRESS;DataBase=GREENDESERT;Integrated Security=true", ObjModVentas, out ClsModResultado objModResultado);
                mostrar();

                editar = false;
            }
        }
        public void limpiar()
        {

            txtCliente.Clear();
            txtEmpleado.Clear();
            txtid.Clear();
            txtproduc.Clear();
            editar = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {

                editar = true;
                txtid.Text = dgvVentas.CurrentRow.Cells["id_venta"].Value.ToString();
                txtproduc.Text = dgvVentas.CurrentRow.Cells["id_producto"].Value.ToString();
                txtEmpleado.Text = dgvVentas.CurrentRow.Cells["id_empledo"].Value.ToString();
                txtCliente.Text = dgvVentas.CurrentRow.Cells["no_cliente"].Value.ToString();
                dateTimePicker1.Text = dgvVentas.CurrentRow.Cells["fecha_de_despacho"].Value.ToString();


            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
