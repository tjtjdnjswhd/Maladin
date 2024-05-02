namespace Maladin.Api.Models
{
    public record PaymentPrepareResponse(int UserId, Guid OrderUid, int Amount, int Point);
}