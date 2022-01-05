using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using System.Text;
using System.Threading.Tasks;

namespace ClbDatGREENDESERT
{
    public class ClsDatCliente: Class1

    {
        SqlCommand comando = new SqlCommand();

        public static void Cargar()
        {
            int[] array = new int[5];

            try
            {
                using (SqlConnection conexion = new SqlConnection(base.AbrirConexion()))
                {

                    array = conexion.QueryFirstOrDefault("[dbo].[spCatEmpresaCargarXalias]",
                          commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
