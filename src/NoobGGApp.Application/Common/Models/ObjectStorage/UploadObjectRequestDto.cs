namespace NoobGGApp.Application.Common.Models.ObjectStorage;

public sealed record UploadObjectRequestDto
{
    public byte[] FileBytes { get; init; }
    public string FileName { get; init; }
    public string FileExtension { get; init; }
    public string FileType { get; init; }
    public Dictionary<string, string> Metadata { get; init; }

    public UploadObjectRequestDto(byte[] fileBytes, string fileName, string fileExtension, string fileType, Dictionary<string, string> metadata)
    {
        FileBytes = fileBytes;
        FileName = fileName;
        FileExtension = fileExtension;
        FileType = fileType;
        Metadata = metadata;
    }
}
