using API.Dtos;
using API.Interface;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class AppUserPrivateDetailRepository : IAppUserPrivateDetailRepository
    {
        private readonly dbLoanAppContext _context;

        public AppUserPrivateDetailRepository(dbLoanAppContext context)
        {
            _context = context;
        }

        public async Task<AppUserPrivateDetailDto> GetFirstOrDefault(int id)
        {
            var result = await (from privateDetail in _context.AppUserPrivateDetails
                                where privateDetail.Id == id
                                select new AppUserPrivateDetailDto
                                {
                                    Id = privateDetail.Id,
                                    UserId = privateDetail.UserId,
                                    AadharCardNo = privateDetail.AadharCardNo,
                                    AadharCardImagePath = privateDetail.AadharCardImagePath,
                                    PancardNo = privateDetail.PancardNo,
                                    PancardImagePath = privateDetail.PancardImagePath,
                                    BankName = privateDetail.BankName,
                                    BankAccountNo = privateDetail.BankAccountNo,
                                    CheckBooKimgPath = privateDetail.CheckBooKimgPath,
                                    PassBookImgPath = privateDetail.PassBookImgPath,
                                    Ifscode = privateDetail.Ifscode,
                                    ProfileImgPath = privateDetail.ProfileImgPath

                                }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<AppUserPrivateDetailDto>> GetList()
        {
            var result = await (from privateDetail in _context.AppUserPrivateDetails
                                select new AppUserPrivateDetailDto
                                {
                                    Id = privateDetail.Id,
                                    UserId = privateDetail.UserId,
                                    AadharCardNo = privateDetail.AadharCardNo,
                                    AadharCardImagePath = privateDetail.AadharCardImagePath,
                                    PancardNo = privateDetail.PancardNo,
                                    PancardImagePath = privateDetail.PancardImagePath,
                                    BankName = privateDetail.BankName,
                                    BankAccountNo = privateDetail.BankAccountNo,
                                    CheckBooKimgPath = privateDetail.CheckBooKimgPath,
                                    PassBookImgPath = privateDetail.PassBookImgPath,
                                    Ifscode = privateDetail.Ifscode,
                                    ProfileImgPath = privateDetail.ProfileImgPath
                                }).ToListAsync();
            return result;
        }

        public async Task<ResponsesContent> ToAddOrUpdate(AppUserPrivateDetailDto applicationUser)
        {
            var updatePrivateDetail = new AppUserPrivateDetailDto();
            ResponsesContent responses = new ResponsesContent();


            responses.Status = "Success";
            responses.Status = "User registration successfully.";

            return responses;
        }

        public async Task<ResponsesContent> ToDelete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
