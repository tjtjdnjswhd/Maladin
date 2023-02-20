using Maladin.Data.Models;
using Maladin.Service.Models;

namespace Maladin.Service.Interfaces
{
    public interface IAdminService
    {
        /// <summary>
        /// 새 <see cref="Role"/> 개체를 추가합니다
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        public Task<ServiceResult> AddRoleAsync(string roleName, int priority);

        /// <summary>
        /// 존재하는 <see cref="Role"/> 개체들을 반환합니다
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResult<IEnumerable<Role>>> GetRolesAsync();

        /// <summary>
        /// <see cref="User.Role"/>을 변경합니다
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public Task<ServiceResult> UpdateRoleAsync(int userId, int roleId);
    }
}