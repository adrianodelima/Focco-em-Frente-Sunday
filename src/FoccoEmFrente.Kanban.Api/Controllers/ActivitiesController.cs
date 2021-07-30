using AutoMapper;
using FoccoEmFrente.Kanban.Api.Controllers.Attributes;
using FoccoEmFrente.Kanban.Api.Models;
using FoccoEmFrente.Kanban.Application.Entities;
using FoccoEmFrente.Kanban.Application.Repositories;
using FoccoEmFrente.Kanban.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Api
{

    [Route("api/[controller]")]
    [ApiController]
    [ValidateModelState]
    [Authorize]

    public class ActivitiesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IActivityService _activityService;
        private readonly UserManager<IdentityUser> _userManager;
        public ActivitiesController(IMapper mapper, IActivityService activityService, UserManager<IdentityUser> userManager) 
        {
            _mapper = mapper;
            _activityService = activityService;
            _userManager = userManager;
        }

        protected Guid UserId => Guid.Parse(_userManager.GetUserId(User));

        [HttpGet]
        public async Task<IActionResult> ListarAsync() 
        {
            var atividades = await _activityService.GetAllAsync(UserId);

            var activityDtos = _mapper.Map<IEnumerable<ActivityDto>>(atividades);

            return Ok(activityDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarAsync(Guid id, Guid userId)
        {
            var atividade = await _activityService.GetByIdAsync(id, userId);

            if (atividade == null) return NotFound();
            return Ok(atividade);
        }

        [HttpPost]
        public async Task<IActionResult> InserirAsync(ActivityDto activityDto)
        {
            var activity = _mapper.Map<Activity>(activityDto);

            activity.UserId = UserId;

            var addedActivity = await _activityService.AddAsync(activity);

            var addedActivityDto = _mapper.Map<ActivityDto>(addedActivity);

            return Ok(addedActivityDto);
        }

        [HttpPut]
        public async Task<IActionResult> AlterarAsync(ActivityDto activityDto)
        {

            var activity = _mapper.Map<Activity>(activityDto);

            activity.UserId = UserId;

            var newActivity = await _activityService.UpdateAsync(activity);

            var newActivityDto = _mapper.Map<ActivityDto>(newActivity);

            return Ok(newActivityDto);
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirAsync(Activity activity)
        {

            activity.UserId = UserId;

            var newActivity = await _activityService.RemoveAsync(activity);

            return Ok(newActivity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirByIdAsync(Guid id)
        {
            var newActivity = await _activityService.RemoveAsync(id, UserId);

            return Ok(newActivity);
        }
        [HttpPut("{id}/todo")]
        public async Task<IActionResult> AtualizarStatusParaTodo(Guid id)
        {
            var activity = await _activityService.UpdateToTodoAsync(id, UserId);

            return Ok(activity);
        }

        [HttpPut("{id}/doing")]
        public async Task<IActionResult> AtualizarStatusParaDoing(Guid id)
        {
            var activity = await _activityService.UpdateToDoingAsync(id, UserId);

            return Ok(activity);
        }

        [HttpPut("{id}/done")]
        public async Task<IActionResult> AtualizarStatusParaDone(Guid id)
        {
            var activity = await _activityService.UpdateToDoneAsync(id, UserId);

            return Ok(activity);
        }
    }

}
