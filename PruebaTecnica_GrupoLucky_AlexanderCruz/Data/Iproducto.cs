using PruebaTecnica_GrupoLucky_AlexanderCruz.Models;

namespace PruebaTecnica_GrupoLucky_AlexanderCruz.Data
{
    public interface Iproducto
    {
        IEnumerable<Producto> ObtenerProductos();

        Producto ObtenerProductoPorId(int id);

        void InsertarProducto(Producto producto);

        void ActualizarProducto(Producto producto);

        void EliminarProducto(int id);
    }
}
