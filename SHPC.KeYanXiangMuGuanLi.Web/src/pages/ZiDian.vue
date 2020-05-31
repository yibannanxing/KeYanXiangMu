<template>
    <div style="padding:10px">
        <i-form :model="zidian" :label-width="80" label-position="right">
            <Form-item label="表名称：" prop="BiaoMingCheng">
                <i-input v-model="zidian.biaoMingCheng"
                         :maxlength="30"
                         placeholder="请填表名称"></i-input>
            </Form-item>
            <Form-item label="一级名称：" prop="YiJiMingCheng">
                <i-input v-model="zidian.yiJiMingCheng"
                         :maxlength="30"></i-input>
            </Form-item>

            <Form-item>
                <i-button  type="primary" @click="save">提交</i-button>
            </Form-item>
        </i-form>


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
                zidian: [],
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