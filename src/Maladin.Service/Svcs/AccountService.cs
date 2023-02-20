using MailKit.Net.Smtp;

using Maladin.Data;
using Maladin.Data.Models;
using Maladin.Service.Interfaces;
using Maladin.Service.Models;
using Maladin.Service.Settings;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using MimeKit;

namespace Maladin.Service.Svcs
{
    public class AccountService : IAccountService
    {
        private readonly MaladinDbContext _dbContext;
        private readonly ILogger<AccountService> _logger;

        public AccountService(MaladinDbContext dbContext, SmtpClient smtpClient, ILogger<AccountService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<bool>> IsEmailExistAsync(string email, CancellationToken cancellationToken = default)
        {
            try
            {
                bool result = await _dbContext.Users.AnyAsync(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase), cancellationToken);
                return ServiceResult<bool>.NoError(result);
            }
            catch (OperationCanceledException)
            {
                return ServiceResult<bool>.Canceled;
            }
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<bool>> IsNameExistAsync(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                bool result = await _dbContext.Users.AnyAsync(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase), cancellationToken);
                return ServiceResult<bool>.NoError(result);
            }
            catch (OperationCanceledException)
            {
                return ServiceResult<bool>.Canceled;
            }
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<User?>> LoginAsync(string email, string passwordHash, string ip, CancellationToken cancellationToken = default)
        {
            User? user;
            try
            {
                user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase), cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                return ServiceResult<User?>.Canceled;
            }

            if (user == null)
            {
                return new ServiceResult<User?>(null, EErrorCode.NotExistEmail, nameof(email));
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
                _dbContext.SaveChanges();
                return ServiceResult<User?>.NoError(user);
            }

            return new ServiceResult<User?>(null, EErrorCode.NotMatchPasswordHash);
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<User?>> LoginAsync(int providerId, string nameIdentifier, string ip, CancellationToken cancellationToken = default)
        {
            if (!_dbContext.OAuthProviders.Any(p => p.Id == providerId))
            {
                return new ServiceResult<User?>(null, EErrorCode.NotExistOAuthProvider);
            }

            User? user;
            try
            {
                user = await _dbContext.Users.FirstOrDefaultAsync(u => u.IsOAuth && u.OauthIds.Any(oauth => oauth.ProviderId == providerId && oauth.NameIdentifier == nameIdentifier), cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                return ServiceResult<User?>.Canceled;
            }

            if (user == null)
            {
                return new ServiceResult<User?>(null, EErrorCode.NotExistNameIdentifier);
            }

            user.LastLoginDate = DateTimeOffset.UtcNow;
            user.LastLoginIp = ip;
            _dbContext.SaveChanges();

            return ServiceResult<User?>.NoError(user);
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<User?>> SignupAsync(string email, string passwordHash, string name, string ip, CancellationToken cancellationToken = default)
        {
            if (_dbContext.Users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                return new ServiceResult<User?>(null, EErrorCode.DuplicateEmail);
            }

            if (_dbContext.Users.Any(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                return new ServiceResult<User?>(null, EErrorCode.DuplicateName);
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
            catch (OperationCanceledException)
            {
                return ServiceResult<User?>.Canceled;
            }
            catch (DbUpdateException)
            {
                return ServiceResult<User?>.UpdateError;
            }

            //TODO: 이메일 인증 발송

            return ServiceResult<User?>.NoError(user);
        }

        /// <inheritdoc/>
        public async Task<ServiceResult<User?>> SignupAsync(int providerId, string nameIdentifier, string email, string name, string ip, CancellationToken cancellationToken = default)
        {
            if (!_dbContext.OAuthProviders.Any(p => p.Id == providerId))
            {
                return new ServiceResult<User?>(null, EErrorCode.NotExistOAuthProvider);
            }

            if (_dbContext.Users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                return new ServiceResult<User?>(null, EErrorCode.DuplicateEmail);
            }

            if (_dbContext.Users.Any(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                return new ServiceResult<User?>(null, EErrorCode.DuplicateName);
            }

            if (_dbContext.OAuthIds.Any(o => o.ProviderId == providerId && o.NameIdentifier == nameIdentifier))
            {
                return new ServiceResult<User?>(null, EErrorCode.DuplicateNameIdentifier);
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
            catch (OperationCanceledException)
            {
                return ServiceResult<User?>.Canceled;
            }
            catch (DbUpdateException)
            {
                return ServiceResult<User?>.UpdateError;
            }

            return ServiceResult<User?>.NoError(user);
        }

        /// <inheritdoc/>
        public Task<ServiceResult> WithdrawAsync(int userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult<bool>> VerifyEmailAsync(string email, string code, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult> UpdateNameAsync(int userId, string name, string ip, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult> UpdateEmailAsync(int userId, string email, string ip, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult> UpdatePasswordAsync(int userId, string password, string ip, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult> LinkOAuthAsync(int userId, int providerId, string nameIdentifier, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult> UnlinkOAuthAsync(int userId, int providerId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult> AddProviderAsync(string providerName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult> RemoveProviderAsync(int providerId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ServiceResult<IEnumerable<OAuthProvider>>> GetProvidersAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
