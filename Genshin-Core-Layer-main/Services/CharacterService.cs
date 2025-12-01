using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Genshin_Core_Layer.Models;
using Genshin_Core_Layer.Services;

 

namespace Genshin_Core_Layer.Services
{
    public class CharacterService
    {
        private readonly ImageCacheManager _cacheManager;
        private readonly HttpClient _httpClient;

        public CharacterService()
        {
            _cacheManager = new ImageCacheManager();
            _httpClient = new HttpClient();
            
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0"); 
        }

       

public Task<CharacterDto> GetCharacterDataAsync(string characterId)
        {
            return Task.FromResult(new CharacterDto 
            {
                Id = characterId,
                Name = $"Traveler {characterId}",
                
                
                PortraitUrl = $"https://placehold.co/150x150/0000FF/FFFFFF.png?text={characterId}",
            });
        }
        
        public async Task<byte[]> GetCharacterPortraitAsync(string characterId, string portraitUrl)
        {
            
            Uri uri = new Uri(portraitUrl);
            string cleanPath = uri.AbsolutePath; 

            
            string fileExtension = Path.GetExtension(cleanPath); 
            if (string.IsNullOrEmpty(fileExtension) || fileExtension.Length < 2) 
            {
                fileExtension = ".png"; 
            }
            string cacheKey = $"{characterId}{fileExtension}"; 
            
            
           
            byte[] imageData = _cacheManager.LoadImage(cacheKey);

            if (imageData != null)
            {
                Console.WriteLine($"[INFO] Portrait: Завантажено з локального кешу. ({characterId})");
                return imageData;
            }

            
            Console.WriteLine($"[INFO] Portrait: Кешу немає. Завантажуємо з {portraitUrl}");
            try
            {
                
                byte[] serverData = await _httpClient.GetByteArrayAsync(portraitUrl);

                
                _cacheManager.SaveImage(cacheKey, serverData);
                Console.WriteLine($"[SUCCESS] Cache Manager: Зображення збережено: {cacheKey}");
                return serverData;
            }
            catch (HttpRequestException ex)
            {
                
                Console.WriteLine($"[ERROR] Portrait: Помилка мережі при завантаженні: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"[ERROR] An unexpected error occurred: {ex.Message}");
                return null;
            }
        }
    }
}