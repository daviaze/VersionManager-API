using Riok.Mapperly.Abstractions;
using VersionManager.Application.Dtos.Contracts;
using VersionManager.Domain.Entities;

namespace VersionManager.Application.Mappers
{
    [Mapper]
    public static partial class ContractMapper
    {
        [MapProperty(nameof(Contract.ExternalId), nameof(ContractReadDto.Id))]
        [MapProperty(nameof(Contract.Status), nameof(ContractReadDto.Status))]
        [MapProperty(nameof(Contract.UpdatedAt), nameof(ContractReadDto.UpdatedAt))]
        [MapProperty(nameof(Contract.CreatedAt), nameof(ContractReadDto.CreatedAt))]
        [MapperIgnoreSource(nameof(Contract.Id))]
        [MapperIgnoreSource(nameof(Contract.Customers))]
        [MapperIgnoreTarget(nameof(Contract.Customers))]
        [MapperIgnoreSource(nameof(Contract.Systems))]
        [MapperIgnoreTarget(nameof(Contract.Systems))]
        public static partial ContractReadDto MapToReadDto(this Contract contract);
        public static Contract MapToContract(this ContractCreateDto contract)
            => Contract.Create([..contract.Customers], [..contract.Systems]);
    }
}
