using Dapper;
using PruebaTecnica_GrupoLucky_AlexanderCruz.Models;
using System.Linq;

namespace PruebaTecnica_GrupoLucky_AlexanderCruz.Data
{
    public class ProductoImplement : Iproducto

    {
        private readonly Conexion _conexion;

        public ProductoImplement(Conexion conexion)
        {
            _conexion = conexion;
        }

        public void ActualizarProducto(Producto producto)
        {
            using (var conexion=_conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", producto.Id, System.Data.DbType.Int32);
                parametros.Add("@Nombre", producto.Nombre, System.Data.DbType.String);
                parametros.Add("@Precio", producto.Precio, System.Data.DbType.Decimal);
                conexion.Execute("ActualizarProducto", parametros, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void EliminarProducto(int id)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", id, System.Data.DbType.Int32);
                conexion.Execute("EliminarProducto", parametros, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void InsertarProducto(Producto producto)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
             
                parametros.Add("@Nombre", producto.Nombre, System.Data.DbType.String);
                parametros.Add("@Precio", producto.Precio, System.Data.DbType.Decimal);
                conexion.Execute("InsertarProducto", parametros, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Producto ObtenerProductoPorId(int id)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", id, System.Data.DbType.Int32);

                return conexion.QueryFirstOrDefault<Producto>("ObtenerProductoPorId", parametros, commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public IEnumerable<Producto> ObtenerProductos()
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
 
                return conexion.Query<Producto>("ObtenerProductos",commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
        }
    }
}
