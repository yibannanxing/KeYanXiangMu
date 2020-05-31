<template>

    <Tabs type="card" v-model="active">
        <Tab-pane label="论文" key="lunwen" name="lunwen">
            <CGLunWenList :leixing="active"></CGLunWenList>
        </Tab-pane>
        <Tab-pane label="著作" key="zuzuo" name="zuzuo">
            <CGLunWenList :leixing="active"></CGLunWenList>
        </Tab-pane>

        <Tab-pane label="教材" key="jiaocai" name="jiaocai">
            <CGLunWenList :leixing="active"></CGLunWenList>
        </Tab-pane>

        <Tab-pane label="软件" key="ruanjian" name="ruanjian">
            <CGLunWenList :leixing="active"></CGLunWenList>
        </Tab-pane>

        <Tab-pane label="专利" key="zhuanli" name="zhuanli">
            <CGLunWenList :leixing="active"></CGLunWenList>
        </Tab-pane>
        <Tab-pane label="其他" key="qita" name="qita">
            <CGLunWenList :leixing="active"></CGLunWenList>
        </Tab-pane>
        <Tab-pane label="科研项目" key="keyanxiangmu" name="keyanxiangmu">
            <CGLunWenList :leixing="active"></CGLunWenList>
        </Tab-pane>
    </Tabs>

</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    import UploadCtrl from '../components/UploadCtrl.vue';
    import CGLunWenList from './CGLunWenList.vue';
    const qs = require('qs');
    export default {
        data() {
            return {
                active: 'lunwen',
                filelist: []
            }
        },
        props: [],
        mounted() {

        },
        computed: {},
        components: {
            CGLunWenList
        },
        methods: {

        }
    };
</script>
<style>
</style>