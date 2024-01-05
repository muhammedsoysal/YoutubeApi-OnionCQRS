using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Exception;

public class EmailAddressShouldBeValidException : BaseException
{
	public EmailAddressShouldBeValidException() : base("Böyle bir email adresi bulunmamaktadır.") { }
}