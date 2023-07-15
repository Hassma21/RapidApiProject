using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IBookingDal :IGenericDal<Booking>
    {
        void BookingStatusChangeApproved(int id);
        void BookingStatusChangeCancaled(int id);
        void BookingStatusChangeWaited(int id);
        
        int BookingCount();
        List<Booking> GetLast3Booking();
    }
}
