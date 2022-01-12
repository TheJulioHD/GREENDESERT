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
    public class ClsNegVentas
    {
        public IEnumerable<ClsModVentas> Cargar(string strConexion)
        {
            ClsDatVentas obdatVentas = new ClsDatVentas();
            return obdatVentas.Cargar(strConexion);
        }

        public ClsModVentas agregar(string strConexion, ClsModVentas objModVentas, out ClsModResultado objModResultado)
        {
            ClsDatVentas obdatVentas = new ClsDatVentas();
            return obdatVentas.agregar(strConexion, objModVentas, out objModResultado);
        }

        public ClsModVentas Actualizar(string strConexion, ClsModVentas objModVentas, out ClsModResultado objModResultado)
        {
            ClsDatVentas obdatVentas = new ClsDatVentas();
            return obdatVentas.Actualizar(strConexion, objModVentas, out objModResultado);
        }
    }
}
