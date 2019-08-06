interface IStatePopoverFilters {
  categoriesOptions: object[];
  categoriesSelected: object[];
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
  "SET_FILTERS"(state: IStatePopoverFilters, payload): void {
    state.categoriesSelected = payload.categories;
  }
};

export {
  State as PopoverFilterBooksByCategoriesState,
  Mutations as PopoverFilterBooksByCategoriesMutations
};