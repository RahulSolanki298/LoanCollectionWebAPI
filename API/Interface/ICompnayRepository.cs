using API.Dtos;
using API.Models;

namespace API.Interface
{
    public interface ICompnayRepository
    {
        Task<List<CompanyBranchDetail>> GetList();
        Task<CompanyBranchDetail> GetFirstOrDefault(int id);
        Task<ResponsesContent> ToAddOrUpdate(CompanyBranchDetails companyBranchDetails);
        Task<ResponsesContent> ToDelete(int id);
    }
}
