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
    public class ClsDatCliente

    {
        private readonly string Error = "ClsDatCliente";


        public IEnumerable<ClsModCliente>Cargar(string strConexion)
        {

            try
            {
                using (SqlConnection conexion = new SqlConnection(strConexion))
                {

                    return conexion.Query<ClsModCliente>("[dbo].[SPCLIENTEcargar]",
                          commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex);
                throw;
            }
        }

        public ClsModCliente agregar(string strConexion, ClsModCliente objmodcliente, out ClsModResultado objModResultado)
        {
            objModResultado = new ClsModResultado();
            try
            {
                var lstParametros = new DynamicParameters();
                lstParametros.Add("@no_cliente", objmodcliente.no_cliente);
                lstParametros.Add("@nombre", objmodcliente.nombre);
                lstParametros.Add("@apellido", objmodcliente.apellido);
                lstParametros.Add("@direccion", objmodcliente.direccion);
                
                using (SqlConnection conexion = new SqlConnection(strConexion))
                {
                    objModResultado.Id = conexion.ExecuteScalar<int>("[dbo].[SPClientesAgregar]", lstParametros, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                objModResultado.MsgError = $"{Error}-agregar, {ex.Message}";
            }

            return objmodcliente;
        }

        public ClsModCliente Actualizar(string strConexion, ClsModCliente objmodcliente, out ClsModResultado objModResultado)
        {
            objModResultado = new ClsModResultado();
            try
            {
                var lstParametros = new DynamicParameters();
                lstParametros.Add("@no_cliente", objmodcliente.no_cliente);
                lstParametros.Add("@nombre", objmodcliente.nombre);
                lstParametros.Add("@apellido", objmodcliente.apellido);
                lstParametros.Add("@direccion", objmodcliente.direccion);

                using (SqlConnection conexion = new SqlConnection(strConexion))
                {
                    objModResultado.Id = conexion.ExecuteScalar<int>("[dbo].[SPClientesActualizar]", lstParametros, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                objModResultado.MsgError = $"{Error}-Actualizar, {ex.Message}";
            }

            return objmodcliente;
        }

       
    }

}
