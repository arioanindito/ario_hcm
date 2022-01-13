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

        //GET: Administrator/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var result = await _userClient.GetAsync(id);

            return View(new AdministratorViewModel
            {
                Id = result.Id,
                Username = result.Username,
                Email = result.Email,
                Phone = result.Phone,
            });
        }

        // POST: Administrator/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(
            [FromRoute] string id,
            [FromForm] AdministratorViewModel administratorViewModel)
        {
            try
            {
                var result = await _userClient.PutAsync(id, new UpdateAdministratorDto
                {
                    Username = administratorViewModel.Username,
                    Email = administratorViewModel.Email,
                    Phone = administratorViewModel.Phone,
                    Id = id,
                });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrator/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _userClient.GetAsync(id);
            return View(new AdministratorViewModel
            {
                Id = result.Id,
                Username = result.Id,
                Email = result.Email,
                Password = result.Password,
                Phone = result.Phone,
                Role = result.Role
            });
        }

        // POST: Administrator/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, IFormCollection collection)
        {
            try
            {
                await _userClient.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}