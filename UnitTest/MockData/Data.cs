//using backend.DataAccess;
//using backend.Entities;
//using Faker;
//using System.Collections.Generic;
//using System.Linq;

//namespace UnitTest.MockData
//{
//    public static class Data
//    {
//        public static void Seed(ProjectDbContext dbContext)
//        {
//            List<User> users = new List<User>()
//            {
//                new User
//                {
//                    Username = Faker.Name.First(),
//                    Password = Faker.Lorem.Words(1).First(),
//                    Email = Faker.Internet.Email(),
//                    // DateOfBirth = Faker.Date.
//                    FirstName = Faker.Name.First(),
//                    LastName = Faker.Name.Last(),
//                    Address = Faker.Address.StreetAddress(),
//                    PhoneNumber = Faker.Phone.Number(),

//                },

//                 new User
//                {
//                    Username = Faker.Name.First(),
//                    Password = Faker.Lorem.Words(1).First(),
//                    Email = Faker.Internet.Email(),
//                    // DateOfBirth = Faker.Date.
//                    FirstName = Faker.Name.First(),
//                    LastName = Faker.Name.Last(),
//                    Address = Faker.Address.StreetAddress(),
//                    PhoneNumber = Faker.Phone.Number(),

//                },
//                  new User
//                {
//                    Username = Faker.Name.First(),
//                    Password = Faker.Lorem.Words(1).First(),
//                    Email = Faker.Internet.Email(),
//                    // DateOfBirth = Faker.Date.
//                    FirstName = Faker.Name.First(),
//                    LastName = Faker.Name.Last(),
//                    Address = Faker.Address.StreetAddress(),
//                    PhoneNumber = Faker.Phone.Number(),

//                },
//                   new User
//                {
//                    Username = Faker.Name.First(),
//                    Password = Faker.Lorem.Words(1).First(),
//                    Email = Faker.Internet.Email(),
//                    // DateOfBirth = Faker.Date.
//                    FirstName = Faker.Name.First(),
//                    LastName = Faker.Name.Last(),
//                    Address = Faker.Address.StreetAddress(),
//                    PhoneNumber = Faker.Phone.Number(),

//                },
//                    new User
//                {
//                    Username = Faker.Name.First(),
//                    Password = Faker.Lorem.Words(1).First(),
//                    Email = Faker.Internet.Email(),
//                    // DateOfBirth = Faker.Date.
//                    FirstName = Faker.Name.First(),
//                    LastName = Faker.Name.Last(),
//                    Address = Faker.Address.StreetAddress(),
//                    PhoneNumber = Faker.Phone.Number(),

//                },

//            };
//            List<Event> events = new List<Event>()
//            {
//                new Event
//                {
//                    Name = Faker.Name.FullName(),
//                    Description = Faker.Lorem.Sentence(),
//                    // DateAndTime = Faker.DateAndTime.Recent(),
//                    //Location = Faker.Address.FullAddress(),
//                    OrganizerID = Faker.RandomNumber.Next(1, 1000),
//                    TicketsAvailable = Faker.RandomNumber.Next(1, 100),
//                    TicketPrice = Faker.RandomNumber.Next(10, 1000),
//                    Tickets = new List<Ticket>(),
//                    Orders = new List<Order>()
//                },
//                new Event
//                {
//                    Name = Faker.Name.FullName(),
//                    Description = Faker.Lorem.Sentence(),
//                    // DateAndTime = Faker.DateAndTime.Recent(),
//                    //Location = Faker.Address.FullAddress(),
//                    OrganizerID = Faker.RandomNumber.Next(1, 1000),
//                    TicketsAvailable = Faker.RandomNumber.Next(1, 100),
//                    TicketPrice = Faker.RandomNumber.Next(10, 1000),
//                    Tickets = new List<Ticket>(),
//                    Orders = new List<Order>()
//                },
//                new Event
//                {
//                    Name = Faker.Name.FullName(),
//                    Description = Faker.Lorem.Sentence(),
//                    // DateAndTime = Faker.DateAndTime.Recent(),
//                    //Location = Faker.Address.FullAddress(),
//                    OrganizerID = Faker.RandomNumber.Next(1, 1000),
//                    TicketsAvailable = Faker.RandomNumber.Next(1, 100),
//                    TicketPrice = Faker.RandomNumber.Next(10, 1000),
//                    Tickets = new List<Ticket>(),
//                    Orders = new List<Order>()
//                },
//                new Event
//                {
//                    Name = Faker.Name.FullName(),
//                    Description = Faker.Lorem.Sentence(),
//                    // DateAndTime = Faker.DateAndTime.Recent(),
//                    //Location = Faker.Address.FullAddress(),
//                    OrganizerID = Faker.RandomNumber.Next(1, 1000),
//                    TicketsAvailable = Faker.RandomNumber.Next(1, 100),
//                    TicketPrice = Faker.RandomNumber.Next(10, 1000),
//                    Tickets = new List<Ticket>(),
//                    Orders = new List<Order>()
//                },
//                new Event
//                {
//                    Name = Faker.Name.FullName(),
//                    Description = Faker.Lorem.Sentence(),
//                    // DateAndTime = Faker.DateAndTime.Recent(),
//                    //Location = Faker.Address.FullAddress(),
//                    OrganizerID = Faker.RandomNumber.Next(1, 1000),
//                    TicketsAvailable = Faker.RandomNumber.Next(1, 100),
//                    TicketPrice = Faker.RandomNumber.Next(10, 1000),
//                    Tickets = new List<Ticket>(),
//                    Orders = new List<Order>()
//                },
//            };

//            List<Ticket> tickets = new List<Ticket>()
//            {
//                new Ticket
//                {

//                    //TicketType = Faker.Lorem.Word(1),
//                    Price = Faker.RandomNumber.Next(10, 100),
//                    QuantityAvailable = Faker.RandomNumber.Next(1, 100),
//                    //SaleStartDate = Faker.DateAndTime.Between(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-1)),
//                    // SaleEndDate = Faker.DateAndTime.Between(DateTime.Now, DateTime.Now.AddDays(30))
//                },
//                new Ticket
//                {

//                    //TicketType = Faker.Lorem.Word(1),
//                    Price = Faker.RandomNumber.Next(10, 100),
//                    QuantityAvailable = Faker.RandomNumber.Next(1, 100),
//                    //SaleStartDate = Faker.DateAndTime.Between(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-1)),
//                    // SaleEndDate = Faker.DateAndTime.Between(DateTime.Now, DateTime.Now.AddDays(30))
//                },
//                new Ticket
//                {

//                    //TicketType = Faker.Lorem.Word(1),
//                    Price = Faker.RandomNumber.Next(10, 100),
//                    QuantityAvailable = Faker.RandomNumber.Next(1, 100),
//                    //SaleStartDate = Faker.DateAndTime.Between(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-1)),
//                    // SaleEndDate = Faker.DateAndTime.Between(DateTime.Now, DateTime.Now.AddDays(30))
//                },
//                new Ticket
//                {

//                    //TicketType = Faker.Lorem.Word(1),
//                    Price = Faker.RandomNumber.Next(10, 100),
//                    QuantityAvailable = Faker.RandomNumber.Next(1, 100),
//                    //SaleStartDate = Faker.DateAndTime.Between(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-1)),
//                    // SaleEndDate = Faker.DateAndTime.Between(DateTime.Now, DateTime.Now.AddDays(30))
//                },
//                new Ticket
//                {

//                    //TicketType = Faker.Lorem.Word(1),
//                    Price = Faker.RandomNumber.Next(10, 100),
//                    QuantityAvailable = Faker.RandomNumber.Next(1, 100),
//                    //SaleStartDate = Faker.DateAndTime.Between(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-1)),
//                    // SaleEndDate = Faker.DateAndTime.Between(DateTime.Now, DateTime.Now.AddDays(30))
//                },
//            };
//            if (!dbContext.Users.Any())
//                dbContext.Users.AddRange(users);

//            if (!dbContext.Events.Any())
//                dbContext.Events.AddRange(events);

//            if (!dbContext.Tickets.Any())
//                dbContext.Tickets.AddRange(tickets);

//            dbContext.SaveChanges();
//        }
//    }
//}
