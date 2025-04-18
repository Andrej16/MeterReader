using Google.Protobuf.WellKnownTypes;
using MeterReader.gRPC;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class AggregatorController : ControllerBase
{
    private readonly MeterReaderService.MeterReaderServiceClient _meterReaderServiceClient;

    public AggregatorController(
        MeterReaderService.MeterReaderServiceClient meterReaderServiceClient)
    {
        _meterReaderServiceClient = meterReaderServiceClient;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CancellationToken cancellationToken)
    {
        ReadingPacket packet = new () { Successful = ReadingStatus.Success };

        for (var i = 0; i < 5; i++)
        {
            ReadingMessage reading = new ()
            {
                CustomerId = i,
                ReadingTime = Timestamp.FromDateTime(DateTime.UtcNow),
                ReadingValue = new Random().Next(1000)
            };

            packet.Readings.Add(reading);
        }

        StatusMessage statusMessage = await _meterReaderServiceClient.AddReadingAsync(
            packet, 
            cancellationToken: cancellationToken);

        if (statusMessage.Status == ReadingStatus.Success)
        {
            return Ok(statusMessage.Notes);
        }

        return BadRequest(statusMessage.Notes);
    }
}
