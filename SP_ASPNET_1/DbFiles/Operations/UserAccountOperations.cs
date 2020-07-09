using Microsoft.AspNet.Identity;
using SP_ASPNET_1.DbFiles.UnitsOfWork;
using SP_ASPNET_1.Models;
using SP_ASPNET_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SP_ASPNET_1.DbFiles.Operations
{
    public class UserAccountOperations
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        public IEnumerable<AppUser> GetUsers()
        {
            List<AppUser> users = (_unitOfWork.UserRepository.Get()).ToList();

            return users;
        }

        public AppUser GetUserById(string id)
        {
            return _unitOfWork.UserRepository.GetByID(id);
        }

        internal async Task<IdentityResult> Create(AppUser user, string password)
        {
            try
            {
                return await this._unitOfWork.UserRepository.InsertUser(user, password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        internal IdentityResult Update(AppUser user)
        {
            try
            {
                return this._unitOfWork.UserRepository.UpdateUser(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}