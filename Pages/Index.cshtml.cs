using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ventas.Model;

namespace Ventas.Pages
{
    public class IndexModel : PageModel
    {
        public IListadoVentas Listado { get; set; }
        public IndexModel(IListadoVentas listado)
        {
            Listado = listado;
        }
        public void OnGet()
        {
        }
    }
}
