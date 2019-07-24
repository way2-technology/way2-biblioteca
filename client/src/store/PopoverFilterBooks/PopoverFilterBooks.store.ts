const PopoverFilterBooksState = {
  categories: [] as object[],
};

const PopoverFilterBooksMutations = {
  "SET_FILTERS"(state: any, params: any) {
    state.categories = params;
  }
};

export { PopoverFilterBooksState, PopoverFilterBooksMutations };