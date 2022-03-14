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
    public class CityService : BaseEntityService<CityViewModel, City>, ICityService
    {
        public CityService(
            ICityRepository repository, 
            IEntityViewModelConverter<CityViewModel, City> converter)
            : base(repository, converter)
        {
        }
    }
}
