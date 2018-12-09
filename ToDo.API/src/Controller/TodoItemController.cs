using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.API.Controller
{
    using model;
    using Infrastructure;
    using System.Net;
    using Microsoft.EntityFrameworkCore;

    [Route("api/v1[controller]")]
    [ApiController]
    public class TodoItemController: ControllerBase
    {
        private readonly TodoContext _todoContext;

        public TodoItemController(TodoContext context)
        {
            _todoContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        [Route("Items")]
        [ProducesResponseType(typeof(IEnumerable<TodoItem>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Items()
        {
            var items = await _todoContext.TodoItems
                .OrderBy(ci => ci.CreatedAt)
                .ToListAsync();

            return Ok(items);
        }

        [HttpGet]
        [Route("items/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(TodoItem),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItemById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var item = await _todoContext.TodoItems.SingleOrDefaultAsync(ci => ci.Id == id);

            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        //POST api/v1/[controller]/items
        [Route("items")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Createtodo([FromBody]TodoItem todo)
        {
            var item = new TodoItem
            {
                CreatedAt = DateTime.Now,
                Title = todo.Title,
                Content = todo.Content,
            };
            _todoContext.TodoItems.Add(item);

            await _todoContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, null);
        }
    }
}
