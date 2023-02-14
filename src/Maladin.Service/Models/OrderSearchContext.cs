using Maladin.Data.Enums;

using System.Text.RegularExpressions;

namespace Maladin.Service.Models
{
    public sealed class OrderSearchContext
    {
        public OrderSearchContext(int? userIdOrNull, EOrderState deliveryState, EOrderSearchTarget searchTarget, DateTimeOffset startDate, DateTimeOffset endDate, Regex regex, int skip, int take)
        {
            UserIdOrNull = userIdOrNull;
            DeliveryState = deliveryState;
            SearchTarget = searchTarget;
            StartDate = startDate;
            EndDate = endDate;
            Regex = regex;
            Skip = skip;
            Take = take;
        }

        public int? UserIdOrNull { get; init; }
        public EOrderState DeliveryState { get; init; }
        public EOrderSearchTarget SearchTarget { get; init; }
        public DateTimeOffset StartDate { get; init; }
        public DateTimeOffset EndDate { get; init; }
        public Regex Regex { get; init; }
        public int Skip { get; init; }
        public int Take { get; init; }
    }

    public enum EOrderSearchTarget
    {
        OrderId,
        BookName,
        ReciverName
    }
}