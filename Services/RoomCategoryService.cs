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
    public class RoomCategoryService : BaseEntityService<RoomCategoryViewModel, RoomCategory>, IRoomCategoryService
    {
        public RoomCategoryService(
            IRoomCategoryRepository repository,
            IEntityViewModelConverter<RoomCategoryViewModel, RoomCategory> converter)
            : base(repository, converter)
        {
        }
    }
}