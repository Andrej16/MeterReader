using Grpc.Core;
using MeterReader.gRPC;
using static MeterReader.gRPC.MeterReaderService;

namespace MeterReader.Services;

public class MeterReadingService : MeterReaderServiceBase
{
    private readonly ILogger<MeterReadingService> _logger;

    public MeterReadingService(ILogger<MeterReadingService> logger)
    {
        _logger = logger;
    }

    public override async Task<StatusMessage> AddReading(ReadingPacket request, ServerCallContext context)
    {
        if (request.Successful == ReadingStatus.Success)
        {
            _logger.LogInformation("Successfully saved.");
            
            return new StatusMessage()
            {
                Notes = "Successfully added to the database.",
                Status = ReadingStatus.Success
            };
        }

        _logger.LogError("Failed to save.");

        return new StatusMessage()
        {
            Notes = "Failed to store readings in Database",
            Status = ReadingStatus.Success
        };
    }
}
