using HotelProject.EntityLayer.Concrete;


namespace HotelProject.BusinessLayer.Abstract
{
    public interface IBookingService :IGenericService<Booking>
    {
        void TBookingStatusChangeApproved(int id);
        void TBookingStatusChangeCancaled(int id);
        void TBookingStatusChangeWaited(int id);
        int TBookingCount();
        public List<Booking> TGetLast3Booking();
    }
}
