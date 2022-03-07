﻿using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.COREUI.VMClasses;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.COREUI.Controllers
{
    public class CategoryController : Controller
    {

        ICategoryManager _cMan;

        public CategoryController(ICategoryManager cMan)
        {
            _cMan = cMan;
        }
        public IActionResult CategoryList()
        {

            CategoryVM cvm = new CategoryVM
            {
                Categories = _cMan.GetActives()
            };
            return View(cvm);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            
            TempData["message"] = _cMan.Add(category);
            return RedirectToAction("CategoryList");
        }
    }
}
