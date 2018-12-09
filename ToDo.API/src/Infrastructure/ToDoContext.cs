using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.API.Infrastructure{
    using model;
    using EntityTypeConfiguration;
    using Microsoft.EntityFrameworkCore.Design;

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

    public class TodoContextDeisgnFactory : IDesignTimeDbContextFactory<TodoContext>
    {
        public TodoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoContext>()
                .UseSqlServer("Server=.;Initial Catalog=ToDotNetCore.Services.ToDoDB;Integrated Security=true");
            
            return new TodoContext(optionsBuilder.Options);
        }
    }
}