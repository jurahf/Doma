using Services.Converters;
using Services.RepositoryDeclaration;
using Services.ServiceDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services
{
    public class HotelService : BaseEntityService<HotelViewModel, Hotel>, IHotelService
    {
        public HotelService(
            IHotelRepository repository,
            IEntityViewModelConverter<HotelViewModel, Hotel> converter)
            : base(repository, converter)
        {
        }
    }
}