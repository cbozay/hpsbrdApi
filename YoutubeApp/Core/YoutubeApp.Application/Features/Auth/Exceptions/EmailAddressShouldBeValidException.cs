using YoutubeApp.Application.Bases;

namespace YoutubeApp.Application.Features.Auth.Exceptions
{
    public class EmailAddressShouldBeValidException : BaseException
    {
        public EmailAddressShouldBeValidException() : base("Böyle bir email adresi bulunmamaktadır!")
        {
        }
    }
}
