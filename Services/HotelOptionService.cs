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
    public class HotelOptionService : BaseEntityService<HotelOptionViewModel, HotelOption>, IHotelOptionService
    {
        public HotelOptionService(
            IHotelOptionRepository repository,
            IEntityViewModelConverter<HotelOptionViewModel, HotelOption> converter)
            : base(repository, converter)
        {
        }
    }
}