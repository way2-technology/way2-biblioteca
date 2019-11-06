import { UserState } from "./common/User/User.store";
import { LoaderState } from "./common/Loader/Loader.store";
import { BookDetailsState } from "./components/BookDetails/BookDetails.store";
import { PopoverFilterBooksByCategoriesState } from "./components/PopoverFilterBooksByCategories/PopoverFilterBooksByCategories.store";

const state = {
  ...UserState,
  ...LoaderState,
  ...BookDetailsState,
  ...PopoverFilterBooksByCategoriesState
};

export default state;