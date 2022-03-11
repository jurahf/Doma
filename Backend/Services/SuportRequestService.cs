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
    public class SupportRequestService : BaseEntityService<SupportRequestViewModel, SupportRequest>, ISupportRequestService
    {
        public SupportRequestService(
            ISupportRequestRepository repository,
            IEntityViewModelConverter<SupportRequestViewModel, SupportRequest> converter)
            : base(repository, converter)
        {
        }
    }
}