import Vue from "vue";

async function actionGet(url: string): Promise<any> {
  const result = await fetch(url)
    .then(res => res.json())
    .then(response => {
      return response;
    }).catch(() => {
      return null;
    });

  return result;
}

async function actionPost(url: string, body): Promise<any> {
  const result = await fetch(url, {
    method: "POST",
    headers: {
      "Accept": "application/json",
      "Content-Type": "application/json"
    },
    body
  })
    .then(res => res.json())
    .then(response => {
      return response;
    }).catch(() => {
      return null;
    });

  return result;
}

/** Prototype functions */
async function $get(url: string) {
  const result = await actionGet(url);
  return result;
}

async function $post(url: string, body) {
  const result = await actionPost(url, body);
  return result;
}

async function $getWithLoader({ url, typeLoader = "" }) {
  Vue.prototype["$store"].commit("SHOW_LOADER", { type: typeLoader });

  const result = await actionGet(url);

  Vue.prototype["$store"].commit("HIDE_LOADER");

  return result;
}

async function $postWithLoader({ url, body, typeLoader = "" }) {
  Vue.prototype["$store"].commit("SHOW_LOADER", { type: typeLoader });

  const result = await actionPost(url, body);

  Vue.prototype["$store"].commit("HIDE_LOADER");

  return result;
}

const AjaxPlugin = {
  install() {
    Vue.prototype.$get = $get;
    Vue.prototype.$post = $post;
    Vue.prototype.$getWithLoader = $getWithLoader;
    Vue.prototype.$postWithLoader = $postWithLoader;
  }
};

export default AjaxPlugin;