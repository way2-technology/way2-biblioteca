<template>
  <div class="avatar">
    <figure>
      <img :src="url" alt="User Avatar" />
    </figure>
    <div>
      <small class="desc" v-if="desc">{{ desc }}</small>
      <strong class="name" v-if="name">{{ name }}</strong>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  name: "avatar",
  props: {
    url: {
      type: String,
      required: true
    },
    name: {
      type: String,
      default: ""
    },
    desc: {
      type: String,
      default: ""
    }
  }
});
</script>

<style lang="scss" scoped>
.avatar {
  display: flex;
  align-items: center;

  figure {
    width: 30px;
    height: 30px;
    border-radius: 100%;
    background: #eee;
    margin: 0 8px 0 0;
    overflow: hidden;
  }

  img {
    width: 100%;
  }
  .name {
    font-size: 16px;
  }

  div {
    display: flex;
    flex-direction: column;
  }
}
</style>

