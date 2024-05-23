using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Controllers;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Services;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AgendamentoWebAPI.Tests.ControllerTests
{
    public class AgendamentoControllerTest
    {
        [Fact]
        public async void ListarAgendamentosPacienteOk()
        {
            //Arrange
            
            var loggerMock = new Mock<ILogger<AgendamentoController>>();
            var agendamentoServiceMock = new Mock<IAgendamentoService>();
            var idPacienteMock = 1;
            var listaAgendamentosMock = PopularAgendamentos();
            agendamentoServiceMock.Setup(s => s.EncontrarAgendamentosPaciente(idPacienteMock)).ReturnsAsync(listaAgendamentosMock);
            var controller = new AgendamentoController(loggerMock.Object, agendamentoServiceMock.Object);

            //Act

            var result = await controller.GetAgendamentosPaciente(idPacienteMock);

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void ListarAgendamentosPacienteNotFound()
        {
            //Arrange
            
            var loggerMock = new Mock<ILogger<AgendamentoController>>();
            var agendamentoServiceMock = new Mock<IAgendamentoService>();
            var idPacienteMock = 1;
            var listaAgendamentosMock = new List<Agendamento>();
            agendamentoServiceMock.Setup(s => s.EncontrarAgendamentosPaciente(idPacienteMock)).ReturnsAsync(listaAgendamentosMock);
            var controller = new AgendamentoController(loggerMock.Object, agendamentoServiceMock.Object);

            //Act

            var result = await controller.GetAgendamentosPaciente(idPacienteMock);

            //Assert

            Assert.IsType<NotFoundObjectResult>(result);
        }
        
        [Fact]
        public async void ListarAgendamentosMedicoOk()
        {
            //Arrange
            
            var loggerMock = new Mock<ILogger<AgendamentoController>>();
            var agendamentoServiceMock = new Mock<IAgendamentoService>();
            var idMedicoMock = 1;
            var listaAgendamentosMock = PopularAgendamentos();
            agendamentoServiceMock.Setup(s => s.EncontrarAgendamentosMedico(idMedicoMock)).ReturnsAsync(listaAgendamentosMock);
            var controller = new AgendamentoController(loggerMock.Object, agendamentoServiceMock.Object);

            //Act

            var result = await controller.GetAgendamentosMedico(idMedicoMock);

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void ListarAgendamentosMedicoNotFound()
        {
            //Arrange
            
            var loggerMock = new Mock<ILogger<AgendamentoController>>();
            var agendamentoServiceMock = new Mock<IAgendamentoService>();
            var idMedicoMock = 1;
            var listaAgendamentosMock = new List<Agendamento>();
            agendamentoServiceMock.Setup(s => s.EncontrarAgendamentosMedico(idMedicoMock)).ReturnsAsync(listaAgendamentosMock);
            var controller = new AgendamentoController(loggerMock.Object, agendamentoServiceMock.Object);

            //Act

            var result = await controller.GetAgendamentosMedico(idMedicoMock);

            //Assert

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async void BuscarAgendamentoOk()
        {
            //Arrange
            
            var loggerMock = new Mock<ILogger<AgendamentoController>>();
            var agendamentoServiceMock = new Mock<IAgendamentoService>();
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
            agendamentoServiceMock.Setup(s => s.EncontrarAgendamentoPorId(idAgendamentoMock)).ReturnsAsync(agendamentoMock);
            var controller = new AgendamentoController(loggerMock.Object, agendamentoServiceMock.Object);

            //Act

            var result = await controller.GetAgendamento(idAgendamentoMock);

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void BuscarAgendamentoNotFound()
        {
             //Arrange
            
            var loggerMock = new Mock<ILogger<AgendamentoController>>();
            var agendamentoServiceMock = new Mock<IAgendamentoService>();
            var idAgendamentoMock = 1;
            
            agendamentoServiceMock.Setup(s => s.EncontrarAgendamentoPorId(idAgendamentoMock)).Returns(Task.FromResult<Agendamento>(null));
            var controller = new AgendamentoController(loggerMock.Object, agendamentoServiceMock.Object);

            //Act

            var result = await controller.GetAgendamento(idAgendamentoMock);

            //Assert

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async void CadastrarAgendamentoOk()
        {
            //Arrange
            
            var loggerMock = new Mock<ILogger<AgendamentoController>>();
            var agendamentoServiceMock = new Mock<IAgendamentoService>();
            var agendamentoFormMock = new AgendamentoForm() {
                IdPaciente = 1,
                IdMedico = 1,
                IdEspecialidade = 1,
                IdStatusConsulta = 1,
                IdTipoConsulta = 1,
                DataAgendada = new DateTime(2024, 5, 20)
            };
            agendamentoServiceMock.Setup(s => s.CadastrarAgendamento(agendamentoFormMock)).ReturnsAsync(new AgendamentoCriado());
            var controller = new AgendamentoController(loggerMock.Object, agendamentoServiceMock.Object);

            //Act

            var result = await controller.PostAgendamento(agendamentoFormMock);

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void CadastrarAgendamentoBadResquest()
        {
            //Arrange
            
            var loggerMock = new Mock<ILogger<AgendamentoController>>();
            var agendamentoServiceMock = new Mock<IAgendamentoService>();
            var agendamentoFormMock = new AgendamentoForm() {
                IdPaciente = 1,
                IdMedico = 1,
                IdEspecialidade = 1,
                IdStatusConsulta = 1,
                IdTipoConsulta = 1,
                DataAgendada = new DateTime(2024, 5, 20)
            };
            //agendamentoServiceMock.Setup(s => s.CadastrarAgendamento(agendamentoFormMock)).ReturnsAsync(false);
            var controller = new AgendamentoController(loggerMock.Object, agendamentoServiceMock.Object);

            //Act

            var result = await controller.PostAgendamento(agendamentoFormMock);

            //Assert

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void AtualizarAgendamentoOk()
        {
            //Arrange
            
            var loggerMock = new Mock<ILogger<AgendamentoController>>();
            var agendamentoServiceMock = new Mock<IAgendamentoService>();
            var idAgendamentoMock = 1;
            var agendamentoFormMock = new AgendamentoForm() {
                IdPaciente = 1,
                IdMedico = 1,
                IdEspecialidade = 1,
                IdStatusConsulta = 1,
                IdTipoConsulta = 1,
                DataAgendada = new DateTime(2024, 5, 20)
            };
            agendamentoServiceMock.Setup(s => s.AtualizarAgendamento(idAgendamentoMock, agendamentoFormMock)).ReturnsAsync(true);
            var controller = new AgendamentoController(loggerMock.Object, agendamentoServiceMock.Object);

            //Act

            var result = await controller.PatchAgendamento(idAgendamentoMock, agendamentoFormMock);

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void AtualizarAgendamentoBadResquest()
        {
            //Arrange
            
            var loggerMock = new Mock<ILogger<AgendamentoController>>();
            var agendamentoServiceMock = new Mock<IAgendamentoService>();
            var idAgendamentoMock = 1;
            var agendamentoFormMock = new AgendamentoForm() {
                IdPaciente = 1,
                IdMedico = 1,
                IdEspecialidade = 1,
                IdStatusConsulta = 1,
                IdTipoConsulta = 1,
                DataAgendada = new DateTime(2024, 5, 20)
            };
            agendamentoServiceMock.Setup(s => s.AtualizarAgendamento(idAgendamentoMock, agendamentoFormMock)).ReturnsAsync(false);
            var controller = new AgendamentoController(loggerMock.Object, agendamentoServiceMock.Object);

            //Act

            var result = await controller.PatchAgendamento(idAgendamentoMock, agendamentoFormMock);

            //Assert

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void CancelarAgendamentoOk()
        {
            //Arrange
            
            var loggerMock = new Mock<ILogger<AgendamentoController>>();
            var agendamentoServiceMock = new Mock<IAgendamentoService>();
            var idAgendamentoMock = 1;
            agendamentoServiceMock.Setup(s => s.CancelarAgendamento(idAgendamentoMock)).ReturnsAsync(true);
            var controller = new AgendamentoController(loggerMock.Object, agendamentoServiceMock.Object);

            //Act

            var result = await controller.CancelarAgendamento(idAgendamentoMock);

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void CancelarAgendamentoBadRequest()
        {
            //Arrange
            
            var loggerMock = new Mock<ILogger<AgendamentoController>>();
            var agendamentoServiceMock = new Mock<IAgendamentoService>();
            var idAgendamentoMock = 1;
            var listaAgendamentosMock = new List<Agendamento>();
            agendamentoServiceMock.Setup(s => s.CancelarAgendamento(idAgendamentoMock)).ReturnsAsync(false);
            var controller = new AgendamentoController(loggerMock.Object, agendamentoServiceMock.Object);

            //Act

            var result = await controller.CancelarAgendamento(idAgendamentoMock);

            //Assert

            Assert.IsType<BadRequestObjectResult>(result);
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