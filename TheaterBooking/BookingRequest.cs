using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterBooking
{
    class BookingRequest
    {
        public string Name { get; set; }
        public int TicketsRequest { get; set; }

        public int Row { get; set; }

        public int Section { get; set; }

        public bool IsMessage { get; set; }

        public string Message { get; set; }

        public BookingRequest(string _Name, int _TicketsRequest)
        {
            Name = _Name;
            TicketsRequest = _TicketsRequest;
            Row = 0;
            Section = 0;
            IsMessage = false;
            Message = "";
        }

        public override string ToString()
        {
            if (IsMessage)
            {
                return Message;
            }
            else
            {
                return Name + " Row " + Row + " Section " + Section;
            }
        }
    }
}
