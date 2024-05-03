namespace Maladin.EFCore.Models.Abstractions
{
    public interface IUserRelationEntity : IEntity
    {
        int UserId { get; }
        User User { get; }
    }
}