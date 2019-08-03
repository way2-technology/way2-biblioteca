import { UserMutations } from "./common/User/User.store";
import { LoaderMutations } from "./common/Loader/Loader.store";
import { BookDetailsMutations } from "./components/BookDetails/BookDetails.store";
import { PopoverFilterBooksByCategoriesMutations } from "./components/PopoverFilterBooksByCategories/PopoverFilterBooksByCategories.store";

const mutations = {
  ...UserMutations,
  ...LoaderMutations,
  ...BookDetailsMutations,
  ...PopoverFilterBooksByCategoriesMutations
};

export default mutations;
