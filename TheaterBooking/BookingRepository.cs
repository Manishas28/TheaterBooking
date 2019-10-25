using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TheaterBooking
{
    public class BookingRepository
    {

        private static string SPACE = " ";
        static private List<List<string>> rows = new List<List<string>>();
        static private List<string> sections;
        static private List<BookingRequest> booking = new List<BookingRequest>();
        static private int totalCapacity = 0;

        public static List<List<string>> ParseLayoutAndBooking(string textInput)
        {
            try
            {

                if (File.Exists(textInput))
                {
                    using (StreamReader file = new StreamReader(textInput))
                    {
                        string ln;

                        while ((ln = file.ReadLine()).Trim() != "")
                        {
                            sections = new List<string>();
                            string[] section = ln.Split(SPACE);
                            foreach (string line in section)
                            {
                                sections.Add(line);
                            }
                            rows.Add(sections);
                        }

                        BookingRequest bookingRequest = null;
                        while ((ln = file.ReadLine()) != null)
                        {
                            string[] bking = ln.Split(SPACE);
                            bookingRequest = new BookingRequest(bking[0], Int32.Parse(bking[1]));
                            booking.Add(bookingRequest);
                        }
                        file.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                rows[0][0] = "Exception : " + ex.Message;
                return rows;
            }
            return rows;
        }

        public static void CalculateTheaterCapacity(List<List<string>> rows)
        {
            foreach (List<string> row in rows)
            {
                foreach (string sec in row)
                {
                    totalCapacity = (totalCapacity + Int32.Parse(sec.Trim()));
                }

            }

        }

        public static void AllotSeating()
        {
            foreach (BookingRequest bkng in booking)
            {
                if ((bkng.TicketsRequest > totalCapacity))
                {
                    Console.WriteLine((bkng.Name + " Sorry, we cannot handle your party"));
                }
                else
                {
                    int rowTemp = 0;
                    int section = 0;
                    bool match = false;
                    foreach (List<string> row in rows)
                    {
                        section = 0;
                        foreach (string sec in row)
                        {
                            if ((((Int32.Parse(sec) - bkng.TicketsRequest)
                                        > 1)
                                        || ((Int32.Parse(sec) - bkng.TicketsRequest)
                                        == 0)))
                            {
                                rows[rowTemp][section] = ((Int32.Parse(rows[rowTemp][section]) - bkng.TicketsRequest) + "");
                                Console.WriteLine((bkng.Name + (" Row "
                                                + ((rowTemp + 1) + (" Section "
                                                + (section + 1))))));
                                totalCapacity = (totalCapacity - bkng.TicketsRequest);
                                match = true;
                                break;
                            }

                            section++;
                        }

                        if (match)
                        {
                            break;
                        }

                        rowTemp++;
                    }

                    if (!match)
                    {
                        Console.WriteLine((bkng.Name + " Call to split party."));
                    }

                }

            }

        }
    }
}
