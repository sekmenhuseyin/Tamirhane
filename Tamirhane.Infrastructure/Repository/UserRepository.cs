using System;
using System.Collections.Generic;
using System.Linq;
using Tamirhane.Core;
using Tamirhane.Core.Models;

namespace Tamirhane.Infrastructure.Repository
{
    public class UserRepository : GenericInterface<User>
    {
        TamirhaneDbContext Db = new TamirhaneDbContext();

        /// <summary>
        /// adds new user
        /// </summary>
        public Result Add(User p)
        {
            Db.User.Add(p);
            try
            {
                Db.SaveChanges();
                return new Result(true, p.Id);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        /// <summary>
        /// saves edited user
        /// </summary>
        public Result Edit(User p)
        {
            try
            {
                Db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                return new Result(true, p.Id);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        /// <summary>
        /// gets selected user
        /// </summary>
        public User FindById(int Id)
        {
            return Db.User.Where(m => m.Id == Id).FirstOrDefault();
        }

        /// <summary>
        /// gets all users
        /// </summary>
        public IEnumerable<User> GetAll()
        {
            return Db.User;
        }

        /// <summary>
        /// deletes selected user
        /// </summary>
        public Result Remove(int Id)
        {
            var p = FindById(Id);
            Db.User.Remove(p);
            try
            {
                Db.SaveChanges();
                return new Result(true, p.Id);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
    }
}
