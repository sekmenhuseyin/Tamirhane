using System;
using System.Collections.Generic;
using System.Linq;
using Tamirhane.Core;
using Tamirhane.Core.Models;

namespace Tamirhane.Infrastructure.Repository
{
    public class CarRepository : GenericInterface<Car>
    {
        TamirhaneDbContext Db = new TamirhaneDbContext();

        /// <summary>
        /// 
        /// </summary>
        public Result Add(Car p)
        {
            Db.Car.Add(p);
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
        /// 
        /// </summary>
        public Result Edit(Car p)
        {
            var tmp = FindById(p.Id);
            tmp.Plate = p.Plate;
            tmp.Company = p.Company;
            tmp.Model = p.Model;
            tmp.Year = p.Year;
            tmp.DateModified = DateTime.Now;
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
        /// 
        /// </summary>
        public Car FindById(int Id)
        {
            return Db.Car.Where(m => m.Id == Id).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Car> GetAll()
        {
            return Db.Car;
        }

        /// <summary>
        /// 
        /// </summary>
        public Result Remove(int Id)
        {
            var p = FindById(Id);
            Db.Car.Remove(p);
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
