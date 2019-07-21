const BookDetailsState = {
  book: {} as object,
  visible: false as boolean
};

const BookDetailsMutations = {
  "SHOW_BOOK_DETAILS"(state: any, book: any) {
    state.bookDetails.book = book;
    state.bookDetails.visible = true;
  },
  "CLOSE_BOOK_DETAILS"(state: any) {
    state.bookDetails.visible = false;
  }
};

export { BookDetailsState, BookDetailsMutations };