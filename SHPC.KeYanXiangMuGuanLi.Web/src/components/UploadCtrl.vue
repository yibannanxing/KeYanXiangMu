<template>
    <div style="min-width:400px;">
        <div v-if="type==0">
            <div class="demo-upload-list" v-for="(item,index) in fileList" :key="item.id">
                <template>
                    <img :src="item.luJing">
                    <div class="demo-upload-list-cover">
                        <Icon type="ios-trash-outline" @click.native="deleteItem(item,index)"></Icon>
                        <Icon type="ios-eye-outline" @click.native="imgView(item)"></Icon>
                    </div>
                </template>
            </div>
            <Upload ref="upload"
                    :show-upload-list="false"
                    :on-success="success"
                    :format="['jpg','jpeg','png','gif']"
                    :max-size="maxSize"
                    :on-format-error="imgFormatError"
                    :on-exceeded-size="imgMaxSize"
                    :before-upload="imgBeforeUpload"
                    multiple
                    type="drag"
                    :action="'api/Upload/UploadFile?type='+type"
                    style="display: inline-block;width:58px;">
                <div style="width: 58px;height:58px;line-height: 58px;">
                    <Icon type="ios-camera" size="20"></Icon>
                </div>
            </Upload>
            <Modal title="图片预览" v-model="visible">
                <img :src="imgViewItem.luJing" v-if="visible" style="width: 100%">
            </Modal>
        </div>
        <div v-else>
            <Upload v-if="type==1"
                    :on-success="success"
                    :format="['jpg','jpeg','png','gif','rar','doc','docx','xls','ppt','txt']"
                    :on-format-error="wenjianFormatError"
                    :show-upload-list="false"
                    :on-exceeded-size="imgMaxSize"
                    :max-size="maxSize"
                    type="drag"
                    :action="'api/Upload/UploadFile?type='+type">
                <div style="padding: 20px 0">
                    <Icon type="ios-cloud-upload" size="52" style="color: #3399ff"></Icon>
                    <p>上传文件</p>
                </div>
            </Upload>
            <Upload v-if="type==2"
                    multiple
                    :on-success="success"
                    :show-upload-list="false"
                    :on-exceeded-size="imgMaxSize"
                    :max-size="maxSize"
                    :action="'api/Upload/UploadFile?type='+type">
                <Button icon="ios-cloud-upload-outline">上传文件</Button>
            </Upload>
            <div style="margin-top:15px;">
                <p style="line-height:30px;border-bottom:1px dashed #ddd;margin-bottom:8px;" v-if="fileList.length>0">文件列表</p>
                <Alert closable v-for="(item,index) in fileList"
                       :key="item.id" @on-close="deleteItem(item,index)">
                    {{item.wenJianMingCheng}}
                </Alert>
            </div>
        </div>
    </div>
</template>
<script lang="ts">
    /*
     组件类型有三种：
     1、0=图片
     2、1=支持拖放文件上传
     3、2=按钮
     */
    import Vue from 'vue';
    import axios from 'axios';

    export default {
        data() {
            return {
                visible: false,
                imgViewItem: {}
            }
        },
        model: {
            prop: 'fileList',
            event:'upload'
        },
        props: ['type','fileList','filelimit','maxSize'],
        watch: {
            fileList: {
                deep: true,
                handler(newVal) {
                    this.$emit('upload',newVal);
                }
            }
        },
        mounted() {
            this.$nextTick(function () {
                if (!this.filelimit) {
                    this.filelimit = 5;
                }
                if (!this.maxSize) {
                    this.maxSize = 2048;
                }
            });
        },
        methods: {
            success(resp) {
                var file = resp.result;
                this.fileList.push(file)
            },
            deleteItem(item,index) {
                this.$Modal.confirm({
                    title: "删除",
                    content: "您确定要删除嘛",
                    onOk: () => {
                        axios.get('api/Upload/DelFile?filePath='+item.luJing+'&fileId='+item.id)
                     .then(resp => {
                         this.fileList.splice(index, 1);
                     }).catch(err => {
                         console.log(err);
                     });
                    },
                })
            },
            imgView(item) {
                this.visible = true;
                this.imgViewItem = item;
            },
            imgFormatError (file) {
                this.$Notice.warning({
                    title: '警告',
                    desc: '请上传图片格式.'
                });
            },
            wenjianFormatError (file) {
                this.$Notice.warning({
                    title: '警告',
                    desc: '请上传图片、rar、txt 、xls、doc格式.'
                });
            },
            imgMaxSize (file) {
                this.$Notice.warning({
                    title: '警告',
                    desc: '文件大小不能超过'+this.maxSize+'.'+'KB'
                });
            },
            imgBeforeUpload () {
                const check = this.fileList.length < this.filelimit;
                if (!check) {
                    this.$Notice.warning({
                        title: '文件上传个数不能超过'+this.filelimit+'.'
                    });
                }
                return check;
            },
        }
    };
</script>
<style>
    .demo-upload-list {
        display: inline-block;
        width: 60px;
        height: 60px;
        text-align: center;
        line-height: 60px;
        border: 1px solid transparent;
        border-radius: 4px;
        overflow: hidden;
        background: #fff;
        position: relative;
        box-shadow: 0 1px 1px rgba(0,0,0,.2);
        margin-right: 4px;
    }

        .demo-upload-list img {
            width: 100%;
            height: 100%;
        }

    .demo-upload-list-cover {
        display: none;
        position: absolute;
        top: 0;
        bottom: 0;
        left: 0;
        right: 0;
        background: rgba(0,0,0,.6);
    }

    .demo-upload-list:hover .demo-upload-list-cover {
        display: block;
    }

    .demo-upload-list-cover i {
        color: #fff;
        font-size: 20px;
        cursor: pointer;
        margin: 0 2px;
    }
</style>