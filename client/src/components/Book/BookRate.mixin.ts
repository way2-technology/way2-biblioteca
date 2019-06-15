const BookRateMixin = {
  data() {
    return {
      rate: {
        value: 1,
        colors: ["#99A9BF", "#F7BA2A", "#FF9900"],
        texts: ["Ruim", "Poderia ser melhor", "Regular", "Muito Bom", "Excelente"]
      } as object
    };
  }
};

export default BookRateMixin;