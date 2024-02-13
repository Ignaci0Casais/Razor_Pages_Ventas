using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ventas.Model;

namespace Ventas.Pages
{
    public class NuevoModel : PageModel
    {
        public IListadoVentas Listado { get; set; }

        public NuevoModel(IListadoVentas listado)
        {
            Listado = listado;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            // En Request.Form tenemos todos los campos.
            // Request.Form[valorDelAtributoName]
            /*
             * Para DateTime
            string textoFecha = Request.Form["Fecha"]; // 2022-11-08

            string[] fechaPartes = textoFecha.Split('-'); // { "2022", "11", "08" }

            int dia = Convert.ToInt32(fechaPartes[2]);
            int mes = Convert.ToInt32(fechaPartes[1]);
            int anio = Convert.ToInt32(fechaPartes[0]);
            */
            // 1) Crear el modelo
            Listado.Crear(new Venta()
            {
                Id = Convert.ToInt32(Request.Form["Id"]),
                Cantidad = Convert.ToInt32(Request.Form["Cantidad"]),
                Descripcion = Request.Form["Descripcion"],
                Fecha = Request.Form["Fecha"], // Fecha es string? | Con DateTime: Fecha = new DateOnly(anio, mes, dia)
                Nombre = Request.Form["Nombre"],
                Precio = Convert.ToDouble(Request.Form["Precio"]),
                Vendedor = Request.Form["Vendedor"]
            });

            // 2) Redirigir al Index
            // Response.Redirect("loMismoQuePodriasEnElHrefDelA");
            // Redirigir a Inicio => Response.Redirect("/");
            Response.Redirect("/");
        }
    }
}
