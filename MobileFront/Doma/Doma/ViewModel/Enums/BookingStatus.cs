using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Enums
{
    public enum BookingStatus
    {
        Request,
        HotelConfirm,
        HotelReject,
        ClientCancel,
        PayFrozen,
        ClientCome,
        PaySend,
        Done
    }
}
