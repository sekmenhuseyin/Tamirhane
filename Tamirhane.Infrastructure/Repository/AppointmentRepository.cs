using System;
using System.Collections.Generic;
using System.Linq;
using Tamirhane.Core;
using Tamirhane.Core.Models;

namespace Tamirhane.Infrastructure.Repository
{
    public class AppointmentRepository : GenericInterface<Appointment>
    {
        TamirhaneDbContext Db = new TamirhaneDbContext();

        /// <summary>
        /// 
        /// </summary>
        public Result Add(Appointment p)
        {
            Db.Appointment.Add(p);
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
        public Result Edit(Appointment p)
        {
            var tmp = FindById(p.Id);
            tmp.DateTime = p.DateTime;
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
        public Appointment FindById(int Id)
        {
            return Db.Appointment.Where(m => m.Id == Id).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Appointment> GetAll()
        {
            return Db.Appointment;
        }

        /// <summary>
        /// 
        /// </summary>
        public Result Remove(int Id)
        {
            var p = FindById(Id);
            Db.Appointment.Remove(p);
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
