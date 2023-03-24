using API.Dtos;

namespace API.Interface
{
    public interface ICustomerLoanManagerRepository
    {
        Task<List<CustomerLoanDTO>> GetList();

        Task<CustomerLoanDTO> GetFirstOrDefault(int customerId);

        Task<ResponsesContent> ToAddOrUpdate(CustomerLoanDTO customerLoan);

    }
}
