using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services.Converters
{
    public class RoomCategoryConverter : IEntityViewModelConverter<RoomCategoryViewModel, RoomCategory>
    {
        public RoomCategory ConvertToStoredModel(RoomCategoryViewModel viewModel, bool withRelations = true)
        {
            if (viewModel == null)
                return null;

            return new RoomCategory()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
            };
        }

        public RoomCategoryViewModel ConvertToViewModel(RoomCategory dbModel, bool withRelations = true)
        {
            if (dbModel == null)
                return null;

            return new RoomCategoryViewModel()
            {
                Id = dbModel.Id,
                Name = dbModel.Name,                
            };
        }
    }
}
