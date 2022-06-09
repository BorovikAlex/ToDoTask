using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTask.DataAccess.Models;

namespace ToDoTask.DataAccess.ModelsConfiguration
{
    public class ToDoConfiguration : IEntityTypeConfiguration<ToDoModel>
    {
        public void Configure(EntityTypeBuilder<ToDoModel> builder)
        {
            builder.ToTable("ToDo")
                .HasKey(k => k.ToDoID);


            builder.Property(b => b.ToDoName)
            .IsRequired()
            .HasMaxLength(256);

            builder.Property(b => b.IsDone)
            .IsRequired()
            .HasDefaultValue(false);

        }
    }
}