using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSamlpe
{
    internal class Program
    {
        public struct User
        {
            public User(string nick, string email, int year, string country)
            {
                Nick = nick;
                Email = email;
                YearOfBorn = year;
                Country = country;
            }

            public string Nick { get; }
            public string Email { get; }
            public int YearOfBorn { get; }
            public string Country { get; }

            public override string ToString()
            {
                return $"Nick: {Nick} | Email: {Email} | Year: {YearOfBorn} | Country: {Country}";
            }

        }


        public static List<User> UserList;
        static void Main(string[] args)
        {
            UserList = new List<User>();
            FillUserList();
            var result = GetResult();
            
            foreach(var user in result)
            {
                Console.WriteLine(user.ToString());
            }

            Console.ReadKey();
        }

        private static void FillUserList()
        {
            UserList.Add(new User("test1", "afa@ass.pl", 1999, "Poland"));
            UserList.Add(new User("noName", "ajjjjfa@ass.com", 2015, "USA"));
            UserList.Add(new User("tex", "mmmmm@ass.cz", 2020, "Czech"));
            UserList.Add(new User("Mecha", "aa@Onet.pl", 1985, "Poland"));
            UserList.Add(new User("Dragon", "drag@on.com", 2014, "UK"));
            UserList.Add(new User("TikTak", "tik@tak.pl", 1996, "Poland"));
            UserList.Add(new User("Bombardier", "afa@ass.com", 2002, "Germany"));
            UserList.Add(new User("Dexter", "Dex@ass.pl", 2013, "UK"));
            UserList.Add(new User("HomeSitter", "afa@ass.nl", 1990, "Germany"));
            UserList.Add(new User("Terefere", "Tere@ass.pl", 1999, "Slovakia"));
            UserList.Add(new User("Gigat", "afa@Giga.pl", 2011, "Poland"));
            UserList.Add(new User("Kitanai", "Kita@ass.jp", 1999, "Japan"));
            UserList.Add(new User("Senoku", "afa@ass.jp", 2009, "Japan"));
        }

        class UserMail
        {
            public string Nick;
            public string Email;

            public UserMail(string nick, string email)
            {
                Nick = nick;
                Email = email;
            }

            public override string ToString()
            {
                return $"{Nick} posiada mail {Email}";
            }

        }

        public static IEnumerable GetResult()
        {
            return from user in UserList
                   where (user.Country == "Poland" && 2023 - user.YearOfBorn >= 18)
                   select new UserMail(user.Nick, user.Email);
        }


    }
}
