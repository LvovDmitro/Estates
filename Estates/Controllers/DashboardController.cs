using CloudinaryDotNet.Actions;
using Estates.Data;
using Estates.Interfaces;
using Estates.Models;
using Estates.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Estates.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;

        public DashboardController(IDashboardRepository dashboardRepository, 
            IHttpContextAccessor httpContextAccessor, IPhotoService photoService) 
        {
            _dashboardRepository = dashboardRepository;
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
        }

        private void MapUserEdit(AppUser user, EditUserDashboardViewModel editVM, ImageUploadResult photoResult)
        {
            user.Id = editVM.Id;
            user.Price = editVM.Price;
            user.Money = editVM.Money;
            user.ProfileImageUrl = photoResult.Url.ToString();
            user.State = editVM.State;
            user.City = editVM.City;
        }
        public async Task<IActionResult> Index()
        {
            var userRooms = await _dashboardRepository.GettAllUserRooms();
            var userFlats = await _dashboardRepository.GettAllUserFlats();
            var dashboardViewModel = new DashboardViewModel()
            {
                Rooms = userRooms,
                Flats = userFlats
            };
            return View(dashboardViewModel);
        }

        public async Task<IActionResult> EditUserProfile()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var user = await _dashboardRepository.GetUserById(curUserId);
            if (user == null) return View("Error");
            var editUserViewModel = new EditUserDashboardViewModel()
            {
                Id = curUserId,
                Price = user.Price,
                Money = user.Money,
                ProfileImageUrl = user.ProfileImageUrl,
                City = user.City,
                State = user.State

            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserDashboardViewModel editVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditUserProfile", editVM);
            }

            var user = await _dashboardRepository.GetByIdNoTracking(editVM.Id);

            if (user.ProfileImageUrl == "" || user.ProfileImageUrl == null)
            {
                var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

                MapUserEdit(user, editVM, photoResult);

                _dashboardRepository.Update(user);
                return RedirectToAction("Index");
                
            }
            else{
                try
                {
                    await _photoService.DeletePhotoAsync(user.ProfileImageUrl);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(editVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

                MapUserEdit(user, editVM, photoResult);

                _dashboardRepository.Update(user);
                return RedirectToAction("Index");
            }
        }
    }
}
