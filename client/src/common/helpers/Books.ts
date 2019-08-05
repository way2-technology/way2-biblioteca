function parseBooks(books: object[]): object[] {
  return books.map((book: any) => {
    const {
      id,
      volumeInfo: { categories, title, imageLinks }
    } = book;

    const category =
      categories && typeof categories === "object" ? categories[0] : "General";

    const image = imageLinks ? imageLinks.thumbnail : "";

    return {
      id,
      title,
      category,
      image,
      borrowed: {
        avatar: "",
        fullName: ""
      },
      rate: {
        value: 5,
        count: 5
      }
    };
  });
};


export {
  parseBooks
};