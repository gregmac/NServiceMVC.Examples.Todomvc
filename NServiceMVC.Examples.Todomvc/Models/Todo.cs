using System;

namespace NServiceMVC.Examples.Todomvc.Models
{
    public class Todo
    {
        public Todo()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool Done { get; set; }
        public int Order { get; set; }
    }
}