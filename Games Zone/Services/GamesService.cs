
namespace Games_Zone.Services
{
    public class GamesService : IGamesService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _webHost;
        private readonly string _imagesPath;

        public IEnumerable<SelectListItem> UniqueGames { get ; set ; }

        public GamesService(ApplicationDbContext dbContext,IWebHostEnvironment webHost)
        {
            _dbContext = dbContext;
            _webHost = webHost;
            _imagesPath = $"{_webHost.WebRootPath}/{FileSettings.ImagePath}";

            UniqueGames = (from g in _dbContext.Games
                           select g)
                           .Distinct()
                           .Select(ga => new SelectListItem
                           {
                               Value = ga.Id.ToString(),
                               Text = ga.Name,
                           }).ToList();
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            var games =await _dbContext.Games
                .Include(g=>g.Category)
                .Include(g=>g.Devices)
                .ThenInclude(d=>d.Device)
                .AsNoTracking()
                .ToListAsync();
            return  games;
        }

        public async Task<Game>? GetByIdAsync(int? id)
        {
            var game =await _dbContext.Games
                .Include(g => g.Category)
                .Include(g => g.Devices)
                .ThenInclude(d => d.Device)
                .AsNoTracking()
                .SingleOrDefaultAsync(g=>g.Id==id);
            return game;
        }

        public async Task CreateAsync(CreateGameFormViewModel model) // Post method of create
        {

            bool IsAdult = false;
            if (model.AgeRate >= 18)
                IsAdult = true;
            var CoverName = await saveCover(model.Cover);

            Game game = new() //Manual mapping (From CreateGameFormViewModel to Game so that it will be stored on database)
            {
                Name = model.Name.ToLower(),
                Description = model.Description,
                CategoryId = model.CategoryId,
                Cover = CoverName,
                Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList(),
                GameWebsite = model.GameWebsite,
                Rate= model.Rate,
                AgeRate= model.AgeRate,
                isAdult=IsAdult
            };

            await _dbContext.AddAsync(game);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Game?> UpdateAsync(EditGameFormViewModel model)
        {
            bool IsAdult = false;
            if (model.AgeRate >= 18)
                IsAdult = true;

            var game =await _dbContext.Games
                        .Include(g =>g.Devices)
                        .SingleOrDefaultAsync(g => g.Id == model.Id);

            if (game == null)
                return null;

            var hasNewCover =model.Cover is not null;
            var oldCover = game.Cover;

            game.Name = model.Name.ToLower();
            game.Description = model.Description;
            game.CategoryId = model.CategoryId;
            game.Devices = model.SelectedDevices.Select(Id => new GameDevice { DeviceId = Id }).ToList();
            game.GameWebsite = model.GameWebsite;
            game.Rate = model.Rate;
            game.AgeRate = model.AgeRate;
            game.isAdult = IsAdult;

            if (hasNewCover)
                game.Cover = await saveCover(model.Cover!);

            var updatedRows=await _dbContext.SaveChangesAsync();
            if (updatedRows > 0)
            {
                if (hasNewCover)
                {
                    var cover = Path.Combine(_imagesPath, oldCover);
                    File.Delete(cover);
                }
                return game;

            }
            else
            {
                var cover = Path.Combine(_imagesPath, game.Cover);
                File.Delete(cover);

                return null;
            }

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var isDeleted = false;

            var game=await _dbContext.Games.FindAsync(id);

            if (game is null)
                return isDeleted;

            _dbContext.Remove(game);

            var effectedRows=await _dbContext.SaveChangesAsync();
            if (effectedRows > 0)
            {
                isDeleted = true;

                var cover =Path.Combine(_imagesPath, game.Cover);
                File.Delete(cover);
            }
            return isDeleted;
        }

        
        

        public async Task clientCreateAsync(CreateGameFormViewModel model)
        {
            bool IsAdult = false;
            if(model.AgeRate >= 18)
               IsAdult = true;

            var CoverName = await saveCover(model.Cover);
            userGame userGame = new ()
            {
                Name= model.Name.ToLower(),
                Description= model.Description,
                CategoryId= model.CategoryId,
                Cover= CoverName,
                Devices = model.SelectedDevices.Select(d => new userGameDevice { DeviceId = d }).ToList(),
                GameWebsite= model.GameWebsite,
                Rate= model.Rate,
                AgeRate=model.AgeRate,
                isAdult=IsAdult
            };
            await _dbContext.AddAsync(userGame);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Game>> GetByCategoryAsync(int categoryId)
        {
            var games =await _dbContext.Games
                .Include(g => g.Category)
                .Include(g => g.Devices)
                .ThenInclude(d => d.Device)
                .Where(g=>g.CategoryId==categoryId)
                .AsNoTracking()
                .ToListAsync();
            return games;
        }

        public async Task<IEnumerable<Game>>? GetByNameAsync(string? name) 
        {

            #region the code you will write if you dont read documentation
            //if (string.IsNullOrEmpty(name))
            //{
            //    return null;
            //}

            //var lowerCaseName=name.ToLower(); 

            //var Names = _dbContext.Games.Select(g => g.Name).ToList();


            //string? matchedName = null;

            //foreach (var namee in Names)
            //{
            //    var splittedName = namee.Split(' ');

            //    if (lowerCaseName.Split(' ').Length > 1)
            //    {
            //        if(lowerCaseName.Split(' ').Length == 2)
            //        {
            //            if (splittedName[0].ToLower() == lowerCaseName.Split(' ')[0] && splittedName[1].ToLower() == lowerCaseName.Split(' ')[1])
            //            {
            //                matchedName = namee;
            //                break;
            //            }
            //        }

            //        else
            //            matchedName = lowerCaseName;
            //    }



            //    else
            //        if (splittedName[0].ToLower() == lowerCaseName)  
            //        {
            //            matchedName = namee;
            //            break;
            //        }

            //}

            //if(matchedName==null)
            //    return Enumerable.Empty<Game>(); 
            #endregion



            var game =await _dbContext.Games
                .Include(g => g.Category)
                .Include(g => g.Devices)
                .ThenInclude(d => d.Device)
                .AsNoTracking()
                .Where(g => g.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync()
                
                ;
             return game;
        }

        public async Task<IEnumerable<Game>>? GetTopRatedAsync()
        {
            var topRatedGames =await _dbContext.Games
                .Include(g =>g.Category)
                .Include(g => g.Devices)
                .ThenInclude(d => d.Device)
                .OrderByDescending(g=>g.Rate)
                .ToListAsync();

            return topRatedGames;
        }

        //Save image to server and cover name to database
        private async Task<string> saveCover(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var path = Path.Combine(_imagesPath, coverName);

            using var Stream = File.Create(path);
            await cover.CopyToAsync(Stream);
            Stream.Dispose();

            return coverName;
        }

       
    }
}
