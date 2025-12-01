using System.Collections.Generic;
using System.Threading.Tasks;
using Genshin_Core_Layer.Models;      
using Genshin_Core_Layer.Interfaces; 

namespace Genshin_Core_Layer.Mocks
{
    
    public class MockCharacterRepository : ICharacterRepository
    {
        public Task<List<CharacterDto>> GetAllCharactersAsync()
        {
            
            var characters = new List<CharacterDto>
            {
                new CharacterDto { Id = "1001", Name = "Aether", PortraitUrl = "http://example.com/aether.jpg" },
                new CharacterDto { Id = "1002", Name = "Lumine", PortraitUrl = "http://example.com/lumine.jpg" }
            };
            
            return Task.FromResult(characters);
        }

        
    }
}