

namespace Games_Zone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesService _gamesService;

        public GamesController(ICategoriesService categoriesService, IDevicesService devicesService , IGamesService gamesService)
        {
            _categoriesService = categoriesService;
            _devicesService = devicesService;
            _gamesService = gamesService;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            dynamic games =await _gamesService.GetAllAsync();

            

            return View(games);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var game =_gamesService.GetByIdAsync(id);

            if (game is null)
                return NotFound();

            return View(game);
        }

        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Create()
        {
            CreateGameFormViewModel viewModel = new()
            {
                Categories =await _categoriesService.GetSelectListAsync(),
                Devices =await _devicesService.GetSelectedDevicesAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel viewModel)
        {
            if (!ModelState.IsValid) 
            {
                viewModel.Categories =await _categoriesService.GetSelectListAsync();
                viewModel.Devices =await _devicesService.GetSelectedDevicesAsync();
                return View(viewModel);
            }

            await _gamesService.CreateAsync(viewModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var game = await _gamesService.GetByIdAsync(id);

            if (game is null)
                return NotFound();

            EditGameFormViewModel viewModel = new()
            {
                Id =game.Id,
                CategoryId = game.CategoryId,
                Description = game.Description,
                Name = game.Name,
                Categories =await _categoriesService.GetSelectListAsync(),
                Devices =await _devicesService.GetSelectedDevicesAsync(),
                SelectedDevices=game.Devices.Select(d=>d.DeviceId).ToList(),
                CurrentCover = game.Cover,
                GameWebsite =game.GameWebsite
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(EditGameFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories =await _categoriesService.GetSelectListAsync();
                viewModel.Devices =await _devicesService.GetSelectedDevicesAsync();
                return View(viewModel);
            }

            var game =await _gamesService.UpdateAsync(viewModel);

            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id,DeleteGameFormViewModel viewModel)
        {
            var game =_gamesService.GetByIdAsync(id);

            if(game is null)
                return BadRequest();
            

            return View(game);
        }
        

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var game =await _gamesService.DeleteAsync(id);

            return game? RedirectToAction(nameof(Index)) : BadRequest();
        }

        public async Task<IActionResult> DetailsByCategory(int categoryId)
        {
            var games =await _gamesService.GetByCategoryAsync(categoryId);

            ViewBag.CategoryName=games.FirstOrDefault()?.Category.Name + " section";

            return View(games);
        }

    }
}
