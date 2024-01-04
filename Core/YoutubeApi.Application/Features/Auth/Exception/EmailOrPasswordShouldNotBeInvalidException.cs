using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Exception;

public class EmailOrPasswordShouldNotBeInvalidException : BaseException
{
	public EmailOrPasswordShouldNotBeInvalidException() : base("Kullanıcı adı veya şifre yanlıştır.") { }
}