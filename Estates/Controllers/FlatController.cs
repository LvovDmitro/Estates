using Estates.Data;
using Estates.Interfaces;
using Estates.Models;
using Estates.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Estates.Controllers
{
    public class FlatController : Controller
    {
        private readonly IFlatRepository _flatRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FlatController(IFlatRepository flatRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {

            _flatRepository = flatRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Flat> flats = await _flatRepository.GetAll();
            return View(flats);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Flat flat = await _flatRepository.GetByIdAsync(id);
            return View(flat);
        }

        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var createFlatViewModel = new CreateFlatViewModel { AppUserId = curUserId };
            return View(createFlatViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFlatViewModel flatVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(flatVM.Image);

                var flat = new Flat
                {
                    Title = flatVM.Title,
                    Description = flatVM.Description,
                    Image = result.Url.ToString(),
                    Price = flatVM.Price,
                    AppUserId = flatVM.AppUserId,
                    Address = new Address
                    {
                        Street = flatVM.Address.Street,
                        City = flatVM.Address.City,
                        State = flatVM.Address.State,
                    }
                };
                _flatRepository.Add(flat);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(flatVM);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var flat = await _flatRepository.GetByIdAsync(id);
            if (flat == null) return View("Error");
            var flatVM = new EditFlatViewModel
            {
                Title = flat.Title,
                Description = flat.Description,
                AddressId = flat.AddressId,
                Address = flat.Address,
                URL = flat.Image,
                FlatCategory = flat.FlatCategory,
                Price = flat.Price,
            };
            return View(flatVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditFlatViewModel flatVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit flat");
                return View("Edit", flatVM);
            }

            var userFlat = await _flatRepository.GetByIdAsyncNoTracking(id);

            if (userFlat != null)
            {
                try
                {
                    //await _photoService.DeletePhotoAsync(userFlat.Image);
                    var fi = new FileInfo(userFlat.Image);
                    var publicId = Path.GetFileNameWithoutExtension(fi.Name);
                    await _photoService.DeletePhotoAsync(publicId);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(flatVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(flatVM.Image);

                var flat = new Flat
                {
                    Id = id,
                    Title = flatVM.Title,
                    Description = flatVM.Description,
                    Image = photoResult.Url.ToString(),
                    AddressId = flatVM.AddressId,
                    Address = flatVM.Address,
                    FlatCategory = flatVM.FlatCategory,
                    Price = flatVM.Price,
                };

                _flatRepository.Update(flat);

                return RedirectToAction("Index");
            }
            else
            {
                return View(flatVM);
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            var flatDetails = await _flatRepository.GetByIdAsync(id);
            if (flatDetails == null) return View("Error");
            return View(flatDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteFlat(int id)
        {
            var flatDetails = await _flatRepository.GetByIdAsync(id);
            if (flatDetails == null) return View("Error");

            _flatRepository.Delete(flatDetails);
            return RedirectToAction("Index");
        }


    }
}
