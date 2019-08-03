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
          trigger: "blur",
          message: "Campo obrigatório",
        }]
      };
    }
  }
};

export default FormRulesNewBookMixin;