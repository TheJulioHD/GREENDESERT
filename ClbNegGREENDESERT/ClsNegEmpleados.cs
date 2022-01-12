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
    public class ClsNegEmpleados
    {
        public IEnumerable<ClsModEmpleado> Cargar(string strConexion)
        {
            ClsDatEmpleado ObjDatEmpleado = new ClsDatEmpleado();
            return ObjDatEmpleado.Cargar(strConexion);
        }

        public ClsModEmpleado agregar(string strConexion, ClsModEmpleado objmodEmpleado, out ClsModResultado objModResultado)
        {
            ClsDatEmpleado ObjDatEmpleado = new ClsDatEmpleado();
            return ObjDatEmpleado.agregar(strConexion, objmodEmpleado, out objModResultado);
        }

        public ClsModEmpleado Actualizar(string strConexion, ClsModEmpleado objmodEmpleado, out ClsModResultado objModResultado)
        {
            ClsDatEmpleado ObjDatEmpleado = new ClsDatEmpleado();
            return ObjDatEmpleado.Actualizar(strConexion, objmodEmpleado, out objModResultado);
        }
    }
}
