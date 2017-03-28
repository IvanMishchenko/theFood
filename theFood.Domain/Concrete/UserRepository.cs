using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFood.Domain.Abstract;
using theFood.Domain.DbModel;

namespace theFood.Domain.Concrete
{
    public class UserRepository:IUser
    {
        readonly Model_theFoodDbContainer _dbContext = new Model_theFoodDbContainer();

        public IQueryable<User> Users
        {
            get { return _dbContext.UserSet; }
        }

        public void AddUser(User user)
        {
            if (user.Id == 0)
            {
                _dbContext.UserSet.Add(user);
            }
            else
            {
                var dbEntry = _dbContext.UserSet.Find(user.Id);
                if (dbEntry != null)
                {
                    dbEntry.FirstName = user.FirstName;
                    dbEntry.SecondName = user.SecondName;
                    dbEntry.Age = user.Age;
                    dbEntry.Email = user.Email;
                    dbEntry.Login = user.Login;
                    dbEntry.Password = user.Password;
                    dbEntry.Mobile = user.Mobile;
                    dbEntry.ConfirmPerson = user.ConfirmPerson;
                    dbEntry.Status = user.Status;
                }
            }
            _dbContext.SaveChanges();
        }

        public User DeleteUser(int userId)
        {
            var dbEntry = _dbContext.UserSet.Find(userId);
            if (dbEntry != null)
            {
                _dbContext.UserSet.Remove(dbEntry);
                _dbContext.SaveChanges();
            }
            return dbEntry;
        }
    }
}
