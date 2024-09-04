using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Mvc;
using S3.Dtos;

[ApiController]

public class FileController : ControllerBase
{
    const string accessKeyId = "SEU_ACCESS_KEY";
    const string secretAccessKey = "SUA_SECRET_ACCESS_KEY";

    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromBody] FileUploadDto dto)
    {
        try
        {
            byte[] fileBytes = Convert.FromBase64String(dto.ContentBase64);
            using var stream = new MemoryStream(fileBytes);

            var request = new TransferUtilityUploadRequest
            {
                InputStream = stream,
                Key = dto.Key,
                BucketName = "NOME_DO_BUCKET",
                CannedACL = S3CannedACL.NoACL
            };

            using var client = new AmazonS3Client(accessKeyId, secretAccessKey, RegionEndpoint.SAEast1);
            var transferUtility = new TransferUtility(client);

            await transferUtility.UploadAsync(request);

            return Ok(new { Message = "Arquivo enviado para o Bucket S3!" });

        }
        catch (AmazonS3Exception s3Ex)
        {
            return BadRequest(s3Ex.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}

