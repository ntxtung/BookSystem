using System.Collections.Generic;
using BookSystem.Entities;

namespace BookSystem.Services {
    public interface IBooksServices {
        // Return a Book by finding its Id
        Books GetBookById(int id);
        
        // Just return all books
        List<Books> GetAllBooks();
        
        // Create new book and save it to database
        int RegisterNewBook(Books book);
        
        // Update a book (Find by Id) and update its properties due to newBook properties
        int UpdateBook(int id, Books newBook);
        
        // Delete book (Find by Id), should delete its relevant rows in User_Request_Book table in database
        int DeleteBook(int id);
    }
}