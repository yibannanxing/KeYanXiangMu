<template>
    <div v-if="isLoading === false">
        <Form ref="xiangmuzuyuan" :model="xiangmuzuyuan" :rules="ruleValidate" :label-position="'right'">
            <FormItem label="姓名" prop="xiangMuZuChengYuanXingMing">
                <Row>
                    <Col span="12">
                    <i-input v-model="xiangmuzuyuan.xiangMuZuChengYuanXingMing"  :maxlength="20" placeholder="请输入姓名"></i-input>
                    </Col>
                </Row>
            </FormItem>

            <FormItem label="性别" prop="xingBie">
                <RadioGroup v-model="xiangmuzuyuan.xingBie"  placeholder="请选择性别">
                    <Radio label="0">男</Radio>
                    <Radio label="1">女</Radio>
                </RadioGroup>
            </FormItem>
           
            <FormItem label="出生年月" prop="chuShengNianYue">
                <Row>
                    <Col span="12">
                    <FormItem prop="chuShengNianYue">
                        <DatePicker type="date" placeholder="选择日期" style="width: 200px" v-model="xiangmuzuyuan.chuShengNianYue"></DatePicker>
                    </FormItem>
                    </Col>
                </Row>
            </FormItem>
            <!--<FormItem label="联系电话" prop="lianXiDianHua">
            <Input v-model="xiangmu.lianXiDianHua" placeholder="请输入联系电话..." />
            </FormItem>-->
            <FormItem label="职务" prop="zhiWuMingCheng">
                <Row>
                    <Col span="12">
                    <i-input v-model="xiangmuzuyuan.zhiWuMingCheng" :maxlength="20"  placeholder="请输入职务"></i-input>
                    </Col>
                </Row>

            </FormItem>

            <FormItem label="研究专长" prop="yanJiuZhuanChang">
                <Row>
                    <Col span="12">
                    <i-input v-model="xiangmuzuyuan.yanJiuZhuanChang" :maxlength="20"  placeholder="请输入研究专长"></i-input>
                    </Col>
                </Row>

            </FormItem>

            <FormItem label="学历" prop="xueLi">
                <Row>
                    <Col span="12">
                    <i-input v-model="xiangmuzuyuan.xueLi" :maxlength="20"  placeholder="请输入学历"></i-input>
                    </Col>
                </Row>

            </FormItem>
            <FormItem label="所属部门" prop="suoSuBuMenMingCheng">
                <Row>
                    <Col span="12">
                    <i-input v-model="xiangmuzuyuan.suoSuBuMenMingCheng" :maxlength="20" placeholder="请输入所属部门"></i-input>
                    </Col>
                </Row>

            </FormItem>

            <FormItem>
                <Button @click="save" type="primary">保存</Button>
                <Button @click="handleReset('xiangmuzuyuan')" style="margin-left: 8px">重置</Button>
            </FormItem>
        </Form>
    </div>
    <div v-else>
        laoding...
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
                isLoading: false,
                ruleValidate: {
                    xiangMuZuChengYuanXingMing: [
                        { required: true, message: '姓名不能为空', trigger: 'blur' }
                    ],
                    xingBie: [
                        { required: true, message: '请选择性别', trigger: 'change' }
                    ],
                    chuShengNianYue: [
                        { required: true, type: 'date', message: '请选择日期', trigger: 'change' }
                    ],
                    zhiWuMingCheng: [
                        { required: true, message: '职务不能为空', trigger: 'blur' }
                    ],
                    yanJiuZhuanChang: [
                        { required: true, message: '研究专长不能为空', trigger: 'blur' }
                    ],
                    xueLi: [
                        { required: true, message: '学历不能为空', trigger: 'blur' }
                    ],
                    suoSuBuMenMingCheng: [
                        { required: true, message: '所属部门不能为空', trigger: 'blur' }
                    ],
                }
            }
        },
        props: ['xiangmuzuyuan'],
        watch: {
            //xiangmuzuyuan: {
            //    deep: true,
            //    handler(newName, oldName) {
            //        console.log(newName)
            //        console.log(oldName)
            //        console.log(this.xiangmuzuyuan)
            //        if (!this.xiangmuzuyuan) {

            //        }
            //    },
            //}
            
        },
        mounted() {
            if (!this.xiangmuzuyuan.id) {
                this.xiangmuzuyuan.id = this.newGuid();
                this.xiangmuzuyuan.xingBie = '0'
            }
            else {
                this.xiangmuzuyuan.xingBie = this.xiangmuzuyuan.xingBie + '';
            }
        },
        computed: {},
        components: {

        },
        methods: {
            save() {
                this.$refs.xiangmuzuyuan.validate((valid) => {
                    if (valid) {
                        this.$Message.success('保存成功!');
                        this.$emit('close', this.xiangmuzuyuan);
                    } else {
                        this.$Message.error('请完成必填项!');
                    }
                }) 
            },
            handleReset(name) {
                this.$refs[name].resetFields();
            },
            newGuid() {
                var guid = "";
                for (var i = 1; i <= 32; i++){
                    var n = Math.floor(Math.random()*16.0).toString(16);
                    guid +=   n;
                    if((i==8)||(i==12)||(i==16)||(i==20))
                    guid += "-";
                }
                return guid;
            }
        },


    };
</script>
<style>
</style>