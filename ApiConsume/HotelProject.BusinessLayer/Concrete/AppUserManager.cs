using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;


namespace HotelProject.BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public int TAppUserCount()
        {
            return _appUserDal.AppUserCount();
        }

        public void TDelete(AppUser entity)
        {
            _appUserDal.Delete(entity);
        }

        public List<AppUser> TGetAll()
        {
            return _appUserDal.GetAll();
        }

        public AppUser TGetById(int id)
        {
            return _appUserDal.GetById(id);
        }

        public void TInsert(AppUser entity)
        {
            _appUserDal.Insert(entity);
        }

        public void TUpdate(AppUser entity)
        {
            _appUserDal.Update(entity);
        }

        public List<AppUser> TUserListWithLocation()
        {
            return _appUserDal.UserListWithLocation();
        }
    }
}
