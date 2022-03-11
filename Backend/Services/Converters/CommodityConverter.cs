using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services.Converters
{
    public class CommodityConverter : IEntityViewModelConverter<CommodityViewModel, Commodity>
    {
        public Commodity ConvertToStoredModel(CommodityViewModel viewModel, bool withRelations = true)
        {
            if (viewModel == null)
                return null;

            return new Commodity()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
            };
        }

        public CommodityViewModel ConvertToViewModel(Commodity dbModel, bool withRelations = true)
        {
            if (dbModel == null)
                return null;

            return new CommodityViewModel()
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
            };
        }
    }
}
