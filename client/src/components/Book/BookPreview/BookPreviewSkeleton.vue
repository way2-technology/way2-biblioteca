<template>
  <div class="book skeleton">
    <el-card>
      <figure class="book__image">
        <div class="img"></div>
      </figure>
      <div class="book__categories">
        <div class="book__tag"></div>
      </div>
      <h2 class="book__title"></h2>
      <footer>
        <div class="book__rating"></div>
      </footer>
    </el-card>
  </div>
</template>

<script>
import "./BookPreview.scss";
export default {};
</script>

<style lang="scss">
.skeleton {
  .book__image {
    background: #eee;
  }
  .book__title{
    height: 25px;
    background: #eee;
    width: 70%;
    padding: 0;
    margin: 20px 0 35px;
  }

  .book__rating {
    height: 15px;
    background: #eee;
    width: 45%;
  }
}
</style>