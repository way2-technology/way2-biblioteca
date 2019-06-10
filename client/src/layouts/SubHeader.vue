<template>
  <div class="subheader">
    <div class="subheader__wrapper">
      <el-button class="btn btn-add" type="text">
        <unicon name="filter"></unicon>
        <strong>Filtrar</strong>
      </el-button>
      <el-button class="btn btn-add" type="text">
        <unicon name="plus"></unicon>
        <strong>Novo</strong>
      </el-button>
    </div>
  </div>
</template>

<style lang="scss">
.subheader {
  background: $--color-black;
  border-top: 1px solid $--color-black-3;
  position: sticky;
  top: 0;
  z-index: 3;

  &__wrapper {
    max-width: $--width-container;
    margin: 0 auto;
    padding: 5px 16px;
    display: flex;
    justify-content: flex-end;
    align-items: center;
  }

  .btn {
    padding: 5px;
    margin-left: 8px;
    color: #fff;
    border-radius: 2px;

    span {
      display: flex;
      align-items: center;
      text-transform: uppercase;
      font-size: 12px;
      letter-spacing: 1px;
    }

    svg {
      fill: #fff;
      width: 14px;
      height: 100%;
      margin-right: 3px;
    }

    &:hover {
      span,
      svg {
        color: $--color-primary-light-3;
        fill: $--color-primary-light-3;
      }
    }
  }
}
</style>

