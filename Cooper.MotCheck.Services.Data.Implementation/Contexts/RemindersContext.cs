using Cooper.MotCheck.Services.Data.Implementation.TableModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cooper.MotCheck.Services.Data.Implementation.Contexts
{
    public class RemindersContext : DbContext
    {
        private string connectionString;

        public RemindersContext()
        {
            connectionString = "Server=(localdb)\\MSSQLLocalDb;Database=MotReminders;Trusted_Connection=yes;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<TableModels.Reminder> Reminders { get; set; }
    }
}
