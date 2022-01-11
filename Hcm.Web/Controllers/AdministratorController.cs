using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hcm.Api.Client;
using Hcm.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hcm.Web.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IUserClient _userClient;

        public AdministratorController(IUserClient userClient)
        {
            _userClient = userClient;
        }

        // GET: Administrator
        public async Task<ActionResult> Index()
        {
            var administrators = await _userClient.GetAllAsync();
            
            return View(administrators
                .Select(e => new AdministratorViewModel
                {
                    Id = e.Id,
                    Username = e.Username,
                    Password = e.Password,
                    Phone = e.Phone,
                    Email = e.Email,
                    Role = e.Role
                }).ToArray());
        }

        // GET: Administrator/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //// GET: Administrator/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Administrator/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Administrator/Edit/5
        //public async Task<ActionResult> Edit(string id)
        //{
        //    //var result = await _userClient.GetAsync(id);

        //    //return View(new AdministratorViewModel
        //    //{

        //    //});
        //}

        // POST: Administrator/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(
        //    [FromRoute] string id,
        //    [FromForm] EmployeeViewModel employeeViewModel)
        //{
        //    try
        //    {
        //        if (User.IsInRole("Employee")
        //        && id != User.FindFirst("employeeId").Value)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }

        //        var result = await _userClient.PutAsync(id, new EmployeeUpdateDto
        //        {
        //            Country = employeeViewModel.Country,
        //            FirstName = employeeViewModel.FirstName,
        //            LastName = employeeViewModel.LastName,
        //            Email = employeeViewModel.Email,
        //            AddressLine = employeeViewModel.AddressLine,
        //            City = employeeViewModel.City,
        //            Phone = employeeViewModel.Phone,
        //            PostCode = employeeViewModel.PostCode,
        //        });
        //        if (!User.IsInRole("Employee"))
        //        {
        //            return RedirectToAction(nameof(Index));

        //        }
        //        else
        //        {
        //            return RedirectToAction(nameof(Edit), new { id = id });
        //        }
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Administrator/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administrator/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}