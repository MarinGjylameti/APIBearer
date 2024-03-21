using TeamSystem.Models;
using TeamSystem.Models.DTOs;

namespace TeamSystem.RepositoryLayer
{
    public interface IKategoriRepository
    {
        public Task<List<Kategori>> GetAllKategories();
        public Task<Kategori> SaveKategori(Kategori model);
        public Task<Kategori> UpdateKategori(long kategoriID, Kategori model);
        public Task<KategoriPostim> SaveKategoriPostim(KategoriPostim model);
        public Task<Kategori> GetKategoriById(long id);
    }
}
