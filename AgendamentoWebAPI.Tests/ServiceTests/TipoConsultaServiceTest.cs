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
    public class TipoConsultaServiceTest
    {
        [Fact]
        public async void BuscarTipoConsultaSucesso()
        {
            // Arrange
            
            var tipoConsultaDatabaseMock = new Mock<ITipoConsultaDatabase>();
            int idMedicoMock = 1;
            var tipoConsultaMock = new List<TipoConsulta>() {
                new TipoConsulta(){ Id = 1, Descricao = "Telemedicina"}
            };
            tipoConsultaDatabaseMock.Setup(s => s.EncontrarTiposConsulta(idMedicoMock)).ReturnsAsync(tipoConsultaMock);
            var service = new TipoConsultaService(tipoConsultaDatabaseMock.Object);

            // Act

            var response = await service.EncontrarTiposConsulta(idMedicoMock);

            // Assert

            Assert.IsType<List<TipoConsulta>>(response);
            Assert.True(response.Count > 0);

        }

        [Fact]
        public async void BuscarTipoConsultaListaVazia()
        {
            // Arrange
            
            var tipoConsultaDatabaseMock = new Mock<ITipoConsultaDatabase>();
            int idMedicoMock = 1;
            var tipoConsultaMock = new List<TipoConsulta>();
            tipoConsultaDatabaseMock.Setup(s => s.EncontrarTiposConsulta(idMedicoMock)).ReturnsAsync(tipoConsultaMock);
            var service = new TipoConsultaService(tipoConsultaDatabaseMock.Object);

            // Act

            var response = await service.EncontrarTiposConsulta(idMedicoMock);

            // Assert

            Assert.IsType<List<TipoConsulta>>(response);
            Assert.True(response.Count == 0);

        }
    }
}