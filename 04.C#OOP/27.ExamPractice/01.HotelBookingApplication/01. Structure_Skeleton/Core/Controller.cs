using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            if (hotels.Select(hotelName) == null)
            {
                hotels.AddNew(new Hotel(hotelName, category));
                return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
            }

            return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            Hotel hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room != null)
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }
            if (roomTypeName != "DoubleBed" && roomTypeName != "Apartment" && roomTypeName != "Studio")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            else
            {
                if (roomTypeName == "DoubleBed")
                {
                    room = new DoubleBed();
                }
                else if(roomTypeName == "Apartment")
                {
                    room = new Apartment();
                }
                else if (roomTypeName == "Studio")
                {
                    room = new Studio();
                }

                hotel.Rooms.AddNew(room);
                return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
            }
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            Hotel hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (roomTypeName != "DoubleBed" && roomTypeName != "Apartment" && roomTypeName != "Studio")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room == null)
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);

        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            List<Hotel> hotels = this.hotels.All().Where(x => x.Category == category).OrderBy(x => x.FullName).ToList();
            if (hotels.Count == 0)
            {
                return (string.Format(OutputMessages.CategoryInvalid, category));
            }
            List<IRoom> rooms = new List<IRoom>();
            Dictionary<IRoom, Hotel> selectedRoomAndHotel = new Dictionary<IRoom, Hotel>();
            foreach (var hotel in hotels)
            {
                foreach (var room in hotel.Rooms.All())
                {
                    if (room.PricePerNight > 0)
                    {
                        selectedRoomAndHotel.Add(room, hotel);
                    }
                }
            }

            selectedRoomAndHotel = selectedRoomAndHotel.OrderBy(x => x.Key.BedCapacity).ToDictionary(k => k.Key, v => v.Value);
            Hotel selectedHotel = selectedRoomAndHotel.FirstOrDefault(x => x.Key.BedCapacity >= adults + children).Value;
            IRoom selectedRoom = selectedRoomAndHotel.FirstOrDefault(x => x.Key.BedCapacity >= adults + children).Key;

            if (selectedRoom == null)
            {
                return OutputMessages.RoomNotAppropriate;
            }
            int bookingNumber = selectedHotel.Bookings.All().Count + 1;
            selectedHotel.Bookings.AddNew(new Booking(selectedRoom, duration, adults, children, bookingNumber));
            return string.Format(OutputMessages.BookingSuccessful, bookingNumber, selectedHotel.FullName);

        }

        public string HotelReport(string hotelName)
        {
            Hotel hotel = hotels.All().FirstOrDefault(x => x.FullName == hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();
            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                    sb.AppendLine();
                }
            }

            return sb.ToString().Trim();
        }
    }
}