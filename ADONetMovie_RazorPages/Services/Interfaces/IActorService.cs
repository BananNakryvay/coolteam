using ADONetMovie_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.Interfaces
{
   public  interface IActorService
    {
        IEnumerable<Actor> GetActors();
        public Actor GetActorById(int id);
       void DeleteActor(Actor actor);

    }
}
