const UserLoggedMixin = {
  computed: {
    $userLogged(): object {
      const {
        user: { info }
      } = this.$store.state;

      return info;
    }
  }
};

export default UserLoggedMixin;