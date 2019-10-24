export interface IBookDisplay {
  id: number | string;
  title: string;
  description: string;
  imageUrl: string;
  category: string[];
  publicationDate: Date | string;
  publisher: string;
  pages: number;
  isbn: number | string;
  rating: object;
  borrowed: object | null;
}

function parseSingleBook(book): IBookDisplay {
  const {
    id,
    title,
    description,
    categories,
    imageUrl,
    rating,
    publisher,
    publicationDate,
    isbn,
    pages
  } = book;

  const category = categories[0] ? categories[0] : "General";

  const publicationDateFormated = publicationDate ? new Date(publicationDate).toLocaleDateString() : new Date();

  return {
    id,
    title,
    description,
    category,
    imageUrl,
    publisher,
    publicationDate: publicationDateFormated,
    pages,
    isbn,
    rating: {
      value: rating,
      count: null
    },
    borrowed: {
      avatar: "",
      fullName: ""
    }
  };
}

function parseListBooks(books: object[]): object[] {
  return books.map((book) => {
    return parseSingleBook(book);
  });
}

export {
  parseSingleBook,
  parseListBooks
};