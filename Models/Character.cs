namespace Core.Models
{
    
    public class Character
    {
        public string Name { get; set; }
        public string Element { get; set; } 
        public int Stars { get; set; }
        public string ImageUrl { get; set; } 
        public string WeaponType { get; set; } 
        public string ShortDescription { get; set; } 
        
        
        public override string ToString()
        {
            return $"{Name} ({Stars}*) - Елемент: {Element} / Зброя: {WeaponType}";
        }
    }
}