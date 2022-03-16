using Microsoft.EntityFrameworkCore;
using Services.Parameters;
using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(BookingDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        protected override IQueryable<Room> DefaultOrder(IQueryable<Room> set)
        {
            return set.OrderBy(x => x.Hotel.Name).ThenBy(x => x.CostPerDay);
        }

        protected override IQueryable<Room> Fetch(IQueryable<Room> set)
        {
            return set
                .Include(x => x.Hotel)
                    .ThenInclude(x => x.City)
                .Include(x => x.Category)
                .Include(x => x.Photos)
                .Include(x => x.Commodities)
                .Include(x => x.Bookings);
        }

        public Task<List<Room>> SearchRooms(SearchRoomsFilter filter)
        {
            var set = Fetch(dbContext.Rooms);

            if (filter != null)
            {
                if (filter.CityId != null)
                    set = set.Where(x => x.Hotel.CityId == filter.CityId);

                // TODO: Проверка наличия мест
                //if (filter.StartDate != null)
                //    set = set.Where(x => x.Bookings.Select(t => t.StartDate)

                //if (filter.EndDate != null)
                //    set = set.Where(x => x.Bookings.Select(t => t.EndDate)

                set = set.Where(x => x.AdultPlaces >= filter.AdultsCount
                        && x.ChildPlaces >= filter.ChildrenCount);
            }

            return set.ToListAsync();
        }

    }
}
