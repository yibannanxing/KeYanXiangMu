<template>
    <div style="padding:10px">

        <i-form :model="jiaocai" :label-width="120" label-position="right" :rules="ruleValidate">
            <div>
                <Divider>佐证材料如果超过5张，请当做其他附件上传</Divider>
                <Form-item label="封面" prop="fengmianList">
                    <UploadCtrl :type="0"
                                v-model="fengmianList"
                                :filelimit="5"
                                :disabled="isview"
                                :maxSize="10240"></UploadCtrl>
                </Form-item>

                <!--<Form-item label="目录" prop="fileList">
                    <UploadCtrl :type="0"
                                v-model="fileList"
                                :filelimit="5"
                                :disabled="isview"
                                :maxSize="10240"></UploadCtrl>
                </Form-item>-->
                <!--<Form-item label="版权页" prop="banquanlist">
                    <UploadCtrl :type="0"
                                v-model="banquanlist"
                                :filelimit="5"
                                :disabled="isview"
                                :maxSize="10240"></UploadCtrl>
                </Form-item>-->
                <!--<Form-item label="教材页面" prop="articleList">
                    <UploadCtrl :type="0"
                                v-model="articleList"
                                :filelimit="5"
                                :disabled="isview"
                                :maxSize="10240"></UploadCtrl>
                </Form-item>-->
                <!--<Form-item label="其他附件" prop="wenjianList">
                    <UploadCtrl :type="1"
                                v-model="wenjianList"
                                :filelimit="10"
                                :disabled="isview"
                                :maxSize="10240"></UploadCtrl>
                </Form-item>-->
            </div>


            <Upload action="api/Upload/UploadFile?type=0"
                    :on-success="success"
                    :format="['jpg','jpeg','png','gif']"
                    :on-format-error="imgFormatError"
                    v-model="fileList"
                    :on-exceeded-size="imgMaxSize"
                    :max-size="10240">
                <Button icon="ios-cloud-upload-outline">附件上传</Button>
            </Upload>
            <i-button @click="upload" type="primary" style="margin-bottom:5px">上传</i-button>
        </i-form>

        <Modal title="上传"
               v-model="modalshow"
               width="50%"
               :footer-hide="true"
               :styles="{top: '0'}"
               :mask-closable="false"
               :scrollable='false'
               :transfer="false"
               class-name="vertical-center-modal">
            <div :style="{height:matchHeight+'px','overflow-y':'auto',padding:0}">
                <sccs v-if="modalshow" @close="close"></sccs>

            </div>
        </Modal>


    </div>

</template>

<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    import UploadCtrl from '../components/UploadCtrl.vue';
    import sccs from '../components/sccs.vue';
    import shenhe from '../components/shenhe.vue';
    const qs = require('qs');
    export default {
        data() {
            return {
                username: '',
                jilu: {},
                sh: [],
                jiaocai: {},
                fengmianList: [],
                fileList: [],
                banquanlist: [],
                articleList: [],
                wenjianList: [],
                modalshow: false,
                matchHeight: window.innerHeight * 0.8,
            }
        },
        props: ['id', 'isview', 'isshenhe', 'istuihui', 'shlx', 'issee', 'iswanjie'],
        watch: {

        },
        mounted() {

        },
        computed: {},
        components: {
            UploadCtrl,
            sccs
        },
        methods: {
            success(resp) {
                var file = resp.result;
                this.fileList.push(file);
                console.log(this.fileList);
            },
            imgFormatError(file) {
                this.$Notice.warning({
                    title: '警告',
                    desc: '请上传图片格式.'
                });
            },
            imgMaxSize(file) {
                this.$Notice.warning({
                    title: '警告',
                    desc: '文件大小不能超过' + '10m'
                });
            },
            upload() {
                this.modalshow = true;
            },
            close() {
                this.modalshow = false;
            },
        }
    };
</script>
<style scoped>
    /deep/ .ivu-form .ivu-form-item-label {
        color: black;
    }

    /deep/ .ivu-form .ivu-input {
        background-color: #ffffff;
        color: #b1b1b1;
    }

    /deep/ .ivu-select-selected-value {
        background-color: #ffffff;
        color: #b1b1b1;
    }
</style>