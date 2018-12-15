using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.API.model
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set;  }
        //public bool IsComplete { get; set; } to be added
        public DateTime CreatedAt {get; set; }
    }
}
