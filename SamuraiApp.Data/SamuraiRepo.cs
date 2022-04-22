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
        //Get Samurai with Katana
        public async Task<Samurai> GetSamurai(int id)
        {
            var result = await _context.Samurais.Include(x => x.Katanas).FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Samurai Id: {id} tidak ditemukan");
            return result;
        }
        //Get Samurai with Katana and Elemen
        public async Task<Samurai> GetSamuraiElemen(int id)
        {
            var result = await _context.Samurais
                .Include(x => x.Katanas)
                    .ThenInclude(a => a.Elemens)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Samurai Id: {id} tidak ditemukan");
            return result;
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
                await _context.Samurais.AddAsync(obj);
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
        //Insert Katana
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
        //Insert Elemen
        public async Task<Elemen> Insert(Elemen obj)
        {
            try
            {  
                await _context.Elemens.AddAsync(obj);
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
        //Insert IntermediateTable
        public async Task<ElemenKatana> Insert(ElemenKatana obj)
        {
            try
            {
                await _context.ElemenKatanas.AddAsync(obj);
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
    }
}
