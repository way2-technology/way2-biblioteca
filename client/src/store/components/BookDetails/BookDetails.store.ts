interface IStateBookDetails {
  bookDetails: {
    book: object,
    visible: boolean
  };
}

const State: IStateBookDetails = {
  bookDetails: {
    book: {},
    visible: false
  }
};

const Mutations = {
  "SHOW_BOOK_DETAILS"(state: IStateBookDetails, { book }) {
    state.bookDetails.book = book;
    state.bookDetails.visible = true;
  },
  "CLOSE_BOOK_DETAILS"(state: IStateBookDetails) {
    state.bookDetails.visible = false;
  }
};

export { State as BookDetailsState, Mutations as BookDetailsMutations };