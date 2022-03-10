using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services.Converters
{
    public interface IEntityViewModelConverter<VM, DB>
        where VM : IViewModel
        where DB : IEntity
    {
        DB ConvertToStoredModel(VM viewModel, bool withRelations = true);
        VM ConvertToViewModel(DB dbModel, bool withRelations = true);
    }
}
