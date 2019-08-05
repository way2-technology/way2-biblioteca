interface IStatePopoverFilters {
  categoriesSelected: object[];
}

const State: IStatePopoverFilters = {
  categoriesSelected: []
};

const Mutations = {
  "SET_FILTERS"(state: IStatePopoverFilters, payload): void {
    state.categoriesSelected = payload.categories;
  }
};

export {
  State as PopoverFilterBooksByCategoriesState,
  Mutations as PopoverFilterBooksByCategoriesMutations
};