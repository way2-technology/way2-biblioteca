module.exports = {
    productionSourceMap: false,
    css: {
        loaderOptions: {
            sass: {
                data: `@import "@/assets/scss/variables.scss";`
            }
        }
    }
};