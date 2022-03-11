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
    public class RoomService : BaseEntityService<RoomViewModel, Room>, IRoomService
    {
        public RoomService(
            IRoomRepository repository,
            IEntityViewModelConverter<RoomViewModel, Room> converter)
            : base(repository, converter)
        {
        }
    }
}