using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Controllers;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Repository;
using AgendamentoWebAPI.Services;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AgendamentoWebAPI.Tests.ServiceTests
{
    public class AgendamentoServiceTest
    {
        [Fact]
        public async void CadastrarAgendamentoSuccesso()
        {
            //Arrange
            
            var agendamentoDatabaseMock = new Mock<IAgendamentoDatabase>();
            var agendamentoFormMock = new AgendamentoForm() {
                IdPaciente = 1,
                IdMedico = 1,
                IdEspecialidade = 1,
                IdStatusConsulta = 1,
                IdTipoConsulta = 1,
                DataAgendada = new DateTime(2024, 5, 20)
            };
            agendamentoDatabaseMock.Setup(s => s.CadastrarAgendamento(agendamentoFormMock)).ReturnsAsync(true);
            agendamentoDatabaseMock.Setup(s => s.BuscarAgendamentoRecemCriado()).ReturnsAsync(new AgendamentoCriado());
            
            var service = new AgendamentoService(agendamentoDatabaseMock.Object);

            //Act

            var result = await service.CadastrarAgendamento(agendamentoFormMock);

            //Assert

            Assert.IsType<AgendamentoCriado>(result);
        }

        [Fact]
        public async void CadastrarAgendamentoErro()
        {
            //Arrange
            
            var agendamentoDatabaseMock = new Mock<IAgendamentoDatabase>();
            var agendamentoFormMock = new AgendamentoForm() {
                IdPaciente = 1,
                IdMedico = 1,
                IdEspecialidade = 1,
                IdStatusConsulta = 1,
                IdTipoConsulta = 1,
                DataAgendada = new DateTime(2024, 5, 20)
            };
            agendamentoDatabaseMock.Setup(s => s.CadastrarAgendamento(agendamentoFormMock)).ReturnsAsync(false);
            var service = new AgendamentoService(agendamentoDatabaseMock.Object);

            //Act

            var result = await service.CadastrarAgendamento(agendamentoFormMock);

            //Assert

            Assert.Null(result);
        }

        [Fact]
        public async void AtualizarAgendamentoSuccesso()
        {
            //Arrange
            
            var agendamentoDatabaseMock = new Mock<IAgendamentoDatabase>();
            var agendamentoIdMock = 1;
            var agendamentoFormMock = new AgendamentoForm() {
                IdPaciente = 1,
                IdMedico = 1,
                IdEspecialidade = 1,
                IdStatusConsulta = 1,
                IdTipoConsulta = 1,
                DataAgendada = new DateTime(2024, 5, 23)
            };
            agendamentoDatabaseMock.Setup(s => s.AtualizarAgendamento(agendamentoIdMock, agendamentoFormMock)).ReturnsAsync(true);
            var service = new AgendamentoService(agendamentoDatabaseMock.Object);

            //Act

            var result = await service.AtualizarAgendamento(agendamentoIdMock, agendamentoFormMock);

            //Assert

            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Fact]
        public async void AtualizarAgendamentoErro()
        {
            //Arrange
            
            var agendamentoDatabaseMock = new Mock<IAgendamentoDatabase>();
            var agendamentoIdMock = 1;
            var agendamentoFormMock = new AgendamentoForm() {
                IdPaciente = 1,
                IdMedico = 1,
                IdEspecialidade = 1,
                IdStatusConsulta = 1,
                IdTipoConsulta = 1,
                DataAgendada = new DateTime(2024, 5, 20)
            };
            agendamentoDatabaseMock.Setup(s => s.AtualizarAgendamento(agendamentoIdMock, agendamentoFormMock)).ReturnsAsync(false);
            var service = new AgendamentoService(agendamentoDatabaseMock.Object);

            //Act

            var result = await service.AtualizarAgendamento(agendamentoIdMock, agendamentoFormMock);

            //Assert

            Assert.IsType<bool>(result);
            Assert.False(result);
        }

        [Fact]
        public async void CancelarAgendamentoSucesso()
        {
            //Arrange
            
            var agendamentoDatabaseMock = new Mock<IAgendamentoDatabase>();
            var idAgendamentoMock = 1;
            agendamentoDatabaseMock.Setup(s => s.CancelarAgendamento(idAgendamentoMock)).ReturnsAsync(true);
            var service = new AgendamentoService(agendamentoDatabaseMock.Object);

            //Act

            var result = await service.CancelarAgendamento(idAgendamentoMock);

            //Assert

            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Fact]
        public async void CancelarAgendamentoErro()
        {
            //Arrange
            
            var agendamentoDatabaseMock = new Mock<IAgendamentoDatabase>();
            var idAgendamentoMock = 1;
            agendamentoDatabaseMock.Setup(s => s.CancelarAgendamento(idAgendamentoMock)).ReturnsAsync(false);
            var service = new AgendamentoService(agendamentoDatabaseMock.Object);

            //Act

            var result = await service.CancelarAgendamento(idAgendamentoMock);

            //Assert

            Assert.IsType<bool>(result);
            Assert.False(result);
        }

        [Fact]
        public async void BuscarAgendamentoPorIdEncontrado()
        {
            //Arrange
            
            var agendamentoDatabaseMock = new Mock<IAgendamentoDatabase>();
            var idAgendamentoMock = 1;
            var agendamentoMock = new Agendamento() {
                Id = 1,
                TipoConsulta = "Telemedicina",
                TipoConsultaId = 1,
                MedicoId = 1,
                NomeMedico = "Medico1",
                PacienteId = 3,
                NomePaciente = "Paciente3",
                StatusConsultaId = 1,
                StatusConsulta = "Agendado"

            };
            agendamentoDatabaseMock.Setup(s => s.EncontrarAgendamentoId(idAgendamentoMock)).ReturnsAsync(agendamentoMock);
            var service = new AgendamentoService(agendamentoDatabaseMock.Object);

            //Act

            var result = await service.EncontrarAgendamentoPorId(idAgendamentoMock);

            //Assert

            Assert.IsType<Agendamento>(result);
            Assert.True(result.Id == idAgendamentoMock);
        }

        [Fact]
        public async void BuscarAgendamentoPorIdNaoEncontrado()
        {
            //Arrange
            
            var agendamentoDatabaseMock = new Mock<IAgendamentoDatabase>();
            var idAgendamentoMock = 1;
            agendamentoDatabaseMock.Setup(s => s.EncontrarAgendamentoId(idAgendamentoMock)).Returns(Task.FromResult<Agendamento>(null));
            var service = new AgendamentoService(agendamentoDatabaseMock.Object);

            //Act

            var result = await service.EncontrarAgendamentoPorId(idAgendamentoMock);

            //Assert

            Assert.Null(result);
        }
        
        [Fact]
        public async void ListarAgendamentosMedicoEncontrado()
        {
            //Arrange
            
            var agendamentoDatabaseMock = new Mock<IAgendamentoDatabase>();
            var idMedicoMock = 1;
            var listaAgendamentosMock = PopularAgendamentos();
            agendamentoDatabaseMock.Setup(s => s.EncontrarAgendamentosMedico(idMedicoMock)).ReturnsAsync(listaAgendamentosMock);
            var service = new AgendamentoService(agendamentoDatabaseMock.Object);

            //Act

            var result = await service.EncontrarAgendamentosMedico(idMedicoMock);

            //Assert

            Assert.IsType<List<Agendamento>>(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async void ListarAgendamentosMedicoListaVazia()
        {
            //Arrange
            
            var agendamentoDatabaseMock = new Mock<IAgendamentoDatabase>();
            var idMedicoMock = 1;
            var listaAgendamentosMock = new List<Agendamento>();
            agendamentoDatabaseMock.Setup(s => s.EncontrarAgendamentosMedico(idMedicoMock)).ReturnsAsync(listaAgendamentosMock);
            var service = new AgendamentoService(agendamentoDatabaseMock.Object);

            //Act

            var result = await service.EncontrarAgendamentosMedico(idMedicoMock);

            //Assert

            Assert.IsType<List<Agendamento>>(result);
            Assert.True(result.Count == 0);
        }

        [Fact]
        public async void ListarAgendamentosPacienteEncontrado()
        {
            //Arrange
            
            var agendamentoDatabaseMock = new Mock<IAgendamentoDatabase>();
            var idPacienteMock = 1;
            var listaAgendamentosMock = PopularAgendamentos();
            agendamentoDatabaseMock.Setup(s => s.EncontrarAgendamentosPaciente(idPacienteMock)).ReturnsAsync(listaAgendamentosMock);
            var service = new AgendamentoService(agendamentoDatabaseMock.Object);

            //Act

            var result = await service.EncontrarAgendamentosPaciente(idPacienteMock);

            //Assert

            Assert.IsType<List<Agendamento>>(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async void ListarAgendamentosPacienteListaVazia()
        {
            //Arrange
            
            var agendamentoDatabaseMock = new Mock<IAgendamentoDatabase>();
            var idPacienteMock = 1;
            var listaAgendamentosMock = new List<Agendamento>();
            agendamentoDatabaseMock.Setup(s => s.EncontrarAgendamentosPaciente(idPacienteMock)).ReturnsAsync(listaAgendamentosMock);
            var service = new AgendamentoService(agendamentoDatabaseMock.Object);

            //Act

            var result = await service.EncontrarAgendamentosPaciente(idPacienteMock);

            //Assert

            Assert.IsType<List<Agendamento>>(result);
            Assert.True(result.Count == 0);
        }

        private List<Agendamento> PopularAgendamentos(){
            var listaAgendamentos = new List<Agendamento>(){
              new Agendamento() {
                Id = 1,
                MedicoId = 1,
                PacienteId = 1,
                NomePaciente = "Paciente1",
                EspecialidadeId = 1,
                Especialidade = "Psicologia",
                TipoConsultaId = 1,
                TipoConsulta = "Telemedicina",
                StatusConsultaId = 1,
                StatusConsulta = "Agendado",
                DataAgendamento = new DateTime(2024, 5, 14)
                }  
            };
            return listaAgendamentos;
        }
        
    }
}