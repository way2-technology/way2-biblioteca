export default {
  computed: {
    $userLogged(): object {
      const {
        user: { info }
      } = this.$store.state;

      return info;
    }
  }
};