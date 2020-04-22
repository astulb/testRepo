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
            PeopleViewModel viewModel = new PeopleViewModel(PersonsBL.GetAll());

            return View("PeopleView",viewModel);
        }

        public ActionResult Delete(int id)
        {
            PersonsBL.Delete(id);

            PeopleViewModel viewModel = new PeopleViewModel(PersonsBL.GetAll());

            return View("PeopleView", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var personToEdit = PersonsBL.GetById(id);

            PersonViewModel viewModel = new PersonViewModel(personToEdit);

            return View("EditPersonView", viewModel);
        }

        [HttpPost]
        public ActionResult EditSubmit(PersonViewModel pvm)
        {
            if (PersonsBL.EmailExists(pvm.Email, pvm.Id))
            {
                ModelState.AddModelError("Email", "Email already exists");
                return View("EditPersonView", pvm);
            }

            PersonsBL.Edit(pvm.Id, pvm.Name, pvm.LastName, pvm.Email, pvm.Phone);

            PeopleViewModel viewModel = new PeopleViewModel(PersonsBL.GetAll());

            return View("PeopleView", viewModel);
        }

        public ActionResult Create()
        {
            return View("CreatePersonView", new PersonViewModel());
        }

        [HttpPost]
        public ActionResult CreateSubmit(PersonViewModel pvm)
        {
            if (PersonsBL.EmailExists(pvm.Email))
            {
                ModelState.AddModelError("Email", "Email already exists");
                return View("CreatePersonView", pvm);
            }
            PersonsBL.Create(pvm.Name, pvm.LastName, pvm.Email, pvm.Phone);

            PeopleViewModel viewModel = new PeopleViewModel(PersonsBL.GetAll());

            return View("PeopleView", viewModel);
        }

        public ActionResult AddFriend(int id)
        {
            PersonsBL.AddFriend(id);

            PeopleViewModel viewModel = new PeopleViewModel(PersonsBL.GetAll());

            return View("PeopleView", viewModel);
        }

        public ActionResult AddPartner(int id)
        {
            Person newPartner = PersonsBL.GetById(id);
            if (!PersonsBL.HasPartner() && newPartner.Partner == null)
            {
                PersonsBL.AddPartner(id);
            }

            PeopleViewModel viewModel = new PeopleViewModel(PersonsBL.GetAll());

            return View("PeopleView", viewModel);
        }

        public ActionResult AddPet(int id)
        {
            PersonsBL.AddPetTo(id);



            PeopleViewModel viewModel = new PeopleViewModel(PersonsBL.GetAll());

            return View("PeopleView", viewModel);
        }
    }
}