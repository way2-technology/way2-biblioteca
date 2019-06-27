<template>
  <el-container class="comments">
    <div class="comments__form">
      <el-input
        placeholder="Escreva um comentário..."
        type="textarea"
        maxlength="30"
        v-model="inputText"
        show-word-limit
      />
      <el-button type="primary" size="medium">Enviar</el-button>
    </div>
    <div class="comments__list">
      <div class="comment">Coment 1</div>
      <div class="comment">Coment 1</div>
      <div class="comment">Coment 1</div>
    </div>
  </el-container>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  data() {
    return {
      inputText: "" as string,
      comments: [] as object[]
    };
  }
});
</script>

<style lang="scss" scoped>
.comments {
  padding: 10px 0;
  flex-direction: column;

  > div {
    width: 100%;
  }

  &__form {
    display: flex;
    flex-direction: column;
    align-items: flex-end;
    margin: 10px 0;

    button {
      margin-top: 15px;
    }
  }
}
</style>
