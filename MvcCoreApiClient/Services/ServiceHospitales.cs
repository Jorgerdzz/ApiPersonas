using MvcCoreApiClient.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MvcCoreApiClient.Services
{
    public class ServiceHospitales
    {
        private string apiUrl;
        //NECESITAMOS INDICAR EL TIPO DE DATOS QUE VAMOS A LEER
        private MediaTypeWithQualityHeaderValue header;

        public ServiceHospitales(IConfiguration configuration)
        {
            this.apiUrl = configuration.GetValue<string>("ApiUrls:ApiHospitales");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            //SE UTILIZA LA CLASE HTTPCLIENT PARA LAS PETICIONES
            using(HttpClient client = new HttpClient())
            {
                string request = "api/hospital";
                //INDICAMOS EL HOST
                client.BaseAddress = new Uri(this.apiUrl);
                //INDICAMOS LOS DATOS QUE VAMOS A CONSUMIR
                //LIMPIAMOS LAS CABECERAS POR NORMA
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                //REALIZAMOS LA PETICION Y CAPTURAMOS UNA RESPUESTA
                HttpResponseMessage response =
                    await client.GetAsync(request);
                //EN LA RESPUESTA TENEMOS LA CLAVE SI DESEAMOS PERSONALIZAR ERRORES
                if (response.IsSuccessStatusCode)
                {
                    //RECUPERAMOS CONTENIDO EN JSON
                    string json =
                        await response.Content.ReadAsStringAsync();
                    //MEDIANTE NEWTON DESERIALIZAMOS JSON A LIST
                    List<Hospital> hospitales = JsonConvert.DeserializeObject<List<Hospital>>(json);
                    return hospitales;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Hospital> FindHospitalAsync(int id)
        {
            using(HttpClient client = new HttpClient())
            {
                string request = "api/hospital/" + id;
                client.BaseAddress = new Uri(this.apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    //SI LAS PROPIEDAD DEL MODEL Y DEL JSON SE LLAMAN IGUAL
                    //NO ES NECESARIO DECORAR CON [JsonProperty] Y TAMPOCO UTILIZAR JsonConvert
                    Hospital h = await response.Content.ReadAsAsync<Hospital>();
                    return h;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
