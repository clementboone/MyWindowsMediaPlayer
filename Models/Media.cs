using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    class Media
    {
        public  int NbPlayed { get; set; }
        public  int Rating { get; set; }
        public DateTime lastPlay { get; set; }
        public string Location { get; private set; }
        
        
        public Media(string location)
        {
            this.Location = location;
        }
    }
}
