using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services.Converters
{
    public class ChatMessageConverter : IEntityViewModelConverter<ChatMessageViewModel, ChatMessage>
    {
        public ChatMessage ConvertToStoredModel(ChatMessageViewModel viewModel, bool withRelations = true)
        {
            if (viewModel == null)
                return null;

            return new ChatMessage()
            {
                Id = viewModel.Id,
                DateTime = viewModel.DateTime,
                Status = (StoredModel.Enums.ChatMessageStatus)(int)viewModel.Status,
                Text = viewModel.Text,
                Author = new User() { Id = viewModel.Author?.Id ?? 0, Name = viewModel.Author?.Name },
                AuthorId = viewModel.Author?.Id ?? 0,
                Reciver = new User() { Id = viewModel.Reciver?.Id ?? 0, Name = viewModel.Reciver?.Name },
                ReciverId = viewModel.Reciver?.Id ?? 0,
            };
        }

        public ChatMessageViewModel ConvertToViewModel(ChatMessage dbModel, bool withRelations = true)
        {
            if (dbModel == null)
                return null;

            return new ChatMessageViewModel()
            {
                Id = dbModel.Id,
                DateTime = dbModel.DateTime,
                Status = (ViewModel.Enums.ChatMessageStatus)(int)dbModel.Status,
                Text = dbModel.Text,
                Author = new UserViewModel() { Id = dbModel.Author?.Id ?? 0, Name = dbModel.Author?.Name },
                Reciver = new UserViewModel() { Id = dbModel.Reciver?.Id ?? 0, Name = dbModel.Reciver?.Name },
            };
        }
    }
}
