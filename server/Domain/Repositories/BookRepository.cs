using Dapper;
using Domain.Entities;
using Domain.Interfaces.Helpers;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ISqlConnectionHelper _sqlConnectionHelper;

        private const string BookFields = @"id as Id, title as Title, isbn13 as ISBN13, isbn10 as ISBN, goodreads_id as GoodreadsId, image_url as ImageUrl,
                    publication as PublicationDate, description as Description, goodreads_rating as AverageRating, goodreads_rating_count as RatingCount,
                    pages as NumberOfPages, goodreads_url as GoodreadsUrl";

        private string BaseBooksSql(string condition) =>
            $@"SELECT {BookFields} FROM book {condition}
                ORDER by goodreads_rating desc, title
               OFFSET     @offset ROWS
                FETCH NEXT @fetch ROWS ONLY;";

        public BookRepository(ISqlConnectionHelper sqlConnectionFactory)
        {
            _sqlConnectionHelper = sqlConnectionFactory;
        }

        public IEnumerable<Book> ListAll(int skip, int take) =>
            _sqlConnectionHelper.Query<Book>(BuildSql(), new { offset = skip, fetch = take });

        public IEnumerable<Book> Search(string keyword, int skip, int take)
        {
            var sql = BuildSql($"title like '%{keyword}%' or description like '%{keyword}%'");
            return _sqlConnectionHelper.Query<Book>(sql, new { offset = skip, fetch = take });
        }

        public void Save(Book bookToSave)
        {
            throw new NotImplementedException();
        }

        public Book Load(int id)
        {
            using (var conn = _sqlConnectionHelper.CreateNewConnection())
            {
                var sql = BuildSql("id = @id") +
                    "select c.id, name from category c join book_categories bc on bc.category_id = c.id and bc.book_id = @id;";
                using (var multi = conn.QueryMultiple(sql, new { id, offset = 0, fetch = int.MaxValue }))
                {
                    var book = multi.Read<Book>().FirstOrDefault();
                    if (book != null)
                    {
                        book.Categories = multi.Read<Category>().ToArray();
                        return book;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Category> GetActiveCategories() =>
            _sqlConnectionHelper.Query<Category>("select id as ID, name as Name from category order by name", null);

        public IEnumerable<Book> ListAll(int categoryId, int skip, int take)
        {
            var sql = $@"
                SELECT {BookFields}
                FROM book b
                join book_categories bc on bc.book_id = b.id
				where bc.category_id = @categoryId
                ORDER by goodreads_rating desc, title
                OFFSET     @skip ROWS
                FETCH NEXT @take ROWS ONLY;";
            return _sqlConnectionHelper.Query<Book>(sql, new { categoryId, skip, take });
        }

        private string BuildSql(string condition = null) =>
            condition == null ?
            BaseBooksSql(string.Empty) :
            BaseBooksSql($" where {condition}");
    }
}