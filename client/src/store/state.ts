import { UserState } from "./User/User.store";
import { BookDetailsState } from "./BookDetails/BookDetails.store";

const state = {
  user: UserState,
  bookDetails: BookDetailsState
};

export default state;