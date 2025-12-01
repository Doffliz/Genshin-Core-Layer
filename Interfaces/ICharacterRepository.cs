using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
  
    public interface ICharacterRepository
    {
        Task<List<string>> GetAllNamesAsync();
        Task<CharacterDto> GetDetailsAsync(string name);
    }
}