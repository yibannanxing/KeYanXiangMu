<template>
    <Tabs active-key="keyanxiangmu" type="card" style="width:1200px;">
        <Tab-pane label="科研项目" key="keyanxiangmu">
            <CG_kyxm :close="close"></CG_kyxm>
        </Tab-pane>

        <Tab-pane label="著作" key="zuzuo">
            <CG_zuzuo :close="close"></CG_zuzuo>
        </Tab-pane>

        <Tab-pane label="教材" key="jiaocai">
            <CG_jiaocai :close="close"></CG_jiaocai>
        </Tab-pane>
        <Tab-pane label="论文" key="lunwen">
            <CG_lunwen :close="close"></CG_lunwen>
        </Tab-pane>
        <Tab-pane label="软件与专利" key="ruanjianyuzhuanli">
            <CG_ruanjian :close="close"></CG_ruanjian>
        </Tab-pane>
        <Tab-pane label="其他" key="qita">
            <CG_Qita :close="close"></CG_Qita>
        </Tab-pane>
    </Tabs>
</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    import CG_kyxm from '../components/CG_kyxm.vue';
    import CG_zuzuo from '../components/CG_zuzuo.vue';
    import CG_jiaocai from '../components/CG_jiaocai.vue';
    import CG_lunwen from '../components/CG_lunwen.vue';
    import CG_ruanjian from '../components/CG_ruanjian.vue';
    import CG_Qita from '../components/CG_Qita.vue';
    const qs = require('qs');
    export default {
        data() {
            return {
                userInfo: {}
            }
        },
        props: [],
        mounted() {

        },
        computed: {},
        components: {
            CG_kyxm,
            CG_zuzuo,
            CG_jiaocai,
            CG_lunwen,
            CG_ruanjian,
            CG_Qita,
        },
        methods: {
            close() {
                this.$emit('close')
            }
        }
    };
</script>
<style scoped>

</style>