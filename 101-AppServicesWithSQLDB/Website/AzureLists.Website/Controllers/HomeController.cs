﻿using AzureLists.Website.Models;
using AzureLists.Website.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AzureLists.Website.Controllers
{
    public class HomeController : Controller
    {
        private ListsService _listsService;

        public HomeController()
        {
            _listsService = new ListsService();
        }

        public async Task<ActionResult> Index(string list = null)
        {
            var vm = new ListsViewModel()
            {
                Lists = await _listsService.GetAllLists()
            };
            vm.SelectedList = (list != null) 
                ? vm.Lists.SingleOrDefault(x => x.Id == list)
                : vm.Lists[0];

            if (vm.SelectedList == null)
                return RedirectToAction("Index");

            return View(vm);
        }

   
    }
}