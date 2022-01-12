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
    public class ClsDatVentas

    {
        private readonly string Error = "ClsDatVentas";


        public IEnumerable<ClsModVentas>Cargar(string strConexion)
        {

            try
            {
                using (SqlConnection conexion = new SqlConnection(strConexion))
                {

                    return conexion.Query<ClsModVentas>("[dbo].[SPVENTAScargar]",
                          commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex);
                throw;
            }
        }

        public ClsModVentas agregar(string strConexion, ClsModVentas objModVentas, out ClsModResultado objModResultado)
        {
            objModResultado = new ClsModResultado();
            try
            {
                var lstParametros = new DynamicParameters();
                lstParametros.Add("@id_producto", objModVentas.id_producto);
                lstParametros.Add("@id_empledo", objModVentas.id_empledo);
                lstParametros.Add("@no_cliente", objModVentas.no_cliente);
                lstParametros.Add("@fecha_de_despacho", objModVentas.fecha_de_despacho);

                using (SqlConnection conexion = new SqlConnection(strConexion))
                {
                    objModResultado.Id = conexion.ExecuteScalar<int>("[dbo].[SPVENTASAgregar]", lstParametros, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                objModResultado.MsgError = $"{Error}-agregar, {ex.Message}";
            }

            return objModVentas;
        }

        public ClsModVentas Actualizar(string strConexion, ClsModVentas objModVentas, out ClsModResultado objModResultado)
        {
            objModResultado = new ClsModResultado();
            try
            {
                var lstParametros = new DynamicParameters();
                lstParametros.Add("@id_venta", objModVentas.id_venta);
                lstParametros.Add("@id_producto", objModVentas.id_producto);
                lstParametros.Add("@id_empledo", objModVentas.id_empledo);
                lstParametros.Add("@no_cliente", objModVentas.no_cliente);
                lstParametros.Add("@fecha_de_despacho", objModVentas.fecha_de_despacho);

                using (SqlConnection conexion = new SqlConnection(strConexion))
                {
                    objModResultado.Id = conexion.ExecuteScalar<int>("[dbo].[SPVENTASActualizar]", lstParametros, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                objModResultado.MsgError = $"{Error}-Actualizar, {ex.Message}";
            }

            return objModVentas;
        }

       
    }

}
