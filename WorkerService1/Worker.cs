namespace WorkerService1;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ReadingGenerator _readingGenerator;
    private readonly int _customerId;

    public Worker(ILogger<Worker> logger, ReadingGenerator readingGenerator,
        IConfiguration configuration)
    {
        _logger = logger;
        _readingGenerator = readingGenerator;
        _customerId = configuration.GetValue<int>("CustomerId");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Call the gRPC service

            await Task.Delay(1000, stoppingToken);
        }
    }
}
