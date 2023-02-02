using Application.Abstract;
using Entities;
using EntityFramework.Abstract;
using EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrete
{
    
    public class BilgiManager : IBilgiService
    {
        private IBilgiRepository _bilgiRepository;

        public BilgiManager()
        {
            _bilgiRepository = new BilgiRepository();

        }
        
        public List<Bilgi> BatchCreationBilgi(List<Bilgi> bilgi)
        {
            return _bilgiRepository.BatchCreationBilgi(bilgi);
        }
        
        public Bilgi CreatedBilgi(Bilgi bilgi)
        {
            return _bilgiRepository.CreatedBilgi(bilgi);
        }

        public void DeleteBilgi(int id)
        {
            _bilgiRepository.DeleteBilgi(id);
        }

        public List<Bilgi> GetAllBilgiler()
        {
            return _bilgiRepository.GetAllBilgiler();
        }

        public Bilgi GetBilgiById(int id)
        {
            if (id > 0)
            {
                return _bilgiRepository.GetBilgiById(id);
            }

            throw new Exception("id 1'den küçük olamaz");
        }

        public Bilgi UpdateBilgi(Bilgi bilgi)
        {
            return _bilgiRepository.UpdateBilgi(bilgi);
        }
    }
}
