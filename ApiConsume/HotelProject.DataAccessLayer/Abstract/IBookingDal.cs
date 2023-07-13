using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IBookingDal :IGenericDal<Booking>
    {
        void BookingStatusChangeApproved(Booking booking);
        int BookingCount();
        List<Booking> GetLast3Booking();
    }
}
