using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Entities;
using MVC_Sample.Models;

namespace MVC_Sample.Controllers
{
    public class PeopleController : Controller
    {
        public ActionResult Index()
        {
            PeopleViewModel viewModel = new PeopleViewModel(PersonsBL.People);

            return View("PeopleView",viewModel);
            //return View("PeopleView");
        }

        public ActionResult Delete(int id)
        {
            var personToRemove = PersonsBL.People.FirstOrDefault(x => x.Id == id);

            PersonsBL.People.Remove(personToRemove);

            PeopleViewModel viewModel = new PeopleViewModel(PersonsBL.People);

            return View("PeopleView", viewModel);
        }
    }
}