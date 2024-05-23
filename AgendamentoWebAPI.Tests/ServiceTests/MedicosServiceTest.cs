using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Controllers;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Repository;
using AgendamentoWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AgendamentoWebAPI.Tests.ServiceTests
{
    public class MedicosServiceTest
    {
        [Fact]
        public async void BuscarMedicosSemFiltroSucesso()
        {
            // Arrange
            
            var medicoDatabaseMock = new Mock<IMedicoDatabase>();
            int idMedicoMock = 3;
            List<Medico> medicosMock = new List<Medico>(){
                new Medico() {Id = 1, Nome = "Medico1", CRM = "11111111", CRP = "1111111"},
                new Medico() {Id = 2, Nome = "Medico2", CRM = "22222222", CRP = "2222222"}
            };
            medicoDatabaseMock.Setup(s => s.EncontrarMedicos(idMedicoMock)).ReturnsAsync(medicosMock);
            var service = new MedicoService(medicoDatabaseMock.Object);
            
            // Act

            var result = await service.EncontrarMedicos(idMedicoMock);

            // Assert

            Assert.IsType<List<Medico>>(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async void BuscarMedicosComFiltroSucesso()
        {
            // Assert
            
            var medicoDatabaseMock = new Mock<IMedicoDatabase>();
            int idEspecialidadeMock = 0;
            int idMedicoMock = 3;
            List<Medico> medicosMock = new List<Medico>(){
                new Medico() {Id = 1, Nome = "Medico1", CRM = "11111111", CRP = "1111111"},
                new Medico() {Id = 2, Nome = "Medico2", CRM = "22222222", CRP = "2222222"}
            };
            medicoDatabaseMock.Setup(s => s.EncontrarMedicoPorEspecialidade(idEspecialidadeMock, idMedicoMock)).ReturnsAsync(medicosMock);
            var service = new MedicoService(medicoDatabaseMock.Object);
            
            // Act

            var result = await service.EncontrarMedicosPorEspecialidade(idEspecialidadeMock, idMedicoMock);

            // Assert

            Assert.IsType<List<Medico>>(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async void BuscarMedicosSemFiltroListaVazia()
        {
            // Arrange
            
            var medicoDatabaseMock = new Mock<IMedicoDatabase>();
            int idMedicoMock = 3;
            List<Medico> medicosMock = new List<Medico>();
            medicoDatabaseMock.Setup(s => s.EncontrarMedicos(idMedicoMock)).ReturnsAsync(medicosMock);
            var service = new MedicoService(medicoDatabaseMock.Object);
            
            // Act

            var result = await service.EncontrarMedicos(idMedicoMock);

            // Assert

            Assert.IsType<List<Medico>>(result);
            Assert.True(result.Count == 0);
        }

        [Fact]
        public async void BuscarMedicosComFiltroListaVazia()
        {
            // Assert
            
            var medicoDatabaseMock = new Mock<IMedicoDatabase>();
            int idEspecialidadeMock = 0;
            int idMedicoMock = 3;
            List<Medico> medicosMock = new List<Medico>();
            medicoDatabaseMock.Setup(s => s.EncontrarMedicoPorEspecialidade(idEspecialidadeMock, idMedicoMock)).ReturnsAsync(medicosMock);
            var service = new MedicoService(medicoDatabaseMock.Object);
            
            // Act

            var result = await service.EncontrarMedicosPorEspecialidade(idEspecialidadeMock, idMedicoMock);

            // Assert

            Assert.IsType<List<Medico>>(result);
            Assert.True(result.Count == 0);
        }
    }
}