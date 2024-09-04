using Amazon.S3;
using Microsoft.AspNetCore.Mvc;

[ApiController]

public class FileController : ControllerBase
{
    private readonly IAmazonS3 _s3Client;
    
}