using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using BulkeyWebManage.Application.DTOs;
using BulkeyWebManage.Application.Interfaces;
using BulkeyWebManage.Application.mapper;
using BulkeyWebManage.Domain.Interfaces;

namespace BulkeyWebManage.Application.Service
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly GenreMapper _genreMapper;
        public GenreService(IUnitOfWork unitOfWork, GenreMapper genreMapper)
        {
            _unitOfWork = unitOfWork;
            _genreMapper = genreMapper;
        }
        public async Task<IEnumerable<GenreDTO>> GetAll()
        {
            var genres = await _unitOfWork.Genres.GetAll();

            var genreDTOs = genres.Select(genre => _genreMapper.ToDTO(genre));

            return genreDTOs;
        }

        public async Task<GenreDTO> GetById(int id)
        {
            var genre = await _unitOfWork.Genres.GetById(id);

            return _genreMapper.ToDTO(genre);
        }

        public Task<IEnumerable<Genre>> GetByName(string name)
        {
            return _unitOfWork.Genres.GetByName(name);
        }
        public async Task<GenreDTO> Add(CreateGenreDTO createGenreDTO)
        {
            var genre = new Genre
            {
                Name = createGenreDTO.Name,
                Description = createGenreDTO.Description,
                IsActive = createGenreDTO.IsActive
            };

            var newGenre = await _unitOfWork.Genres.Add(genre);
            await _unitOfWork.CompleteAsync();

            return _genreMapper.ToDTO(newGenre);
        }

        public async Task Delete(int id)
        {
            var genre = await _unitOfWork.Genres.GetById(id);
            if (genre != null) _unitOfWork.Genres.Delete(genre);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<GenreDTO> Update(int id, UpdateGenreDTO updateGenreDTO)
        {
            var genre = await _unitOfWork.Genres.GetById(id);

            genre.Name = updateGenreDTO.Name;
            genre.Description = updateGenreDTO.Description;
            genre.IsActive = updateGenreDTO.IsActive;

            _unitOfWork.Genres.Update(genre);

            await _unitOfWork.CompleteAsync();

            return _genreMapper.ToDTO(genre);
        }
    }
}
