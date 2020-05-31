<template>
    <div style="padding:10px">
        <i-form ref="xiangMuChengGuo"
                :model="xiangMuChengGuo"
                label-position="right"
                :rules="ruleValidate"
                :label-width="130">
            <Form-item label="作者：" prop="zuoZeMingCheng">
                <i-input v-model="xiangMuChengGuo.zuoZeMingCheng"
                         :maxlength="50"
                         placeholder="请填写作者名称（限50字）"></i-input>
            </Form-item>
            <Form-item label="成果名称：" prop="chengGuoMingCheng">
                <i-input v-model="xiangMuChengGuo.chengGuoMingCheng"
                         :maxlength="50"
                         placeholder="请填写成果名称（限50字）"></i-input>
            </Form-item>
            <Form-item label="成果类型：" prop="chengGuoLeiXing">
                <RadioGroup v-model="xiangMuChengGuo.chengGuoLeiXing">
                    <!--<Radio label="5">期刊</Radio>-->
                    <Radio label="0">著作</Radio>
                    <Radio label="1">论文</Radio>
                    <Radio label="2">研究报告</Radio>
                    <Radio label="3">软件</Radio>
                    <Radio label="4">技术产品</Radio>
                    <Radio label="6">专利</Radio>
                    <Radio label="7">其他</Radio>
                </RadioGroup>
            </Form-item>
            <Form-item label="年期：" prop="nianQi">
                <i-input v-model="xiangMuChengGuo.nianQi"
                         :maxlength="20"
                         placeholder="请填写年期"></i-input>
            </Form-item>
            <Form-item label="出版社（发表人）：" prop="nianQi">
                <i-input v-model="xiangMuChengGuo.chuBanSe"
                         :maxlength="50"
                         placeholder="请填写出版社（限50字）"></i-input>
            </Form-item>
            <Form-item>
                <div slot="label">
                    附件上传：<br />
                    <span style="color:red;font-size:12px;">(单文件上传小于2M)</span>
                </div>
                <div v-if="xiangMuChengGuo.chengGuoLeiXing=='0'||xiangMuChengGuo.chengGuoLeiXing=='1'||xiangMuChengGuo.chengGuoLeiXing=='2'">
                    <Form-item label="封面" prop="fengmianList">
                        <UploadCtrl :type="0"
                                    v-model="fengmianList"
                                    :filelimit="2"
                                    :maxSize="2048"></UploadCtrl>
                    </Form-item>
                    <Form-item label="目录" prop="fileList">
                        <UploadCtrl :type="0"
                                    v-model="fileList"
                                    :filelimit="5"
                                    :maxSize="2048"></UploadCtrl>
                    </Form-item>
                    <Form-item label="文章页面" prop="articleList">
                        <UploadCtrl :type="0"
                                    v-model="articleList"
                                    :filelimit="10"
                                    :maxSize="2048"></UploadCtrl>
                    </Form-item>
                </div>

                <div v-else-if="xiangMuChengGuo.chengGuoLeiXing=='3'||xiangMuChengGuo.chengGuoLeiXing=='4'||xiangMuChengGuo.chengGuoLeiXing=='6'||xiangMuChengGuo.chengGuoLeiXing=='7'">
                    <UploadCtrl :type="1"
                                v-model="wenjianList"
                                :filelimit="1"
                                :maxSize="2048"></UploadCtrl>
                </div>

                <Form-item label=" ">
                    <i-button type="primary" @click="handleSubmit">提交并审核</i-button>
                </Form-item>

            </Form-item>

        </i-form>

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
                fengmianList: [],
                fileList: [],
                articleList: [],
                wenjianList: [],
                xiangMuChengGuo: { chengGuoLeiXing: '5' },
                ruleValidate: {
                    zuoZeMingCheng: [
                        { required: true, message: '作者名称不能为空', trigger: 'blur' }
                    ],
                    chengGuoMingCheng: [
                        { required: true, message: '成果名称不能为空', trigger: 'blur' }
                    ],
                    nianQi: [
                        { required: true, message: '年期不能为空', trigger: 'blur' }
                    ],
                    chuBanSe: [
                        { required: true, message: '出版社不能为空', trigger: 'blur' }
                    ],
                    chengGuoLeiXing: [
                        { required: true, message: '请选择成果类型', trigger: 'change', type: 'string' }
                    ],
                }
            }
        },
        props: ['id'],
        mounted() {
            if (this.id != null) {
                this.getChengGuo();
            }
        },
        computed: {

        },
        components: {
            UploadCtrl
        },
        methods: {
            getChengGuo() {
                axios.get('api/XiangMuChengGuo/GetXiangMuChengGuoById', {
                    params: {
                        ChengGuoID: this.id,
                    }
                })
                    .then(response => {
                        this.xiangMuChengGuo = response.data.result
                        this.xiangMuChengGuo.chengGuoLeiXing = this.xiangMuChengGuo.chengGuoLeiXing + '';
                        this.xiangMuChengGuo.fuJians.forEach(x => {
                            if (x.wenJianLeiXing == 0) {
                                this.fengmianList.push(x);
                            } else if (x.wenJianLeiXing == 1) {
                                this.fileList.push(x);
                            } else if (x.wenJianLeiXing == 2) {
                                this.articleList.push(x);
                            } else {
                                this.wenjianList.push(x);
                            }
                        })
                        console.log(this.xiangMuChengGuo);
                    }).catch(error => {
                        console.log(error);
                    });
            },
            handleSubmit() {
                var chengGuoRequest_Bag = {
                    xiangMuChengGuo: this.xiangMuChengGuo,
                    fengmianList: this.fengmianList,
                    fileList: this.fileList,
                    articleList: this.articleList,
                    wenjianList: this.wenjianList,
                }
                //上传
                this.$refs.xiangMuChengGuo.validate(valid => {
                    if (valid) {
                        //获取选中的成果类型 
                        var leixing = this.xiangMuChengGuo.chengGuoLeiXing;
                        var fm= chengGuoRequest_Bag.fengmianList.length;
                        var mulu = chengGuoRequest_Bag.fileList.length;
                        var yemian = chengGuoRequest_Bag.articleList.length;
                        var wenjian = chengGuoRequest_Bag.wenjianList.length;
                        if (leixing == 0 || leixing == 1 || leixing == 2) {
                            if (fm==0) {
                                this.$Message.error('请上传封面');
                            } else if (mulu==0) {
                                this.$Message.error('请上传目录');
                            } else if (yemian==0) {
                                this.$Message.error('请上传文章页面');
                            } else {
                                axios.post('api/XiangMuChengGuo/AddXiangMuChengGuo', qs.stringify({
                                    "chengGuoRequest_Bag": chengGuoRequest_Bag
                                })).then(response => {
                                    if (response.data.result) {
                                        this.$Message.success('保存成功!');
                                        this.$emit('close')
                                    }
                                });
                            }

                        } else if (leixing == 3 || leixing == 4 || leixing == 6 || leixing == 7) {
                            if (wenjian==0) {
                                this.$Message.error('请上传文件');
                            } else {
                                axios.post('api/XiangMuChengGuo/AddXiangMuChengGuo', qs.stringify({
                                    "chengGuoRequest_Bag": chengGuoRequest_Bag
                                })).then(response => {
                                    if (response.data.result) {
                                        this.$Message.success('保存成功!');
                                        this.$emit('close')
                                    }
                                });
                            }
                        } else if (fm != 0 && wenjian!=0) {
                            this.$Message.error('请不要上传两种成果类型的文件');
                        }
                    } else {
                        this.$Message.error('请完成必填项!');
                    }
                })

            }
        },
    };
</script>
<style>
</style>