using System.Net.NetworkInformation;
using PortalFerreteria.Shared.Models;
using PortalFerreteria.Shared.Services;
using Newtonsoft.Json;
using PortalFerreteria.Shared.Models.Nmodels;
using Syncfusion.Blazor.DropDowns;

namespace PortalFerreteria.Pages
{

    public partial class Productos
    {
        string? Mensaje;
        string? ComboValOpciones;
        public MainServices? service;

        string url = "api/v1/GetProductos/ObtenerProductos";
        public int IdProducto { get; set; }
        public int ActivoProducto { get; set; }

        public List<OpcionesNmodels> listaOpciones = new List<OpcionesNmodels>();
        protected override async Task OnInitializedAsync()
        {
            OpcionesNmodels op1 = new OpcionesNmodels { IdOpcion = 0, NombreOpcion = "Todos los Productos"};
            listaOpciones.Add(op1);
            OpcionesNmodels op2 = new OpcionesNmodels { IdOpcion = 0, NombreOpcion = "Desactivados" };
            listaOpciones.Add(op2);
            OpcionesNmodels op3 = new OpcionesNmodels { IdOpcion = 1, NombreOpcion = "Activados" };
            listaOpciones.Add(op3);
            OpcionesNmodels op4 = new OpcionesNmodels { IdOpcion = -1, NombreOpcion = "Código de Producto" };
            listaOpciones.Add(op4);
            OpcionesNmodels op5 = new OpcionesNmodels { IdOpcion = 2, NombreOpcion = "Todos los Estados" };
            listaOpciones.Add(op5);

            //await CargarGrillaProdutos();
            await Task.Delay(1);
            StateHasChanged();
        }

        private async Task CargarGrillaProdutos()
        {
            service = new MainServices();
            var respuesta = await service.ConectionService.HttpClientInstance.GetAsync($"{url}/{IdProducto}/{ActivoProducto}");
            if (respuesta != null)
            {
                var lista = JsonConvert.DeserializeObject<List<ProductosMod>>(await respuesta.Content.ReadAsStringAsync());
            }
            
            await Task.Delay(1);
        }

        private async Task onChangeComboOpciones(ChangeEventArgs<string, OpcionesNmodels> opciones)
        {
            try
            {
                IdProducto = opciones.ItemData.IdOpcion;
                StateHasChanged();
            }
            catch (Exception ex)
            {
                await Task.Delay(1);
                Mensaje = ex.Message;
            }
        }

    }
}
