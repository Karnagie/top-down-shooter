using CodeBase.Infrastructure.CommandCache;
using CodeBase.Infrastructure.CommandCache.Commands;
using CodeBase.Infrastructure.CommandCache.SaveLoad;
using CodeBase.Infrastructure.Services;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CodeBase.Infrastructure.Tests.Edit
{
    public class CommandCacheTests
    {
        [Test]
        public void WhenPerform_AndCommandLogMessage_ThenGetMessageAsLast()
        {
            // Arrange.
            var log = new LogService();
            var services = new InfrastructureServiceHolder(log, null);
            var facade = CreateCommandsFacade(services);

            var test = facade.Create<DebugCommand, DebugCommand.Args>
                (new (){Text = "Test"});
        
            // Act.
            test.Perform();
        
            // Assert.
            Assert.AreEqual(test.LogValue, log.LastLog);
        }

        [Test]
        public void WhenParseArgs_AndValueNotDefault_ThenReturnTheSameValue()
        {
            // Arrange.
            var log = new LogService();
            var services = new InfrastructureServiceHolder(log, null);
            var facade = CreateCommandsFacade(services);

            var args = new DebugCommand.Args(){Text = "Test"};
            var test = facade.Create<DebugCommand, DebugCommand.Args>
                (args);

            // Act.
            var jsonArgs = JsonConvert.SerializeObject(new DebugCommand.Args() {Text = "Test"});
            var converted = JsonConvert.DeserializeObject<DebugCommand.Args>(test.JsonArgs());
        
            // Assert.
            Assert.AreEqual(jsonArgs, test.JsonArgs());
            Assert.AreEqual(converted, args);
        }
    
        [Test]
        public void WhenInitialize_AndWasLogCommand_ThenLogInNewFacade()
        {
            // Arrange.
            var log = new LogService();
            var services = new InfrastructureServiceHolder(log, null);
        
            var service = new CommandCacheService();
            var commandFactory = new CommandFactory(service);
            var saveLoader = new Mock<ICommandSaveLoader<InfrastructureServiceHolder>>();
            var facade = new CommandService<InfrastructureServiceHolder>(commandFactory, service, services, saveLoader.Object);
        
            ICacheCommand[] loadCommands = 
            {
                commandFactory.Create<DebugCommand, DebugCommand.Args, InfrastructureServiceHolder>(
                    new DebugCommand.Args(){Text = "Test"}, 
                    services)
            };
            saveLoader.Setup((loader => loader.LoadAll())).Returns(loadCommands);
        
            var test = facade.Create<DebugCommand, DebugCommand.Args>
                (new (){Text = "Test"});
        
            // Act.
            service = new CommandCacheService();
            facade = new CommandService<InfrastructureServiceHolder>(commandFactory, service, services, saveLoader.Object);
        
            facade.Initialize();
        
            // Assert.
            Assert.AreEqual(test.LogValue, log.LastLog);
        }

        private static CommandService<InfrastructureServiceHolder> CreateCommandsFacade(
            InfrastructureServiceHolder services)
        {
            var service = new CommandCacheService();
            var commandFactory = new CommandFactory(service);
            var saveLoader = new Mock<ICommandSaveLoader<InfrastructureServiceHolder>>();
            var facade = new CommandService<InfrastructureServiceHolder>(commandFactory, service, services, saveLoader.Object);
            return facade;
        }
    }
}