using Newtonsoft.Json;
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
        
        public static async Task ObtenerToken()
        {
            //Por favor poner un interruptor en la linea 38 para mostrar el resultado 
            try
            {

                var urlToken = "https://api.apoloservice.com/api/Sesion/RevisaSesion";
                var urlKeyword = "https://api.apoloservice.com/api/Alertas/NewListadoKeywords";
                var cliente = new HttpClient();

                Persona post = new Persona()
                {
                    Correo = "prueba0704758@osiris.com",
                    Password = "123456"
                };
                Keyword edr = new Keyword()
                {
                    KeyString = "Edrei Prueba"
                };

                //serializacion de Objeto Persona
                var data = JsonConvert.SerializeObject(post);
                HttpContent contenido =
                    new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                //serializacion de objeto Keyword
                var datos = JsonConvert.SerializeObject(edr);
                HttpContent content =
                    new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                //respuestas HTTP
                
                var httpResponse = await cliente.PostAsync(urlToken, contenido);
                var httpResponseKeywords = await cliente.PostAsync(urlKeyword, contenido);
                var httpAgreagrKey = await cliente.PostAsync(urlKeyword, content);
                if (httpResponse.IsSuccessStatusCode)
                {
                    var resultKey = await httpResponseKeywords.Content.ReadAsStringAsync();
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    var resultAgregarKey = await httpAgreagrKey.Content.ReadAsStringAsync();
                    
                    //Desearilzacion de Post
                    var postResult = JsonConvert.DeserializeObject(result);
                    var postKey = JsonConvert.DeserializeObject(resultKey);

                    //Desearializacion de edr
                    var postAgregarKey = JsonConvert.DeserializeObject(resultAgregarKey);
                    
                    
                    //se imprime
                    Console.WriteLine(postResult.ToString());
                    Console.WriteLine();
                    Console.WriteLine("Aqui se obtiene el KeyWords");
                    Console.WriteLine(postKey.ToString());
                    Console.WriteLine();
                    Console.WriteLine("Aqui se agrega el Key");
                    Console.WriteLine(postAgregarKey.ToString());

                }
                Console.WriteLine("termina aqui");
                


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
                Persona token = new Persona()
                {
                    Id = 0,
                    PersonaID = 5611,
                    Contacto = "Osiris Prueba nuevo home 2021",
                    Correo = "prueba0704758@osiris.com",
                    Password = null,
                    Token = "rzDoTZiZ9-2gXNfr27Vamlu6G3UP20GTExY_YkoehnCFE67E-yZF4mr4HFSaei7tvWAjHntLOIkoWg4ltKQ2CXa0PYYRSWCetiDZCKBIkOAIpok79CtgDgfqcGwySIGVvzL5UxWJ_LA__jwSKzqYtg.."
                };
                var data = JsonConvert.SerializeObject(token);
                HttpContent contenido =
                    new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                var httpResponse = await cliente.PostAsync(urlKeyword, contenido);
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    var postResult = JsonConvert.DeserializeObject(result);
                    Console.WriteLine(postResult.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        static async Task Main(string[] args)
        {

            await ObtenerToken();
        }
    }
}
