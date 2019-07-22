const BookDetailsState = {
  book: {} as object,
  visible: false as boolean
};

const BookDetailsMutations = {
  "SHOW_BOOK_DETAILS"(state: any, params: any) {
    state.bookDetails.book = params;
    state.bookDetails.visible = true;
  },
  "CLOSE_BOOK_DETAILS"(state: any) {
    state.bookDetails.visible = false;
  }
};

export { BookDetailsState, BookDetailsMutations };