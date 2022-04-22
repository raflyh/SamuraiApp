using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data.Interface
{
    public interface ISamurai : ICrud<Samurai>
    {
        Task<Katana> Insert(Katana obj);
        Task<Katana> GetKatanaById(int id);
        Task<Elemen> Insert(Elemen obj);
        Task<ElemenKatana> Insert(ElemenKatana obj);

    }
}
