using Business.Abstract;
using Business.Constants;
using Core.Ultilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = CheckReturnDate(rental.CarId);
            if (!result.Success)
            {
                return new ErrorResult(Messages.RentalAddError);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdd);
        }

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(c => c.CarId == carId && c.ReturnDate == null);
            if (result.Count > 0)
            {
                new ErrorResult(Messages.CheckReturnDateFalse);
            }
            return new SuccessResult(Messages.CheckReturndateTrue);

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDelete);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsList);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId), Messages.RentalGet);
        }

        public IDataResult<List<CarRentalDetailDto>> GetCarRentalDetail()
        {
            return new SuccessDataResult<List<CarRentalDetailDto>>(_rentalDal.GetCarRentalDetails(), Messages.RentalsDetailList);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdate);
        }
    }
}
