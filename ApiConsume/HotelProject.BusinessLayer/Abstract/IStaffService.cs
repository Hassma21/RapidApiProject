using HotelProject.EntityLayer.Concrete;


namespace HotelProject.BusinessLayer.Abstract
{
    public interface  IStaffService : IGenericService<Staff>
    {
        public int TGetStaffCount();
        public List<Staff> TGetLast4Staff();
    }
}
