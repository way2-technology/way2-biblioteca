interface IStatePopoverFilters {
  categoriesSelected: object[];
}

const PopoverFilterBooksByCategoriesState: IStatePopoverFilters = {
  categoriesSelected: []
};

const PopoverFilterBooksByCategoriesMutations = {
  "SET_FILTERS"(state: IStatePopoverFilters, payload: any): void {
    state.categoriesSelected = payload.categories;
  }
};

export {
  PopoverFilterBooksByCategoriesState,
  PopoverFilterBooksByCategoriesMutations
};