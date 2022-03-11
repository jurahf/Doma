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
    public class ChatMessageService : BaseEntityService<ChatMessageViewModel, ChatMessage>, IChatMessageService
    {
        public ChatMessageService(
            IChatMessageRepository repository,
            IEntityViewModelConverter<ChatMessageViewModel, ChatMessage> converter)
            : base(repository, converter)
        {
        }
    }
}
