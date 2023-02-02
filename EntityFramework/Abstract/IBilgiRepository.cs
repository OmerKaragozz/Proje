using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Abstract
{
    public interface IBilgiRepository
    {
        List<Bilgi> GetAllBilgiler();

        Bilgi GetBilgiById(int id);

        Bilgi CreatedBilgi(Bilgi bilgi);

        Bilgi UpdateBilgi(Bilgi bilgi);
        
        List<Bilgi> BatchCreationBilgi(List<Bilgi> bilgi);
        
        void DeleteBilgi(int id);
    }
}
