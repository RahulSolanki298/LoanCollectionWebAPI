using API.Dtos;
using API.Helpers;
using API.Interface;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class CustomerLoanManagerRepository : ICustomerLoanManagerRepository
    {
        public readonly dbLoanAppContext _context;

        public CustomerLoanManagerRepository()
        {
            _context = new dbLoanAppContext();
        }

        public async Task<CustomerLoanDTO> GetFirstOrDefault(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerLoanDTO>> GetList()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponsesContent> ToAddOrUpdate(CustomerLoanDTO customerLoan)
        {
            CustomerLoanManager updateCustomerLoanManager = new CustomerLoanManager();
            ResponsesContent responses = new ResponsesContent();

            if (customerLoan.Id > 0)
            {
                updateCustomerLoanManager =
                    await _context.CustomerLoanManagers.Where(x => x.Id == customerLoan.Id).FirstOrDefaultAsync();

                updateCustomerLoanManager.UserId = customerLoan.UserId;
                updateCustomerLoanManager.BranchId = customerLoan.BranchId;
                updateCustomerLoanManager.LoanApplyAmountDate = customerLoan.LoanApplyAmountDate;
                updateCustomerLoanManager.LoanApplyAmount = customerLoan.LoanApplyAmount;
                updateCustomerLoanManager.NoOfDays = customerLoan.NoOfDays;
                updateCustomerLoanManager.NoOfWeeks = customerLoan.NoOfWeeks;
                updateCustomerLoanManager.NoOfMonths = customerLoan.NoOfMonths;
                updateCustomerLoanManager.NoOfYears = customerLoan.NoOfYears;
                updateCustomerLoanManager.IsNoOfDays = customerLoan.IsNoOfDays;
                updateCustomerLoanManager.IsNoOfWeeks = customerLoan.IsNoOfWeeks;
                updateCustomerLoanManager.IsNoOfMonths = customerLoan.IsNoOfMonths;
                updateCustomerLoanManager.IsNoOfYear = customerLoan.IsNoOfYear;
                updateCustomerLoanManager.LoanDate = customerLoan.LoanDate;
                updateCustomerLoanManager.LoanAccNo = customerLoan.LoanAccNo;
                updateCustomerLoanManager.LoanIntrest = customerLoan.LoanIntrest;
                _context.CustomerLoanManagers.Update(updateCustomerLoanManager);

            }
            else
            {
                var customerLoanManager = new CustomerLoanManager();
                customerLoanManager.UserId = customerLoan.UserId;
                customerLoanManager.BranchId = customerLoan.BranchId;
                customerLoanManager.LoanApplyAmountDate = customerLoan.LoanApplyAmountDate;
                customerLoanManager.LoanApplyAmount = customerLoan.LoanApplyAmount;
                customerLoanManager.NoOfDays = customerLoan.NoOfDays;
                customerLoanManager.NoOfWeeks = customerLoan.NoOfWeeks;
                customerLoanManager.NoOfMonths = customerLoan.NoOfMonths;
                customerLoanManager.NoOfYears = customerLoan.NoOfYears;
                customerLoanManager.IsNoOfDays = customerLoan.IsNoOfDays;
                customerLoanManager.IsNoOfWeeks = customerLoan.IsNoOfWeeks;
                customerLoanManager.IsNoOfMonths = customerLoan.IsNoOfMonths;
                customerLoanManager.IsNoOfYear = customerLoan.IsNoOfYear;
                customerLoanManager.CreatedById = customerLoan.CreatedById;
                customerLoanManager.CreatedDate = DateTime.Now;
                customerLoanManager.LoanDate = customerLoan.LoanDate;
                customerLoanManager.LoanAccNo = customerLoan.LoanAccNo;
                customerLoanManager.LoanIntrest = customerLoan.LoanIntrest;
                _context.CustomerLoanManagers.Add(customerLoanManager);
                await _context.SaveChangesAsync();

                int CustomerId = customerLoanManager.Id;

                _context.CustomerLoanManagerStages.Add(new CustomerLoanManagerStage()
                {
                    CustomerLoanManagerId = CustomerId,
                    LoanStagesId = GetLoanStage(LoanStages.Applied)
                });
            }
            await _context.SaveChangesAsync();

            responses.Status = "Success";
            responses.Message = "Loan apply successfully.";

            return responses;
        }

        private int GetLoanStage(string stageName) => _context.LoanStages.Where(x => x.Name == stageName).Select(x => x.Id).FirstOrDefault();
    }
}
