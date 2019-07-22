import state from "./State";
import { UserMutations } from "./User/User.store";
import { BookDetailsMutations } from "./BookDetails/BookDetails.store";

const mutations = {
  ...UserMutations,
  ...BookDetailsMutations
};

export default mutations;
