using Microsoft.AspNetCore.Http;

namespace Dtos;

public class UploadPictureDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public IFormFile ProfilePicture { get; set; }
}