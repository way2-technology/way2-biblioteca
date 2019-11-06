interface IRating {
  rating: {
    colors: string[];
  };
}

const BookRatingMixin = {
  data(): IRating {
    return {
      rating: {
        colors: ["#99A9BF", "#F7BA2A", "#FF9900"]
      }
    };
  }
};

export default BookRatingMixin;