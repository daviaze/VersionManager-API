using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionManager.Domain.Entities.VersionAggregate;

namespace VersionManager.Application.Dtos.Launchs
{
    public sealed record LaunchReadDto(Guid Id, string Message, Guid VersionId,
        bool AllowedForAllContracts, bool RequiredAcceptance, DateTime CreatedAt, DateTime? UpdateAt);
}
