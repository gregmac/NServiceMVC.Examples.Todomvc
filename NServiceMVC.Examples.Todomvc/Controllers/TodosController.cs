using System;
using System.Collections.Generic;
using System.Linq;
using NServiceMVC;
using AttributeRouting;

namespace NServiceMVC.Examples.Todomvc.Controllers
{
    public class TodosController : ServiceController
    {
        [GET("todos")]
        public IEnumerable<Models.Todo> Index()
        {
            return new List<Models.Todo>() {
                new Models.Todo() {
                    Text = "Item1",
                },
                new Models.Todo() {
                    Text = "Item2",
                    Done = true,
                }
            };
        }
    }
}
