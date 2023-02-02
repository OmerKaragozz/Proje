using Entities;
using EntityFramework.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Concrete
{
    public class BilgiRepository : IBilgiRepository
    {
        public Bilgi CreatedBilgi(Bilgi bilgi)
        {
            using (var myContext = new MyContext())
            using (var transaction = myContext.Database.BeginTransaction())
            {
                myContext.Database.OpenConnection();
                myContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Bilgiler ON");
                myContext.Bilgiler.Add(bilgi);
                myContext.SaveChanges();
                myContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Bilgiler OFF");
                transaction.Commit();
                myContext.Database.CloseConnection();
                return bilgi;
            }
        }

        public void DeleteBilgi(int id)
        {
            using (var myContext = new MyContext())
            {
                var deletedBilgi = GetBilgiById(id);
                myContext.Bilgiler.Remove(deletedBilgi);
                myContext.SaveChanges();
            }
        }

        public List<Bilgi> GetAllBilgiler()
        {
            using (var myContext = new MyContext())
            {
                return myContext.Bilgiler.ToList();
            }               
        }

        public Bilgi GetBilgiById(int id)
        {
            using (var myContext = new MyContext())
            {
                return myContext.Bilgiler.Find(id);
            }
        }

        public Bilgi UpdateBilgi(Bilgi bilgi)
        {
            using (var myContext = new MyContext())
            {
                myContext.Bilgiler.Update(bilgi);
                myContext.SaveChanges();
                return bilgi;
            }
        }
        
        public List<Bilgi> BatchCreationBilgi(List<Bilgi> bilgi)
        {
            using (var myContext = new MyContext())
                using (var transaction = myContext.Database.BeginTransaction())
            {
                
                myContext.Database.OpenConnection();
                myContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Bilgiler ON");
                
                myContext.Bilgiler.AddRange(bilgi);
                myContext.SaveChanges();
                
                myContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Bilgiler OFF");
                transaction.Commit();
                myContext.Database.CloseConnection();
                
                return myContext.Bilgiler.ToList();
            }
        }
        
    }
}
