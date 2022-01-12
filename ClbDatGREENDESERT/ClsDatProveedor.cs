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
    public class ClsDatProveedor

    {
        private readonly string Error = "ClsDatProveedor";


        public IEnumerable<ClsModProveedor>Cargar(string strConexion)
        {

            try
            {
                using (SqlConnection conexion = new SqlConnection(strConexion))
                {

                    return conexion.Query<ClsModProveedor>("[dbo].[SPPROVEEDOREScargar]",
                          commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex);
                throw;
            }
        }

        public ClsModProveedor agregar(string strConexion, ClsModProveedor objModProveedor, out ClsModResultado objModResultado)
        {
            objModResultado = new ClsModResultado();
            try
            {
                var lstParametros = new DynamicParameters();
                lstParametros.Add("@id_proveedor", objModProveedor.id_proveedor);
                lstParametros.Add("@codigo_prov", objModProveedor.codigo_prov);
                lstParametros.Add("@nombre", objModProveedor.nombre);
                lstParametros.Add("@direccion", objModProveedor.direccion);

                using (SqlConnection conexion = new SqlConnection(strConexion))
                {
                    objModResultado.Id = conexion.ExecuteScalar<int>("[dbo].[SPPROVEEDORESAgregar]", lstParametros, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                objModResultado.MsgError = $"{Error}-agregar, {ex.Message}";
            }

            return objModProveedor;
        }

        public ClsModProveedor Actualizar(string strConexion, ClsModProveedor objModProveedor, out ClsModResultado objModResultado)
        {
            objModResultado = new ClsModResultado();
            try
            {
                var lstParametros = new DynamicParameters();
                lstParametros.Add("@id_proveedor", objModProveedor.id_proveedor);
                lstParametros.Add("@codigo_prov", objModProveedor.codigo_prov);
                lstParametros.Add("@nombre", objModProveedor.nombre);
                lstParametros.Add("@direccion", objModProveedor.direccion);

                using (SqlConnection conexion = new SqlConnection(strConexion))
                {
                    objModResultado.Id = conexion.ExecuteScalar<int>("[dbo].[SPPROVEEDORESActualizar]", lstParametros, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                objModResultado.MsgError = $"{Error}-Actualizar, {ex.Message}";
            }

            return objModProveedor;
        }

       
    }

}
