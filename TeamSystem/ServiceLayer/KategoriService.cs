using AutoMapper;
using TeamSystem.Models;
using TeamSystem.Models.DTOs;
using TeamSystem.RepositoryLayer;

namespace TeamSystem.ServiceLayer
{
    public class KategoriService : IKategoriService
    {
        private readonly IMapper _mapper;
        public readonly IKategoriRepository _kategoriRepository;
        public KategoriService(IMapper mapper, IKategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
            _mapper = mapper;
        }
        public async Task<List<Kategori>> GetAllKategories()
        {
            return await _kategoriRepository.GetAllKategories();
        }

        public async Task<Kategori> SaveKategori(KategoriDTO _kategori)
        {
           var kategori = _mapper.Map<Kategori>(_kategori);
           return await _kategoriRepository.SaveKategori(kategori);
        }

        public async Task<KategoriPostim> SaveKategoriPostim(KategoriPostDTO _postkategori)
        {
            var model = _mapper.Map<KategoriPostim>(_postkategori);
            return await _kategoriRepository.SaveKategoriPostim(model);
        }

        public async Task<Kategori> UpdateKategori(long kategoriId, KategoriDTO _kategori)
        {
            var model = _mapper.Map<Kategori>(_kategori);
            if(_kategoriRepository.GetKategoriById(kategoriId) == null)
            {
                return null;
            }
            else
            {
                return await _kategoriRepository.UpdateKategori(kategoriId, model);
            }
        }
    }
}
