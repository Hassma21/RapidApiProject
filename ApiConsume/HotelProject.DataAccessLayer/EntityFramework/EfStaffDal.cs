using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;


namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public EfStaffDal(Context context) : base(context)
        {
        }

        public List<Staff> GetLast4Staff()
        {
            using(Context context = new Context())
            {
                return context.Staffs.OrderByDescending(s => s.StaffId).Take(4).ToList();
            }
        }

        public int GetStaffCount()
        {
            using(Context context =new Context())
            {
                return context.Staffs.Count();
            }
        }
    }
}
