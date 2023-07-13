using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;


namespace HotelProject.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public int TBookingCount()
        {
            return _bookingDal.BookingCount();
        }

        public void TBookingStatusChangeApproved(Booking booking)
        {
            _bookingDal.BookingStatusChangeApproved(booking);
        }

        public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public List<Booking> TGetAll()
        {
            return _bookingDal.GetAll();
        }

        public Booking TGetById(int id)
        {
           return _bookingDal.GetById(id);
        }

        public List<Booking> TGetLast3Booking()
        {
            return _bookingDal.GetLast3Booking();
        }

        public void TInsert(Booking entity)
        {
            _bookingDal.Insert(entity);
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
