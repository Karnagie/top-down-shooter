using CodeBase.Infrastructure.CommandCache;
using CodeBase.Infrastructure.CommandCache.Commands;
using CodeBase.Infrastructure.CommandCache.SaveLoad;
using CodeBase.Infrastructure.Services;
using NUnit.Framework;

namespace CodeBase.Infrastructure.Tests.Edit
{
    public class PlayerPrefsCommandSaveLoaderTests
    {
        [Test]
        public void WhenLoad_AndSetLogCommand_ThenLastLogNotEmpty()
        {
            // Arrange.
            var logService = new LogService();
            var commandCacheService = new CommandCacheService();
            var commandFactory = new CommandFactory(commandCacheService);
            var serviceHolder = new InfrastructureServiceHolder(logService, null);
            var saveLoader = 
                new PlayerPrefsCommandSaveLoader<InfrastructureServiceHolder>(logService, commandFactory, serviceHolder);

            // Act.
            var command = commandFactory.Create<DebugCommand, DebugCommand.Args, InfrastructureServiceHolder>(
                new DebugCommand.Args(){ Text = "Test"},
                serviceHolder);
            saveLoader.Save(command);
        
            logService = new LogService();
            commandCacheService = new CommandCacheService();
            commandFactory = new CommandFactory(commandCacheService);
            serviceHolder = new InfrastructureServiceHolder(logService, null);
            saveLoader = 
                new PlayerPrefsCommandSaveLoader<InfrastructureServiceHolder>(logService, commandFactory, serviceHolder);
        
            var commands = saveLoader.LoadAll();
            foreach (var c in commands)
            {
                c.Perform();
            }
        

            // Assert.
            Assert.AreEqual(command.LogValue, logService.LastLog);
        }
    }
}