using Grpc.Core;
using MeterReader.gRPC;
using static MeterReader.gRPC.MeterReaderService;

namespace MeterReader.Services;

public class MeterReadingService : MeterReaderServiceBase
{
    public override async Task<StatusMessage> AddReading(ReadingPacket request, ServerCallContext context)
    {
        if (request.Successful == ReadingStatus.Success)
        {
            return new StatusMessage()
            {
                Notes = "Successfully added to the database.",
                Status = ReadingStatus.Success
            };
        }

        return new StatusMessage()
        {
            Notes = "Failed to store readings in Database",
            Status = ReadingStatus.Success
        };
    }
}
