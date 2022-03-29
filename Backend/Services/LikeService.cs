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
        private readonly ILikeRepository likeRepository;
        private readonly IRoomRepository roomRepository;
        private readonly IEntityViewModelConverter<RoomViewModel, Room> roomConverter;

        public LikeService(
            ILikeRepository likeRepository,
            IRoomRepository roomRepository,
            IEntityViewModelConverter<LikeViewModel, Like> likeConverter,
            IEntityViewModelConverter<RoomViewModel, Room> roomConverter)
            : base(likeRepository, likeConverter)
        {
            this.likeRepository = likeRepository;
            this.roomRepository = roomRepository;
            this.roomConverter = roomConverter;
        }

        public async Task<List<LikeViewModel>> LikesByRoom(int roomId)
        {
            List<Like> likes = await likeRepository.LikesByRoom(roomId);
            List<LikeViewModel> likesViewModel =
                likes.Select(x => converter.ConvertToViewModel(x))
                .ToList();

            foreach (var like in likesViewModel)
            {
                like.Room = roomConverter.ConvertToViewModel(roomRepository.GetById(like.Room.Id));
            }

            return likesViewModel;
        }

        public async Task<List<LikeViewModel>> LikesByUser(int userId)
        {
            List<Like> likes = await likeRepository.LikesByUser(userId);
            List<LikeViewModel> likesViewModel = 
                likes.Select(x => converter.ConvertToViewModel(x))
                .ToList();

            foreach (var like in likesViewModel)
            {
                like.Room = roomConverter.ConvertToViewModel(roomRepository.GetById(like.Room.Id));
            }

            return likesViewModel;
        }
    }
}
