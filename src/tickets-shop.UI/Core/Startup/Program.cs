using tickets_shop.Infrastructure.Database;
using tickets_shop.UI.Features.UIServices.Menu;

namespace tickets_shop.UI.Core.Startup;

/// <summary>
/// The main entry point class for the application.
/// It is responsible for initializing the database, setting up the application's
/// services and dependencies, and starting the main application controller loop.
/// </summary>
static class Program
{
    /// <summary>
    /// The main method executed when the application starts.
    /// </summary>
    /// <param name="args">Command-line arguments (not used).</param>
    static void Main(string[] args)
    {
        // 1. Database Initialization
        using var db = AppDbContext.Create();
        db.Database.EnsureCreated();
        
        // 2. Dependency setup, Initializes all concrete repository implementations
        var (userRepo, eventsRepo, ticketsRepo) = ProgramSetup.InitializeRepositories(db);
        var authenticationService = ProgramSetup.SetUpAuthenticationService(userRepo);
        
        // 3. Initialize the main controller
        var consoleAppController = new ConsoleAppController(authenticationService, new MenuService(), userRepo, eventsRepo, ticketsRepo, db);
        
        consoleAppController.Run();
    }
}