using ClbDatGREENDESERT;
using ClbModGREENDESERT;
using ClbModGreenDesertv2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClbNegGREENDESERT
{
    public class ClsNegProveedores
    {

        public IEnumerable<ClsModProveedor> Cargar(string strConexion)
        {
            ClsDatProveedor obdatProveedor = new ClsDatProveedor();
            return obdatProveedor.Cargar(strConexion);
        }

        public ClsModProveedor agregar(string strConexion, ClsModProveedor objModProveedor, out ClsModResultado objModResultado)
        {
            ClsDatProveedor obdatProveedor = new ClsDatProveedor();
            return obdatProveedor.agregar(strConexion, objModProveedor, out objModResultado);
        }

        public ClsModProveedor Actualizar(string strConexion, ClsModProveedor objModProveedor, out ClsModResultado objModResultado)
        {
            ClsDatProveedor obdatProveedor = new ClsDatProveedor();
            return obdatProveedor.Actualizar(strConexion, objModProveedor, out objModResultado);
        }
    }
}
