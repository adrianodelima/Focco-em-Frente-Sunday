using System;
using System.Collections.Generic;
using System.Text;

namespace FoccoEmFrente.Kanban.Application.Entities.Atividade2
{
    public abstract class Person : Entity, IAggregateRoot
    {
        public Person() { }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
