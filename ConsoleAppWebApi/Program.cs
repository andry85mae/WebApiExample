using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleAppWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:50538/";

            GetValue(baseAddress).Wait();

            GetValueCustom(baseAddress).Wait();

            GetValueContrainCustom(baseAddress).Wait();

            GetValueOptionCustom(baseAddress).Wait();

            Phone p = new Phone() { Name = "Test", Description = string.Empty, Colour = "Red", Price = 100, Quantity = 10, published = true, Images = null };

            PostPhone(p, baseAddress).Wait();

            p.Price = 40;

            PostAndCheckPhone(p, false, baseAddress).Wait();

            GetAllPhone(baseAddress).Wait();
        }

        public static async Task GetValue(string baseAddress)
        {
            using (HttpClient cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseAddress);

                Console.WriteLine("Web Api With Default Routing");
                HttpResponseMessage respons = await cl.GetAsync("api/Sample/GetSampleValue");
                if (respons.StatusCode == HttpStatusCode.OK)
                {
                    string value = await respons.Content.ReadAsStringAsync();
                    Console.WriteLine("Response : " + value);
                }
                else
                {
                    Console.WriteLine("Errore");
                }

            }

            Console.ReadLine();
        }


        public static async Task GetValueCustom(string baseAddress)
        {
            using (HttpClient cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseAddress);

                Console.WriteLine("Web Api With Attribute Routing");
                HttpResponseMessage respons = await cl.GetAsync("api/attribute/custom");
                if (respons.StatusCode == HttpStatusCode.OK)
                {
                    string value = await respons.Content.ReadAsStringAsync();
                    Console.WriteLine("Response : " + value);
                }
                else
                {
                    Console.WriteLine("Errore");
                }

            }

            Console.ReadLine();
        }


        public static async Task GetValueContrainCustom(string baseAddress)
        {
            using (HttpClient cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseAddress);
                Console.WriteLine("Web Api With Contrain");
                HttpResponseMessage respons = await cl.GetAsync("api/attribute/value/6");
                if (respons.StatusCode == HttpStatusCode.OK)
                {
                    string value = await respons.Content.ReadAsStringAsync();
                    Console.WriteLine("Response : " + value);
                }
                else
                {
                    Console.WriteLine("Errore");
                }

            }

            Console.ReadLine();
        }


        public static async Task GetValueOptionCustom(string baseAddress)
        {
            using (HttpClient cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseAddress);
                Console.WriteLine("Web Api With Option");
                HttpResponseMessage respons = await cl.GetAsync("api/attribute/optional");
                if (respons.StatusCode == HttpStatusCode.OK)
                {
                    string value = await respons.Content.ReadAsStringAsync();
                    Console.WriteLine("Response : " + value);
                }
                else
                {
                    Console.WriteLine("Errore");
                }

            }

            Console.ReadLine();
        }


        public static async Task PostPhone(Phone p, string baseAddress)
        {
            using (HttpClient cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseAddress);
                cl.DefaultRequestHeaders.Accept.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                Console.WriteLine("Web Api Post");

                HttpResponseMessage response = await cl.PostAsync("api/attribute/create", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("OK!!!");
                }
                else
                {
                    Console.WriteLine("Errore");
                }

                Console.ReadLine();
            }

        }


        public static async Task PostAndCheckPhone(Phone p, bool replace, string baseAddress)
        {
            using (HttpClient cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseAddress);
                cl.DefaultRequestHeaders.Accept.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                Console.WriteLine("Web Api Post and Check");

                HttpResponseMessage response = await cl.PostAsync("api/attribute/createandcheck?replace=" + replace, content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("OK!!!");
                }
                else
                {
                    Console.WriteLine("Errore");
                }

                Console.ReadLine();
            }

        }

        public static async Task GetAllPhone(string baseAddress) {

            using (HttpClient cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseAddress);
                Console.WriteLine("Web Api List");
                HttpResponseMessage respons = await cl.GetAsync("api/attribute/getallphone");
                if (respons.StatusCode == HttpStatusCode.OK)
                {
                    string response = await respons.Content.ReadAsStringAsync();
                    List<Phone> list = JsonConvert.DeserializeObject<List<Phone>>(response);
                }
                else
                {
                    Console.WriteLine("Errore");
                }

            }
        }
    }
}
