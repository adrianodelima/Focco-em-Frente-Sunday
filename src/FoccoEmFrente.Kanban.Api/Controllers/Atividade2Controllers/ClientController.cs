using FoccoEmFrente.Kanban.Api.Controllers.Attributes;
using FoccoEmFrente.Kanban.Application.Entities.Atividade2;
using FoccoEmFrente.Kanban.Application.Repositories.Atividade2Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Api.Controllers.Atividade2Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [ValidateModelState]
    [Authorize]

    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ListarAsync()
        {
            var atividades = await _clientRepository.GetAllAsync();

            return Ok(atividades);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarAsync(Guid id)
        {
            var atividade = await _clientRepository.GetByIdAsync(id);

            return Ok(atividade);
        }

        [HttpPost]
        public IActionResult Inserir(Client client)
        {
            var newClient = _clientRepository.Add(client);

            return Ok(newClient);
        }

        [HttpPut]
        public IActionResult Alterar(Client client)
        {
            var newClient = _clientRepository.Update(client);

            return Ok(newClient);
        }

        [HttpDelete]
        public IActionResult Excluir(Client client)
        {
            var newClient = _clientRepository.Remove(client);

            return Ok(newClient);
        }
    }

}
