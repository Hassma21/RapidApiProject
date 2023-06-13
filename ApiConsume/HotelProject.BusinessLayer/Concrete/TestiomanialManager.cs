using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class TestiomanialManager : ITestiomanialService
    {
        private readonly ITestiomanialDal _testiomanialDal;

        public TestiomanialManager(ITestiomanialDal testiomanialDal)
        {
            _testiomanialDal = testiomanialDal;
        }

        public void TDelete(Testimonial entity)
        {
            _testiomanialDal.Delete(entity);
        }

        public List<Testimonial> TGetAll()
        {
            return _testiomanialDal.GetAll();
        }

        public Testimonial TGetById(int id)
        {
            return _testiomanialDal.GetById(id);
        }

        public void TInsert(Testimonial entity)
        {
            _testiomanialDal.Insert(entity);
        }

        public void TUpdate(Testimonial entity)
        {
            _testiomanialDal.Update(entity);
        }
    }
}
