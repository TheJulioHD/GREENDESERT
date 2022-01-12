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
    public class ClsDatProducto

    {
        private readonly string Error = "ClsDatCliente";


        public IEnumerable<ClsModProducto> Cargar(string strConexion)
        {

            try
            {
                using (SqlConnection conexion = new SqlConnection(strConexion))
                {

                    return conexion.Query<ClsModProducto>("[dbo].[SPPRODUCTOcargar]",
                          commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex);
                throw;
            }
        }

        public ClsModProducto agregar(string strConexion, ClsModProducto objModProducto, out ClsModResultado objModResultado)
        {
            objModResultado = new ClsModResultado();
            try
            {
                var lstParametros = new DynamicParameters();
                lstParametros.Add("@codigo", objModProducto.codigo);
                lstParametros.Add("@nombre", objModProducto.nombre);
                lstParametros.Add("@marca", objModProducto.marca);
                lstParametros.Add("@id_Provedor", objModProducto.id_Provedor);

                using (SqlConnection conexion = new SqlConnection(strConexion))
                {
                    objModResultado.Id = conexion.ExecuteScalar<int>("[dbo].[SPPRODUCTOAgregar]", lstParametros, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                objModResultado.MsgError = $"{Error}-agregar, {ex.Message}";
            }

            return objModProducto;
        }

        public ClsModProducto Actualizar(string strConexion, ClsModProducto objmodProducto, out ClsModResultado objModResultado)
        {
            objModResultado = new ClsModResultado();
            try
            {
                var lstParametros = new DynamicParameters();
                lstParametros.Add("@id_producto", objmodProducto.id_producto);
                lstParametros.Add("@codigo", objmodProducto.codigo);
                lstParametros.Add("@nombre", objmodProducto.nombre);
                lstParametros.Add("@marca", objmodProducto.marca);
                lstParametros.Add("@id_Provedor", objmodProducto.id_Provedor);

                using (SqlConnection conexion = new SqlConnection(strConexion))
                {
                    objModResultado.Id = conexion.ExecuteScalar<int>("[dbo].[SPPRODUCTOActualizar]", lstParametros, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                objModResultado.MsgError = $"{Error}-Actualizar, {ex.Message}";
            }

            return objmodProducto;
        }

       
    }

}
