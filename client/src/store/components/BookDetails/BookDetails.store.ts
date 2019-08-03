interface IStateBookDetails {
  bookDetails: {
    book: object,
    visible: boolean
  };
}

const BookDetailsState: IStateBookDetails = {
  bookDetails: {
    book: {},
    visible: false
  }
};

const BookDetailsMutations = {
  "SHOW_BOOK_DETAILS"(state: IStateBookDetails, payload) {
    state.bookDetails.book = payload.book;
    state.bookDetails.visible = true;
  },
  "CLOSE_BOOK_DETAILS"(state: IStateBookDetails) {
    state.bookDetails.visible = false;
  }
};

export { BookDetailsState, BookDetailsMutations };