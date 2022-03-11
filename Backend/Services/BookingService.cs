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
    public class BookingService : BaseEntityService<BookingViewModel, Booking>, IBookingService
    {
        public BookingService(
            IBookingRepository repository, 
            IEntityViewModelConverter<BookingViewModel, Booking> converter)
            : base(repository, converter)
        {
        }
    }
}
