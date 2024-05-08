using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{


    
    public class CarManager : ICarService
    {

        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
            
        }


        public IResult Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public IDataResult<List<Car>> GetAll()
        {

            var result = _carDal.GetAll().ToList();
            return new SuccessDataResult<List<Car>>(result, Messages.ProductsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            

            var result = _carDal.Get((p) => p.Id == id);
            return new SuccessDataResult<List<Car>>(result, Messages.ProductsListed);

        }

        public IResult Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
