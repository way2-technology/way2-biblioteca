<template>
  <transition name="translate-aside">
    <aside class="book-details" v-if="asideVisble" :class="{'book-details--open': asideVisble}">
      <div class="book-details__wrapper">
        <header>
          <h2 class="title">{{ bookDisplay.title }}</h2>
          <el-button
            class="close"
            size="mini"
            type="plain"
            icon="el-icon-close"
            circle
            @click="closeBookDetails"
          ></el-button>
        </header>
        <el-row class="book-details__content">
          <el-col>
            <figure class="image">
              <img :src="bookDisplay.image" :alt="bookDisplay.title" />
            </figure>

            <div class="rate">
              <el-rate disabled v-model="rate.value" :colors="rate.colors" />
              <span class="count">5 Reviews</span>
            </div>

            <template v-if="$userLogged">
              <div class="loan">
                <el-button type="primary">
                  <Unicon name="bookmark" />
                  <span>Pegar este livro emprestado</span>
                </el-button>
              </div>
            </template>
          </el-col>
          <el-col class="info">
            <div class="details">
              <ul>
                <li>
                  <strong>Publicação:</strong>
                  <span>{{ bookDisplay.publicacao.toLocaleDateString() }}</span>
                </li>
                <li>
                  <strong>Editora:</strong>
                  <span>{{ bookDisplay.editora }}</span>
                </li>
                <li>
                  <strong>Páginas:</strong>
                  <span>{{ bookDisplay.paginas }}</span>
                </li>
                <li class="cateogries">
                  <strong>Categorias:</strong>
                  <template v-for="(category, key) in bookDisplay.categories">
                    <el-tag :key="key" size="mini">{{category}}</el-tag>
                  </template>
                </li>
                <li>
                  <strong>ISBN:</strong>
                  <span>9780062259677</span>
                </li>
              </ul>
            </div>
            <div class="description">{{bookDisplay.description}}</div>
          </el-col>
        </el-row>
      </div>
      <div class="book-details__overlay" @click="closeBookDetails"></div>
    </aside>
  </transition>
</template>

<script lang="ts">
import Vue from "vue";
import BookRateMixin from "./BookRate.mixin";

interface IBookDisplay {
  id: [number, string];
  title: string;
  description: string;
  image: string;
  categories: string[];
  publicacao: Date;
  editora: string;
  paginas: number;
}

export default Vue.extend({
  mixins: [BookRateMixin],
  computed: {
    asideVisble(): boolean {
      const {
        bookDetails: { visible }
      } = this["$store"].state;

      return visible;
    },
    bookDisplay(): IBookDisplay {
      const {
        bookDetails: { book }
      } = this["$store"].state;

      const {
        id,
        volumeInfo: {
          title: bookTitle,
          description: bookDesc,
          categories: bookCats,
          imageLinks: { thumbnail }
        }
      } = book;

      return {
        id,
        title: bookTitle ? bookTitle : "",
        description: bookDesc ? bookDesc : "",
        image: thumbnail ? thumbnail : "",
        categories: bookCats,
        publicacao: new Date(),
        editora: "xxxxx",
        paginas: 200
      };
    }
  },
  methods: {
    closeBookDetails(): void {
      this["$store"].commit("CLOSE_BOOK_DETAILS");
    }
  }
});
</script>

<style lang="scss">
.book-details {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  z-index: 99;

  &__wrapper {
    position: absolute;
    top: 0;
    right: 0;
    width: 100%;
    height: 100%;
    background: #fff;
    display: flex;
    flex-direction: column;
    text-align: left;
    box-shadow: -2px 0 8px rgba(0, 0, 0, 0.15);
    overflow: auto;
    z-index: 1;

    @media screen and (min-width: 767px) {
      width: 75%;
    }
  }

  header {
    position: sticky;
    top: 0;
    z-index: 1;
    background: #f4f4f4;
    padding: 0 20px;
    min-height: 60px;
    display: flex;
    align-items: center;
    border-bottom: 1px solid #e8e8e8;

    h2 {
      font-size: 24px;
      white-space: nowrap;
      width: 100%;
      max-width: 95%;
      overflow: hidden;
      text-overflow: ellipsis;
    }

    .close {
      position: absolute;
      right: 10px;
      top: 50%;
      transform: translateY(-50%);
    }
  }

  &__content,
  &__comments {
    padding: 20px;
  }

  &__content {
    display: flex;

    @media screen and (max-width: 767px) {
      flex-direction: column;
      align-items: center;
    }

    .el-col {
      width: auto;

      &:nth-child(1) {
        text-align: center;
      }
    }

    .image {
      border: 1px solid #ddd;
      border-radius: 4px;
      position: relative;
      overflow: hidden;
      width: 222px;
      height: 300px;
      margin: 0 auto;

      img {
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        width: 100%;
        height: 100%;
      }
    }

    .rate {
      margin: 15px 0;

      .count {
        display: block;
        margin: 5px 0 10px;
      }
    }

    .loan {
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center;
      margin-bottom: 20px;

      .el-button {
        padding: 10px;
        > span {
          display: flex;
          align-items: center;
        }

        svg {
          fill: #fff;
          width: 18px;
          margin-right: 5px;
        }
      }
    }

    .info {
      flex-grow: 1;

      @media screen and (min-width: 767px) {
        padding-left: 30px;
      }
    }

    .description {
      margin-bottom: 20px;
    }

    .details {
      ul {
        list-style: none;
        margin-bottom: 20px;
        border: 1px solid #eee;
        border-radius: 5px;
      }
      li {
        display: block;
        border-bottom: 1px solid #eee;
        padding: 8px;

        &:last-child {
          border: 0;
        }

        strong {
          margin-right: 5px;
        }
      }

      .cateogries {
        display: flex;
        align-items: center;

        .el-tag {
          margin: 0 5px;
        }
      }
    }
  }

  &__comments {
    border-top: 1px solid #eee;
  }

  &__overlay {
    position: absolute;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.4);
  }
}

.translate-aside-enter-active {
  transition: all 0.1s cubic-bezier(1, 0.5, 0.8, 1);
}
.translate-aside-leave-active {
  transition: all 0.1s cubic-bezier(1, 0.5, 0.8, 1);
}
.translate-aside-enter,
.translate-aside-leave-to {
  transform: translateX(5px);
  opacity: 0;
}
</style>
