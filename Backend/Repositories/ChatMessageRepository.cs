using Microsoft.EntityFrameworkCore;
using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class ChatMessageRepository : BaseRepository<ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(BookingDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        protected override IQueryable<ChatMessage> DefaultOrder(IQueryable<ChatMessage> set)
        {
            return set.OrderByDescending(x => x.DateTime);
        }

        protected override IQueryable<ChatMessage> Fetch(IQueryable<ChatMessage> set)
        {
            return set
                .Include(x => x.Author)
                .Include(x => x.Reciver);
        }
    }
}
