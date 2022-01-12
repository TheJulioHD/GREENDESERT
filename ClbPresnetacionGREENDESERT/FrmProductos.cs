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
    public partial class FrmProductos : Form
    { 
        ClsNegProductos ObjNegProducto = new ClsNegProductos();
        private bool editar = false;
        private string id = null;

        public FrmProductos()
        {
            InitializeComponent();
            mostrar();
        }
        private void mostrar()
        {
            ClsNegProductos ObjNegProducto = new ClsNegProductos();
            dgvProducto.DataSource = ObjNegProducto.Cargar(@"Server=DESKTOP-PKU45LG\SQLEXPRESS;DataBase=GREENDESERT;Integrated Security=true");


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (editar == false)
            {
                ClsModProducto ObjModProducto = new ClsModProducto();

                var idproducto = Convert.ToInt32(txtiD.Text);
                var idproveedor = Convert.ToInt32(txtIDprov.Text);


                ObjModProducto.id_producto = idproducto;
                ObjModProducto.codigo = txtCodigo.Text;
                ObjModProducto.nombre = txtNombre.Text;
                ObjModProducto.marca = txtMarca.Text;
                ObjModProducto.id_Provedor = idproveedor;

                ObjNegProducto.agregar(@"Server=DESKTOP-PKU45LG\SQLEXPRESS;DataBase=GREENDESERT;Integrated Security=true", ObjModProducto, out ClsModResultado objModResultado);

                mostrar();
                limpiar();
            }
            if (editar == true)
            {
                ClsModProducto ObjModProducto = new ClsModProducto();

                var idproducto = Convert.ToInt32(txtiD.Text);
                var idproveedor = Convert.ToInt32(txtIDprov.Text);



                ObjModProducto.id_producto = idproducto;
                ObjModProducto.codigo = txtCodigo.Text;
                ObjModProducto.nombre = txtNombre.Text;
                ObjModProducto.marca = txtMarca.Text;
                ObjModProducto.id_Provedor = idproveedor;
                ObjNegProducto.Actualizar(@"Server=DESKTOP-PKU45LG\SQLEXPRESS;DataBase=GREENDESERT;Integrated Security=true", ObjModProducto, out ClsModResultado objModResultado);
                mostrar();

                editar = false;
            }
        }

        public void limpiar()
        {

            txtNombre.Clear();
            txtIDprov.Clear();
            txtiD.Clear();
            txtCodigo.Clear();
            txtMarca.Clear();
            editar = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProducto.SelectedRows.Count > 0)
            {

                editar = true;
                txtiD.Text = dgvProducto.CurrentRow.Cells["id_producto"].Value.ToString();
                txtCodigo.Text = dgvProducto.CurrentRow.Cells["codigo"].Value.ToString();
                txtNombre.Text = dgvProducto.CurrentRow.Cells["nombre"].Value.ToString();
                txtMarca.Text = dgvProducto.CurrentRow.Cells["marca"].Value.ToString();
                txtIDprov.Text = dgvProducto.CurrentRow.Cells["id_Provedor"].Value.ToString();


            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
