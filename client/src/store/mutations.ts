import state from "./state";
import { UserMutations } from "./User/User.store";
import { BookDetailsMutations } from "./BookDetails/BookDetails.store";
import { PopoverFilterBooksByCategoriesMutations } from "./PopoverFilterBooksByCategories/PopoverFilterBooksByCategories.store";

const mutations = {
  ...UserMutations,
  ...BookDetailsMutations,
  ...PopoverFilterBooksByCategoriesMutations
};

export default mutations;
