<template>
  <div class="book">
    <el-card>
      <figure class="book__image" @click="triggerShowBook">
        <img :src="$urlBaseApi + book.imageUrl" />
      </figure>

      <div class="book__categories">
        <el-tag size="mini">{{book.category}}</el-tag>
      </div>

      <h2 class="book__title">{{ book.title }}</h2>

      <footer>
        <el-rate disabled v-model="book.rating.value" :colors="rating.colors" />

        <!-- TODO: [Usuário Logado] -->
        <!-- TODO: Função para pegar livro emprestado de acordo com o usuário -->
        <!-- <template v-if="$userLogged">
          <el-tooltip
            class="item"
            effect="dark"
            content="Pegar este livro emprestado"
            placement="top"
            v-if="book.borrowed"
          >
            <button type="text" v-loading>
              <Unicon name="bookmark" />
            </button>
          </el-tooltip>

          <Avatar v-else :url="book.borrowed.avatar" />
        </template> -->
      </footer>
    </el-card>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Avatar from "@/common/components/Avatar.vue";
import BookRatingMixin from "../BookRating.mixin";

export default Vue.extend({
  name: "book-preview",
  components: {
    Avatar
  },
  props: {
    book: {
      type: Object,
      required: true
    }
  },
  mixins: [BookRatingMixin],
  methods: {
    triggerShowBook(): void {
      this.$emit("trigger-show-book", this.book.id);
    }
  }
});
</script>

<style lang="scss" src="./BookPreview.scss" />