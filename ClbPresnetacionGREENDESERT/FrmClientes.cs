using ClbModGREENDESERT;
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

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            ClsModCliente objmodcliente = new ClsModCliente();

            objmodcliente.nombre = txtname.Text;
            objmodcliente.apellido = txtapellido.Text;
            objmodcliente.direccion = txtdireccion.Text;
            objNegCliente.agregar("Server=DESKTOP-UEPK13H\\RONETJOHN;DataBase= Practica;Integrated Security=true", objmodcliente);
        }
    }
}
