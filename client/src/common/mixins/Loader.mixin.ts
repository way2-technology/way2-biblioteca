import EventBus from "@/common/providers/EventBus";

export default {
  computed: {
    $loader(): object {
      return this.$store.state.loader;
    }
  }
};