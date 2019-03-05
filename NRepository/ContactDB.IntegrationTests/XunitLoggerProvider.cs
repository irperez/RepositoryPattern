using System;
using System.Collections.Generic;
using System.Text;
using EvitiContact.ContactModel;
using Microsoft.Extensions.Logging;
using Shouldly;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
 
using static ContactDB.IntegrationTests.SliceFixture;
namespace ContactDB.IntegrationTests
{
    //https://stackoverflow.com/questions/46169169/net-core-2-0-configurelogging-xunit-test
    /// <summary>
    /// @myusrn Check the linked xUnit docs, there’s a screenshot of how it looks. 
    /// You will have to click on the “Output” link of the test result in the test explorer panel. – poke Jan 8 at 9:57
    /// </summary>
    public class XunitLoggerProvider : ILoggerProvider
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public XunitLoggerProvider(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new XunitLogger(_testOutputHelper, categoryName);
        }

        public void Dispose()
        { }
    }

    public class XunitLogger : ILogger
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly string _categoryName;

        public XunitLogger(ITestOutputHelper testOutputHelper, string categoryName)
        {
            _testOutputHelper = testOutputHelper;
            _categoryName = categoryName;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return NoopDisposable.Instance;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _testOutputHelper.WriteLine($"{_categoryName} [{eventId}] {formatter(state, exception)}");
            if (exception != null)
            {
                _testOutputHelper.WriteLine(exception.ToString());
            }
        }

        private class NoopDisposable : IDisposable
        {
            public static NoopDisposable Instance = new NoopDisposable();
            public void Dispose()
            { }
        }
    }
}
