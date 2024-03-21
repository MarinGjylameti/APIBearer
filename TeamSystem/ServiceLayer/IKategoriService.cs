using TeamSystem.Models;
using TeamSystem.Models.DTOs;

namespace TeamSystem.ServiceLayer
{
    public interface IKategoriService
    {
        public Task<List<Kategori>> GetAllKategories();
        public Task<Kategori> SaveKategori(KategoriDTO modelDTO);
        public Task<Kategori> UpdateKategori(long kategoriId,KategoriDTO modelDTO);
        public Task<KategoriPostim> SaveKategoriPostim(KategoriPostDTO modelDTO);
    }
}
