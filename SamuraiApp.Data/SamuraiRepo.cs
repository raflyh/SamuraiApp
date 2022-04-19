using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data.Interface;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class SamuraiRepo : ISamurai
    {
        private readonly SamuraContext _context;

        public SamuraiRepo(SamuraContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deleteSamurai = await GetById(id);
                _context.Samurais.Remove(deleteSamurai);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Samurai>> GetAll()
        {
            var results = await _context.Samurais.OrderBy(s => s.Name).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Samurai> GetById(int id)
        {
            var result = await _context.Samurais.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Samurai Id: {id} tidak ditemukan");
            return result;
        }

        public Task<Samurai> GetById(int id, Samurai obj)
        {
            throw new NotImplementedException();
        }

        public async Task<Katana> GetKatanaById(int id)
        {
            var result = await _context.Katanas.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Katana Id: {id} tidak ditemukan");
            return result;
        }

        public async Task<Samurai> Insert(Samurai obj)
        {
            try
            {
                _context.Samurais.Add(obj);
                _context.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Katana> Insert(Katana obj)
        {
            try
            {
                await _context.Katanas.AddAsync(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Samurai> Update(int id, Samurai obj)
        {
            try
            {
                var updateSamurai = await GetById(id); //tracking
                updateSamurai.Name = obj.Name;
                await _context.SaveChangesAsync();
                return updateSamurai;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Katana> InsertElemen(Katana obj)
        {
            try
            {
                var katana = new Katana()
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    ForgedDate = obj.ForgedDate,
                    Elemens = obj.Elemens.Select(s => new Elemen()
                    {
                        ElemenId = s.ElemenId,
                        Name = s.Name,
                    }).ToList()
                };
                await _context.Katanas.AddAsync(katana);
                await _context.SaveChangesAsync();

                return katana;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
