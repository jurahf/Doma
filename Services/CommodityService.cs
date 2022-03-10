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
    public class CommodityService : BaseEntityService<CommodityViewModel, Commodity>, ICommodityService
    {
        public CommodityService(
            ICommodityRepository repository,
            IEntityViewModelConverter<CommodityViewModel, Commodity> converter)
            : base(repository, converter)
        {
        }
    }
}
