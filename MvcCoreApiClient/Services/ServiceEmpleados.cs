using MvcCoreApiClient.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MvcCoreApiClient.Services
{
    public class ServiceEmpleados
    {
        private string apiUrl;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceEmpleados(IConfiguration configuration)
        {
            this.apiUrl = configuration.GetValue<string>("ApiUrls:ApiEmpleados");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            using(HttpClient client = new HttpClient())
            {
                string request = "api/Empleados";
                client.BaseAddress = new Uri(this.apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    List<Empleado> empleados = await response.Content.ReadAsAsync<List<Empleado>>();
                    return empleados;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Empleado> GetEmpleadoAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/Empleados/" + id;
                client.BaseAddress = new Uri(this.apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {      
                    Empleado empleado = await response.Content.ReadAsAsync<Empleado>();
                    return empleado;
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
