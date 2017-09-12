using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GigHub.Core.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public bool isCanceled { get; private set; }

        public ApplicationUser Artist { get; set; }
         
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        public string Venue { get; set; }
  
        public Genre Genre { get; set; }
      
        public byte GenreId { get; set; }

        public ICollection<Attendance> Attendances { get;private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }
        public void Cancel() {

            isCanceled = true;
            var notification =Notification.GigCanceled(this);


            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }

        }
        public void Modify(DateTime datetime , string venue , byte genre)
        {
            var notification =Notification.GigUpdated(this, DateTime , Venue);
            Venue = venue;
            DateTime = datetime;
            GenreId = genre;
            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }

        }
    }
  
}