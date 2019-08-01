import { UserState } from "./User/User.store";
import { BookDetailsState } from "./BookDetails/BookDetails.store";
import { PopoverFilterBooksByCategoriesState } from "./PopoverFilterBooksByCategories/PopoverFilterBooksByCategories.store";

const state = {
  ...UserState,
  ...BookDetailsState,
  ...PopoverFilterBooksByCategoriesState
};

export default state;