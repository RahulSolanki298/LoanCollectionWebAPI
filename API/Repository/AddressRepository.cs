using API.Dtos;
using API.Interface;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly dbLoanAppContext _context;
        public AddressRepository()
        {
            _context = new dbLoanAppContext();
        }

        public async Task<AddressMasterDto> GetFirstOrDefault(int id)
        {
            var result = await (from address in _context.AddressMasters
                                where address.Id == id
                                select new AddressMasterDto
                                {
                                    Id = address.Id,
                                    AddressFor = address.AddressFor,
                                    AddressLine1 = address.AddressLine1,
                                    AddressLine2 = address.AddressLine2,
                                    City = address.City,
                                    Country = address.Country,
                                    CompanyDetailId = address.CompanyDetailId,
                                    State = address.State,
                                    UserId = address.UserId,
                                    ZipCode = address.ZipCode,
                                }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<AddressMasterDto>> GetList()
        {
            var result = await (from address in _context.AddressMasters
                                select new AddressMasterDto
                                {
                                    Id = address.Id,
                                    AddressFor = address.AddressFor,
                                    AddressLine1 = address.AddressLine1,
                                    AddressLine2 = address.AddressLine2,
                                    City = address.City,
                                    Country = address.Country,
                                    CompanyDetailId = address.CompanyDetailId,
                                    State = address.State,
                                    UserId = address.UserId,
                                    ZipCode = address.ZipCode,
                                }).ToListAsync();
            return result;
        }

        public async Task<ResponsesContent> ToAddOrUpdate(AddressMasterDto address)
        {
            var updateAddress = new AddressMaster();
            ResponsesContent responses = new ResponsesContent();

            if (address.Id > 0)
            {
                updateAddress = await _context.AddressMasters.FindAsync(address.Id);

                updateAddress.AddressLine1 = address.AddressLine1;
                updateAddress.AddressLine2 = address.AddressLine2;
                updateAddress.AddressFor = address.AddressFor;
                updateAddress.UserId = address.UserId;
                updateAddress.CompanyDetailId = address.CompanyDetailId;
                updateAddress.ZipCode = address.ZipCode;
                updateAddress.City = address.City;
                updateAddress.State = address.State;
                updateAddress.Country = address.Country;

                _context.AddressMasters.Update(updateAddress);
            }
            else
            {
                _context.AddressMasters.Add(new AddressMaster()
                {
                    AddressLine1 = address.AddressLine1,
                    AddressLine2 = address.AddressLine2,
                    AddressFor = address.AddressFor,
                    UserId = address.UserId,
                    CompanyDetailId = address.CompanyDetailId,
                    ZipCode = address.ZipCode,
                    City = address.City,
                    State = address.State,
                    Country = address.Country
                });
            }
            await _context.SaveChangesAsync();

            responses.Status = "Success";
            responses.Status = "User registration successfully.";

            return responses;
        }

        public async Task<ResponsesContent> ToDelete(int id)
        {
            var response = await _context.AddressMasters.FindAsync(id);

            if (response != null)
            {
                _context.AddressMasters.Remove(response);
                _context.SaveChanges();

                var result = new ResponsesContent()
                {
                    Status = "Success",
                    Message = $"Address deleted successfully."
                };
                return result;
            }
            return new ResponsesContent() { Status = "Fail", Message = "Data not found. something is invalid." };
        }
    }
}
