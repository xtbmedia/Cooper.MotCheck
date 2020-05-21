using Cooper.MotCheck.Services.Data.Implementation.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cooper.MotCheck.Services.Data.Implementation.Contexts
{
    public class RemindersContext : DbContext
    {
        private string connectionString;

        public RemindersContext(IConfiguration configuration)
        {
            connectionString = configuration["DbConnectionString"];
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<TableModels.Reminder> Reminders { get; set; }
    }
}
