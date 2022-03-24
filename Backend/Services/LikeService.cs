using Services.Converters;
using Services.RepositoryDeclaration;
using Services.ServiceDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services
{
    public class LikeService : BaseEntityService<LikeViewModel, Like>, ILikeService
    {
        private readonly ILikeRepository repository;

        public LikeService(ILikeRepository repository, IEntityViewModelConverter<LikeViewModel, Like> converter)
            : base(repository, converter)
        {
            this.repository = repository;
        }

        public async Task<List<LikeViewModel>> LikesByRoom(int roomId)
        {
            List<Like> likes = await repository.LikesByRoom(roomId);
            return likes.Select(x => converter.ConvertToViewModel(x)).ToList();
        }

        public async Task<List<LikeViewModel>> LikesByUser(int userId)
        {
            List<Like> likes = await repository.LikesByUser(userId);
            return likes.Select(x => converter.ConvertToViewModel(x)).ToList();
        }
    }
}
