using People.DataLayer.Entities;
using People.Manager.Dtos;

namespace People.Manager.Mappers
{
    public static class AddessDtoMapper
    {
        public static AddressDto Map(Person source)
        {
            if (source == null)
                return null;

            return new AddressDto
            {
                StreetAddress = source.Address.StreetAddress,
                City = source.Address.City,
                State = source.Address.State.ToString(),
                PostalCode = source.Address.PostalCode,
            };
        }

    }
}
