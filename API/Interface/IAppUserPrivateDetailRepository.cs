using API.Dtos;
using API.Models;

namespace API.Interface
{
    public interface IAppUserPrivateDetailRepository
    {
        Task<List<AppUserPrivateDetailDto>> GetList();
        Task<AppUserPrivateDetailDto> GetFirstOrDefault(int id);
        Task<ResponsesContent> ToAddOrUpdate(AppUserPrivateDetailDto applicationUser);
        Task<ResponsesContent> ToDelete(int id);
    }
}
