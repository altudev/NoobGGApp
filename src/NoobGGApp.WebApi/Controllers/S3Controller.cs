
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Application.Common.Models.ObjectStorage;
using NoobGGApp.WebApi.Models;

namespace NoobGGApp.WebApi.Controllers
{

    public class S3Controller : ApiControllerBase
    {
        private readonly IObjectStorage _objectStorage;

        public S3Controller(ISender mediator, IObjectStorage objectStorage) : base(mediator)
        {
            _objectStorage = objectStorage;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] S3UploadObjectRequestDto requestDto)
        {
            using var memoryStream = new MemoryStream();
            await requestDto.File.CopyToAsync(memoryStream);
            var fileBytes = memoryStream.ToArray();

            var objectPutRequestDto = new UploadObjectRequestDto(
                fileBytes: fileBytes,
                fileName: requestDto.File.FileName,
                fileExtension: Path.GetExtension(requestDto.File.FileName),
                fileType: requestDto.File.ContentType,
                metadata: new Dictionary<string, string> { { "UserId", "1" } }
            );

            var result = await _objectStorage.UploadObjectAsync(objectPutRequestDto);

            return Ok(result);
        }
    }
}
