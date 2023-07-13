using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;


namespace HotelProject.BusinessLayer.Concrete
{
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public int TGetStaffCount()
        {
            return _staffDal.GetStaffCount();
        }

        public void TDelete(Staff entity)
        {
            _staffDal.Delete(entity);
        }

        public List<Staff> TGetAll()
        {
            return _staffDal.GetAll();
        }

        public Staff TGetById(int id)
        {
            return _staffDal.GetById(id);
        }

        public void TInsert(Staff entity)
        {
            _staffDal.Insert(entity);
        }

        public void TUpdate(Staff entity)
        {
            _staffDal.Update(entity);
        }

        public List<Staff> TGetLast4Staff()
        {
            return _staffDal.GetLast4Staff();
        }
    }
}
