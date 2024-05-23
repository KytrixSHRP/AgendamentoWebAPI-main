using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Controllers;
using AgendamentoWebAPI.Services;
using MedicoEspecialidadeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AgendamentoWebAPI.Tests.ControllerTests
{
    public class DataHoraControllerTest
    {
        [Fact]
        public async void BuscarDataHoraListaOk()
        {
            // Arrange

            var loggerMock = new Mock<ILogger<DataHoraController>>();
            var dataHoraAgendamentoServiceMock = new Mock<IDataHoraAgendamentoService>();
            int idMedicoMock = 2;
            int idPacienteMock = 1;
            List<DataHoraAgendamento> datas = PopularListaDatas();
            dataHoraAgendamentoServiceMock.Setup(s => s.BuscarDataHoraDisponiveis(idPacienteMock, idMedicoMock)).ReturnsAsync(datas);
            var controller = new DataHoraController(loggerMock.Object, dataHoraAgendamentoServiceMock.Object);

            // Act

            var result = await controller.GetDataHora(idPacienteMock, idMedicoMock);

            // Assert

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async void BuscarDataHoraNoContent()
        {
            // Arrange

            var loggerMock = new Mock<ILogger<DataHoraController>>();
            var dataHoraAgendamentoServiceMock = new Mock<IDataHoraAgendamentoService>();
            int idMedicoMock = 2;
            int idPacienteMock = 1;
            List<DataHoraAgendamento> datas = new List<DataHoraAgendamento>();
            dataHoraAgendamentoServiceMock.Setup(s => s.BuscarDataHoraDisponiveis(idPacienteMock, idMedicoMock)).ReturnsAsync(datas);
            var controller = new DataHoraController(loggerMock.Object, dataHoraAgendamentoServiceMock.Object);

            // Act

            var result = await controller.GetDataHora(idPacienteMock, idMedicoMock);

            // Assert

            Assert.IsType<NoContentResult>(result);

        }


        private List<DataHoraAgendamento> PopularListaDatas()
        {
            return new List<DataHoraAgendamento>(){
                new DataHoraAgendamento() {
                    DataHora = new DateTime(2024, 05, 10, 11, 00, 0)
                },
                new DataHoraAgendamento(){
                    DataHora = new DateTime(2024, 05, 11, 13, 30, 0)
                }
            };
        }
    }
}