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
    border: 0;
    background: $--color-light-2;
  }
  .book__tag {
    height: 15px;
    background: $--color-light-2;
    width: 50px;
  }
  .book__title {
    height: 35px;
    background: $--color-light-2;
    width: 70%;
    padding: 0;
    margin: 20px 0 30px;
  }

  .book__rating {
    height: 15px;
    background: $--color-light-2;
    width: 45%;
  }
}
</style>