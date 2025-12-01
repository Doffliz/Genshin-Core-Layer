
using System.Text;

namespace Genshin_Core_Layer.Models
{
    public class CharacterDto 
    {
        
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? PortraitUrl { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, URL: {PortraitUrl}";
        }
    }
}