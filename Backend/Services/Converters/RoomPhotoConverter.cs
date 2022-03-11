using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services.Converters
{
    public class RoomPhotoConverter : IEntityViewModelConverter<RoomPhotoViewModel, RoomPhoto>
    {
        public RoomPhoto ConvertToStoredModel(RoomPhotoViewModel viewModel, bool withRelations = true)
        {
            if (viewModel == null)
                return null;

            return new RoomPhoto()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Url = viewModel.Url,
            };
        }

        public RoomPhotoViewModel ConvertToViewModel(RoomPhoto dbModel, bool withRelations = true)
        {
            if (dbModel == null)
                return null;

            return new RoomPhotoViewModel()
            {
                Id = dbModel.Id,
                Title = dbModel.Title,
                Url = dbModel.Url,
            };
        }
    }
}
