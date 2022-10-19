using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Lab.Core;

namespace Lab.EF
{
    class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=remotemysql.com;port=3306;database=xxFhi3fR3w;user=xxFhi3fR3w;password=ASTO8UWANW";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
