using Microsoft.EntityFrameworkCore;

namespace ToDo.API.Infrastructure{
    using model;
    using EntityTypeConfiguration;

    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> TodoItems {get; set;}

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TodoItemEntityTypeConfiguration());
        }
    }
}