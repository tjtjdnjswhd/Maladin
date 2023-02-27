using Maladin.Data.Enums;

using System.Text.RegularExpressions;

namespace Maladin.Service.Models
{
    public sealed class OrderSearchContext
    {
        public OrderSearchContext(int? userIdOrNull, EOrderState deliveryState, EOrderSearchTarget searchTarget, Regex filter, DateTimeOffset start, DateTimeOffset end, int skip, int take)
        {
            UserIdOrNull = userIdOrNull;
            DeliveryState = deliveryState;
            Target = searchTarget;
            Filter = filter;
            Start = start;
            End = end;
            Skip = skip;
            Take = take;
        }

        public int? UserIdOrNull { get; init; }
        public EOrderState DeliveryState { get; init; }
        public EOrderSearchTarget Target { get; init; }
        public Regex Filter { get; init; }
        public DateTimeOffset Start { get; init; }
        public DateTimeOffset End { get; init; }
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