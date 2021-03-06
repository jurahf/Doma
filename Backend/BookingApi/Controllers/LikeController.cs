using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Authorization;
using Services.ServiceDeclaration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : BaseEntityController<LikeViewModel>
    {
        private readonly ILikeService service;

        public LikeController(ILikeService service)
            : base(service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("GetByRoom")]
        [Authorize]
        public async Task<List<LikeViewModel>> GetByRoom(int roomId)
        {
            if (roomId <= 0)
                throw new ArgumentException();

            return await service.LikesByRoom(roomId);
        }


        [HttpGet]
        [Route("GetByUser")]
        [Authorize]
        public async Task<List<LikeViewModel>> GetByUser(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException();

            string userIdStr = AuthorizationHelper.GetClaim(Request, AuthorizationHelper.UserIdClaimName);
            if (!int.TryParse(userIdStr, out int currentUserId) || userId != currentUserId)    // то есть можно посмотреть только свое избранное
                throw new ArgumentException();

            return await service.LikesByUser(userId);
        }

    }
}
