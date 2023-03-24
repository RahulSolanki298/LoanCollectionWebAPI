using API.Dtos;
using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompnayBranchController : ControllerBase
    {
        public readonly ICompnayRepository _companyRepo;

        public CompnayBranchController(ICompnayRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        [HttpGet("GetCompanyBranchList")]
        public async Task<List<CompanyBranchDetail>> GetCompanyBranchList() => await _companyRepo.GetList();

        [HttpGet("GetCompanyBranch/{id}")]
        public async Task<CompanyBranchDetail> GetCompanyBranch(int id) => await _companyRepo.GetFirstOrDefault(id);

        [HttpPost("SaveCompanyBranch")]
        public async Task<ResponsesContent> SaveCompanyBranch(CompanyBranchDetails companyBranchDetails) => await _companyRepo.ToAddOrUpdate(companyBranchDetails);

        [HttpDelete("DeleteCompanyBranch/{id}")]
        public async Task<ResponsesContent> DeleteCompanyBranch(int id) => await _companyRepo.ToDelete(id);
    }
}
