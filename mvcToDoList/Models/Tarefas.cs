using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskList.Models
{
    public class Tarefas
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Data { get; set; }
        public string Meta { get; set; }
        public string Status { get; set; }
    }

    public class TodosDBContext : DbContext
    {
        public DbSet<Tarefas> Todo { get; set; }
    }
}