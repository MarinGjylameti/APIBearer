using Microsoft.AspNetCore.Http.HttpResults;
using TeamSystem.Data;
using TeamSystem.Models;
using TeamSystem.Models.DTOs;

namespace TeamSystem.RepositoryLayer
{
    public class KategoriRepository : IKategoriRepository
    {
        private readonly ApiDbContext _db;
        public KategoriRepository(ApiDbContext db)
        {
            _db = db;  
        }
        public Task<List<Kategori>> GetAllKategories()
        {
            var models = _db.Kategori.ToList();
            return Task.FromResult(models);
        }

        public Task<Kategori> GetKategoriById(long id)
        {
            var kategori = _db.Kategori.FirstOrDefault(x => x.Code == id);
            return Task.FromResult(kategori);
        }

        public Task<Kategori> SaveKategori(Kategori model)
        {
            try
            {
                _db.Kategori.Add(model);
                _db.SaveChanges();
                return Task.FromResult(model);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<KategoriPostim> SaveKategoriPostim(KategoriPostim model)
        {
            try
            {
                var CheckIfPostimIdExist = _db.Posts.FirstOrDefault(x => x.id == model.KategoriId);
                var CheckIfKategoriIDExist = _db.Kategori.FirstOrDefault(x => x.Code == model.PostimId);
                if (CheckIfPostimIdExist != null && CheckIfKategoriIDExist != null)
                {
                    var exist = _db.KategoriPostim.FirstOrDefault(x => x.KategoriId == model.KategoriId && x.PostimId == model.PostimId);
                    if (exist == null)
                    {
                        _db.KategoriPostim.Add(model);
                        _db.SaveChanges();
                        return Task.FromResult(model);
                    }
                    else
                    {
                        return Task.FromResult(exist);
                    }
                }
                else
                {
                    return Task.FromResult(new KategoriPostim() { KategoriId = -1 , PostimId = -1});
                }
                
            }
            catch (Exception)
            {
                return Task.FromResult(new KategoriPostim());
            }
        }

        public Task<Kategori> UpdateKategori(long kategoriID, Kategori model)
        {
            try
            {
                var kategori = _db.Kategori.FirstOrDefault(x => x.Code == kategoriID);
                kategori.Name = model.Name;
                kategori.Description = model.Description;
                _db.SaveChanges();
                return Task.FromResult(kategori);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
