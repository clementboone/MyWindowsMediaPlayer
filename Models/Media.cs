using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    class Media
    {
        public  int NbPlayed { get; private set; }
        public  int Rating { get; private set; }
        public DateTime lastPlay { get; private set; }
        public string Location { get; private set; }
        
        
        public Media(string location)
        {
            this.Location = location;
        }
    }
}
