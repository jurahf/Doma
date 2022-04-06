using System;
using System.Collections.Generic;
using System.Text;

namespace StoredModel.Enums
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
