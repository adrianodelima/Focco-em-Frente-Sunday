using System;
using System.ComponentModel.DataAnnotations;

namespace FoccoEmFrente.Kanban.Api.Models
{
    public class ActivityDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O título deve ser informado.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O status deve ser informado.")]
        public string Status { get; set; }
    }
}