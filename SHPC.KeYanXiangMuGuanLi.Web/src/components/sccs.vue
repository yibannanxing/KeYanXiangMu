<template>
    <div style="padding:10px">
        <UploadCtrl :type="0"
                    v-model="filelist"
                    :filelimit="10"
                    :maxSize="10240"></UploadCtrl>
    </div>
</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
     import UploadCtrl from '../components/UploadCtrl.vue';
    const qs = require('qs');
    export default {
        data() {
            return {
                filelist: []
            }
        },
        props: [],
        mounted() {

        },
        computed: {},
        components: {
            UploadCtrl
        },
        methods: {

        }
    };
</script>
<style>
</style>