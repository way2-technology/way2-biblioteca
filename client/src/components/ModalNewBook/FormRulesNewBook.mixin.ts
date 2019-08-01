export interface IFormRulesNewBook {
  requiredOnlyBlur: object[];
  requiredMessageBlur: object[];
}

const FormRulesNewBookMixin = {
  computed: {
    formRules(): IFormRulesNewBook {
      return {
        requiredOnlyBlur: [{
          required: true,
          trigger: "blur"
        }],
        requiredMessageBlur: [{
          required: true,
          message: "Campo obrigatório",
          trigger: "blur"
        }]
      };
    }
  }
};

export default FormRulesNewBookMixin;