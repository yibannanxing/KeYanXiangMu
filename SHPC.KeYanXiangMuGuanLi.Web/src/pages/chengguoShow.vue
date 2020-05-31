<template>
    <div style="padding:10px">
        <i-form :model="XiangMuChengGuo" label-position="left" :label-width="100">
            <Form-item label="作者">
                {{XiangMuChengGuo.zuoZeMingCheng}}
            </Form-item>
            <Form-item label="部门">
                {{XiangMuChengGuo.buMenMingCheng}}
            </Form-item>
            <Form-item label="成果名称">
                {{XiangMuChengGuo.chengGuoMingCheng}}
            </Form-item>
            <Form-item label="成果类型">
                {{XiangMuChengGuo.chengGuoLeiXingName}}
            </Form-item>
            <Form-item label="年期">
                {{XiangMuChengGuo.nianQi}}
            </Form-item>
            <Form-item label="出版社">
                {{XiangMuChengGuo.chuBanSe}}
            </Form-item>
            <Form-item label="附件">
             <!--<span>期刊目录</span>
    <span>文章页面</span>
    <span>文件附件</span>-->
                <div>
                    <div v-for="(item,index) in XiangMuChengGuo.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==0">期刊封面</span>
                        <span v-if="item.wenJianLeiXing==1">期刊目录</span>
                        <span v-if="item.wenJianLeiXing==2">文章页面</span>
                        <span v-if="item.wenJianLeiXing==3">文件附件</span>
                        <img v-if="item.wenJianLeiXing==0||item.wenJianLeiXing==1||item.wenJianLeiXing==2" 
                             :src="item.luJing" 
                             style="width:100%;" />
                        <a v-if="item.wenJianLeiXing!=0&&item.wenJianLeiXing!=1&&item.wenJianLeiXing!=2" 
                           :href="item.luJing">{{item.wenJianMingCheng}}</a>
                    </div>
                </div>
            </Form-item>

            <Form-item label="">
                <i-button type="primary" @click="shenhe" v-if="!isview">审核</i-button>
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
                XiangMuChengGuo: {},
            }
        },
        props: ['id','isview'],
        mounted() {
            this.getChengGuo();
        },
        computed: {},
        components: {

        },
        methods: {
            getChengGuo() {
                axios.get('api/XiangMuChengGuo/GetXiangMuChengGuoById', {
                    params: {
                        ChengGuoID: this.id,
                    }
                })
                    .then(response => {
                        this.XiangMuChengGuo = response.data.result
                    }).catch(error => {
                        console.log(error);
                    });
            },
            shenhe() {
                axios.get('api/XiangMuChengGuo/UpdateXiangMuChengGuo', {
                    params: {
                        cgId: this.id,
                    }
                })
                    .then(response => {
                        this.$Message.success('审核成功!');
                        this.$emit('close');
                        //this.XiangMuChengGuo = response.data.result
                        console.log(this.XiangMuChengGuo);
                    }).catch(error => {
                        console.log(error);
                    });
            }


        }
    };
</script>
<style>
</style>