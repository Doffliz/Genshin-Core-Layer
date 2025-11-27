using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Mocks
{
    public class MockCharacterRepository : ICharacterRepository
    {
        public async Task<List<string>> GetAllNamesAsync()
        {
            
            return await Task.FromResult(new List<string> { "Amber", "Diluc", "Barbara", "Klee", "Sayu" });
        }

        public async Task<CharacterDto> GetDetailsAsync(string name)
        {
            switch (name)
            {
                case "Amber":
                    return await Task.FromResult(new CharacterDto { 
                        Name = "Amber", Vision = "Pyro", Weapon = "Bow", Rarity = 4, 
                        Description = "Always energetic and full of life, Amber is the best and only Outrider of the Knights of Favonius. A long and detailed description for testing clipping." 
                    });
                case "Diluc":
                    return await Task.FromResult(new CharacterDto { 
                        Name = "Diluc", Vision = "Pyro", Weapon = "Claymore", Rarity = 5, 
                        Description = "The current owner of the Dawn Winery, a name that is widely recognized in Mondstadt." 
                    });
                case "Barbara":
                    return await Task.FromResult(new CharacterDto { 
                        Name = "Barbara", Vision = "Hydro", Weapon = "Catalyst", Rarity = 4, 
                        Description = "The Deaconess of the Favonius Church and a shining star of idol in Mondstadt." 
                    });
                case "Klee":
                    return await Task.FromResult(new CharacterDto { 
                        Name = "Klee", Vision = "Pyro", Weapon = "Catalyst", Rarity = 5, 
                        Description = "Klee is a playable Pyro character in Genshin Impact. She is the daughter of the adventurer Alice." 
                    });
                case "Sayu":
                    return await Task.FromResult(new CharacterDto { 
                        Name = "Sayu", Vision = "Anemo", Weapon = "Claymore", Rarity = 3, 
                        Description = "A small ninja that always sleeps." 
                    });
                default:
                    return null;
            }
        }
    }
}