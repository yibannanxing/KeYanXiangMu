<template>
    <div style="padding:10px">
        <Form-item label="期刊封面">
            <UploadCtrl :type="0" v-model="fengmianList" :filelimit="1" :maxSize="2048"> </UploadCtrl> <span style="color:red">请上传小于2M</span>
        </Form-item>
        <Form-item label="期刊目录">
            <UploadCtrl :type="0" v-model="fileList" :filelimit="5" :maxSize="2048"> </UploadCtrl>
        </Form-item>
        <Form-item label="文章页面">
            <UploadCtrl :type="0" v-model="articleList" :filelimit="1" :maxSize="2048"> </UploadCtrl>
        </Form-item>
    </div>
</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    const qs = require('qs');
    export default {
        data() {
            return {
                fengmianList: [],
                fileList: [],
                articleList: [],
            }
        },
        props: [],
        mounted() {
            
        },
        computed: {},
        components: {
            
        },
        methods: {
            
        }
    };
</script>
<style>
    
</style>