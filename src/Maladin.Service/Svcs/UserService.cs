using Maladin.Data;
using Maladin.Data.Models;
using Maladin.Service.Interfaces;
using Maladin.Service.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Maladin.Service.Svcs
{
    public class UserService : IUserService
    {
        private readonly MaladinDbContext _dbContext;
        private readonly ILogger<UserService> _logger;

        public UserService(MaladinDbContext dbContext, ILogger<UserService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<User?>> GetUserOrNullAsync(int userId, CancellationToken cancellationToken = default)
        {
            User? user;
            try
            {
                user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                return ServiceResult<User?>.Canceled;
            }

            ServiceResult<User?> result = user == null ? new(null, EErrorCode.NotExistKey, nameof(userId)) : ServiceResult<User?>.NoError(user);
            return result;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<Membership?>> GetUserMembershipOrNullAsync(int userId, CancellationToken cancellationToken = default)
        {
            Membership? membership;
            try
            {
                membership = await _dbContext.Memberships.AsNoTracking().FirstOrDefaultAsync(m => m.Users.Any(u => u.Id == userId), cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                return ServiceResult<Membership?>.Canceled;
            }

            ServiceResult<Membership?> result = membership == null ? new(null, EErrorCode.NotExistKey, nameof(userId)) : ServiceResult<Membership?>.NoError(membership);
            return result;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult> SetUserMembershipAsync(int userId, int membershipId, CancellationToken cancellationToken = default)
        {
            User? user;
            try
            {
                user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                return ServiceResult.Canceled;
            }

            if (user == null)
            {
                return new ServiceResult(EErrorCode.NotExistKey, nameof(userId));
            }

            user.MembershipId = membershipId;

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (DbUpdateException)
            {
                return new ServiceResult(EErrorCode.NotExistKey, nameof(membershipId));
            }
            catch (OperationCanceledException)
            {
                return ServiceResult.Canceled;
            }

            return ServiceResult.NoError;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<int>> GetPointBalanceAsync(int userId, CancellationToken cancellationToken = default)
        {
            if (!IsUserExist(userId))
            {
                return new ServiceResult<int>(-1, EErrorCode.NotExistKey, nameof(userId));
            }

            try
            {
                int amount = await _dbContext.Points.Where(p => p.UserId == userId && p.ExpireAt.CompareTo(DateTimeOffset.Now) > 0).SumAsync(p => p.Balance, cancellationToken).ConfigureAwait(false);
                return ServiceResult<int>.NoError(amount);
            }
            catch (OperationCanceledException)
            {
                return ServiceResult<int>.Canceled;
            }
        }

        /// <inheritdoc/>
        public ServiceResult<IEnumerable<Point>> GetPointsDetail(int userId)
        {
            if (!IsUserExist(userId))
            {
                return new ServiceResult<IEnumerable<Point>>(Enumerable.Empty<Point>(), EErrorCode.NotExistKey, nameof(userId));
            }

            IEnumerable<Point> points = _dbContext.Points.Where(p => p.UserId == userId && p.ExpireAt.CompareTo(DateTimeOffset.Now) > 0).AsNoTracking().AsEnumerable();
            return ServiceResult<IEnumerable<Point>>.NoError(points);
        }

        /// <inheritdoc/>
        public async Task<ServiceResult> AddAddressAsync(int userId, string address, bool isDefault, CancellationToken cancellationToken = default)
        {
            if (!IsUserExist(userId))
            {
                return new ServiceResult(EErrorCode.NotExistKey, nameof(userId));
            }

            UserAddress userAddress = new()
            {
                UserId = userId,
                Address = address,
                IsDefault = isDefault
            };

            try
            {
                if (isDefault)
                {
                    UserAddress? defaultBefore = await _dbContext.UserAddresses.FirstOrDefaultAsync(a => a.UserId == userId && a.IsDefault, cancellationToken).ConfigureAwait(false);
                    if (defaultBefore != null)
                    {
                        defaultBefore.IsDefault = false;
                    }
                }

                _dbContext.UserAddresses.Add(userAddress);
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (DbUpdateException)
            {
                return ServiceResult.UpdateError;
            }
            catch (OperationCanceledException)
            {
                return ServiceResult.Canceled;
            }

            return ServiceResult.NoError;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<UserAddress?>> GetDefaultAddressOrNullAsync(int userId, CancellationToken cancellationToken = default)
        {
            if (!IsUserExist(userId))
            {
                return new ServiceResult<UserAddress?>(null, EErrorCode.NotExistKey, nameof(userId));
            }

            UserAddress? address;
            try
            {
                address = await _dbContext.UserAddresses.AsNoTracking().FirstOrDefaultAsync(a => a.UserId == userId && a.IsDefault, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                return ServiceResult<UserAddress?>.Canceled;
            }

            return ServiceResult<UserAddress?>.NoError(address);
        }

        /// <inheritdoc/>
        public ServiceResult<IEnumerable<UserAddress>> GetAddresses(int userId)
        {
            if (!IsUserExist(userId))
            {
                return new ServiceResult<IEnumerable<UserAddress>>(null, EErrorCode.NotExistKey, nameof(userId));
            }

            var result = _dbContext.UserAddresses.Where(a => a.UserId == userId).AsNoTracking().AsEnumerable();
            return ServiceResult<IEnumerable<UserAddress>>.NoError(result);
        }

        /// <inheritdoc/>
        public async Task<ServiceResult> RemoveAddressAsync(int addressId, CancellationToken cancellationToken = default)
        {
            try
            {
                UserAddress? address = await _dbContext.UserAddresses.FirstOrDefaultAsync(a => a.Id == addressId, cancellationToken).ConfigureAwait(false);
                if (address == null)
                {
                    return new ServiceResult(EErrorCode.NotExistKey, nameof(addressId));
                }

                _dbContext.UserAddresses.Remove(address);
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (DbUpdateException)
            {
                return ServiceResult.Canceled;
            }

            return ServiceResult.NoError;
        }

        /// <inheritdoc/>
        public ServiceResult<IEnumerable<Membership>> GetMemberships()
        {
            IEnumerable<Membership> memberships = _dbContext.Memberships.AsEnumerable();
            return ServiceResult<IEnumerable<Membership>>.NoError(memberships);
        }

        private bool IsUserExist(int userId)
        {
            return _dbContext.Users.Any(u => u.Id == userId);
        }
    }
}