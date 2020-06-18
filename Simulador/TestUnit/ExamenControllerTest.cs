using Moq;
using NUnit.Framework;
using SimuladorExamenUPN.Controllers;
using SimuladorExamenUPN.Models;
using SimuladorExamenUPN.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Simulador.TestUnit
{
    [TestFixture]
    class ExamenControllerTest
    {
        [Test]
        public void TestNOtNullCrearGet() {
            var mocky = new Mock<IExamenService>();
            mocky.Setup(a => a.GetTemas()).Returns(new List<Tema>());
            var controller = new ExamenController(mocky.Object);
            var view = (ViewResult)controller.Crear();
            Assert.IsNotNull(view.Model);
            Assert.IsInstanceOf<Examen>(view.Model);
            Assert.IsNotNull(view.ViewBag.Temas);
            Assert.IsInstanceOf<List<Tema>>(view.ViewBag.Temas);
        }
        public void TestNOtNullCrearPOST() {
            var mocky = new Mock<IExamenService>();
            mocky.Setup(a => a.GetTemas()).Returns(new List<Tema>());
            mocky.Setup(a => a.AddExamenPregunta(new ExamenPregunta()));
            mocky.Setup(a => a.AddExamenPregunta(new ExamenPregunta()));
            var controller = new ExamenController(mocky.Object);

        }
    }
}
