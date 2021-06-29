using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASPNET Core 1", "Minha descrição 1", 1, 1, 10000),
                new Project("Meu projeto ASPNET Core 2", "Minha descrição 2", 1, 1, 20000),
                new Project("Meu projeto ASPNET Core 3", "Minha descrição 3", 1, 1, 30000)
            };

            Users = new List<User>
            {
                new User("Rodrigo Waldow", "waldowrodrigo@gmail.com", new DateTime(1984, 1, 1)),
                new User("Anne Waldow", "annewaldow@gmail.com", new DateTime(2016, 1, 1)),
                new User("Levi Waldow", "leviwaldow@gmail.com", new DateTime(2020, 1, 1)),
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL"),
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
