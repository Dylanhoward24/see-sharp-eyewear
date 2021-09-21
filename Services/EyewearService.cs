using SeeSharpEyewear.Models;
using System.Collections.Generic;
using System.Linq;
 
namespace SeeSharpEyewear.Services
{
   public static class EyewearService
   {
       static List<Eyewear> Glasses { get; }
       static int nextId = 4;
       static EyewearService()
       {
           Glasses = new List<Eyewear>
           {
               new Eyewear { Id = 1, Name = "Ray-Ban Clubmaster", Color = "Brown / Gold", Shape = "Browline" },
               new Eyewear { Id = 2, Name = "Ottoto Bellona", Color = "Pink / Gold", Shape = "Oval" },
               new Eyewear { Id = 3, Name = "Oakley Socket 5.5", Color = "Gunmetal", Shape = "Rectangle" }
           };
       }
 
       public static List<Eyewear> GetAll() => Glasses;
 
       public static Eyewear Get(int id) => Glasses.FirstOrDefault(p => p.Id == id);
 
       public static void Add(Eyewear eyewear)
       {
           eyewear.Id = nextId++;
           Glasses.Add(eyewear);
       }
 
       public static void Delete(int id)
       {
           var eyewear = Get(id);
           if(eyewear is null)
               return;
 
           Glasses.Remove(eyewear);
       }
 
       public static void Update(Eyewear eyewear)
       {
           var index = Glasses.FindIndex(p => p.Id == eyewear.Id);
           if(index == -1)
               return;
 
           Glasses[index] = eyewear;
       }
   }
}

