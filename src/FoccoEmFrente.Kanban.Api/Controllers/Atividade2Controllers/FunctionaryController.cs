using FoccoEmFrente.Kanban.Api.Controllers.Attributes;
using FoccoEmFrente.Kanban.Application.Entities.Atividade2;
using FoccoEmFrente.Kanban.Application.Repositories.Atividade2Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Api.Controllers.Atividade2Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [ValidateModelState]
    [Authorize]

    public class FunctionaryController : ControllerBase
    {
        private readonly IFunctionaryRepository _functionaryRepository;
        public FunctionaryController(IFunctionaryRepository functionaryRepository)
        {
            _functionaryRepository = functionaryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ListarAsync()
        {
            var atividades = await _functionaryRepository.GetAllAsync();

            return Ok(atividades);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarAsync(Guid id)
        {
            var atividade = await _functionaryRepository.GetByIdAsync(id);

            return Ok(atividade);
        }

        [HttpPost]
        public IActionResult Inserir(Functionary functionary)
        {
            var newFunctionary = _functionaryRepository.Add(functionary);

            return Ok(newFunctionary);
        }

        [HttpPut]
        public IActionResult Alterar(Functionary functionary)
        {
            var newFunctionary = _functionaryRepository.Update(functionary);

            return Ok(newFunctionary);
        }

        [HttpDelete]
        public IActionResult Excluir(Functionary functionary)
        {
            var newFunctionary = _functionaryRepository.Remove(functionary);

            return Ok(newFunctionary);
        }
    }

}
