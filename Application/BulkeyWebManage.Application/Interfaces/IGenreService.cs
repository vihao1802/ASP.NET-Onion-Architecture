using BulkeyWebManage.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkeyWebManage.Application.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDTO>> GetAll();
        Task<GenreDTO> GetById(int id);
        Task<IEnumerable<Genre>> GetByName(string name);
        Task<GenreDTO> Add(CreateGenreDTO genre);
        Task<GenreDTO> Update(int id, UpdateGenreDTO updateGenreDTO);
        Task Delete(int id);
    }
}
