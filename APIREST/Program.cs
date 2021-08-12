using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;



namespace APIREST
{
    
    class Program
    {
        
        private static async Task ObtenerToken()
        {
            //Por favor poner un interruptor en la linea 38 para mostrar el resultado 
            try
            {

                var urlToken = "https://api.apoloservice.com/api/Sesion/RevisaSesion";
                var cliente = new HttpClient();

                Persona post = new Persona()
                {
                    Correo = "prueba0704758@osiris.com",
                    Password = "123456"
                };

                var data = JsonSerializer.Serialize<Persona>(post);
                HttpContent contenido =
                    new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                var httpResponse = await cliente.PostAsync(urlToken, contenido);
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();

                    var postResult = JsonSerializer.Deserialize<Persona>(result);
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        private static async Task ObtenerKeyword()
        {
            //Por favor poner un interruptor en la linea 77 para mostrar el resultado 
            try
            {
                var urlKeyword = "https://api.apoloservice.com/api/Alertas/NewListadoKeywords";
                var cliente = new HttpClient();

                Persona post = new Persona()
                {
                    Id= 0,
                    PersonaID = 5611,
                    Contacto= "Osiris Prueba nuevo home 2021",
                    Correo= "prueba0704758@osiris.com",
                    Password = "123456",
                    Token= "rzDoTZiZ9-2gXNfr27Vamlu6G3UP20GTExY_YkoehnCFE67E-yZF4mr4HFSaei7tvWAjHntLOIkoWg4ltKQ2CXa0PYYRSWCetiDZCKBIkOAIpok79CtgDgfqcGwySIGVvzL5UxWJ_LA__jwSKzqYtg..",
                    TipoSesion= 1,
                    TokenSubscription = "null"
                };

                var data = JsonSerializer.Serialize<Persona>(post);
                HttpContent contenido =
                    new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                var httpResponse = await cliente.PostAsync(urlKeyword, contenido);
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();

                    var postResult = JsonSerializer.Deserialize<Persona>(result);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        static async Task Main(string[] args)
        {

            int opcion;
            Console.WriteLine("Que deseas?");
            Console.WriteLine("1- Obtener Token / " +
                "2- Obtener Keyword / " +
                "3- Agregar Keyword / ");

            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    await ObtenerToken();
                    break;
                case 2:
                    await ObtenerKeyword();
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
    }
}
