using Maladin.Data.Models;
using Maladin.Service.Models;

namespace Maladin.Service.Interfaces
{
    public interface IBookDisplay
    {
        /// <summary>
        /// 신규 <see cref="BookDisplay"/> 개체를 추가합니다
        /// </summary>
        /// <param name="bookDisplayContext"></param>
        /// <returns></returns>
        public Task<ServiceResult<BookDisplay>> AddBookDisplayAsync(BookDisplayContext bookDisplayContext);

        /// <summary>
        /// 해당 <see cref="BookDisplay"/> 개체를 반환합니다
        /// </summary>
        /// <param name="bookDisplayId"></param>
        /// <returns></returns>
        public Task<ServiceResult<BookDisplay?>> GetBookDisplayByIdOrNullAsync(int bookDisplayId);

        /// <summary>
        /// 해당 <see cref="BookDisplay"/> 개체를 반환합니다
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public Task<ServiceResult<BookDisplay?>> GetBookDisplayByBookIdOrNullAsync(int bookId);

        /// <summary>
        /// <paramref name="searchContext"/>에 해당하는 <see cref="BookDisplay"/> 개체들을 반환합니다
        /// </summary>
        /// <param name="searchContext"></param>
        /// <returns></returns>
        public Task<ServiceResult<IEnumerable<BookDisplay>>> GetBookDisplaysAsync(BookDisplaySearchContext searchContext);

        /// <summary>
        /// 해당 <see cref="BookDisplay"/> 개체를 변경합니다
        /// </summary>
        /// <param name="bookDisplayId"></param>
        /// <param name="bookDisplayContext"></param>
        /// <returns></returns>
        public Task<ServiceResult<BookDisplay>> UpdateBookDisplayAsync(int bookDisplayId, BookDisplayContext bookDisplayContext);

        /// <summary>
        /// 해당 <see cref="BookDisplay"/> 개체를 삭제합니다
        /// </summary>
        /// <param name="bookDisplayId"></param>
        /// <returns></returns>
        public Task<ServiceResult> RemoveBookDisplayAsync(int bookDisplayId);

        /// <summary>
        /// 신규 <see cref="BookCategory"/> 개체를 추가합니다
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public Task<ServiceResult<BookCategory>> AddBookCategoryAsync(string name, int? parentId);

        /// <summary>
        /// 해당 <see cref="BookCategory"/> 개체를 반환합니다
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public Task<ServiceResult<BookCategory?>> GetBookCategoryOrNullAsync(int categoryId);

        /// <summary>
        /// 해당 <see cref="BookCategory"/> 개체를 변경합니다
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="newName"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public Task<ServiceResult<BookCategory>> UpdateBookCategoryAsync(int categoryId, string newName, int? parentId);

        /// <summary>
        /// 해당 <see cref="BookCategory"/> 개체를 제거합니다
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public Task<ServiceResult> RemoveBookCategoryAsync(int categoryId);

        /// <summary>
        /// 신규 <see cref="Publisher"/> 개체를 추가합니다
        /// </summary>
        /// <param name="name"></param>
        /// <param name="introduce"></param>
        /// <returns></returns>
        public Task<ServiceResult<Publisher>> AddPublisherAsync(string name, string? introduce);

        /// <summary>
        /// 해당 <see cref="Publisher"/> 개체를 반환합니다
        /// </summary>
        /// <param name="publisherId"></param>
        /// <returns></returns>
        public Task<ServiceResult<Publisher>> GetPublisherByIdOrNullAsync(int publisherId);

        /// <summary>
        /// 해당 <see cref="Publisher"/> 개체를 반환합니다
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<ServiceResult<Publisher>> GetPublisherByNameOrNullAsync(string name);

        /// <summary>
        /// 해당 <see cref="Publisher"/> 개체를 변경합니다
        /// </summary>
        /// <param name="publishId"></param>
        /// <param name="newName"></param>
        /// <param name="newIntroduce"></param>
        /// <returns></returns>
        public Task<ServiceResult<Publisher>> UpdatePublisherAsync(int publishId, string newName, string? newIntroduce);

        /// <summary>
        /// 해당 <see cref="Publisher"/> 개체를 제거합니다
        /// </summary>
        /// <param name="publishId"></param>
        /// <returns></returns>
        public Task<ServiceResult> RemovePublisherAsync(int publishId);

        /// <summary>
        /// 신규 <see cref="Author"/> 개체를 추가합니다
        /// </summary>
        /// <param name="name"></param>
        /// <param name="introduce"></param>
        /// <returns></returns>
        public Task<ServiceResult<Author>> AddAuthorAsync(string name, string? introduce);

        /// <summary>
        /// 해당 <see cref="Author"/> 개체를 반환합니다
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public Task<ServiceResult<Author>> GetAuthorByIdOrNullAsync(int authorId);

        /// <summary>
        /// 해당 <see cref="Author"/> 개체를 반환합니다
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<ServiceResult<Author>> GetAuthorByNameOrNullAsync(string name);

        /// <summary>
        /// 해당 <see cref="Author"/> 개체를 변경합니다
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="newName"></param>
        /// <param name="newIntroduce"></param>
        /// <returns></returns>
        public Task<ServiceResult<Author>> UpdateAuthorAsync(int authorId, string newName, string? newIntroduce);

        /// <summary>
        /// 해당 <see cref="Author"/> 개체를 제거합니다
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public Task<ServiceResult> RemoveAuthorAsync(int authorId);

        /// <summary>
        /// 신규 <see cref="Translator"/> 개체를 추가합니다
        /// </summary>
        /// <param name="name"></param>
        /// <param name="introduce"></param>
        /// <returns></returns>
        public Task<ServiceResult<Translator>> AddTranslatorAsync(string name, string? introduce);

        /// <summary>
        /// 해당 <see cref="Translator"/> 개체를 반환합니다
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<ServiceResult<Translator?>> GetTranslatorByNameOrNullAsync(string name);

        /// <summary>
        /// 해당 <see cref="Translator"/> 개체를 반환합니다
        /// </summary>
        /// <param name="translatorId"></param>
        /// <returns></returns>
        public Task<ServiceResult<Translator?>> GetTranslatorByIdOrNullAsync(int translatorId);

        /// <summary>
        /// 해당 <see cref="Translator"/> 개체를 변경합니다
        /// </summary>
        /// <param name="translatorId"></param>
        /// <param name="newName"></param>
        /// <param name="newIntroduce"></param>
        /// <returns></returns>
        public Task<ServiceResult<Translator>> UpdateTranslatorAsync(int translatorId, string newName, string? newIntroduce);

        /// <summary>
        /// 해당 <see cref="Translator"/> 개체를 제거합니다
        /// </summary>
        /// <param name="translatorId"></param>
        /// <returns></returns>
        public Task<ServiceResult> RemoveTranslatorAsync(int translatorId);
    }
}