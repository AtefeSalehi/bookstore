using System;
using DataBaseAccess;
using Domain.Entities;
using Service;
using StructureMap;

namespace BookStoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new StructureMap.Container(new DependencyRegister());
            var userservice = container.GetInstance<UserService>();
            var userDBservice = container.GetInstance<UserDataBaseAccess>();
            var bookDB = container.GetInstance<BookDataBaseAccess>();
            var basket = container.GetInstance<BasketDataBaseAccess>();
            var basketDetails = container.GetInstance<BasketDetailsDataBaseAccess>();
            var bookservice = container.GetInstance<BookService>();



            while (true)
            {
                string username, password, fname, lname;
                Console.WriteLine("1.Register User   2.Login User");
                int typeop = int.Parse(Console.ReadLine());
                if (typeop == 1)
                {
                    while (true)
                    {
                        Console.WriteLine("Enter Your UserName : ");
                        username = Console.ReadLine();
                        var user_1 = userservice.Finduser(username);
                        if (user_1.GetType() == typeof(User))
                        {
                            Console.WriteLine("Your username is duplicate. Please enter another one: ");
                        }
                        else
                        {
                            User newuser = new User();
                            newuser.username = username;

                            Console.WriteLine("Enter Your PassWord : ");
                            password = Console.ReadLine();
                            Console.WriteLine("Enter Your Name : ");
                            fname = Console.ReadLine();
                            Console.WriteLine("Enter Your Last Name : ");
                            lname = Console.ReadLine();

                            newuser.password = password;
                            newuser.fname = fname;
                            newuser.lname = lname;
                            userDBservice.AddUserToDB(newuser);
                            break;
                        }
                    }
                }
                else if (typeop == 2)
                {
                    while (true)
                    {
                        Console.WriteLine("Enter Your UserName : ");
                        username = Console.ReadLine();
                        Console.WriteLine("Enter Your PassWord : ");
                        password = Console.ReadLine();
                        var login = userservice.Login(username, password);
                        //if username or password correct
                        if (login != null)
                        {
                            Console.WriteLine("Wellcome!");
                            while (true)
                            {
                                Console.WriteLine("1.Buy Book  2.Show Shopping Cart");
                                int typeOfMenu = int.Parse(Console.ReadLine());
                                if (typeOfMenu == 1)
                                {
                                    var book_1 = bookDB.SelectBook();
                                    foreach (var item in book_1)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.WriteLine("Enter Id book: ");
                                    int bookid = int.Parse(Console.ReadLine());
                                    var book = bookservice.FindBook(bookid);
                                    Console.WriteLine("Enter Count: ");
                                    int bookCount = int.Parse(Console.ReadLine());

                                    //insert userid and date.now
                                    var basketid = basket.AddBasket(login);
                                    if (basketid != 0)
                                    {
                                        basketDetails.AddBasketDetails(basketid, book, bookCount);
                                        Console.WriteLine("Your buying successful! ");
                                    }
                                }
                                else if (typeOfMenu == 2)
                                {
                                    var basket_2 = basketDetails.GetAllBasket(login);
                                    foreach (var item in basket_2)
                                    {
                                        Console.WriteLine(item);
                                    }
                                }

                                else
                                    Console.WriteLine("Your username or password was wrong! ");

                            }
                        }



                    }
                }
            }
        }
    }
}
