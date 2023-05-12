using Business.Abstract;
using Core.Entity.Concrete;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public Task<IDataResult<User>> GetById(int id)
        {
           return _userDal.Get(x=>x.Id == id);
        }
    }
}
