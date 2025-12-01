using System;
using System.Threading.Tasks;
using Genshin_Core_Layer.Services;
using Genshin_Core_Layer.Models;
using Genshin_Core_Layer.Mocks; 

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("--- Практичне Заняття 15: Постійність Інформації (Кешування) ---");
        
        var service = new CharacterService();
        string testCharacterId = "Aether";

        
        var character = await service.GetCharacterDataAsync(testCharacterId);
        string portraitUrl = character.PortraitUrl ?? "http://missing.com/default.jpg";

        Console.WriteLine($"\n--- Тест 1: Перше завантаження (Cache Miss) ---");
        
        byte[]? firstLoadData = await service.GetCharacterPortraitAsync(character.Id!, portraitUrl);
        
        if (firstLoadData != null)
        {
            Console.WriteLine($"[RESULT] Image data size: {firstLoadData.Length} bytes.");
        }
        else
        {
            Console.WriteLine("[RESULT] Failed to get image data (network error).");
        }


        Console.WriteLine($"\n--- Тест 2: Друге завантаження (Cache Hit) ---");
        
        byte[]? secondLoadData = await service.GetCharacterPortraitAsync(character.Id!, portraitUrl);

        if (secondLoadData != null)
        {
            Console.WriteLine($"[RESULT] Image data size: {secondLoadData.Length} bytes.");
            
            if (firstLoadData != null && firstLoadData.Length == secondLoadData.Length)
            {
                 Console.WriteLine("[VERIFICATION] Розмір даних з кешу збігається з даними з мережі.");
            }
        }
        else
        {
            Console.WriteLine("[RESULT] Failed to get image data.");
        }

        Console.WriteLine("\n--- Завершено ---");
    }
}