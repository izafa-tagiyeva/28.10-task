using Core.helper.exceptions;
using Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.data
{
    public static class AppDbContext
    {
            static List<Room> _rooms = new List<Room>();
            static List<Hotel> _hotels = new List<Hotel>();

            public static void AddRoom(Room room)
            {
                _rooms.Add(room);
            }

            public static List<Room> FindAllRooms(string name)
            {
            return _rooms.Where(r => r.Name.ToLower() == name.ToLower()).ToList();
             }


            public static List<Room> FindAllRooms(decimal price)
            {
            return _rooms.Where(r => r.Price == price).ToList();
             }

        /// ////////////////////////////////////////////////////////////////////////////////////

        public static void MakeReservation(int? roomId, int personCount)
            {

                
                if (roomId == null) throw new NotAvailableException("Room ID cannot be null.");

                Room room = _rooms.FirstOrDefault(r => r.Id == roomId);

                if (room == null || !room.IsAvailable)
                {
                    throw new NotAvailableException("Room is not available for reservation.");
                }

                if (room.PersonCapacity < personCount)
                {
                    throw new ArgumentException("Room capacity is insufficient for the number of people.");
                }

                room.IsAvailable = false; 
            }
        /// ////////////////////////////////////////////////////////////////////////////////////////
     
            public static void AddHotel(Hotel hotel)
            {
                _hotels.Add(hotel);
                 
              }

            public static List<Hotel> GetAllHotels()
            {
            return new List<Hotel>(_hotels);
             }

        public static Hotel GetHotelByName(string name)
        {
            foreach (var hotel in _hotels)
            {
                if (hotel.Name.ToLower() == name.ToLower())
                {
                    return hotel;
                }
            }
            return null; 
        }

       
    }


    }
/*AppDbContext Class

- Rooms List - içində Room obyektləri saxlayır və private-dır.
- AddRoom() - Parametr olaraq Room obyekti qəbul edib rooms arrayinə əlavə edir.
-FindAllRoom()-Parametr olaraq bir şərt qebul edecek ve gelen serte uygun olaraq otaqlari geriye qaytaracaq;

- MakeReservation() - Parametr olaraq nullable int tipindən bir roomId ve musteri sayi qəbul edir əgər roomId null olaraq geriyə NullReferanceException qaytarır əks halda göndərilən
roomId-li otaq tapılır IsAvailable dəyəri ve Personal Capacity yoxlanılır əgər IsAvailable dəyəri false-dusa geriyə yuxarıda yaratdığınız NotAvailableException qaytarılır
əgər true-dursa Personal Capacityde uygun gelirse həmin room-un IsAvailable dəyəri true olur.

ps: Name dəyəri olmadan bir Hotel obyekti yaratmaq olmaz.


- Hotel List- içində Hotel obyektləri saxlayır və private-dır
*/