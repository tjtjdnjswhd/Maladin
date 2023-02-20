using Maladin.Data.Models;
using Maladin.Service.Models;

namespace Maladin.Service.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// 해당 email이 존재하는지 여부를 반환합니다
        /// </summary>
        /// <param name="email"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ServiceResult<bool>> IsEmailExistAsync(string email, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 유저 이름이 존재하는지 여부를 반환합니다
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ServiceResult<bool>> IsNameExistAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// id/password로 로그인합니다
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="ip"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ServiceResult<User?>> LoginAsync(string email, string password, string ip, CancellationToken cancellationToken = default);

        /// <summary>
        /// OAuth로 로그인합니다
        /// </summary>
        /// <param name="providerId"></param>
        /// <param name="nameIdentifier"></param>
        /// <param name="ip"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ServiceResult<User?>> LoginAsync(int providerId, string nameIdentifier, string ip, CancellationToken cancellationToken = default);

        /// <summary>
        /// id/password로 가입합니다
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="ip"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ServiceResult<User?>> SignupAsync(string email, string password, string name, string ip, CancellationToken cancellationToken = default);

        /// <summary>
        /// OAuth로 가입합니다
        /// </summary>
        /// <param name="providerId"></param>
        /// <param name="nameIdentifier"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        /// <param name="cancellationToken"></param>
        public Task<ServiceResult<User?>> SignupAsync(int providerId, string nameIdentifier, string email, string name, string ip, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당 회원을 탈퇴시킵니다
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ServiceResult> WithdrawAsync(int userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 이메일 인증을 시도합니다
        /// </summary>
        /// <param name="email"></param>
        /// <param name="code"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ServiceResult<bool>> VerifyEmailAsync(string email, string code, CancellationToken cancellationToken = default);

        /// <summary>
        /// 유저의 이름을 변경합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <param name="ip"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ServiceResult> UpdateNameAsync(int userId, string name, string ip, CancellationToken cancellationToken = default);

        /// <summary>
        /// 유저의 이메일을 변경합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <param name="ip"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ServiceResult> UpdateEmailAsync(int userId, string email, string ip, CancellationToken cancellationToken = default);

        /// <summary>
        /// 유저의 비밀번호를 변경합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <param name="ip"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ServiceResult> UpdatePasswordAsync(int userId, string password, string ip, CancellationToken cancellationToken = default);

        /// <summary>
        /// OAuth 연동을 시도합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="providerId"></param>
        /// <param name="nameIdentifier"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ServiceResult> LinkOAuthAsync(int userId, int providerId, string nameIdentifier, CancellationToken cancellationToken = default);

        /// <summary>
        /// OAuth 연동을 해제합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="providerId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// 
        public Task<ServiceResult> UnlinkOAuthAsync(int userId, int providerId, CancellationToken cancellationToken = default);
        /// <summary>
        /// 새로운 <see cref="OAuthProvider"/> 개체를 추가합니다
        /// </summary>
        /// <param name="providerName"></param>
        /// <returns></returns>
        public Task<ServiceResult> AddProviderAsync(string providerName, CancellationToken cancellationToken = default);

        /// <summary>
        /// 해당하는 <see cref="OAuthProvider"/> 개체를 제거합니다
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns></returns>
        public Task<ServiceResult> RemoveProviderAsync(int providerId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 존재하는 <see cref="OAuthProvider"/> 개체들을 반환합니다
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResult<IEnumerable<OAuthProvider>>> GetProvidersAsync(CancellationToken cancellationToken = default);
    }
}