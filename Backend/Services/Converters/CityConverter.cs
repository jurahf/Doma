using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services.Converters
{
    public class CityConverter : IEntityViewModelConverter<CityViewModel, City>
    {
        public City ConvertToStoredModel(CityViewModel viewModel, bool withRelations = true)
        {
            if (viewModel == null)
                return null;

            return new City()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Latitude = viewModel.Latitude,
                Longitude = viewModel.Longitude,
            };
        }

        public CityViewModel ConvertToViewModel(City dbModel, bool withRelations = true)
        {
            if (dbModel == null)
                return null;

            return new CityViewModel()
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                Latitude = dbModel.Latitude,
                Longitude = dbModel.Longitude,
            };
        }
    }
}
