<template>
  <el-dialog class="modal-new-book" title="Novo Livro" :visible.sync="visible">
    <el-form :model="form">
      <el-form-item label="Titulo">
        <el-input v-model="form.title"></el-input>
      </el-form-item>
      <el-form-item label="Titulo">
        <el-input v-model="form.title"></el-input>
      </el-form-item>
    </el-form>
    <div slot="footer" class="modal-new-book__footer">
      <el-button type="primary">Cadastrar</el-button>
    </div>
  </el-dialog>
</template>

<script lang="ts">
import Vue from "vue";
import { EventBus } from "@/providers/EventBus.js";

interface IForm {
  title: string;
  image: string;
  publicacao: Date;
  editora: string;
  paginas: number;
  categorias: string[];
}

export default Vue.extend({
  data() {
    return {
      visible: false as boolean,
      form: {} as IForm
    };
  },
  created() {
    this.listenEventNewBook();
  },
  methods: {
    listenEventNewBook(): EventBus<void> {
      EventBus.$on("show-modal-new-book", () => {
        this.visible = true;
      });
    }
  }
});
</script>

<style lang="scss">
.modal-new-book {
  &__footer {
    display: flex;

    button {
      display: flex;
      align-items: center;
      justify-content: center;

      &:last-child {
        flex-grow: 1;
      }
    }
  }
}
</style>
