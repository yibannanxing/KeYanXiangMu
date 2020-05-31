import Vue from 'vue';
import App from './app.vue';
import router from './router';
import store from './store';
import iView from 'iview';
import 'iview/dist/styles/iview.css';
Vue.use(iView, {
    size: 'small'
});
new Vue({
    el: '#app',
    router,
    store,
    render: h => h(App)
});
//# sourceMappingURL=app.js.map