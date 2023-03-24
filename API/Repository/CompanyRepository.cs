using API.Dtos;
using API.Interface;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class CompanyRepository : ICompnayRepository
    {
        public readonly dbLoanAppContext _context;

        public CompanyRepository()
        {
            _context = new dbLoanAppContext();
        }

        public async Task<CompanyBranchDetail> GetFirstOrDefault(int id) => await _context.CompanyBranchDetails.FindAsync(id);

        public async Task<List<CompanyBranchDetail>> GetList() => await _context.CompanyBranchDetails.ToListAsync();

        public async Task<ResponsesContent> ToAddOrUpdate(CompanyBranchDetails companyBranchDetails)
        {
            CompanyBranchDetail updateCompanyBranchDetails = new CompanyBranchDetail();
            ResponsesContent responses = new ResponsesContent();

            if (companyBranchDetails.Id > 0)
            {
                updateCompanyBranchDetails = await _context.CompanyBranchDetails.FindAsync(companyBranchDetails.Id);

                updateCompanyBranchDetails.Title = companyBranchDetails.Title;
                updateCompanyBranchDetails.SubTitle = companyBranchDetails.SubTitle;
                updateCompanyBranchDetails.Description = companyBranchDetails.Description;
                updateCompanyBranchDetails.CompanyRegisterDate = companyBranchDetails.CompanyRegisterDate;
                updateCompanyBranchDetails.Certificate = companyBranchDetails.Certificate;
                updateCompanyBranchDetails.CompanyLogo = companyBranchDetails.CompanyLogo;
                updateCompanyBranchDetails.IsActivated = companyBranchDetails.IsActivated;

                _context.CompanyBranchDetails.Update(updateCompanyBranchDetails);
            }
            else
            {
                _context.CompanyBranchDetails.Add(new CompanyBranchDetail()
                {
                    Title = companyBranchDetails.Title,
                    SubTitle = companyBranchDetails.SubTitle,
                    Description = companyBranchDetails.Description,
                    CompanyRegisterDate = companyBranchDetails.CompanyRegisterDate,
                    Certificate = companyBranchDetails.Certificate,
                    CompanyLogo = companyBranchDetails.CompanyLogo,
                    IsActivated = companyBranchDetails.IsActivated
                });
            }
            await _context.SaveChangesAsync();

            responses.Status = "Success";
            responses.Message = "Company branch created successfully.";

            return responses;
        }

        public async Task<ResponsesContent> ToDelete(int id)
        {
            var response = await _context.CompanyBranchDetails.FindAsync(id);

            if (response != null)
            {
                _context.CompanyBranchDetails.Remove(response);
                _context.SaveChanges();

                var result = new ResponsesContent()
                {
                    Status = "Success",
                    Message = $"{response.Title} is deleted successfully."
                };
                return result;
            }
            return new ResponsesContent() { Status = "Fail", Message = "Data not found. something is invalid." };
        }
    }
}
