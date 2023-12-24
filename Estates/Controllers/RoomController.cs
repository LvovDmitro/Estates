using Estates.Data;
using Estates.Interfaces;
using Estates.Models;
using Estates.Repository;
using Estates.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Estates.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoomController(IRoomRepository roomRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _roomRepository = roomRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Room> rooms = await _roomRepository.GetAll();
            return View(rooms);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Room room = await _roomRepository.GetByIdAsync(id);
            return View(room);
        }

        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createRoomViewModel = new CreateRoomViewModel { AppUserId = curUserId };
            return View(createRoomViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoomViewModel roomVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(roomVM.Image);

                var room = new Room
                {
                    Title = roomVM.Title,
                    Description = roomVM.Description,
                    Image = result.Url.ToString(),
                    Price = roomVM.Price,
                    AppUserId = roomVM.AppUserId,
                    Address = new Address
                    {
                        Street = roomVM.Address.Street,
                        City = roomVM.Address.City,
                        State = roomVM.Address.State,
                    }
                };
                _roomRepository.Add(room);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(roomVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null) return View("Error");
            var roomVM = new EditRoomViewModel
            {
                Title = room.Title,
                Description = room.Description,
                AddressId = room.AddressId,
                Address = room.Address,
                URL = room.Image,
                RoomCategory = room.RoomCategory,
                Price = room.Price,
            };
            return View(roomVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditRoomViewModel roomVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit flat");
                return View("Edit", roomVM);
            }

            var userRoom = await _roomRepository.GetByIdAsyncNoTracking(id);

            if (userRoom != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userRoom.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(roomVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(roomVM.Image);

                var room = new Room
                {
                    RoomCategory = roomVM.RoomCategory,
                    Id = id,
                    Title = roomVM.Title,
                    Description = roomVM.Description,
                    Image = photoResult.Url.ToString(),
                    AddressId = roomVM.AddressId,
                    Address = roomVM.Address,
                    Price = roomVM.Price,
                };

                _roomRepository.Update(room);

                return RedirectToAction("Index");
            }
            else
            {
                return View(roomVM);
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            var roomDetails = await _roomRepository.GetByIdAsync(id);
            if (roomDetails == null) return View("Error");
            return View(roomDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var roomDetails = await _roomRepository.GetByIdAsync(id);
            if (roomDetails == null) return View("Error");

            _roomRepository.Delete(roomDetails);
            return RedirectToAction("Index");
        }
    }
}
