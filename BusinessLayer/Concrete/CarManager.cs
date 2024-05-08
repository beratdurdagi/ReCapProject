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

            if(car.CarName.Length > 2 && car.DailyPrice >0 ) {
                _carDal.Add(car);
                return new SuccessResult(Messages.ProductAdded);
            }
            else
            {
                return new ErrorResult("Product Eklenemedi");
            }
         
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult(Messages.ProductDeleted);
        }



        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.ProductDeleted);
        }
        
        public IDataResult<List<Car>> GetAll()
        {

            var result = _carDal.GetAll().ToList();
            return new SuccessDataResult<List<Car>>(result, Messages.ProductsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            

            var result = _carDal.Get((p) => p.Id == id);
            return new SuccessDataResult<Car>(result, Messages.ProductsListed);

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
          var result = _carDal.GetAll((p)=> p.BrandId == brandId).ToList();
         return new SuccessDataResult<List<Car>>(result, Messages.ProductsListed);


        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            var result = _carDal.GetAll((p) => p.ColorId == colorId).ToList();
            return new SuccessDataResult<List<Car>>(result, Messages.ProductsListed);
        }
    }
}
