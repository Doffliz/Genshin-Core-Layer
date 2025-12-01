using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.Services
{
    
    public class ImageManager
    {
        private readonly string _cacheFolder;
        private readonly HttpClient _client = new HttpClient(); 

        public ImageManager()
        {
            
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _cacheFolder = Path.Combine(appData, "Genshin-Core-Layer", "Images");

            
            if (!Directory.Exists(_cacheFolder))
            {
                Directory.CreateDirectory(_cacheFolder);
                Console.WriteLine($"[CACHE] Створено папку кешу: {_cacheFolder}");
            }
        }

        
        public async Task<string> GetOrCacheImageAsync(string imageUrl, string characterName)
        {
            
            string fileName = $"{characterName}.png"; 
            string fullPath = Path.Combine(_cacheFolder, fileName);

            
            if (File.Exists(fullPath))
            {
                Console.WriteLine($"[CACHE HIT] {characterName}: Завантажено з локального диска.");
                return fullPath;
            }

            
            Console.WriteLine($"[NET DOWNLOAD] {characterName}: Кеш відсутній. Завантажую з мережі...");
            
            try
            {
                
                byte[] imageBytes = await _client.GetByteArrayAsync(imageUrl);
                
                
                await File.WriteAllBytesAsync(fullPath, imageBytes);
                Console.WriteLine($"[CACHE SET] {characterName}: Успішно збережено в кеш.");
                
                return fullPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Не вдалося завантажити {characterName}: {ex.Message}");
                
                return imageUrl; 
            }
        }
    }
}