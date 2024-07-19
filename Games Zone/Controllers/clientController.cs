
namespace Games_Zone.Controllers
{
    [Authorize(Roles ="client")]
    public class clientController : Controller
    {
        private readonly IGamesService _gamesService;
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _deviceService;

        public clientController(IGamesService gamesService,ICategoriesService categoriesService, IDevicesService deviceService)
        {
            _gamesService = gamesService;
            _categoriesService = categoriesService;
            _deviceService = deviceService;
        }

        [Authorize(Roles = "client")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles ="client")]
        public async Task<IActionResult> Create()
        {
            CreateGameFormViewModel viewModel = new()
            {
                Categories =await _categoriesService.GetSelectListAsync(),
                Devices =await _deviceService.GetSelectedDevicesAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGameFormViewModel viewModel)
        {
            if (!ModelState.IsValid) 
            {
                viewModel.Categories =await _categoriesService.GetSelectListAsync();
                viewModel.Devices =await _deviceService.GetSelectedDevicesAsync();
                return View(viewModel);
                
            }
            await _gamesService.clientCreateAsync(viewModel);
            return RedirectToAction(nameof(ThanksForYourSuggestion));
        }
        
        public async Task<IActionResult> ThanksForYourSuggestion()
        {
            return View();
        }
    }
}
