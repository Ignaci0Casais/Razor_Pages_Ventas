using System.Collections;

namespace Ventas.Model
{
    public interface IListadoVentas
    {
        public IEnumerable<Venta> ObtenerTodos(); // 4
        public Venta? ObtenerUno(int id);
        public void Crear(Venta venta); // 4
        public void Editar(Venta venta);
        public void Borrar(Venta venta);
    }
    
    /*
    public class ListadoVentasDbContext : DbContext, IListadoVentas
    {

    }
    */

    public class ListadoVentas : IListadoVentas
    {
        private List<Venta> Datos = new List<Venta>()
        {
            new Venta()
            {
                Id = 1,
                Cantidad = 10,
                Descripcion = "Celular LG con camara",
                Fecha = "2022-08-10",
                Nombre = "Celular LG",
                Precio = 12,
                Vendedor = "Sebastian"
            }
        };

        public void Borrar(Venta venta)
        {
            Datos = Datos.Where((v) => !v.Equals(venta)).ToList();
        }

        public void Crear(Venta venta)
        {
            Datos.Add(venta);
        }

        public void Editar(Venta nueva)
        {
            Datos = Datos.Select((previa) =>
            {
                if (previa.Id == nueva.Id)
                    return nueva;
                else
                    return previa;
            }).ToList();
        }

        public IEnumerable<Venta> ObtenerTodos()
        {
            return Datos;
        }

        public Venta? ObtenerUno(int id)
        {
            return Datos.Where((venta) => venta.Id == id).First(); 
        }
    }
}
