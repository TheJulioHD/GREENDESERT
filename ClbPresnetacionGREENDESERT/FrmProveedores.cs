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
    public partial class FrmProveedores : Form
    {
        ClsNegProveedores ObjNegEmpleados = new ClsNegProveedores();
        private bool editar = false;
        private string id= null;
        public FrmProveedores()
        {
            InitializeComponent();
            mostrar();
        }
        private void mostrar()
        {
            ClsNegProveedores objNegProveedores = new ClsNegProveedores();
            dgvProveedores.DataSource = objNegProveedores.Cargar(@"Server=DESKTOP-PKU45LG\SQLEXPRESS;DataBase=GREENDESERT;Integrated Security=true");


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                ClsModProveedor ObjModProveedor = new ClsModProveedor();

                var idprov = Convert.ToInt32(txtID.Text);


                ObjModProveedor.id_proveedor = idprov;
                ObjModProveedor.codigo_prov = txtcodigo_prov.Text;
                ObjModProveedor.nombre = txtNombre.Text;
                ObjModProveedor.direccion = txtDireccion.Text;
                
                ObjNegEmpleados.agregar(@"Server=DESKTOP-PKU45LG\SQLEXPRESS;DataBase=GREENDESERT;Integrated Security=true", ObjModProveedor, out ClsModResultado objModResultado);

                mostrar();
                limpiar();
            }
            if (editar == true)
            {
                ClsModProveedor ObjModProveedor = new ClsModProveedor();

                var idprov = Convert.ToInt32(txtID.Text);


                ObjModProveedor.id_proveedor = idprov;
                ObjModProveedor.codigo_prov = txtcodigo_prov.Text;
                ObjModProveedor.nombre = txtNombre.Text;
                ObjModProveedor.direccion = txtDireccion.Text;
                ObjNegEmpleados.Actualizar(@"Server=DESKTOP-PKU45LG\SQLEXPRESS;DataBase=GREENDESERT;Integrated Security=true", ObjModProveedor, out ClsModResultado objModResultado);
                mostrar();

                editar = false;
            }
        }

        public void limpiar()
        {
            
            txtNombre.Clear();
            txtcodigo_prov.Clear();
            txtDireccion.Clear();
            editar = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {

                editar = true;
                txtcodigo_prov.Text = dgvProveedores.CurrentRow.Cells["codigo_prov"].Value.ToString();
                txtNombre.Text = dgvProveedores.CurrentRow.Cells["nombre"].Value.ToString();
                txtDireccion.Text = dgvProveedores.CurrentRow.Cells["direccion"].Value.ToString();
                txtID.Text = dgvProveedores.CurrentRow.Cells["id_proveedor"].Value.ToString();


            }
        }
    }
}
