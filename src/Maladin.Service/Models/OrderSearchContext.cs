using Maladin.Data.Enums;

using System.Text.RegularExpressions;

namespace Maladin.Service.Models
{
    public sealed class OrderSearchContext
    {
        public OrderSearchContext(int? userIdOrNull, EOrderState? deliveryStateOrNull, EOrderSearchTarget target, Regex filter, DateTimeOffset start, DateTimeOffset end, int minAmount, int maxAmount, int skip, int take)
        {
            UserIdOrNull = userIdOrNull;
            DeliveryStateOrNull = deliveryStateOrNull;
            FilterTarget = target;
            TextFilter = filter;
            Start = start;
            End = end;
            MinAmount = minAmount;
            MaxAmount = maxAmount;
            Skip = skip;
            Take = take;
        }

        public int? UserIdOrNull { get; init; }
        public EOrderState? DeliveryStateOrNull { get; init; }
        public EOrderSearchTarget FilterTarget { get; init; }
        public Regex TextFilter { get; init; }
        public DateTimeOffset Start { get; init; }
        public DateTimeOffset End { get; init; }
        public int MinAmount { get; init; }
        public int MaxAmount { get; init; }
        public int Skip { get; init; }
        public int Take { get; init; }
    }

    public enum EOrderSearchTarget
    {
        BookTitle,
        ReceiverName
    }
}