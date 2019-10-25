using System;
using System.Collections.Generic;
using System.IO;

namespace TheaterBooking
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<List<string>> rows = BookingRepository.ParseLayoutAndBooking("input.txt");
                BookingRepository.CalculateTheaterCapacity(rows);
                BookingRepository.AllotSeating();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
