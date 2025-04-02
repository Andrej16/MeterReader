using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using MeterReader.gRPC;
using static MeterReader.gRPC.MeterReaderService;

namespace WorkerService1;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly int _customerId;
    private readonly string _serviceUrl;

    public Worker(
        ILogger<Worker> logger, 
        IConfiguration configuration)
    {
        _logger = logger;
        _customerId = configuration.GetValue<int>("CustomerId");
        _serviceUrl = configuration["ServiceUrl"] ?? throw new ArgumentNullException();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Call the gRPC service
            var channel = GrpcChannel.ForAddress(_serviceUrl);
            var client = new MeterReaderServiceClient(channel);

            var packet = new ReadingPacket() { Successful = ReadingStatus.Success };

            for (var i = 0; i < 5; i++)
            {
                var reading = new ReadingMessage()
                {
                    CustomerId = _customerId,
                    ReadingTime = Timestamp.FromDateTime(DateTime.UtcNow),
                    ReadingValue = new Random().Next(1000)
                };

                packet.Readings.Add(reading);
            }

            var statusMessage = client.AddReading(packet);
            if (statusMessage.Status == ReadingStatus.Success)
            {
                _logger.LogInformation("Successfully called gRPC.");
            }
            else
            {
                _logger.LogError("Failed to call gRPC.");
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
