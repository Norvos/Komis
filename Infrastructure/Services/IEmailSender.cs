using System.Threading.Tasks;

namespace Komis.Infrastructure.Services
{
    public interface IEmailSender : IService
    {
       Task SendEmail(string to, string subject, string body);
    }
}
