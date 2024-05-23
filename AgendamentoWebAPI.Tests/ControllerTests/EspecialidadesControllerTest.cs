using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Services;
using MedicoEspecialidadeWebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AgendamentoWebAPI.Tests.ControllerTests
{
    public class EspecialidadesControllerTest
    {
        [Fact]
        public async void BuscarEspecialidadesSemFiltroOk()
        {
            // Arrange
            
            var loggerMock = new Mock<ILogger<EspecialidadesController>>();
            var especialidadesServiceMock = new Mock<IEspecialidadesService>();
            int idMedico = 0;
            List<Especialidade> especialidadesMock = new List<Especialidade>(){
                new Especialidade(){ Id = 1, NomeEspecialidade = "Psicologia"},
                new Especialidade(){ Id = 2, NomeEspecialidade = "Psiquiatria"}
            };
            especialidadesServiceMock.Setup(s => s.EncontrarEspecialidades()).ReturnsAsync(especialidadesMock);
            var controller = new EspecialidadesController(loggerMock.Object, especialidadesServiceMock.Object);
            
            // Act

            var result = await controller.GetEspecialidades(idMedico);

            // Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void BuscarEspecialidadesComFiltroOk()
        {
            // Arrange
            
            var loggerMock = new Mock<ILogger<EspecialidadesController>>();
            var especialidadesServiceMock = new Mock<IEspecialidadesService>();
            int idMedico = 1;
            List<Especialidade> especialidadesMock = new List<Especialidade>(){
                new Especialidade(){ Id = 1, NomeEspecialidade = "Psicologia"},
                new Especialidade(){ Id = 2, NomeEspecialidade = "Psiquiatria"}
            };
            especialidadesServiceMock.Setup(s => s.EncontrarEspecialidadesPorMedico(idMedico)).ReturnsAsync(especialidadesMock);
            var controller = new EspecialidadesController(loggerMock.Object, especialidadesServiceMock.Object);
            
            // Act

            var result = await controller.GetEspecialidades(idMedico);

            // Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void BuscarEspecialidadesSemFiltroNoContent()
        {
            // Arrange
            
            var loggerMock = new Mock<ILogger<EspecialidadesController>>();
            var especialidadesServiceMock = new Mock<IEspecialidadesService>();
            int idMedico = 0;
            List<Especialidade> especialidadesMock = new List<Especialidade>();
            especialidadesServiceMock.Setup(s => s.EncontrarEspecialidades()).ReturnsAsync(especialidadesMock);
            var controller = new EspecialidadesController(loggerMock.Object, especialidadesServiceMock.Object);
            
            // Act

            var result = await controller.GetEspecialidades(idMedico);

            // Assert

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void BuscarEspecialidadesComFiltroNoContent()
        {
            // Arrange
            
            var loggerMock = new Mock<ILogger<EspecialidadesController>>();
            var especialidadesServiceMock = new Mock<IEspecialidadesService>();
            int idMedico = 1;
            List<Especialidade> especialidadesMock = new List<Especialidade>();
            especialidadesServiceMock.Setup(s => s.EncontrarEspecialidadesPorMedico(idMedico)).ReturnsAsync(especialidadesMock);
            var controller = new EspecialidadesController(loggerMock.Object, especialidadesServiceMock.Object);
            
            // Act

            var result = await controller.GetEspecialidades(idMedico);

            // Assert

            Assert.IsType<NoContentResult>(result);
        }

    }
}