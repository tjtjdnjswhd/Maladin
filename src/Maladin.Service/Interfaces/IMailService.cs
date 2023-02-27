using Maladin.Service.Models;

namespace Maladin.Service.Interfaces
{
    public interface IMailService
    {
        public Task<ServiceResult<bool>> SendAsync(MailSendContext mailSendContext, CancellationToken cancellationToken = default);
    }
}