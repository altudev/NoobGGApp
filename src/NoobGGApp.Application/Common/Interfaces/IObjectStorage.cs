using NoobGGApp.Application.Common.Models.ObjectStorage;

namespace NoobGGApp.Application.Common.Interfaces;

public interface IObjectStorage
{
    Task<string> UploadObjectAsync(UploadObjectRequestDto requestDto, CancellationToken cancellationToken = default);
}
