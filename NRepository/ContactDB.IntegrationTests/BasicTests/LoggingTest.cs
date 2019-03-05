using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace ContactDB.IntegrationTests.BasicTests
{
    public class LoggingTest
    {
        // run the test and then click on the "output" link on the bottom of the task runner to see the output
        //https://xunit.github.io/docs/capturing-output
        private readonly ITestOutputHelper output;

        private readonly ILogger<LoggingTest> _logger;

        public LoggingTest(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new XunitLoggerProvider(testOutputHelper));
            _logger = loggerFactory.CreateLogger<LoggingTest>();


        }

        [Fact]
        public void TestLoggingXunitLoggerProvider()
        {
            for (int i = 0; i < 100; i++)
            {
                _logger.LogDebug("TestLoggingXunitLoggerProvider - TEST");
            }

        }

        [Fact]
        public void TestLoggingToOutput()
        {
            for (int i = 0; i < 100; i++)
            {
                output.WriteLine("output.WriteLine TEST");
            }

        }


    }

}
