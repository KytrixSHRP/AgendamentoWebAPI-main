using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Controllers;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AgendamentoWebAPI.Tests.ControllerTests
{
    public class TipoConsultaControllerTest
    {
        [Fact]
        public async void BuscarTipoConsultaOk()
        {
            // Arrange
            
            var loggerMock = new Mock<ILogger<TipoConsultaController>>();
            var tipoConsultaServiceMock = new Mock<ITipoConsultaService>();
            int idMedicoMock = 1;
            var tipoConsultaMock = new List<TipoConsulta>() {
                new TipoConsulta(){ Id = 1, Descricao = "Telemedicina"}
            };
            tipoConsultaServiceMock.Setup(s => s.EncontrarTiposConsulta(idMedicoMock)).ReturnsAsync(tipoConsultaMock);
            var controller = new TipoConsultaController(loggerMock.Object, tipoConsultaServiceMock.Object);

            // Act

            var response = await controller.GetTipoConsulta(idMedicoMock);

            // Assert

            Assert.IsType<OkObjectResult>(response);

        }

        [Fact]
        public async void BuscarTipoConsultaBadRequest()
        {
            // Arrange
            
            var loggerMock = new Mock<ILogger<TipoConsultaController>>();
            var tipoConsultaServiceMock = new Mock<ITipoConsultaService>();
            int idMedicoMock = 1;
            var tipoConsultaMock = new List<TipoConsulta>();
            tipoConsultaServiceMock.Setup(s => s.EncontrarTiposConsulta(idMedicoMock)).ReturnsAsync(tipoConsultaMock);
            var controller = new TipoConsultaController(loggerMock.Object, tipoConsultaServiceMock.Object);

            // Act

            var response = await controller.GetTipoConsulta(idMedicoMock);

            // Assert

            Assert.IsType<BadRequestObjectResult>(response);

        }
    }
}