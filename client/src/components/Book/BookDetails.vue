<template>
  <transition name="translate-aside">
    <aside class="book-details" v-if="value" :class="{'book-details--open': value}">
      <div class="book-details__wrapper">
        <header>
          <h2 class="title">{{ bookDisplay.title }}</h2>
          <el-button
            class="close"
            size="mini"
            type="info"
            icon="el-icon-close"
            circle
            @click="closeBookDetails"
          ></el-button>
        </header>
        <el-row class="book-details__content">
          <el-col>
            <figure class="image">
              <img :src="bookDisplay.image" alt>
            </figure>

            <div class="rate">
              <el-rate disabled v-model="rate.value" :colors="rate.colors"/>
              <span class="count">5 Reviews</span>
            </div>
          </el-col>
          <el-col class="info">
            <div class="description">{{bookDisplay.description}}</div>
            <div class="details">
              <ul>
                <li>
                  <strong>Publicação:</strong>
                  <span>{{bookDisplay.publicacao}}</span>
                </li>
                <li>
                  <strong>ISBN:</strong>
                  <span>{{bookDisplay.isbn}}</span>
                </li>
                <li>
                  <strong>Editora:</strong>
                  <span>{{bookDisplay.editora}}</span>
                </li>
                <li>
                  <strong>Páginas:</strong>
                  <span>{{bookDisplay.paginas}}</span>
                </li>
                <li>
                  <strong>Categorias:</strong>
                  <ul>
                    <li v-for="(category, key) in categories" :key="key">
                      {{category}}
                    </li>
                  </ul>
                </li>
              </ul>
            </div>
          </el-col>
        </el-row>
        <!-- <el-row class="book-details__comments">
          <h3>Comentários:</h3>
          <BookComments />
        </el-row>-->
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
  categorias: string[];
  publicacao: Date;
  isbn: string;
  editora: string;
  paginas: number;
}

export default Vue.extend({
  components: {
    // BookComments
  },
  props: {
    value: {
      type: Boolean,
      default: true
    },
    book: {
      type: Object
    }
  },
  mixins: [BookRateMixin],
  computed: {
    bookDisplay(): IBookDisplay {
      const {
        id,
        volumeInfo: {
          title: bookTitle,
          description: bookDesc,
          categories: bookCats,
          imageLinks: { thumbnail }
        }
      } = this.book;

      return {
        id,
        title: bookTitle ? bookTitle : "",
        description: bookDesc ? bookDesc : "",
        image: thumbnail ? thumbnail : "",
        categorias: bookCats,
        publicacao: new Date(),
        isbn: "978-8589134453",
        editora: "xxxxx",
        paginas: 200,
      };
    }
  },
  methods: {
    closeBookDetails(): void {
      this.$emit("input", false);
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
    background: #fff;
    padding: 0 20px;
    min-height: 60px;
    display: flex;
    align-items: center;
    border-bottom: 1px solid #e8e8e8;

    h2 {
      font-size: 26px;
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
      margin: 15px 0 0;

      .count {
        display: block;
        margin: 15px 0;
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
        margin: 10px 0;
        border: 1px solid #eee;
        border-radius: 5px;
      }

      li {
        display: block;
        border-bottom: 1px solid #eee;
        padding: 8px;
      }

      li strong {
        margin-right: 5px;
      }

      li:last-child {
        border: 0;
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
  transition: all 0.2s ease;
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
