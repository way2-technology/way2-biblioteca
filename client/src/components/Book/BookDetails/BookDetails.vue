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
              <img :src="$urlBaseApi + bookDisplay.imageUrl" :alt="bookDisplay.title" />
            </figure>

            <div class="rate">
              <el-rate disabled :value="bookDisplay.rating.value" :colors="rating.colors" />
              <span class="count">{{ bookDisplay.rating.count }} Reviews</span>
            </div>

            <!-- TODO: [Usuário Logado] -->
            <!-- TODO: Função para pegar livro emprestado de acordo com o usuário -->
            <!-- <template v-if="$userLogged">
              <div class="borrow" v-if="!bookDisplay.borrowed">
                <el-button type="primary" :loading="false">
                  <Unicon name="bookmark" />
                  <span>Pegar este livro emprestado</span>
                </el-button>
              </div>
              <div class="borrowed" v-else>
                <small>Livro emprestado para:</small>
                <Avatar :url="bookDisplay.borrowed.avatar" :name="bookDisplay.borrowed.fullName" />
              </div>
            </template> -->
          </el-col>
          <el-col class="info">
            <div class="details">
              <h3>Detalhes:</h3>
              <ul>
                <li>
                  <strong>Publicação:</strong>
                  <span>{{ bookDisplay.publicationDate }}</span>
                </li>
                <li>
                  <strong>Editora:</strong>
                  <span>{{ bookDisplay.publisher }}</span>
                </li>
                <li>
                  <strong>Páginas:</strong>
                  <span>{{ bookDisplay.pages }}</span>
                </li>
                <li class="cateogries">
                  <strong>Categorias:</strong>
                  <template v-for="(category, key) in bookDisplay.categories">
                    <el-tag :key="key" size="mini">{{category}}</el-tag>
                  </template>
                </li>
                <li>
                  <strong>ISBN:</strong>
                  <span>{{ bookDisplay.isbn }}</span>
                </li>
              </ul>
            </div>
            <div class="description">
              <h3>Descrição:</h3>
              <div>{{bookDisplay.description}}</div>
            </div>
          </el-col>
        </el-row>
      </div>
      <div class="book-details__overlay" @click="closeBookDetails"></div>
    </aside>
  </transition>
</template>

<script lang="ts">
import Vue from "vue";
import BookRatingMixin from "../BookRating.mixin";
import Avatar from "@/common/components/Avatar.vue";
import { IBookDisplay, parseSingleBook } from "@/common/helpers/Books";

export default Vue.extend({
  name: "book-details",
  components: {
    Avatar
  },
  mixins: [BookRatingMixin],
  computed: {
    asideVisble(): boolean {
      const {
        bookDetails: { visible }
      } = this.$store.state;

      return visible;
    },
    bookDisplay(): IBookDisplay {
      const {
        bookDetails: { book }
      } = this.$store.state;

      return parseSingleBook(book);
    }
  },
  methods: {
    closeBookDetails(): void {
      this.$store.commit("CLOSE_BOOK_DETAILS");
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
      font-size: 19px;
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
      @media screen and (min-width: 767px) {
        width: auto;
      }

      &:nth-child(1) {
        text-align: center;
        margin-bottom: 20px;
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

    .borrow {
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center;
      margin-bottom: 20px;

      .el-button {
        display: flex;
        align-items: center;
        padding: 10px;
        min-height: 46px;

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

    .borrowed {
      border-top: 1px solid #eee;
      text-align: left;

      small {
        display: block;
        margin: 15px 0 5px;
        text-transform: uppercase;
        font-size: 10px;
      }

      /deep/ .avatar {
        padding: 10px;
        background: #f4f4f4;
        border-radius: 3px;

        .name {
          white-space: nowrap;
        }
      }
    }

    .info {
      flex-grow: 1;

      @media screen and (min-width: 767px) {
        padding-left: 30px;
      }

      h3 {
        margin-bottom: 10px;
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
  transition: opacity 0.1s cubic-bezier(1, 0.5, 0.8, 1);
}
.translate-aside-leave-active {
  transition: opacity 0.1s cubic-bezier(1, 0.5, 0.8, 1);
}
.translate-aside-enter,
.translate-aside-leave-to {
  opacity: 0;
}
</style>
