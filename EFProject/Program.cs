using EFProject.Entities;
using EFProject.Repositories;

namespace EFProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                var User1 = new User { Name = "Art", Email = "art@mail.com" };
                var User2 = new User { Name = "Max", Email = "max@mail.com" };
                var Book1 = new Book { Name = "The Queen of Spades", CreatedDate = 1834, Author = "Pushkin", Genre = "Story" };
                var Book2 = new Book { Name = "The Captain's Daughter", CreatedDate = 1836, Author = "Pushkin", Genre = "Historical novel" };
                var Book3 = new Book { Name = "War and Peace", CreatedDate = 1869, Author = "Leo Tolstoy", Genre = "Historical novel" };
                var Book4 = new Book { Name = "Ward No. 6", CreatedDate = 1892, Author = "Anton Chekhov", Genre = "Novel" };
                var BookRepository = new BookRepository(db);
                var UserRepository = new UserRepository(db);
                UserRepository.AddUser(User1);
                UserRepository.AddUser(User2);
                BookRepository.AddBook(Book1);
                BookRepository.AddBook(Book2);
                BookRepository.AddBook(Book3);
                BookRepository.AddBook(Book4);
                UserRepository.TakeBook(User1, Book2);
                UserRepository.TakeBook(User1, Book1);
                UserRepository.TakeBook(User1, Book3);
                UserRepository.TakeBook(User2, Book4);

                db.SaveChanges();
                var book = BookRepository.GetAllBooks();
            }
        }
    }
}
