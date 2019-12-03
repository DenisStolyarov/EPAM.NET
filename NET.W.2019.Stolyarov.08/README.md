# Bank
### This solution contains:
1. [Class Account](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Bank/Account.cs#L10) - Base template for user account.
2. [Class Bank](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Bank/Bank.cs#L14) - Provides a service for working with an user account:  
   + [AddAccount](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Bank/Bank.cs#L63) - Creates and add new account.
   + [CloseAccount](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Bank/Bank.cs#L91) - Remove account.
   + [Replenish](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Bank/Bank.cs#L108) - Replenishes balance and bonus points.
   + [Debit](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Bank/Bank.cs#L131) - Reduces amount money and bonus points.
   + [Save](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Bank/Bank.cs#L162) / [Load](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Bank/Bank.cs#L176) - Write / Read information from file.
# Library
### This solution contains:
1. [Class book](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Liblary/Book.cs#L12) - Initializes a new instance of the book and realize equivalence and order relations. Override Object class methods.
2. [BookListService](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Liblary/BookListService.cs#L14) - Service for work with book library:
   + [AddBook](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Liblary/BookListService.cs#L25) - Add new book.
   + [RemoveBook](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Liblary/BookListService.cs#L46) - Remove book. 
   + [SortBookByTag](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Liblary/BookListService.cs#L67) - Sort all books by certain criterion.
   + [FindBookByTag](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Liblary/BookListService.cs#L108) - Find all books by certain criterion.
   + [Save](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Liblary/BookListService.cs#L154) / [Load](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Liblary/BookListService.cs#L168) - Write / Read information from file.
3. [BookListStorage](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Liblary/BookListStorage.cs#L14) - Agent for working with streams.
---
[Book work example](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Liblary/Program.cs#L1).
[Bank work example](https://github.com/DenisStolyarov/EPAM.NET/blob/26788e5764aea02a24a60b943d0e5e142f4c8b28/NET.W.2019.Stolyarov.08/Bank/Program.cs#L1).
