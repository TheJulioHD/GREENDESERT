using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using System.Text;

using System.Threading.Tasks;
using ClbModGREENDESERT;

namespace ClbDatGREENDESERT
{
    public class ClsDatCliente

    {
        

        public IEnumerable<ClsModCliente>Cargar(string strConexion, string strCliente)
        {

            try
            {
                using (SqlConnection conexion = new SqlConnection(strConexion))
                {

                    return conexion.QueryFirstOrDefault("[dbo].[spCatEmpresaCargarXalias]", new 
                    {

                        Cliente = strCliente
                    },
                          commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex);
                throw;
            }
        }

        public int agregar(string strConexion, ClsModCliente objmodcliente)
        {

            try
            {
                using (SqlConnection conexion = new SqlConnection(strConexion))
                {

                    return conexion.ExecuteScalar<int>("[dbo].[SPClientesAgregar]", new
                    {

                        no_cliente = objmodcliente.no_cliente,
                        nombre = objmodcliente.nombre,
                        apellido = objmodcliente.apellido,
                        direccion = objmodcliente.direccion
                    },
                          commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex);
                throw;
            }
        }
    }
}
