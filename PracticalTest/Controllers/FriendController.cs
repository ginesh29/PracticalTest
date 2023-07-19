using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticalTest.Entities;
using PracticalTest.ViewModels;

namespace PracticalTest.Controllers
{
    public class FriendController : BaseController
    {
        public FriendController(ApplicationDbContext context, IMapper mapper)
            : base(context, mapper) { }
        public async Task<IActionResult> Index()
        {
            var friends = await _context.Friends.ToListAsync();
            if (friends == null)
                return NotFound();
            return View(friends);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FriendViewModel friend)
        {
            if (ModelState.IsValid)
            {
                var friendMap = _mapper.Map<Friend>(friend);
                await _context.Friends.AddAsync(friendMap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Edit(Guid guid)
        {
            var friend = await _context.Friends.FirstOrDefaultAsync(m => m.Guid == guid);
            if (guid == Guid.Empty || friend == null)
            {
                return NotFound();
            }
            var friendMap = _mapper.Map<FriendViewModel>(friend);
            return View(friendMap);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid guid, IFormCollection frm)
        {
            var friendObj = await _context.Friends.FirstOrDefaultAsync(m => m.Guid == guid);
            if (guid == Guid.Empty || friendObj == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (friendObj != null)
                {
                    friendObj.FriendName = frm["FriendName"];
                    friendObj.Place = frm["Place"];
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
        public async Task<IActionResult> Delete(Guid guid)
        {
            var friend = await _context.Friends.FirstOrDefaultAsync(m => m.Guid == guid);
            if (guid == Guid.Empty || friend == null)
            {
                return NotFound();
            }
            var friendObj = new FriendViewModel
            {
                FriendId = friend.FriendId,
                FriendName = friend.FriendName,
                Place = friend.Place
            };
            return View(friendObj);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid guid)
        {
            var friendObj = await _context.Friends.FirstOrDefaultAsync(m => m.Guid == guid);
            if (guid == Guid.Empty || friendObj == null)
            {
                return NotFound();
            }
            if (friendObj != null)
            {
                _context.Friends.Remove(friendObj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> ValidateFriendId(int FriendId)
        {
            var isExist = await _context.Friends.AnyAsync(m => m.FriendId == FriendId);
            if (isExist)
                return Json(string.Format(ValidationMessage.ALREADY_EXIST, "Friend Id"));
            return Json(true);
        }
    }
}
