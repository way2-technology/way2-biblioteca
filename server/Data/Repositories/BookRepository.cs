using Dapper;
using Data.Interfaces.Helpers;
using Data.Interfaces.Repositories;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories {
    public class BookRepository : IBookRepository {
        private readonly ISqlConnectionHelper _sqlConnectionHelper;

        private const string BookFields = @" b.id as Id, b.title as Title, b.isbn13 as ISBN13, b.isbn10 as ISBN, b.goodreads_id as GoodreadsId, b.image_url as ImageUrl,
                    b.publication as PublicationDate, b.description as Description, b.goodreads_rating as AverageRating, b.goodreads_rating_count as RatingCount,
                    b.pages as NumberOfPages, b.goodreads_url as GoodreadsUrl ";

        private string BaseBooksSql(string condition) =>
            $@"SELECT {BookFields} 
                 FROM book b 
                      {condition}
                ORDER by b.goodreads_rating desc, b.title
               OFFSET     @offset ROWS
                FETCH NEXT @fetch ROWS ONLY;";

        public BookRepository(ISqlConnectionHelper sqlConnectionFactory) {
            _sqlConnectionHelper = sqlConnectionFactory;
        }

        public IEnumerable<Book> ListAll(int skip, int take) =>
            _sqlConnectionHelper.Query<Book>(BuildSql(), new { offset = skip, fetch = take });

        public IEnumerable<Book> Search(string keyword, int[] categoryIds, int skip, int take) {
            var condicoes = new List<string>();
            if (!string.IsNullOrWhiteSpace(keyword)) {
                condicoes.Add($" title like '%{keyword}%' or description like '%{keyword}%' ");
            }
            if (categoryIds.Length > 0) {
                condicoes.Add($"exists (select 1 from book_categories ct where book_id = b.id and ct.category_id in ({string.Join(',', categoryIds)}))");
            }
            var sql = BuildSql(string.Join(" and ", condicoes.ToArray()));
            return _sqlConnectionHelper.Query<Book>(sql, new { offset = skip, fetch = take });
        }

        public void Save(Book bookToSave) {
            throw new NotImplementedException();
        }

        public Book Load(int id) {
            using (var conn = _sqlConnectionHelper.CreateNewConnection()) {
                var sql = BuildSql("id = @id") +
                    "select c.id, name from category c join book_categories bc on bc.category_id = c.id and bc.book_id = @id;";
                using (var multi = conn.QueryMultiple(sql, new { id, offset = 0, fetch = int.MaxValue })) {
                    var book = multi.Read<Book>().FirstOrDefault();
                    if (book != null) {
                        book.Categories = multi.Read<Category>().ToArray();
                        return book;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Category> GetActiveCategories() =>
            _sqlConnectionHelper.Query<Category>("select id as ID, name as Name from category order by name", null);

        public IEnumerable<Book> ListAll(int[] categoryIds, int skip, int take) {
            var sql = $@"
                SELECT {BookFields}
                FROM book b
                join book_categories bc on bc.book_id = b.id
				where bc.category_id in (@categoryIds)
                ORDER by goodreads_rating desc, title
                OFFSET     @skip ROWS
                FETCH NEXT @take ROWS ONLY;";
            return _sqlConnectionHelper.Query<Book>(sql, new { categoryIds, skip, take });
        }

        private string BuildSql(string condition = null) {
            return string.IsNullOrWhiteSpace(condition) ?
                BaseBooksSql(string.Empty) :
                BaseBooksSql($" where {condition}");
        }

        public int CountAll() =>
            _sqlConnectionHelper.Count("book", string.Empty);
    }
}