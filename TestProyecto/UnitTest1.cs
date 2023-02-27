using BrowserTravel.Controllers;
using BrowserTravel.Entidades;
using Moq;

namespace TestProyecto
{
    public class Tests
    {
        private readonly Mock<BdtravelContext> bd;


        public Tests()
        {
            bd = new Mock<BdtravelContext>();
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            LibrosController librosController = new LibrosController(bd.Object);
            var libroResult = librosController.Index();

            Assert.NotNull(libroResult);           
        }
    }
}