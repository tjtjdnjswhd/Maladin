using Maladin.Data;
using Maladin.Data.Models;
using Maladin.Service.Extensions;
using Maladin.Service.Interfaces;
using Maladin.Service.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

using Utils;

namespace Maladin.Service.Svcs
{
    public class AccountService : IAccountService
    {
        private readonly MaladinDbContext _dbContext;
        private readonly IDistributedCache _cache;
        private readonly IMailService _mailService;
        private readonly ILogger<AccountService> _logger;
        private readonly IExceptionLogger<AccountService> _exceptionLogger;

        public AccountService(MaladinDbContext dbContext, IDistributedCache cache, IMailService mailService, ILogger<AccountService> logger, IExceptionLogger<AccountService> exceptionLogger)
        {
            _dbContext = dbContext;
            _cache = cache;
            _mailService = mailService;
            _logger = logger;
            _exceptionLogger = exceptionLogger;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<bool>> IsEmailExistAsync(string email, CancellationToken cancellationToken = default)
        {
            try
            {
                bool result = await _dbContext.Users.AnyAsync(u => u.Email == email, cancellationToken);
                return ServiceResult<bool>.NoError(result);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<bool>> IsNameExistAsync(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                bool result = await _dbContext.Users.AnyAsync(u => u.Name == name, cancellationToken);
                return ServiceResult<bool>.NoError(result);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<User?>> LoginAsync(string email, string passwordHash, string ip, CancellationToken cancellationToken = default)
        {
            User? user;
            try
            {
                user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }

            if (user == null)
            {
                return new ServiceResult<User?>(null, EErrorCode.NotExist, nameof(email));
            }

            if (user.PasswordHash == null)
            {
                return new ServiceResult<User?>(null, EErrorCode.OAuthOnly);
            }

            if (!user.IsEmailAuthenticated)
            {
                return new ServiceResult<User?>(null, EErrorCode.NeedEmailAuth);
            }

            if (user.PasswordHash == passwordHash)
            {
                user.LastLoginDate = DateTimeOffset.UtcNow;
                user.LastLoginIp = ip;
                try
                {
                    await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    _exceptionLogger.Log(e);
                    throw;
                }

                return ServiceResult<User?>.NoError(user);
            }

            return new ServiceResult<User?>(null, EErrorCode.HashNotMatch);
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<User?>> LoginAsync(int providerId, string nameIdentifier, string ip, CancellationToken cancellationToken = default)
        {
            if (!_dbContext.IsExist<OAuthProvider>(providerId))
            {
                return new ServiceResult<User?>(null, EErrorCode.NotExist, nameof(providerId));
            }

            User? user;
            try
            {
                user = await _dbContext.Users.FirstOrDefaultAsync(u => u.IsOAuth && _dbContext.IsNameIdentifierDuplicate(providerId, nameIdentifier), cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }

            if (user == null)
            {
                return new ServiceResult<User?>(null, EErrorCode.NotExist, nameof(nameIdentifier));
            }

            user.LastLoginDate = DateTimeOffset.UtcNow;
            user.LastLoginIp = ip;

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }

            return ServiceResult<User?>.NoError(user);
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<User?>> SignupAsync(string email, string passwordHash, string name, string ip, CancellationToken cancellationToken = default)
        {
            if (_dbContext.IsUserEmailExist(email))
            {
                return new ServiceResult<User?>(null, EErrorCode.DuplicateUnique, nameof(email));
            }

            if (_dbContext.IsUserNameExist(name))
            {
                return new ServiceResult<User?>(null, EErrorCode.DuplicateUnique, nameof(name));
            }

            int roleId = _dbContext.Roles.First(r => r.Priority == _dbContext.Roles.Min(rr => rr.Priority)).Id;
            int membershipId = _dbContext.Memberships.First(m => m.Level == _dbContext.Memberships.Min(mm => mm.Level)).Id;

            User user = new()
            {
                Email = email,
                PasswordHash = passwordHash,
                Name = name,
                SignupIp = ip,
                SignupAt = DateTimeOffset.UtcNow,
                IsEmailAuthenticated = false,
                IsExpired = false,
                IsLocked = false,
                IsOAuth = false,
                MembershipId = membershipId,
                RoleId = roleId
            };

            _dbContext.Users.Add(user);

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }

            //TODO: 이메일 인증 발송
            throw new NotImplementedException();

            return ServiceResult<User?>.NoError(user);
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<User?>> SignupAsync(int providerId, string nameIdentifier, string email, string name, string ip, CancellationToken cancellationToken = default)
        {
            if (!_dbContext.IsExist<OAuthProvider>(providerId))
            {
                return new ServiceResult<User?>(null, EErrorCode.NotExist, nameof(providerId));
            }

            if (_dbContext.IsUserEmailExist(email))
            {
                return new ServiceResult<User?>(null, EErrorCode.DuplicateUnique, nameof(email));
            }

            if (_dbContext.IsUserNameExist(name))
            {
                return new ServiceResult<User?>(null, EErrorCode.DuplicateUnique, nameof(name));
            }

            if (_dbContext.IsNameIdentifierDuplicate(providerId, nameIdentifier))
            {
                return new ServiceResult<User?>(null, EErrorCode.DuplicateUnique, nameof(nameIdentifier));
            }

            int roleId = _dbContext.Roles.First(r => r.Priority == _dbContext.Roles.Min(rr => rr.Priority)).Id;
            int membershipId = _dbContext.Memberships.First(m => m.Level == _dbContext.Memberships.Min(mm => mm.Level)).Id;

            User user = new()
            {
                Email = email,
                Name = name,
                IsEmailAuthenticated = true,
                IsExpired = false,
                IsLocked = false,
                IsOAuth = true,
                MembershipId = membershipId,
                RoleId = roleId,
                SignupAt = DateTimeOffset.UtcNow,
                SignupIp = ip
            };

            _dbContext.Add(user);
            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }

            return ServiceResult<User?>.NoError(user);
        }

        /// <inheritdoc/>
        public async Task<ServiceResult> WithdrawAsync(int userId, CancellationToken cancellationToken = default)
        {
            User? user =_dbContext.Find<User>(userId);

            if (user == null)
            {
                return new ServiceResult(EErrorCode.NotExist, nameof(userId));
            }

            _dbContext.Remove(user);

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }

            return ServiceResult.NoError;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<bool>> VerifyEmailAsync(string email, string code, CancellationToken cancellationToken = default)
        {
            User? user;
            try
            {
                user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }

            if (user == null)
            {
                return new ServiceResult<bool>(false, EErrorCode.NotExist, nameof(email));
            }

            if (user.IsEmailAuthenticated)
            {
                return ServiceResult<bool>.NoError(true);
            }

            if (_cache.GetString(email) == code)
            {
                user.IsEmailAuthenticated = true;
                try
                {
                    await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    _exceptionLogger.Log(e);
                    throw;
                }

                return ServiceResult<bool>.NoError(true);
            }
            else
            {
                return ServiceResult<bool>.NoError(false);
            }
        }

        /// <inheritdoc/>
        public async Task<ServiceResult> UpdateNameAsync(int userId, string name, string ip, CancellationToken cancellationToken = default)
        {
            User? user = _dbContext.Find<User>(userId);

            if (user == null)
            {
                return new ServiceResult(EErrorCode.NotExist, nameof(userId));
            }

            user.Name = name;
            user.UpdateAt = DateTimeOffset.UtcNow;
            user.UpdateIp = ip;

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }

            return ServiceResult.NoError;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult> UpdateEmailAsync(int userId, string email, string ip, CancellationToken cancellationToken = default)
        {
            User? user = _dbContext.Find<User>(userId);

            if (user == null)
            {
                return new ServiceResult(EErrorCode.NotExist, nameof(userId));
            }

            user.Email = email;
            user.UpdateAt = DateTimeOffset.UtcNow;
            user.UpdateIp = ip;

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }

            return ServiceResult.NoError;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult> UpdatePasswordAsync(int userId, string passwordHash, string ip, CancellationToken cancellationToken = default)
        {
            User? user = _dbContext.Find<User>(userId);

            if (user == null)
            {
                return new ServiceResult(EErrorCode.NotExist, nameof(userId));
            }

            user.PasswordHash = passwordHash;
            user.UpdateAt = DateTimeOffset.UtcNow;
            user.UpdateIp = ip;

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }

            return ServiceResult.NoError;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult> AddOAuthAsync(int userId, int providerId, string nameIdentifier, CancellationToken cancellationToken = default)
        {
            if (!_dbContext.IsExist<OAuthProvider>(providerId))
            {
                return new ServiceResult(EErrorCode.NotExist, nameof(providerId));
            }

            if (_dbContext.IsNameIdentifierDuplicate(providerId, nameIdentifier))
            {
                return new ServiceResult(EErrorCode.DuplicateUnique, nameof(nameIdentifier));
            }

            User? user = _dbContext.Find<User>(userId);

            if (user == null)
            {
                return new ServiceResult(EErrorCode.NotExist, nameof(userId));
            }

            OAuthId oAuthId = new()
            {
                UserId = userId,
                ProviderId = providerId,
                NameIdentifier = nameIdentifier,
            };

            _dbContext.Add(oAuthId);

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }

            return ServiceResult.NoError;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult> RemoveOAuthAsync(int userId, int providerId, CancellationToken cancellationToken = default)
        {
            OAuthId? oAuthId = await _dbContext.OAuthIds.FirstOrDefaultAsync(o => o.UserId == userId && o.ProviderId == providerId, cancellationToken).ConfigureAwait(false);
            if (oAuthId == null)
            {
                return new ServiceResult(EErrorCode.NotExist, nameof(providerId));
            }

            _dbContext.OAuthIds.Remove(oAuthId);

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }

            return ServiceResult.NoError;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult> AddProviderAsync(string providerName, CancellationToken cancellationToken = default)
        {
            OAuthProvider provider = new()
            {
                Name = providerName
            };

            _dbContext.OAuthProviders.Add(provider);

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }

            return ServiceResult.NoError;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult> RemoveProviderAsync(int providerId, CancellationToken cancellationToken = default)
        {
            OAuthProvider? provider = _dbContext.Find<OAuthProvider>(providerId);

            if (provider == null)
            {
                return new ServiceResult(EErrorCode.NotExist, nameof(providerId));
            }

            _dbContext.OAuthProviders.Remove(provider);

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
                throw;
            }

            return ServiceResult.NoError;
        }

        /// <inheritdoc/>
        public ServiceResult<IEnumerable<OAuthProvider>> GetProviders()
        {
            var result = _dbContext.OAuthProviders.AsNoTracking().AsEnumerable();
            return new ServiceResult<IEnumerable<OAuthProvider>>(result, EErrorCode.NoError);
        }
    }
}