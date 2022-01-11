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
    public class ClsNegCliente
    {
        public IEnumerable<ClsModCliente> Cargar(string strConexion)
        {
            ClsDatCliente obdatCliente = new ClsDatCliente();
            return obdatCliente.Cargar(strConexion);
        }

        public ClsModCliente agregar(string strConexion, ClsModCliente objmodcliente, out ClsModResultado objModResultado)
        {
            ClsDatCliente obdatCliente = new ClsDatCliente();
            return obdatCliente.agregar(strConexion, objmodcliente, out objModResultado);
        }

        public ClsModCliente Actualizar(string strConexion, ClsModCliente objmodcliente, out ClsModResultado objModResultado)
        {
            ClsDatCliente obdatCliente = new ClsDatCliente();
            return obdatCliente.Actualizar(strConexion, objmodcliente, out objModResultado);
        }
    }
}
