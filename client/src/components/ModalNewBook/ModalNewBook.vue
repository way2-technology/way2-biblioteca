<template>
  <el-dialog class="modal-new-book" title="Novo Livro" :visible.sync="visible">
    <el-form class="modal-new-book__form" :model="form">
      <el-form-item label="Titulo" prop="title" :rules="formRules.requiredMessageBlur">
        <el-input v-model="form.title"></el-input>
      </el-form-item>

      <el-form-item label="Descrição" prop="description" :rules="formRules.requiredMessageBlur">
        <el-input type="textarea" v-model="form.description"></el-input>
      </el-form-item>

      <el-form-item label="Editora" prop="publisher" :rules="formRules.requiredMessageBlur">
        <el-input v-model="form.publisher"></el-input>
      </el-form-item>

      <el-form-item
        label="Data de Publicação"
        prop="publicationDate"
        :rules="formRules.requiredMessageBlur"
      >
        <el-date-picker type="date" v-model="form.publicationDate"></el-date-picker>
      </el-form-item>

      <el-form-item label="Categorias" prop="categories" :rules="formRules.requiredMessageBlur">
        <el-select v-model="form.categories" multiple collapse-tags>
          <el-option v-for="item in 5" :key="item" :label="`LabelTest-${item}`" :value="item"></el-option>
        </el-select>
      </el-form-item>

      <el-form-item
        label="Número de Páginas"
        prop="numberOfPages"
        :rules="formRules.requiredMessageBlur"
      >
        <el-input-number v-model.number="form.numberOfPages" :min="1" controls-position="right"></el-input-number>
      </el-form-item>

      <el-form-item
        label="Imagem do Livro"
        prop="imageUrl"
        :rules="formRules.requiredMessageBlur"
        :class="[{'image-uploaded': form.imageUrl}]"
      >
        <el-upload
          class="upload-demo"
          action="https://jsonplaceholder.typicode.com/posts/"
          :on-progress="handleLocalImage"
          :file-list="uploadImageList"
          :limit="1"
          list-type="picture"
        >
          <el-button size="small" type="plain" icon="el-icon-upload">Upload imagem</el-button>
        </el-upload>
      </el-form-item>
    </el-form>

    <template slot="footer">
      <el-button disabled type="primary">Cadastrar</el-button>
    </template>
  </el-dialog>
</template>

<script lang="ts">
import Vue from "vue";
import FormRulesNewBookMixin from "./FormRulesNewBook.mixin";
import EventBus from "@/providers/EventBus";

interface IForm {
  title: string;
  description: string;
  publicationDate: Date;
  publisher: string;
  numberOfPages: number;
  categories: string[];
  imageUrl: string;
}

export default Vue.extend({
  name: "modal-new-book",
  data() {
    return {
      visible: false as boolean,
      form: {
        numberOfPages: 1,
        imageUrl: ""
      } as IForm,
      uploadImageList: [] as object[]
    };
  },
  mixins: [FormRulesNewBookMixin],
  created() {
    this.listenEventNewBook();
  },
  watch: {
    uploadImageList(value) {
      // console.log(value);
    }
  },
  methods: {
    listenEventNewBook(): void {
      EventBus.$on("show-modal-new-book", () => {
        this.visible = true;
      });
    },
    handleLocalImage(file): void {
      this.form.imageUrl = file;
    }
  }
});
</script>

<style lang="scss">
.modal-new-book {
  overflow: hidden;

  .el-dialog {
    margin: 30px auto !important;
    width: 90%;
    height: calc(100vh - 60px);
    overflow: hidden;
    display: flex;
    flex-direction: column;

    @media screen and (min-width: 767px) {
      max-width: 500px;
    }
    @media screen and (max-width: 767px) {
      width: 100%;
      height: 100%;
      margin: 0 !important;
    }

    &__header,
    &__footer {
      padding: 15px;
      background: #f4f4f4;
    }

    &__header {
      border-bottom: 1px solid #ddd;
    }

    &__body {
      overflow: auto;
      padding: 20px;
      flex-grow: 1;
    }
    &__footer {
      display: flex;
      border-top: 1px solid #ddd;

      button {
        width: 100%;
        background-image: linear-gradient(
          180deg,
          hsla(0, 0%, 100%, 0.1),
          hsla(0, 0%, 100%, 0)
        );
      }
    }
  }

  &__form {
    .el-form-item {
      display: flex;
      flex-direction: column;
      margin-bottom: 20px;

      label {
        min-width: 180px;
        font-weight: bold;
        height: 100%;
        line-height: 25px;
        text-align: left;
      }

      .el-form-item__content {
        flex-grow: 1;

        > .el-input,
        .el-textarea,
        .el-input-number,
        .el-select {
          min-width: 230px;
        }

        textarea {
          min-height: 100px !important;
        }
      }
    }

    .image-uploader {
      .el-upload {
        border: 1px dashed #d9d9d9;
        border-radius: 6px;
        cursor: pointer;
        position: relative;
        overflow: hidden;
      }
      .el-upload:hover {
        border-color: #409eff;
      }
      .el-icon-plus {
        font-size: 28px;
        color: #8c939d;
        width: 178px;
        height: 178px;
        line-height: 178px;
        text-align: center;
      }
      img {
        width: 178px;
        height: 178px;
        display: block;
      }
    }
  }
}
</style>
