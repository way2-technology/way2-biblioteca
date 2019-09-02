type ArrayCategories = Array<{ id: number, value: string }>;
interface IStatePopoverFilters {
  categoriesOptions: ArrayCategories;
  categoriesSelected: ArrayCategories;
}

const State: IStatePopoverFilters = {
  categoriesOptions: [],
  categoriesSelected: []
};

const Mutations = {
  "SET_OPTIONS"(state: IStatePopoverFilters, { categories }): void {
    state.categoriesOptions = categories;
  },
  "SET_FILTERS"(state: IStatePopoverFilters, { categories }): void {
    state.categoriesSelected = categories;
  }
};

export {
  State as PopoverFilterBooksByCategoriesState,
  Mutations as PopoverFilterBooksByCategoriesMutations
};