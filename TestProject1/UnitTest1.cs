using BrowserTravel.Controllers;
using BrowserTravel.Entidades;
using BrowserTravel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestProject1
{
    public class UnitTest1
    {
        private readonly LibrosController _librosController;
        private readonly BdtravelContext bdtravelContext;

        public UnitTest1()
        {
            bdtravelContext = new BdtravelContext();
            _librosController = new LibrosController(bdtravelContext);
        }

        [Fact]
        public void Test1()
        {
            //var controller = new LibrosController(bdtravelContext);
            //var actResult = controller.Index() as ViewResult;

            //Assert.IsType<ViewResult>(actResult);
        }
        [Fact]
        public void Listado()
        {
            //var controller = new LibrosController(bdtravelContext);
            //var actResult = _librosController.Index() as ViewResult;




            //var tt = Assert.IsType<ViewResult>(actResult);
            //Assert.IsType<ViewResult>(tt.ViewName);
            //Assert.Equal("Index", actResult?.ViewName);
            //var value = Assert.IsType<LibroViewModel>(tt.Model);
            //Assert.Equal(LibroViewModel, value);
        }
    }
}