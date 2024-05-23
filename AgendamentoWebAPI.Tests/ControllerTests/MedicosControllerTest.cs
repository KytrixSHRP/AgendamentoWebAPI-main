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
    public class MedicosControllerTest
    {
        [Fact]
        public async void BuscarMedicosSemFiltroOk()
        {
            // Arrange
            
            var loggerMock = new Mock<ILogger<MedicosController>>();
            var medicoServiceMock = new Mock<IMedicoService>();
            int idEspecialidadeMock = 0;
            int idMedicoMock = 3;
            List<Medico> medicosMock = new List<Medico>(){
                new Medico() {Id = 1, Nome = "Medico1", CRM = "11111111", CRP = "1111111"},
                new Medico() {Id = 2, Nome = "Medico2", CRM = "22222222", CRP = "2222222"}
            };
            medicoServiceMock.Setup(s => s.EncontrarMedicos(idMedicoMock)).ReturnsAsync(medicosMock);
            var controller = new MedicosController(loggerMock.Object, medicoServiceMock.Object);
            
            // Act

            var result = await controller.GetMedicos(idEspecialidadeMock, idMedicoMock);

            // Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void BuscarMedicosComFiltroOK()
        {
            // Arrange
            
            var loggerMock = new Mock<ILogger<MedicosController>>();
            var medicoServiceMock = new Mock<IMedicoService>();
            int idEspecialidadeMock = 1;
            int idMedicoMock = 3;
            List<Medico> medicosMock = new List<Medico>(){
                new Medico() {Id = 1, Nome = "Medico1", CRM = "11111111", CRP = "1111111"},
                new Medico() {Id = 2, Nome = "Medico2", CRM = "22222222", CRP = "2222222"}
            };
            medicoServiceMock.Setup(s => s.EncontrarMedicosPorEspecialidade(idEspecialidadeMock, idMedicoMock)).ReturnsAsync(medicosMock);
            var controller = new MedicosController(loggerMock.Object, medicoServiceMock.Object);
            
            // Act

            var result = await controller.GetMedicos(idEspecialidadeMock, idMedicoMock);

            // Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void BuscarMedicosSemFiltroNoContent()
        {
            // Arrange
            
            var loggerMock = new Mock<ILogger<MedicosController>>();
            var medicoServiceMock = new Mock<IMedicoService>();
            int idEspecialidadeMock = 0;
            int idMedicoMock = 3;
            List<Medico> medicosMock = new List<Medico>();
            medicoServiceMock.Setup(s => s.EncontrarMedicos(idMedicoMock)).ReturnsAsync(medicosMock);
            var controller = new MedicosController(loggerMock.Object, medicoServiceMock.Object);
            
            // Act

            var result = await controller.GetMedicos(idEspecialidadeMock, idMedicoMock);

            // Assert

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void BuscarMedicosComFiltroNoContent()
        {
            // Arrange
            
            var loggerMock = new Mock<ILogger<MedicosController>>();
            var medicoServiceMock = new Mock<IMedicoService>();
            int idEspecialidadeMock = 1;
            int idMedicoMock = 3;
            List<Medico> medicosMock = new List<Medico>();
            medicoServiceMock.Setup(s => s.EncontrarMedicosPorEspecialidade(idEspecialidadeMock, idMedicoMock)).ReturnsAsync(medicosMock);
            var controller = new MedicosController(loggerMock.Object, medicoServiceMock.Object);
            
            // Act

            var result = await controller.GetMedicos(idEspecialidadeMock, idMedicoMock);

            // Assert

            Assert.IsType<NoContentResult>(result);
        }
    }
}