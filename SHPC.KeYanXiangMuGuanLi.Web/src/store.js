import Vue from 'vue';
import Vuex from 'vuex';
import axios from 'axios';
Vue.use(Vuex);
export default new Vuex.Store({
    state: {
        currentUser: {},
        privileges: []
    },
    mutations: {},
    actions: {
        getcurrentUser(context) {
            axios.get('api/User/GetCurrentUser').then(resp => {
                context.state.currentUser = resp.data.result;
            }).catch(function (error) {
                console.log(error);
            });
        },
        getPrivilege(context) {
            axios.get('api/User/GetPrivilege').then(resp => {
                context.state.privileges = resp.data.results;
            }).catch(function (error) {
                console.log(error);
            });
        }
    }
});
//# sourceMappingURL=store.js.map