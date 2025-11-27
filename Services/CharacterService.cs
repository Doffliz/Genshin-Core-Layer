using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CharacterService
    {
        private readonly ICharacterRepository _repository;
        private const string BaseImageUrl = "https://genshin.jmp.blue/characters/";

        public CharacterService(ICharacterRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Character>> LoadCharactersAsync()
        {
            var processedCharacters = new List<Character>();
            var names = await _repository.GetAllNamesAsync();

            foreach (var name in names)
            {
                var dto = await _repository.GetDetailsAsync(name);

                if (dto != null)
                {
                    
                   
                    if (dto.Rarity < 4) continue; 
                    
                    
                    string shortDesc = dto.Description;
                    if (shortDesc != null && shortDesc.Length > 50)
                    {
                        shortDesc = shortDesc.Substring(0, 47) + "..."; 
                    }

                   
                    var character = new Character
                    {
                        Name = dto.Name,
                        Element = dto.Vision, 
                        Stars = dto.Rarity,
                        
                        WeaponType = dto.Weapon, 
                        ShortDescription = shortDesc, 
                        
                        
                        ImageUrl = $"{BaseImageUrl}{dto.Name.ToLower()}/icon-big" 
                    };

                    processedCharacters.Add(character);
                }
            }
            
            return processedCharacters;
        }
    }
}