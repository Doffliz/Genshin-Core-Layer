namespace Genshin_Core_Layer.Models
{
    public class Character 
    {
        
        public string? Name { get; set; }
        public string? Element { get; set; }
        
       
        public int Stars { get; set; } 
        
        public string? ImageUrl { get; set; }
        public string? WeaponType { get; set; }
        public string? ShortDescription { get; set; }
        
        public override string ToString()
        {
            
            return $"${Name ?? "N/A"} ({Stars}*) - Елемент: {Element ?? "N/A"} / Зброя: {WeaponType ?? "N/A"}";
        }
    }
}