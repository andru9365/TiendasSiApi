using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace TestTiendasSiApi
{
    [TestClass]
    public class TestApi
    {
        Uri baseAddress = new Uri("https://localhost:44316/api");
        HttpClient cliente;

        public TestApi()
        {
            cliente = new HttpClient();
            cliente.BaseAddress = baseAddress;
        }


        [TestMethod]
        public void TestCrearProducto()
        {

            TiendasSiApi.Entities.TiendasSiProducto tiendasSiProducto = new TiendasSiApi.Entities.TiendasSiProducto();
            tiendasSiProducto.nombreProducto = "Prueba desarrollo";
            tiendasSiProducto.detalleProducto = "pruebas dev";
            tiendasSiProducto.idTipoProducto = 1;
            tiendasSiProducto.estadoProducto = true;

            string data = JsonConvert.SerializeObject(tiendasSiProducto);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = cliente.PostAsync(cliente.BaseAddress + "/TiendasSiProducto", stringContent).Result;

            Assert.IsTrue(responseMessage.IsSuccessStatusCode);

        }

        [TestMethod]
        public void TestCrearProductoVacio()
        {
            TiendasSiApi.Entities.TiendasSiProducto tiendasSiProducto = new TiendasSiApi.Entities.TiendasSiProducto();

            string data = JsonConvert.SerializeObject(tiendasSiProducto);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = cliente.PostAsync(cliente.BaseAddress + "/TiendasSiProducto", stringContent).Result;

            Assert.IsFalse(responseMessage.IsSuccessStatusCode);

        }

        [TestMethod]
        public void TestCrearProductoCaracteresEspeciales()
        {
            TiendasSiApi.Entities.TiendasSiProducto tiendasSiProducto = new TiendasSiApi.Entities.TiendasSiProducto();
            tiendasSiProducto.nombreProducto = "duiogaw'*''";
            tiendasSiProducto.detalleProducto = "'select * from [TiendasSiProducto]'";
            tiendasSiProducto.idTipoProducto = 1;
            tiendasSiProducto.estadoProducto = true;
            string data = JsonConvert.SerializeObject(tiendasSiProducto);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = cliente.PostAsync(cliente.BaseAddress + "/TiendasSiProducto", stringContent).Result;

            Assert.IsTrue(responseMessage.IsSuccessStatusCode);

        }

        [TestMethod]
        public void TestCrearProductoCampoRequerido1()
        {
            TiendasSiApi.Entities.TiendasSiProducto tiendasSiProducto = new TiendasSiApi.Entities.TiendasSiProducto();
           
            tiendasSiProducto.detalleProducto = "prueba requerido";
            tiendasSiProducto.idTipoProducto = 1;
            tiendasSiProducto.estadoProducto = true;
            string data = JsonConvert.SerializeObject(tiendasSiProducto);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = cliente.PostAsync(cliente.BaseAddress + "/TiendasSiProducto", stringContent).Result;

            Assert.IsFalse(responseMessage.IsSuccessStatusCode);

        }
        [TestMethod]
        public void TestCrearProductoCampoRequerido2()
        {
            TiendasSiApi.Entities.TiendasSiProducto tiendasSiProducto = new TiendasSiApi.Entities.TiendasSiProducto();

           
            tiendasSiProducto.idTipoProducto = 1;
            tiendasSiProducto.estadoProducto = true;
            string data = JsonConvert.SerializeObject(tiendasSiProducto);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = cliente.PostAsync(cliente.BaseAddress + "/TiendasSiProducto", stringContent).Result;

            Assert.IsFalse(responseMessage.IsSuccessStatusCode);

        }

        [TestMethod]
        public void TestCrearProductoCampoRequerido3()
        {
            TiendasSiApi.Entities.TiendasSiProducto tiendasSiProducto = new TiendasSiApi.Entities.TiendasSiProducto();

            tiendasSiProducto.estadoProducto = true;
            string data = JsonConvert.SerializeObject(tiendasSiProducto);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = cliente.PostAsync(cliente.BaseAddress + "/TiendasSiProducto", stringContent).Result;

            Assert.IsFalse(responseMessage.IsSuccessStatusCode);

        }

        [TestMethod]
        public void TestCrearProductoCampoRequerido4()
        {
            TiendasSiApi.Entities.TiendasSiProducto tiendasSiProducto = new TiendasSiApi.Entities.TiendasSiProducto();

            string data = JsonConvert.SerializeObject(tiendasSiProducto);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = cliente.PostAsync(cliente.BaseAddress + "/TiendasSiProducto", stringContent).Result;

            Assert.IsFalse(responseMessage.IsSuccessStatusCode);

        }

        [TestMethod]
        public void TestGetProducto()
        {
            HttpResponseMessage responseMessage = cliente.GetAsync(cliente.BaseAddress + "/TiendasSiProducto").Result;    
            Assert.IsTrue(responseMessage.IsSuccessStatusCode);

        }

        [TestMethod]
        public void TestGetProductoByTipoProductoMovie()
        {
            HttpResponseMessage responseMessage = cliente.GetAsync(cliente.BaseAddress + "/TiendasSiProducto/GetTiendasSiProductoByTipo/1").Result;  
            Assert.IsTrue(responseMessage.IsSuccessStatusCode);

        }

        [TestMethod]
        public void TestGetProductoByTipoProductoMovieNoExist()
        {
            HttpResponseMessage responseMessage = cliente.GetAsync(cliente.BaseAddress + "/TiendasSiProducto/GetTiendasSiProductoByTipo/ioyeqwioehl").Result;
            Assert.IsFalse(responseMessage.IsSuccessStatusCode);

        }
        [TestMethod]
        public void TestGetProductoByTipoProductoMovieNoProd()
        {
            HttpResponseMessage responseMessage = cliente.GetAsync(cliente.BaseAddress + "/TiendasSiProducto/GetTiendasSiProductoByTipo/").Result;
            Assert.IsFalse(responseMessage.IsSuccessStatusCode);

        }
    }
}
