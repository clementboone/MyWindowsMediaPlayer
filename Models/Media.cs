using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player
{
    public class Media
    {
        public  int NbPlayed { get; set; }
        public  int Rating { get; set; }
        public DateTime lastPlay { get; set; }
        private string _location = null;
        public string Location {
            get
            {
                return this._location;
            }
            set
            {
                if (this._location == null)
                    this._location = value;
            }
        }

    }
}
