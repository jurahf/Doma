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
    public class RoomPhotoService : BaseEntityService<RoomPhotoViewModel, RoomPhoto>, IRoomPhotoService
    {
        public RoomPhotoService(
            IRoomPhotoRepository repository,
            IEntityViewModelConverter<RoomPhotoViewModel, RoomPhoto> converter)
            : base(repository, converter)
        {
        }
    }
}