using Core.data;
using Core.models;
using System;
using Core.helper.exceptions;

namespace ConsoleApp1
{
    public class Program
    { 
        static void Main(string[] args)
        {
           
          

            
                int choice;
                do
                {
                    Console.WriteLine("****** Menu ******");
                    Console.WriteLine("1. Sisteme giris");
                    Console.WriteLine("0. Cixis");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            UserLogin();
                            break;
                        case 0:
                            Console.WriteLine("Çıxış edildi.");
                            break;
                        default:
                            Console.WriteLine("Yanlış seçim! Yenidən cəhd edin.");
                            break;
                    }
                } while (choice != 0);
            }

            private static void UserLogin()
            {
                int choice;
                do
                {
                    Console.WriteLine("\n1. Hotel yarat");
                    Console.WriteLine("2. Butun Hotelleri gor");
                    Console.WriteLine("3. Hotel sec");
                    Console.WriteLine("0. Evvelki menuya qayit");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            CreateHotel();
                            break;
                        case 2:
                            ShowAllHotels();
                            break;
                        case 3:
                            SelectHotel();
                            break;
                        case 0:
                            Console.WriteLine("Evvelki menuya qayidirsiniz.");
                            break;
                        default:
                            Console.WriteLine("Yanlış seçim! Yenidən cəhd edin.");
                            break;
                    }
                } while (choice != 0);
            }

            private static void CreateHotel()
           {
            Console.Write("Hotel adını daxil edin: ");
            string hotelName = Console.ReadLine();
            Hotel newHotel = new Hotel(hotelName); 
            AppDbContext.AddHotel(newHotel);
            Console.WriteLine($"{hotelName} adlı otel yaradıldı.");
        }

            private static void ShowAllHotels()
            {
                var hotels = AppDbContext.GetAllHotels();
                if (hotels.Count == 0)
                {
                    Console.WriteLine("Heç bir otel yoxdur.");
                    return;
                }

                Console.WriteLine("Mövcud otellər:");
                foreach (var hotel in hotels)
                {
                    Console.WriteLine(hotel.Name);
                }
            }

            private static void SelectHotel()
            {
                Console.Write("Hotel adını daxil edin: ");
                string name = Console.ReadLine();
                var hotel = AppDbContext.GetHotelByName(name);

                if (hotel == null)
                {
                    Console.WriteLine("Belə bir otel tapılmadı.");
                    return;
                }

                int choice;
                do
                {
                    Console.WriteLine($"\nSeçilmiş otel: {hotel.Name}");
                    Console.WriteLine("1. Room yarat");
                    Console.WriteLine("2. Roomlari gor");
                    Console.WriteLine("3. Rezervasya et");
                    Console.WriteLine("0. Evvelki menuya qayit");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            CreateRoom();
                            break;
                        case 2:
                            ShowRooms();
                            break;
                        case 3:
                            MakeReservation();
                            break;
                        case 0:
                            Console.WriteLine("Evvelki menuya qayidirsiniz.");
                            break;
                        default:
                            Console.WriteLine("Yanlış seçim! Yenidən cəhd edin.");
                            break;
                    }
                } while (choice != 0);
            }

            private static void CreateRoom()
            {
                Console.Write("Otaq adını daxil edin: ");
                string name = Console.ReadLine();
                Console.Write("Otaq qiymətini daxil edin: ");
                decimal price = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Otağın şəxsi tutumunu daxil edin: ");
                int capacity = Convert.ToInt32(Console.ReadLine());

                var newRoom = new Room(name, price, capacity);
                AppDbContext.AddRoom(newRoom);
                Console.WriteLine($"Otaq {name} yaradıldı.");
            }

            private static void ShowRooms()
            {
                 Console.Write("Istədiyiniz kriteriyanı daxil edin(ad ve ya qiymət) ");
                 var option = Console.ReadLine();
                 var rooms = AppDbContext.FindAllRooms(option);
                if (rooms.Count == 0)
                {
                    Console.WriteLine("Heç bir otaq yoxdur.");
                    return;
                }

                Console.WriteLine("Mövcud otaqlar:");
                foreach (var room in rooms)
                {
                    Console.WriteLine(room);
                }
            }

            private static void MakeReservation()
            {
                Console.Write("Otaq ID-si daxil edin: ");
                 int roomId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Müştəri sayını daxil edin: ");
                int personCount = Convert.ToInt32(Console.ReadLine());

                try
                {
                    AppDbContext.MakeReservation(roomId, personCount);
                    Console.WriteLine("Rezervasiya uğurla edildi.");
                }
                catch (NotAvailableException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


    }
