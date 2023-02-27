using Microsoft.EntityFrameworkCore;

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public Task<ServiceResult<User?>> GetUserOrNullAsync(int userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 유저의 멤버십을 반환합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public Task<ServiceResult<Membership?>> GetUserMembershipOrNullAsync(int userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 유저의 멤버십을 변경합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="membershipId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult> SetUserMembershipAsync(int userId, int membershipId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 유저의 포인트 잔액을 반환합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public Task<ServiceResult<int>> GetPointBalanceAsync(int userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 유저의 포인트 정보를 반환합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ServiceResult<IEnumerable<Point>> GetPointsDetail(int userId);

        /// <summary>
        /// 해당 유저의 배송 주소를 추가합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="address"></param>
        /// <param name="isDefault"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult> AddAddressAsync(int userId, string address, bool isDefault, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 유저의 기본 배송 주소를 반환합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public Task<ServiceResult<UserAddress?>> GetDefaultAddressOrNullAsync(int userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 유저의 모든 주소를 반환합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ServiceResult<IEnumerable<UserAddress>> GetAddresses(int userId);

        /// <summary>
        /// 해당 주소를 삭제합니다
        /// </summary>
        /// <param name="addressId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult> RemoveAddressAsync(int addressId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 모든 <see cref="Membership"/> 개체를 반환합니다
        /// </summary>
        /// <returns></returns>
        public ServiceResult<IEnumerable<Membership>> GetMemberships();
    }
}