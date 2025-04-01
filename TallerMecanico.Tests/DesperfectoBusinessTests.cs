using Moq;
using NUnit.Framework;
using TallerMecanico.Business.Desperfectos;
using TallerMecanico.DAL.Desperfecto;
using TallerMecanico.DAL.Presupuesto;
using TallerMecanico.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TallerMecanico.Tests
{
    [TestFixture]
    public class DesperfectoBusinessTests
    {
        private Mock<IDesperfectoDAL> _mockDesperfectoDAL;
        private Mock<IPresupuestoDAL> _mockPresupuestoDAL;
        private DesperfectoBusiness _desperfectoBusiness;

        [SetUp]
        public void Setup()
        {
            _mockDesperfectoDAL = new Mock<IDesperfectoDAL>();
            _mockPresupuestoDAL = new Mock<IPresupuestoDAL>();
            _desperfectoBusiness = new DesperfectoBusiness(_mockDesperfectoDAL.Object, _mockPresupuestoDAL.Object);
        }

        [Test]
        public void CargarDefectos_ShouldReturnTrue_WhenDesperfectosAreAddedSuccessfully()
        {
            // Arrange
            long idPresupuesto = 1;
            var desperfectos = new List<Desperfecto>
            {
                new Desperfecto { Id = 1, Descripcion = "Test1", ManoDeObra = 100, Tiempo = 2 },
                new Desperfecto { Id = 2, Descripcion = "Test2", ManoDeObra = 200, Tiempo = 3 }
            };

            var presupuesto = new DAL.Models.Presupuesto { Id = idPresupuesto };
            _mockPresupuestoDAL.Setup(x => x.Get(idPresupuesto)).ReturnsAsync(presupuesto);

            // Act
            var result = _desperfectoBusiness.CargarDefectos(idPresupuesto, desperfectos);

            // Assert
            Assert.That(result, Is.True);
            _mockDesperfectoDAL.Verify(x => x.Add(It.IsAny<DAL.Models.Desperfecto>()), Times.Exactly(desperfectos.Count)); // Use Times
        }

        [Test]
        public void CargarDefectos_ShouldReturnFalse_WhenExceptionIsThrown()
        {
            // Arrange
            long idPresupuesto = 1;
            var desperfectos = new List<Desperfecto>
            {
                new Desperfecto { Id = 1, Descripcion = "Test1", ManoDeObra = 100, Tiempo = 2 },
                new Desperfecto { Id = 2, Descripcion = "Test2", ManoDeObra = 200, Tiempo = 3 }
            };

            _mockPresupuestoDAL.Setup(x => x.Get(idPresupuesto)).ThrowsAsync(new System.Exception());

            // Act
            var result = _desperfectoBusiness.CargarDefectos(idPresupuesto, desperfectos);

            // Assert
            Assert.That(result, Is.False);
            _mockDesperfectoDAL.Verify(x => x.Add(It.IsAny<DAL.Models.Desperfecto>()), Times.Never); // Use Times
        }
    }
}