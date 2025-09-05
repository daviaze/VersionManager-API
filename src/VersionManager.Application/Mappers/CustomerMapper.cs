using Riok.Mapperly.Abstractions;
using VersionManager.Application.Dtos.Customers;
using VersionManager.Domain.Entities;

namespace VersionManager.Application.Mappers
{
    [Mapper]
    public static partial class CustomerMapper
    {
        [MapProperty(nameof(Customer.Id), nameof(CustomerReadDto.Id))]
        [MapProperty(nameof(Customer.Name), nameof(CustomerReadDto.Name))]
        [MapProperty(nameof(Customer.Email), nameof(CustomerReadDto.Email))]
        [MapProperty(nameof(Customer.Document), nameof(CustomerReadDto.Document))]
        [MapperIgnoreSource(nameof(Customer.Contracts))]
        public static partial CustomerReadDto MapToReadDto(this Customer customer);
        public static Customer MapToEntity(this CustomerCreateDto customer)
            => Customer.Create(customer.Name, customer.Document, customer.Email);
    }
}
