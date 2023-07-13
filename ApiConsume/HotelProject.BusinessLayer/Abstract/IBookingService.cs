using HotelProject.EntityLayer.Concrete;


namespace HotelProject.BusinessLayer.Abstract
{
    public interface IBookingService :IGenericService<Booking>
    {
        void TBookingStatusChangeApproved(Booking booking);
        int TBookingCount();
        public List<Booking> TGetLast3Booking();
    }
}
