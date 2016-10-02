using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ilida.Api.Dtos;
using System;

namespace Ilida.Api.Client
{
    public interface IIlidaApi : IDisposable
    {
        Task<bool> AcceptAccidentAsync(AcceptAccidentRequest acceptAccidentRequest, CancellationToken token = default(CancellationToken));
        Task<AccidentDto> CreateAccidentAsync(CreateAccidentRequest createAccidentRequest, CancellationToken token = default(CancellationToken));
        Task<AccidentDto> GetAccidentAsync(long userId, long accidentId, CancellationToken token = default(CancellationToken));
        Task<List<AccidentDto>> GetAccidentsAsync(long userId, CancellationToken token = default(CancellationToken));
        Task<UserDto> LoginAsync(LoginRequest loginRequest, CancellationToken token = default(CancellationToken));
    }
}