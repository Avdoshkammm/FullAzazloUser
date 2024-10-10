using Microsoft.AspNetCore.Mvc;
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
            return View(await _userServoce.GetAllUsers());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var user = await _userServoce.GetUserById(id);
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
            UserDto userDto = await _userServoce.GetUserById(id);
            if(userDto == null)
            {
                return NotFound();
            }
            return View(userDto);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserDto userDto)
        {
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
            var user = await _userServoce.GetUserById(id);
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
