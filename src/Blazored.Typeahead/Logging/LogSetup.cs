using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace Blazored.Typeahead.Logging
{
    public enum LogOptions
    {
        LogWithInjectedLogger,
        LogToConsole
    }
    
    public static class LogSetupStatic
    {
        internal static ILogger Logger;
        
        public static IApplicationBuilder AddLoggingBlazoredTypeahead(this IApplicationBuilder app, LogOptions options)
        {
            if (options == LogOptions.LogWithInjectedLogger)
                Logger = (ILogger)app.ApplicationServices.GetService(typeof(ILogger<BlazoredLogger>));
            else if (options == LogOptions.LogToConsole)
                Logger = new BlazoredLogger();
            
            return app;
        }
    }

    public class BlazoredLogger : ILogger
    {
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Console.Write($"{Environment.NewLine}{logLevel}: {formatter(state, exception)}");
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // do nothing
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            // do nothing
            return null;
        }
    }
}