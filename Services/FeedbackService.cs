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
    public class FeedbackService : BaseEntityService<FeedbackViewModel, Feedback>, IFeedbackService
    {
        public FeedbackService(
            IFeedbackRepository repository,
            IEntityViewModelConverter<FeedbackViewModel, Feedback> converter)
            : base(repository, converter)
        {
        }
    }
}