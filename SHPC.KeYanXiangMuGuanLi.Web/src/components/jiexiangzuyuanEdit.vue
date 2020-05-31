<template>
    <div style="padding:10px">
        <Form ref="jiexiangzuyuan" :model="jiexiangzuyuan"  :label-position="'right'">
            <FormItem label="姓名" prop="xingMing">
                    <i-input v-model="jiexiangzuyuan.xingMing" :maxlength="20" placeholder="请输入姓名"></i-input>
            </FormItem> 
            <div v-if="!isstu">
                <FormItem label="部门" prop="BuMen">
                    <i-input v-model="jiexiangzuyuan.buMen" :maxlength="20" placeholder="请输入部门"></i-input>
                </FormItem>

                <FormItem label="职务" prop="ZhiWu">
                    <i-input v-model="jiexiangzuyuan.zhiWu" :maxlength="20" placeholder="请输入职务"></i-input>
                </FormItem>
            </div>
            <div v-else-if="isstu">
                <FormItem label="研究专长" prop="yanJiuZhuanChang">
                    <i-input v-model="jiexiangzuyuan.yanJiuZhuanChang" :maxlength="20" placeholder="请输入研究专长"></i-input>
                </FormItem>

                <FormItem label="专业" prop="ZuanYe">
                    <i-input v-model="jiexiangzuyuan.zuanYe" :maxlength="20" placeholder="请输入专业"></i-input>
                </FormItem>
            </div>
            <FormItem label="项目分工情况" prop="fenGongQingKuang">
                    <i-input v-model="jiexiangzuyuan.fenGongQingKuang" :maxlength="100" placeholder="请输入分工情况"></i-input>
            </FormItem>

            <FormItem>
                <Button @click="save" type="primary">保存</Button>
            </FormItem>
        </Form>

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
               
            }
        },
        props: ['jiexiangzuyuan','isstu'],
        mounted() {
            //console.log(this.isstu);
        },
        computed: {},
        components: {
            
        },
        methods: {
            save() {
                this.$emit('close', this.jiexiangzuyuan);
            }
        }
    };
</script>
<style>
    
</style>