using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using System.Text;

using System.Threading.Tasks;
using ClbModGREENDESERT;
using ClbModGreenDesertv2;

namespace ClbDatGREENDESERT
{
    public class ClsDatEmpleado


    {
        private readonly string Error = "ClsDatEmpleado";


        public IEnumerable<ClsModEmpleado>Cargar(string strConexion)
        {

            try
            {
                using (SqlConnection conexion = new SqlConnection(strConexion))
                {

                    return conexion.Query<ClsModEmpleado>("[dbo].[SPEMPLEADOScargar]",
                          commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex);
                throw;
            }
        }

        public ClsModEmpleado agregar(string strConexion, ClsModEmpleado objmodEmpleado, out ClsModResultado objModResultado)
        {
            objModResultado = new ClsModResultado();
            try
            {
                var lstParametros = new DynamicParameters();
                lstParametros.Add("@id_empledo", objmodEmpleado.id_empledo);
                lstParametros.Add("@cedula_indentidad", objmodEmpleado.cedula_indentidad);
                lstParametros.Add("@nombre", objmodEmpleado.nombre);
                lstParametros.Add("@apellido", objmodEmpleado.apellido);
                lstParametros.Add("@cargo", objmodEmpleado.cargo);

                using (SqlConnection conexion = new SqlConnection(strConexion))
                {
                    objModResultado.Id = conexion.ExecuteScalar<int>("[dbo].[SPEMPLEADOSAgregar]", lstParametros, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                objModResultado.MsgError = $"{Error}-agregar, {ex.Message}";
            }

            return objmodEmpleado;
        }

        public ClsModEmpleado Actualizar(string strConexion, ClsModEmpleado objmodEmpleado, out ClsModResultado objModResultado)
        {
            objModResultado = new ClsModResultado();
            try
            {
                var lstParametros = new DynamicParameters();
                lstParametros.Add("@id_empledo", objmodEmpleado.id_empledo);
                lstParametros.Add("@cedula_indentidad", objmodEmpleado.cedula_indentidad);
                lstParametros.Add("@nombre", objmodEmpleado.nombre);
                lstParametros.Add("@apellido", objmodEmpleado.apellido);
                lstParametros.Add("@cargo", objmodEmpleado.cargo);
                

                using (SqlConnection conexion = new SqlConnection(strConexion))
                {
                    objModResultado.Id = conexion.ExecuteScalar<int>("[dbo].[SPEMPLEADOSAtualizar]", lstParametros, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                objModResultado.MsgError = $"{Error}-Actualizar, {ex.Message}";
            }

            return objmodEmpleado;
        }

       
    }

}
