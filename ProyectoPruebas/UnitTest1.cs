using BrowserTravel.Controllers;
using BrowserTravel.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace ProyectoPruebas
{
    public class Tests
    {
        private readonly BdtravelContext bdtravelContext;

        public Tests(BdtravelContext bdtravelContext)
        {
            this.bdtravelContext = bdtravelContext;
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TestLibroIndex()
        {
            var obj = new LibrosController(bdtravelContext);

            var actResult = obj.Index() as IActionResult;

            Assert.That(actResult.Equals("Index"));
        }
    }
}