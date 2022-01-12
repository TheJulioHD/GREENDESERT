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
    public class ClsNegProductos
    {
        public IEnumerable<ClsModProducto> Cargar(string strConexion)
        {
            ClsDatProducto ObjDatProducto = new ClsDatProducto();
            return ObjDatProducto.Cargar(strConexion);
        }

        public ClsModProducto agregar(string strConexion, ClsModProducto objModProducto, out ClsModResultado objModResultado)
        {
            ClsDatProducto ObjDatProducto = new ClsDatProducto();
            return ObjDatProducto.agregar(strConexion, objModProducto, out objModResultado);
        }

        public ClsModProducto Actualizar(string strConexion, ClsModProducto objmodProducto, out ClsModResultado objModResultado)
        {
            ClsDatProducto ObjDatProducto = new ClsDatProducto();
            return ObjDatProducto.Actualizar(strConexion, objmodProducto, out objModResultado);
        }
    }
}
