using API.Dtos;
using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet("GetAddress")]
        public async Task<List<AddressMasterDto>> GetAllAddress() => await _addressRepository.GetList();

        [HttpGet("GetAddress/{id}")]
        public async Task<AddressMasterDto> GetAddress(int id) => await _addressRepository.GetFirstOrDefault(id);

        [HttpPost("SaveUser")]
        public async Task<ResponsesContent> SaveAddress(AddressMasterDto addressMasterDto) =>
            await _addressRepository.ToAddOrUpdate(addressMasterDto);

        [HttpDelete("DeleteAddress/{id}")]
        public async Task<ResponsesContent> DeleteAddress(int id) => await _addressRepository.ToDelete(id);
    }
}
