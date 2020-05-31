<template>
    <Form ref="studentxiangmuzuyuan" :model="studentxiangmuzuyuan" style="padding:30px">
        <FormItem label="姓名" prop="xiangMuZuChengYuanXingMing">
            <Input v-model="studentxiangmuzuyuan.xiangMuZuChengYuanXingMing"></Input>
        </FormItem>
        <FormItem label="性别"  prop="xingBie">
            <RadioGroup v-model="studentxiangmuzuyuan.xingBie">
                <Radio label="男"></Radio>
                <Radio label="女"></Radio>
            </RadioGroup>
        </FormItem>
        <FormItem label="出生年月">
            <Row>
                <Col span="12">
                <FormItem prop="chuShengNianYue">
                    <DatePicker type="date" placeholder="选择日期" style="width: 200px" v-model="studentxiangmuzuyuan.chuShengNianYue"></DatePicker>
                </FormItem>
                </Col>
            </Row>
        </FormItem>
        <FormItem label="研究专长" prop="yanJiuZhuanChang">
            <Input v-model="studentxiangmuzuyuan.yanJiuZhuanChang"></Input>
        </FormItem>

        <FormItem label="学历" prop="xueLi">
            <Input v-model="studentxiangmuzuyuan.xueLi"></Input>
        </FormItem>
        <FormItem label="所属部门" prop="suoSuBuMenMingCheng">
            <Input v-model="studentxiangmuzuyuan.suoSuBuMenMingCheng"></Input>
        </FormItem>
       
        <FormItem>
            <Button @click="save" type="primary">保存</Button>
            <Button  @click="handleReset('studentxiangmuzuyuan')"  style="margin-left: 8px">重置</Button>
        </FormItem>
    </Form>
</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    const qs = require('qs');
    export default {
        data() {
            return {
                studentxiangmuzuyuan: {}
            }
        },
        props: ['xiangmuId'],
        watch: {
            
        },
        mounted() {
            //for test  by zzq
            this.xiangmuId = this.xiangmuId ||'00000000-0000-0000-0000-000000000000'
        },
        computed: {},
        components: {

        },
        methods: {
            //添加组员
            save() {
                this.$Message.success('保存成功!');
                this.$emit('close', this.studentxiangmuzuyuan);
                //this.$refs.xiangmuzuyuan.validate((valid) => {
                //    if (valid) {
                //        this.$Message.error('保存成功!');
                //        this.$emit('close', this.xiangmuzuyuan);
                //        //axios.post('api/XiangMuZuYuan/SaveZuYuan1', qs.stringify({
                //        //    "xiangmuzuyuan": this.xiangmuzuyuan
                //        //})).then(response => { this.$emit('close') });

                //    } else {
                //        this.$Message.error('保存失败!');
                //    }
                //})
            },
            handleReset(name) {
                this.$refs[name].resetFields();
            }
        },


    };
</script>
<style>

</style>