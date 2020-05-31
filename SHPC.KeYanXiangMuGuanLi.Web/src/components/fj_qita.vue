<template>
    <div style="padding:10px">
        <Form-item label="其他">
            <UploadCtrl :type="1" v-model="wenjianList" :filelimit="1" :maxSize="2048"> </UploadCtrl> <span>请上传小于2M</span>
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
                wenjianList: [],
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