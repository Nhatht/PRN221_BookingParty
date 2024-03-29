﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BO;
using PartyService;
using CloudinaryDotNet.Actions;
using Newtonsoft.Json;
using PRN221_WebNovel.Models;
using BO.enums;
using PartyService.ViewModel;

namespace PRN221_GroupProjectBookParty.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;

        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IList<Account> Account { get;set; } = default!;
        public string role { get; set; }
        public IActionResult OnGet()
        {
            var loginUserJson = HttpContext.Session.GetString("loginUser");
            if (loginUserJson != null)
            {
                var loginUser = JsonConvert.DeserializeObject<AccountViewmodel>(loginUserJson);
                role = loginUser.Role;
                if (role == "Admin")
                {
                    Account = _accountService.GetListAccount();
                    return Page();
                }
                else
                {
                    HttpContext.Session.Clear();
                    TempData["ErrorMessage"] = "You must be an administrator to perform this action.";
                    return RedirectToPage("/Authentication/Login");
                }
            }
            TempData["ErrorMessage"] = "You must be an administrator to perform this action.";
            return RedirectToPage("/Authentication/Login");
        }
        public async Task<IActionResult> OnPostConfirm(int id)
        {
            try
            {
                var bk = _accountService.GetAccountById(id);
                bk.Status = true;
                _accountService.UpdateAccount(bk);
                ViewData["Notification"] = new Notification
                {
                    Message = "Record Updated Successfully !",
                    Type = NotificationType.Success
                };
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something Went Wrong !" + ex,
                    Type = NotificationType.Error
                };
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCancel(int id)
        {
            try
            {
                var bk = _accountService.GetAccountById(id);
                bk.Status = false;
                _accountService.UpdateAccount(bk);

                ViewData["Notification"] = new Notification
                {
                    Message = "Record Updated Successfully !",
                    Type = NotificationType.Success
                };
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something Went Wrong !" + ex,
                    Type = NotificationType.Error
                };
            }

            return RedirectToPage();
        }
    }
}
