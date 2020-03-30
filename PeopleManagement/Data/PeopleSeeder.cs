using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using PeopleManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Data
{
   
    public class PeopleSeeder
    {
        private readonly PeopleContext _ctx;
        private readonly IHostingEnvironment _hosting;
        public PeopleSeeder(PeopleContext ctx, IHostingEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }
        public void Seed()
        {
            _ctx.Database.EnsureCreated();
            if(_ctx.People.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/Group.json");
                var json = File.ReadAllText(filepath);
                var groups = JsonConvert.DeserializeObject<IEnumerable<Group>>(json);
                _ctx.Groups.AddRange(groups);
                var per = _ctx.People.Where(p => p.Id == 1).FirstOrDefault();
                if(per!=null)
                {
                    new Person()
                    {
                        
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "John.d@test.com",
                        Address = "Testing Road, London",
                        Group = groups.First(),
                        CreatedDate = DateTime.Now,
                    };
                }
                _ctx.SaveChanges();
            }
        }
    }
}
