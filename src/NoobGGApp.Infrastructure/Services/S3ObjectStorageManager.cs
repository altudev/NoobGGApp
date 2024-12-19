using System;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Application.Common.Models.ObjectStorage;
using NoobGGApp.Domain.Settings;

namespace NoobGGApp.Infrastructure.Services;

public sealed class S3ObjectStorageManager : IObjectStorage
{
    private readonly S3Settings _s3Settings;
    private readonly IAmazonS3 _s3Client;
    private readonly ICurrentUserService _currentUserService;

    public S3ObjectStorageManager(IOptions<S3Settings> s3Settings, ICurrentUserService currentUserService)
    {
        _s3Settings = s3Settings.Value;
        _s3Client = new AmazonS3Client(
            _s3Settings.AccessKey,
            _s3Settings.SecretKey,
            Amazon.RegionEndpoint.GetBySystemName(_s3Settings.BucketRegion));
        _currentUserService = currentUserService;
    }

    public async Task<string> UploadObjectAsync(UploadObjectRequestDto requestDto, CancellationToken cancellationToken = default)
    {

        // 2385a18f-c23c-417e-9c22-7721ad2a98a3.png
        var objectKey = $"{Guid.NewGuid()}{requestDto.FileExtension}";

        var putRequest1 = new PutObjectRequest
        {
            BucketName = _s3Settings.BucketName,
            Key = objectKey,
            InputStream = new MemoryStream(requestDto.FileBytes),
            ContentType = requestDto.FileType,
        };

        foreach (var metadata in requestDto.Metadata)
            putRequest1.Metadata.Add(metadata.Key, metadata.Value);

        putRequest1.Metadata.Add("UserId", _currentUserService.UserId.ToString());

        PutObjectResponse response1 = await _s3Client.PutObjectAsync(putRequest1);

        return objectKey;
    }

}
