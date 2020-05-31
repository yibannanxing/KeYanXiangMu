import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);
//import TopicEdit from './pages/TopicManage/TopicEdit.vue';
import xiangmuedit from './pages/xiangmuedit.vue';
import xiangmulist from './pages/xiangmulist.vue';
import zuyuanlist from './pages/zuyuanlist.vue';
import jingfeilist from './pages/jingfeilist.vue';
import xiangmuzuyuan from './components/xiangmuzuyuan.vue';
import xiangmujingfei from './components/xiangmujingfei.vue';
import fangan from './pages/fangan.vue';
import xiangmulistgeren from './pages/xiangmulistgeren.vue';
import chengguolist from './pages/chengguolist.vue';
import chengguolistgeren from './pages/chengguolistgeren.vue';
import JieXianglist from './pages/JieXianglist.vue';
import kaizhiList from './pages/kaizhiList.vue';
import CG_List from './pages/CG_List.vue';
import CG_MyList from './pages/CG_MyList.vue';
import ZiDian from './pages/ZiDian.vue';
import bumenshenhe from './pages/bumenshenhe.vue';
import keyanchuShenHe from './pages/keyanchuShenHe.vue';
import chushen from './pages/chushen.vue';
import Cg_TongJi from './pages/Cg_TongJi.vue';
import cheshi from './pages/cheshi.vue';
import CGLunWenList from './pages/CGLunWenList.vue';
import Tab_Cgtongji from './pages/Tab_Cgtongji.vue';
import jiaogongBase from './default/jiaogongBase.vue';
import studentBase from './default/studentBase.vue';
const routes = [
    {
        path: '/xiangmuedit', component: xiangmuedit, name: 'xiangmuedit'
    },
    {
        path: '/xiangmulist', component: xiangmulist, name: 'xiangmulist'
    },
    {
        path: '/zuyuanlist', component: zuyuanlist, name: 'zuyuanlist'
    },
    {
        path: '/jingfeilist', component: jingfeilist, name: 'jingfeilist'
    },
    {
        path: '/xiangmuzuyuan', component: xiangmuzuyuan, name: 'xiangmuzuyuan'
    },
    {
        path: '/xiangmujingfei', component: xiangmujingfei, name: 'xiangmujingfei'
    },
    {
        path: '/fangan', component: fangan, name: 'fangan'
    },
    {
        path: '/jiaogongBase', component: jiaogongBase, name: 'jiaogongBase'
    },
    {
        path: '/studentBase', component: studentBase, name: 'studentBase'
    },
    {
        path: '/xiangmulistgeren', component: xiangmulistgeren, name: 'xiangmulistgeren'
    },
    {
        path: '/chengguolist', component: chengguolist, name: 'chengguolist'
    },
    {
        path: '/chengguolistgeren', component: chengguolistgeren, name: 'chengguolistgeren'
    },
    {
        path: '/JieXianglist', component: JieXianglist, name: 'JieXianglist'
    },
    {
        path: '/kaizhiList', component: kaizhiList, name: 'kaizhiList'
    },
    {
        path: '/CG_List', component: CG_List, name: 'CG_List'
    },
    {
        path: '/CG_MyList', component: CG_MyList, name: 'CG_MyList'
    },
    {
        path: '/ZiDian', component: ZiDian, name: 'ZiDian'
    },
    {
        path: '/bumenshenhe', component: bumenshenhe, name: 'bumenshenhe'
    },
    {
        path: '/keyanchuShenHe', component: keyanchuShenHe, name: 'keyanchuShenHe'
    },
    {
        path: '/chushen', component: chushen, name: 'chushen'
    },
    {
        path: '/Cg_TongJi', component: Cg_TongJi, name: 'Cg_TongJi'
    },
    {
        path: '/cheshi', component: cheshi, name: 'cheshi'
    },
    {
        path: '/CGLunWenList', component: CGLunWenList, name: 'CGLunWenList'
    },
    {
        path: '/Tab_Cgtongji', component: Tab_Cgtongji, name: 'Tab_Cgtongji'
    },
];
const router = new VueRouter({
    routes,
    mode: "abstract"
});
export default router;
//# sourceMappingURL=router.js.map