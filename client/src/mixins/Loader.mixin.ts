import EventBus from "@/providers/EventBus";

export default {
  computed: {
    $loader(): object {
      return this["$store"].state.$loader;
    }
  }
};