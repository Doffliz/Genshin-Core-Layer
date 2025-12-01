using System.Collections.Generic;
using System.Threading.Tasks;
using Genshin_Core_Layer.Models; 

namespace Genshin_Core_Layer.Interfaces
{
    public interface ICharacterRepository
    {
        
        Task<List<CharacterDto>> GetAllCharactersAsync();
        
       
    }
}