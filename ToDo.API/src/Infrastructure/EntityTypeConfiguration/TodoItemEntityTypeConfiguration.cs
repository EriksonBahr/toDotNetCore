using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.API.Infrastructure.EntityTypeConfiguration
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using model;

    public class TodoItemEntityTypeConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.HasKey(ci => ci.Id);
        }
    }
}
