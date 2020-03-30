using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<PeopleController> _logger;
        public PeopleController(IPersonService personService, IPeopleRepository repository, ILogger<PeopleController> logger)
        {
            _personService = personService;
            _repository = repository;
            _logger = logger;
        }
        public ActionResult Index(string searchBy, string search)
        {
            try
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
                    if (search != null)
                    {
                        return View(results.Where(x => x.FirstName.ToLower().Contains(search.ToLower()) || x.LastName.ToLower().Contains(search.ToLower()) || search == null).ToList());
                    }
                    else
                    {
                        return View(results);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"There is an error in search{ex}");
                return BadRequest("There is an error in search");
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
                var grp = _repository.GetGroupsByGroupName(model.Group);

                var _person = new Person
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    Email = model.Email,
                    CreatedDate = DateTime.Now,
                    Group = grp
                };
                _repository.AddEntity(_person);
                _repository.SaveAll();
                ModelState.Clear();
            }
            else
            {

            }
            return RedirectToAction("Index");
        }

    }
}
