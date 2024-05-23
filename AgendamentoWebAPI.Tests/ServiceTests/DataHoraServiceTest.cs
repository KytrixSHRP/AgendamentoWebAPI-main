using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Repository;
using AgendamentoWebAPI.Services;
using MedicoEspecialidadeWebAPI.Models;
using Moq;
using Xunit;

namespace AgendamentoWebAPI.Tests.ServiceTests
{
    public class DataHoraServiceTest
    {
        [Fact]
        public async void BuscarDataHoraLista()
        {
            // Arrange

            var dataHoraAgendamentoDatabaseMock = new Mock<IDataHoraAgendamentoDatabase>();
            int idMedicoMock = 2;
            int idPacienteMock = 1;
            DateTime dataMock = DateTime.Now.Date.AddDays(1);
            List<DataHoraAgendamento> datas = PopularListaDatas();
            dataHoraAgendamentoDatabaseMock.Setup(s => s.BuscarDataHoraDisponiveis(idPacienteMock, idMedicoMock, dataMock)).ReturnsAsync(datas);
            var service = new DataHoraAgendamentoService(dataHoraAgendamentoDatabaseMock.Object);

            // Act

            var result = await service.BuscarDataHoraDisponiveis(idPacienteMock, idMedicoMock);

            // Assert

            Assert.IsType<List<DataHoraAgendamento>>(result);
            Assert.True(datas.Count > 0);
        }

        [Fact]
        public async void BuscarDataHoraListaVazia()
        {
            // Arrange

            var dataHoraAgendamentoDatabaseMock = new Mock<IDataHoraAgendamentoDatabase>();
            int idMedicoMock = 2;
            int idPacienteMock = 1;
            DateTime dataMock = DateTime.Now.Date.AddDays(1);
            List<DataHoraAgendamento> datas = new List<DataHoraAgendamento>();
            dataHoraAgendamentoDatabaseMock.Setup(s => s.BuscarDataHoraDisponiveis(idPacienteMock, idMedicoMock, dataMock)).ReturnsAsync(datas);
            var service = new DataHoraAgendamentoService(dataHoraAgendamentoDatabaseMock.Object);

            // Act

            var result = await service.BuscarDataHoraDisponiveis(idPacienteMock, idMedicoMock);

            // Assert

            Assert.IsType<List<DataHoraAgendamento>>(result);
            Assert.True(result.Count == 0);

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