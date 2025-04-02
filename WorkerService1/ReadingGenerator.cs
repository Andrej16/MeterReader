using Google.Protobuf.WellKnownTypes;
using MeterReader.gRPC;

namespace WorkerService1;

public class ReadingGenerator
{
    public Task<ReadingMessage> GenerateAsync(int customerld)
    {
        var reading = new ReadingMessage()
        {
            CustomerId = customerld,
            ReadingTime = Timestamp.FromDateTime(DateTime.UtcNow),
            ReadingValue = new Random().Next(1000)
        };

        return Task.FromResult(reading);
    }
}
