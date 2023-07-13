using HotelProject.EntityLayer.Concrete;


namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IStaffDal : IGenericDal<Staff>
    {
        public int GetStaffCount();
        public List<Staff> GetLast4Staff();
    }
}
