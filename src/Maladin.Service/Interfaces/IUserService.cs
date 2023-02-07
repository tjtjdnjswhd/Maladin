using Maladin.Data.Models;
using Maladin.Service.Models;

namespace Maladin.Service.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// 해당하는 <see cref="User"/> 개체를 반환합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<ServiceResult<User?>> GetUserOrNullAsync(int userId);

        /// <summary>
        /// 해당 유저의 멤버십을 반환합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<ServiceResult<Membership?>> GetUserMembershipOrNullAsync(int userId);

        /// <summary>
        /// 해당 유저의 멤버십을 변경합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="membershipId"></param>
        /// <returns></returns>
        public Task<ServiceResult> SetUserMembershipAsync(int userId, int membershipId);

        /// <summary>
        /// 해당 유저의 포인트 잔액을 반환합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<ServiceResult<int>> GetPointBalanceAsync(int userId);

        /// <summary>
        /// 해당 유저의 포인트 정보를 반환합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<ServiceResult<IEnumerable<Point>>> GetPointsDetailAsync(int userId);

        /// <summary>
        /// 해당 유저의 포인트를 추가합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="amount"></param>
        /// <param name="expireAt"></param>
        /// <returns></returns>
        public Task<ServiceResult> AddPointAsync(int userId, int amount, DateTimeOffset expireAt);

        /// <summary>
        /// 해당 유저의 포인트를 줄입니다
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public Task<ServiceResult> ReducePointAsync(int userId, int amount);

        /// <summary>
        /// 해당 유저의 배송 주소를 추가합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="address"></param>
        /// <param name="isDefault"></param>
        /// <returns></returns>
        public Task<ServiceResult> AddAddressAsync(int userId, string address, bool isDefault);

        /// <summary>
        /// 해당 유저의 기본 배송 주소를 반환합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<ServiceResult<UserAddress?>> GetDefaultAddressOrNullAsync(int userId);

        /// <summary>
        /// 해당 유저의 모든 주소를 반환합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<ServiceResult<IEnumerable<UserAddress>>> GetAddressesAsync(int userId);

        /// <summary>
        /// 해당 주소를 삭제합니다
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public Task<ServiceResult> RemoveAddressAsync(int addressId);

        /// <summary>
        /// 모든 <see cref="Membership"/> 개체를 반환합니다
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResult<IEnumerable<Membership>>> GetMembershipsAsync();
    }
}