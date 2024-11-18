using BulkeyWebManage.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkeyWebManage.Application.mapper
{
    public class GenreMapper
    {
        public GenreDTO ToDTO(Genre genre)
        {
            return new GenreDTO
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description,
                IsActive = genre.IsActive
            };
        }
        public Genre ToEntity(GenreDTO genreDTO)
        {
            return new Genre
            {
                Name = genreDTO.Name,
                Description = genreDTO.Description,
                IsActive = genreDTO.IsActive
            };
        }
    }
}
