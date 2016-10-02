using FluentAssertions;
using Ilida.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Ilida.Api.Client.Tests
{
    public class IlidaApiClientTests
    {
        [Fact]
        public async Task I_Can_Login()
        {
            var client = new IlidaApiClient();

            var request = new LoginRequest
            {
                Username = "test",
                Password = "test"
            };

            var result = await client.LoginAsync(request);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task I_Can_Create_Accident_Retrieve_And_Accept()
        {
            var client = new IlidaApiClient();

            var createRequest = new CreateAccidentRequest
            {
                OccuredOn = DateTime.UtcNow,
                UserId = 10,
                HasInjuries = true,
                HasOtherVehicleDamages = true,
                HasOtherItemsDamages = true,
                Latitude = 10.12345,
                Longitude = 20.12345,
                AccidentPhotos = new List<string> { "image1", "image2" },
                AccidentParticipants = new List<AccidentParticipantDto>
                {
                    new AccidentParticipantDto
                    {
                        IdCard = "XX123456",
                        IsDriver = true,
                        HasInjuries = true,
                        AccidentCar = new AccidentCarDto
                        {
                            CarPlate = "XXX1234"
                        }
                    }
                }
            };

            var accident = await client.CreateAccidentAsync(createRequest);

            accident.Should().NotBeNull();

            var retrieved = await client.GetAccidentAsync(accident.User.Id, accident.Id);

            retrieved.Should().NotBeNull();

            var acceptRequest = new AcceptAccidentRequest
            {
                AccidentId = retrieved.Id,
                UserId = retrieved.User.Id
            };

            var accepted = await client.AcceptAccidentAsync(acceptRequest);

            accepted.Should().BeTrue();
        }
    }
}
