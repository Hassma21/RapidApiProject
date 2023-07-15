using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public int BookingCount()
        {
            using(Context context =new Context())
            {
                return context.Bookings.Count();
            }
        }

        public void BookingStatusChangeApproved(int id)
        {
            var context = new Context();
            var values=context.Bookings.Where(x => x.BookingId ==id).FirstOrDefault();
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusChangeCancaled(int id)
        {
            var context = new Context();
            var values = context.Bookings.Where(x => x.BookingId == id).FirstOrDefault();
            values.Status = "İptal Edildi";
            context.SaveChanges();
        }

     

        public void BookingStatusChangeWaited(int id)
        {
            var context = new Context();
            var values = context.Bookings.Where(x => x.BookingId == id).FirstOrDefault();
            values.Status = "Müşteri Aranacak";
            context.SaveChanges();
        }

        public List<Booking> GetLast3Booking()
        {
            using (Context context = new Context())
            {
                return context.Bookings.OrderByDescending(x => x.BookingId).Take(3).ToList();
            }
        }
    }
}
