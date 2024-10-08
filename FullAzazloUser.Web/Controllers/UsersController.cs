using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FullAzazloUser.Domain.Entities;
using FullAzazloUser.Infrastructure.Data;
using FullAzazloUser.Application.Interfaces;
using FullAzazloUser.Application.DTOs;

namespace FullAzazloUser.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userServoce;

        public UsersController(IUserService userServoce)
        {
            _userServoce = userServoce;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _userServoce.GetAllUsersAsync();
            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userServoce.GetUserByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                await _userServoce.CreateUser(userDto);
                return RedirectToAction(nameof(Index));
            }
            return View(userDto);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var userDto = await _userServoce.GetUserByIdAsync(id);
            if(userDto == null)
            {
                return NotFound();
            }
            return View(userDto);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserDto userDto)
        {
        //    if (id != userDto.Id)
        //    {
        //        return NotFound();
        //    }

            if (ModelState.IsValid)
            {
                await _userServoce.UpdateUser(userDto);
                return RedirectToAction(nameof(Index));
            }
            return View(userDto);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userServoce.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userServoce.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
