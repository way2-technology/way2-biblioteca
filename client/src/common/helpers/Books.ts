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

  const category =
    categories && typeof categories === "object" ? categories[0] : "General";

  const publicationDateFormated = publicationDate ? new Date(publicationDate).toLocaleDateString() : new Date();

  return {
    id,
    title,
    description,
    category,
    imageUrl,
    borrowed: {
      avatar: "",
      fullName: ""
    },
    rating: {
      value: rating,
      count: null
    },
    publisher,
    publicationDate: publicationDateFormated,
    isbn,
    pages
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