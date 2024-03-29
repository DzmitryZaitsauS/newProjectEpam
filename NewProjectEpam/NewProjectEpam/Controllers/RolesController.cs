﻿using NewProjectEpam.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

public class RolesController : Controller
{
    private ApplicationRoleManager RoleManager
    {
        get
        {
            return HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();
        }
    }

    public ActionResult Index()
    {
        return View(RoleManager.Roles);
    }

    public ActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create(CreateRoleModel model)
    {
        if (ModelState.IsValid)
        {
            IdentityResult result = await RoleManager.CreateAsync(new ApplicationRole
            {
                Name = model.Name,
                Description = model.Description
            });
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Что-то пошло не так");
            }
        }
        return View(model);
    }

    public async Task<ActionResult> EditRole(string id)
    {
        ApplicationRole role = await RoleManager.FindByIdAsync(id);
        if (role != null)
        {
            return View(new EditRoleModel { Name = role.Name, Description = role.Description });
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<ActionResult> EditRole(EditRoleModel model)
    {
        if (ModelState.IsValid)
        {
            ApplicationRole role = await RoleManager.FindByIdAsync(model.Id);
            if (role != null)
            {
                role.Description = model.Description;
                role.Name = model.Name;
                IdentityResult result = await RoleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Что-то пошло не так");
                }
            }
        }
        return View(model);
    }

    public async Task<ActionResult> Delete(string id)
    {
        ApplicationRole role = await RoleManager.FindByIdAsync(id);
        if (role != null)
        {
            IdentityResult result = await RoleManager.DeleteAsync(role);
        }
        return RedirectToAction("Index");
    }
}