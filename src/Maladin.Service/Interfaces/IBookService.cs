using Microsoft.EntityFrameworkCore;

using Maladin.Data.Models;
using Maladin.Service.Models;

namespace Maladin.Service.Interfaces
{
    public interface IBookService
    {
        /// <summary>
        /// 신규 <see cref="Book"/> 개체를 추가합니다
        /// </summary>
        /// <param name="bookContext"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult<Book>> AddBookAsync(BookContext bookContext);

        /// <summary>
        /// 해당 <see cref="Book"/> 개체를 반환합니다
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public Task<ServiceResult<Book?>> GetBookOrNullAsync(int bookId);

        /// <summary>
        /// 해당 <see cref="Book"/> 개체를 변경합니다
        /// </summary>
        /// <param name="bookContext"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult<Book>> UpdateBookAsync(int bookId, BookContext bookContext);

        /// <summary>
        /// 해당 <see cref="Book"/> 개체를 삭제합니다
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public Task<ServiceResult> RemoveBookAsync(int bookId);
    }
}