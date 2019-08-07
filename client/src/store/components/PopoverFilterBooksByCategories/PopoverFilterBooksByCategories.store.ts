type ArrayCategories = Array<{ id: number, value: string }>;
interface IStatePopoverFilters {
  categoriesOptions: ArrayCategories;
  categoriesSelected: ArrayCategories;
}

const State: IStatePopoverFilters = {
  categoriesOptions: [
    {
      id: 1,
      value: "Option1"
    },
    {
      id: 2,
      value: "Option2"
    }
  ],
  categoriesSelected: []
};

const Mutations = {
  "SET_FILTERS"(state: IStatePopoverFilters, { categories }): void {
    state.categoriesSelected = categories;
  }
};

export {
  State as PopoverFilterBooksByCategoriesState,
  Mutations as PopoverFilterBooksByCategoriesMutations
};