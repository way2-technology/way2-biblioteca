interface IRate {
  colors: string[];
  texts: string[];
}

const BookRateMixin = {
  data() {
    return {
      rate: {
        colors: ["#99A9BF", "#F7BA2A", "#FF9900"],
        texts: ["Ruim", "Poderia ser melhor", "Regular", "Muito Bom", "Excelente"]
      } as IRate
    };
  }
};

export default BookRateMixin;