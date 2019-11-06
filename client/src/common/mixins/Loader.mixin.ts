export default {
  computed: {
    $loader(): object {
      return this.$store.state.loader;
    }
  }
};