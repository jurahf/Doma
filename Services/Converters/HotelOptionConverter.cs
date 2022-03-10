using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services.Converters
{
    public class HotelOptionConverter : IEntityViewModelConverter<HotelOptionViewModel, HotelOption>
    {
        public HotelOption ConvertToStoredModel(HotelOptionViewModel viewModel, bool withRelations = true)
        {
            if (viewModel == null)
                return null;

            return new HotelOption()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
            };
        }

        public HotelOptionViewModel ConvertToViewModel(HotelOption dbModel, bool withRelations = true)
        {
            if (dbModel == null)
                return null;

            return new HotelOptionViewModel()
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
            };
        }
    }
}
