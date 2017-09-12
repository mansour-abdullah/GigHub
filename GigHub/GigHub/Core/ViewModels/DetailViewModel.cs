using GigHub.Core.Models;
namespace GigHub.Core.ViewModels
{
    public class DetailViewModel
    {
        public Gig Gig { get; set; }
        public bool Following { get; set; }
        public bool Attending { get; set; }

    }
   
}