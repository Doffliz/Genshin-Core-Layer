using System;
using System.Threading.Tasks;
using Core.Services;
using Core.Mocks; 
using System.Collections.Generic;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("--- Практичне Заняття 14: Розширена Core Логіка ---");

        var mockRepo = new MockCharacterRepository();
        var service = new CharacterService(mockRepo);

        Console.WriteLine("Старт завантаження та обробки даних...");
        
        List<Core.Models.Character> characters;
        try
        {
            characters = await service.LoadCharactersAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка під час завантаження: {ex.Message}");
            return;
        }

        Console.WriteLine("\n--- Оброблений результат (Трансформація та Фільтрація успішна) ---");

        foreach (var c in characters)
        {
            
            Console.WriteLine($"\n> {c.ToString()}"); 
            Console.WriteLine($"  Опис: {c.ShortDescription}");
            Console.WriteLine($"  URL: {c.ImageUrl}");
        }
        
        
        Console.WriteLine($"\nКількість оброблених персонажів: {characters.Count} (Sayu 3* відфільтровано)"); 
        Console.WriteLine("\n--- Завершено ---");
    }
}