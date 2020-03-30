using Microsoft.AspNetCore.Mvc;
using PeopleManagement.Data;
using PeopleManagement.Data.Entities;
using PeopleManagement.Services;
using PeopleManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IPeopleRepository _repository;
        public PeopleController(IPersonService personService, IPeopleRepository repository)
        {
            _personService = personService;
            _repository = repository;
        }
        public ActionResult Index(string searchBy, string search)
        {
            var results = _repository.GetAllPeople();

            if (searchBy == null)
            {
                return View(results);
            }
            else if (searchBy == "Group")
            {
                return View(results.Where(x => x.Group.GroupName == search || search == null).ToList());
            }
            else
            {
                return View(results.Where(x => x.FirstName.ToLower().Contains(search.ToLower()) || x.LastName.ToLower().Contains(search.ToLower()) || search == null).ToList());
            }

        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.AddEntity(model);
                _repository.SaveAll();
                ModelState.Clear();
            }
            else
            {

            }
            return View();
        }

    }
}
