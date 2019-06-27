<template>
  <el-dialog title="Shipping address" :visible.sync="dialogFormVisible">
    <el-form :model="form">
      <el-form-item label="Promotion name" :label-width="formLabelWidth">
        <el-input v-model="form.name" autocomplete="off"></el-input>
      </el-form-item>
      <el-form-item label="Zones" :label-width="formLabelWidth">
        <el-select v-model="form.region" placeholder="Please select a zone">
          <el-option label="Zone No.1" value="shanghai"></el-option>
          <el-option label="Zone No.2" value="beijing"></el-option>
        </el-select>
      </el-form-item>
    </el-form>
    <span slot="footer" class="dialog-footer">
      <el-button @click="dialogFormVisible = false">Cancel</el-button>
      <el-button type="primary" @click="dialogFormVisible = false">Confirm</el-button>
    </span>
  </el-dialog>
  </template>

<script lang="ts">
import Vue from "vue";

interface IBook {
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
      book: {} as IBook
    };
  },
});
</script>

<style lang="scss" scoped>

</style>
