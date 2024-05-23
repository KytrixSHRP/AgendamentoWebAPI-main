using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Repository;
using AgendamentoWebAPI.Services;
using MedicoEspecialidadeWebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AgendamentoWebAPI.Tests.ServiceTests
{
    public class EspecialidadesServiceTest
    {
        [Fact]
        public async void BuscarEspecialidadesSemFiltroSucesso()
        {
            // Arrange
            
            var especialidadesDatabaseMock = new Mock<IEspecialidadesDatabase>();
            List<Especialidade> especialidadesMock = new List<Especialidade>(){
                new Especialidade(){ Id = 1, NomeEspecialidade = "Psicologia"},
                new Especialidade(){ Id = 2, NomeEspecialidade = "Psiquiatria"}
            };
            especialidadesDatabaseMock.Setup(s => s.EncontrarEspecialidades()).ReturnsAsync(especialidadesMock);
            var service = new EspecialidadesService(especialidadesDatabaseMock.Object);
            
            // Act

            var result = await service.EncontrarEspecialidades();

            // Assert

            Assert.IsType<List<Especialidade>>(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async void BuscarEspecialidadesComFiltroSucesso()
        {
            // Arrange
            
            var especialidadesDatabaseMock = new Mock<IEspecialidadesDatabase>();
            var idMedicoMock = 1;
            List<Especialidade> especialidadesMock = new List<Especialidade>(){
                new Especialidade(){ Id = 1, NomeEspecialidade = "Psicologia"},
                new Especialidade(){ Id = 2, NomeEspecialidade = "Psiquiatria"}
            };
            especialidadesDatabaseMock.Setup(s => s.EncontrarEspecialidadesPorMedico(idMedicoMock)).ReturnsAsync(especialidadesMock);
            var service = new EspecialidadesService(especialidadesDatabaseMock.Object);
            
            // Act

            var result = await service.EncontrarEspecialidadesPorMedico(idMedicoMock);

            // Assert

            Assert.IsType<List<Especialidade>>(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async void BuscarEspecialidadesSemFiltroListaVazia()
        {
            // Arrange
            
            var especialidadesDatabaseMock = new Mock<IEspecialidadesDatabase>();
            List<Especialidade> especialidadesMock = new List<Especialidade>();
            especialidadesDatabaseMock.Setup(s => s.EncontrarEspecialidades()).ReturnsAsync(especialidadesMock);
            var service = new EspecialidadesService(especialidadesDatabaseMock.Object);
            
            // Act

            var result = await service.EncontrarEspecialidades();

            // Assert

            Assert.IsType<List<Especialidade>>(result);
            Assert.True(result.Count == 0);
        }

        [Fact]
        public async void BuscarEspecialidadesComFiltroListaVazia()
        {
            // Arrange
            
            var especialidadesDatabaseMock = new Mock<IEspecialidadesDatabase>();
            int idMedicoMock = 1;
            List<Especialidade> especialidadesMock = new List<Especialidade>();
            especialidadesDatabaseMock.Setup(s => s.EncontrarEspecialidadesPorMedico(idMedicoMock)).ReturnsAsync(especialidadesMock);
            var service = new EspecialidadesService(especialidadesDatabaseMock.Object);
            
            // Act

            var result = await service.EncontrarEspecialidadesPorMedico(idMedicoMock);

            // Assert

            Assert.IsType<List<Especialidade>>(result);
            Assert.True(result.Count == 0);
        }

    }
}