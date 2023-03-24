using API.Dtos;
using API.Models;

namespace API.Interface
{
    public interface IAddressRepository
    {
        Task<List<AddressMasterDto>> GetList();
        Task<AddressMasterDto> GetFirstOrDefault(int id);
        Task<ResponsesContent> ToAddOrUpdate(AddressMasterDto address);
        Task<ResponsesContent> ToDelete(int id);
    }
}
