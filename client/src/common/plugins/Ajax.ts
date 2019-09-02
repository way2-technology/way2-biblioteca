import Vue from "vue";

const urlBaseApi = "https://way2library.azurewebsites.net";

async function actionGet(endpoint: string): Promise<any> {
  const result = await fetch(`${urlBaseApi}/api${endpoint}`)
    .then(res => res.json())
    .then(response => {
      return response;
    }).catch(() => {
      showMessageError();
      return null;
    });

  return result;
}

async function actionPost(endpoint: string, body): Promise<any> {
  const result = await fetch(`${urlBaseApi}/api${endpoint}`, {
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
      showMessageError();
      return null;
    });

  return result;
}

function showMessageError(): void {
  Vue.prototype.$message.error("Oops, Algo deu errado, tente novamente mais tarde!");
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

async function $getWithLoader({ url, typeLoader }) {
  Vue.prototype.$store.commit("SHOW_LOADER", { type: typeLoader });

  const result = await actionGet(url);

  Vue.prototype.$store.commit("HIDE_LOADER");

  return result;
}

async function $postWithLoader({ url, body, typeLoader }) {
  Vue.prototype.$store.commit("SHOW_LOADER", { type: typeLoader });

  const result = await actionPost(url, body);

  Vue.prototype.$store.commit("HIDE_LOADER");

  return result;
}

const AjaxPlugin = {
  install() {
    Vue.prototype.$urlBaseApi = urlBaseApi;
    Vue.prototype.$get = $get;
    Vue.prototype.$post = $post;
    Vue.prototype.$getWithLoader = $getWithLoader;
    Vue.prototype.$postWithLoader = $postWithLoader;
  }
};

export default AjaxPlugin;