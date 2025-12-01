using System;
using System.IO;

namespace Genshin_Core_Layer.Services
{
    public class ImageCacheManager
    {
        private const string CacheFolderName = "GenshinCharacterCache";
        private readonly string _cachePath;

        public ImageCacheManager()
        {
            _cachePath = GetOrCreateCacheDirectory();
        }

        

        public byte[]? LoadImage(string imageId)
        {
            string fullPath = Path.Combine(_cachePath, imageId);

            if (File.Exists(fullPath))
            {
                try
                {
                    
                    return File.ReadAllBytes(fullPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] Cache Manager: Помилка зчитування файлу кешу: {ex.Message}");
                    return null;
                }
            }

            return null;
        }

        public void SaveImage(string imageId, byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return;

            string fullPath = Path.Combine(_cachePath, imageId);

            try
            {
                
                File.WriteAllBytes(fullPath, imageData);
                Console.WriteLine($"[SUCCESS] Cache Manager: Зображення збережено: {fullPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Cache Manager: Помилка запису файлу кешу: {ex.Message}");
            }
        }

        

        private string GetOrCreateCacheDirectory()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string cacheDirectoryPath = Path.Combine(appDataPath, CacheFolderName);

            if (!Directory.Exists(cacheDirectoryPath))
            {
                try
                {
                    Directory.CreateDirectory(cacheDirectoryPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[CRITICAL] Cache Manager: Помилка створення директорії: {ex.Message}");
                }
            }
            return cacheDirectoryPath;
        }
    }
}