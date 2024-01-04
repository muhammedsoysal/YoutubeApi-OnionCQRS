using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Exception;

public class EmailOrPasswordShouldNotBeInvalid : BaseException
{
	public EmailOrPasswordShouldNotBeInvalid() : base("Kullanıcı adı veya şifre yanlıştır!") { }
}