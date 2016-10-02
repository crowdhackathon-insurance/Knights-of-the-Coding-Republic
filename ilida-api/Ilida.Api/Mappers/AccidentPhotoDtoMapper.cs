using Ilida.Api.Dtos;
using Ilida.Api.Models;

namespace Ilida.Api.Mappers
{
    public class AccidentPhotoDtoMapper : BaseMapper<AccidentPhoto, AccidentPhotoDto>
    {
        public override AccidentPhotoDto Map(AccidentPhoto photo)
        {
            if (photo == null) return null;

            return new AccidentPhotoDto
            {
                Id = photo.Id,
                Url = photo.Url
            };
        }
    }
}