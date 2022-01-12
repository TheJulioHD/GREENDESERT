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
    public partial class FrmEmpleados : Form
    {
        ClsNegEmpleados ObjNegEmpleados = new ClsNegEmpleados();
        private bool editar = false;
        public FrmEmpleados()
        {
            InitializeComponent();
            mostrar();
        }

        private void mostrar()
        {
            ClsNegEmpleados ObjNegEmpleados = new ClsNegEmpleados();
            dgvEmpleados.DataSource = ObjNegEmpleados.Cargar(@"Server=DESKTOP-PKU45LG\SQLEXPRESS;DataBase=GREENDESERT;Integrated Security=true");


        }

        

       
        public void limpiar()
        {
            txtCelula.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCargo.Clear();
            editar = false;
        }

        

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (editar == false)
            {
                ClsModEmpleado ObjModEmpleado = new ClsModEmpleado();
                var id = Convert.ToInt32(txtiD.Text);


                ObjModEmpleado.id_empledo = id;
                ObjModEmpleado.cedula_indentidad = txtCelula.Text;
                ObjModEmpleado.nombre = txtNombre.Text;
                ObjModEmpleado.apellido = txtApellido.Text;
                ObjModEmpleado.cargo = txtCargo.Text;
                ObjNegEmpleados.agregar(@"Server=DESKTOP-PKU45LG\SQLEXPRESS;DataBase=GREENDESERT;Integrated Security=true", ObjModEmpleado, out ClsModResultado objModResultado);

                mostrar();
                limpiar();
            }
            if (editar == true)
            {
                ClsModEmpleado ObjModEmpleado = new ClsModEmpleado();

                var id = Convert.ToInt32(txtiD.Text);

                ObjModEmpleado.id_empledo = id;
                ObjModEmpleado.cedula_indentidad = txtCelula.Text;
                ObjModEmpleado.nombre = txtNombre.Text;
                ObjModEmpleado.apellido = txtApellido.Text;
                ObjModEmpleado.cargo = txtCargo.Text;
                ObjNegEmpleados.Actualizar(@"Server=DESKTOP-PKU45LG\SQLEXPRESS;DataBase=GREENDESERT;Integrated Security=true", ObjModEmpleado, out ClsModResultado objModResultado);
                mostrar();

                editar = false;
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                editar = true;
                txtiD.Text = dgvEmpleados.CurrentRow.Cells["id_empledo"].Value.ToString();
                txtCelula.Text = dgvEmpleados.CurrentRow.Cells["cedula_indentidad"].Value.ToString();
                txtNombre.Text = dgvEmpleados.CurrentRow.Cells["nombre"].Value.ToString();
                txtApellido.Text = dgvEmpleados.CurrentRow.Cells["apellido"].Value.ToString();
                txtCargo.Text = dgvEmpleados.CurrentRow.Cells["cargo"].Value.ToString();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
