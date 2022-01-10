using ClbDatGREENDESERT;
using ClbModGREENDESERT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClbNegGREENDESERT
{
    public class ClsNegCliente
    {
        public IEnumerable<ClsModCliente> Cargar(string strConexion, string strCliente)
        {
            ClsDatCliente obdatCliente = new ClsDatCliente();
            return obdatCliente.Cargar(strConexion, strCliente);
        }

        public int agregar(string strConexion, ClsModCliente objmodcliente)
        {
            ClsDatCliente obdatCliente = new ClsDatCliente();
            return obdatCliente.agregar(strConexion, objmodcliente);
        }
    }
}
