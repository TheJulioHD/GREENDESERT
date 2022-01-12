using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClbModGREENDESERT
{
    public class ClsModVentas
    {
        public int id_venta { get; set; }
        public int id_producto { get; set; }
        public int id_empledo { get; set; }
        public int no_cliente { get; set; }
        public DateTime fecha_de_despacho { get; set; }

    }
}
