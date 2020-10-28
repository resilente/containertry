using System;
using Serilog;
using Serilog.Sinks.Loki;

namespace containerdev
{
    class Program
    {
        private const string Url = "http://localhost:3100";

        static void Main(string[] args) => TestLog();

        static void TestLog()
        {
            var credentials = new NoAuthCredentials(Url); // Address to local or remote Loki server

            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .Enrich.WithProperty("context", "product")
                    .Enrich.WithProperty("context_category", "proof-of-concept")
                    .Enrich.WithProperty("context_application", "ConsoleAppLogMetrics")
                    .Enrich.WithProperty("context_request", Guid.NewGuid().ToString())
                    .Enrich.FromLogContext()
                    .WriteTo.LokiHttp(credentials)
                    .CreateLogger();

            //var exception = new { Message = ex.Message, StackTrace = ex.StackTrace };
            //Log.Error(exception);

            var position = new { Latitude = 25, Longitude = 134 };
            var elapsedMs = 34;
            Log.Information("Message processed {@Position} in {Elapsed:000} ms.", position, elapsedMs);

            Log.Error(new Exception("simulated exception!!!"), "Unexpected error {errorid}", Guid.NewGuid());

            Log.CloseAndFlush();
        }
    }
}
