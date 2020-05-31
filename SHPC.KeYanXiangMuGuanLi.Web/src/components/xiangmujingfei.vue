<template>
    <div style="padding:30px;width:300px;">
        <Form ref="jingfei" :model="jingfei" :rules="ruleValidate">
            <FormItem label="经费名称" prop="mingCheng">
                <Row>
                    <Col span="12">
                    <i-select v-model="jingfei.mingCheng" style="width:200px">
                        <i-option value="资料费">资料费</i-option>
                        <i-option value="调研差旅费">调研差旅费</i-option>
                        <i-option value="材料费">材料费</i-option>
                        <i-option value="制作费">制作费</i-option>
                        <i-option value="软件开发费">软件开发费</i-option>
                        <i-option value="咨询费">咨询费</i-option>
                        <i-option value="知识产权服务费等费用">知识产权服务费等费用</i-option>
                        <i-option value="其他">其他</i-option>
                    </i-select>
                    </Col>
                </Row>
                <!--<Input placeholder="请输入项目名称..." v-model="jingfei.mingCheng" ></Input>-->
            </FormItem>
            <FormItem label="经费金额" prop="jinE">
                <Row>
                    <Col span="12">
                    </Col>
                    <Col span="12">
                    <InputNumber v-model="jingfei.jinE" placeholder="请输入金额" min="0" max="100"></InputNumber> 万
                    </Col>
                </Row>
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
    import store from './store.vue';
    const qs = require('qs');
    export default {
        data() {
            const validateJingFei = (rule, value, callback) => {
                if (!value) {
                    callback(new Error('请输入经费金额'));
                } else {
                    callback();
                }
            };
            return {
                jingfei: {
                    jinE: 0,
                    mingCheng: '',
                },
                ruleValidate: {
                    mingCheng: [
                        { required: true, message: '请选择经费类型', trigger: 'change', type: 'string' }
                    ],
                    jinE: [
                        { validator: validateJingFei, trigger: 'blur' }
                    ]
                },
                changdata: {
                    mc: ''
                }
            }
        },
        props: ['jingfei'],
        watch: {
            jingfei: {
                deep: true,
                handler(newName, oldName) {
                    console.log(this.jingfei.jinE)
                    if (this.jingfei.jinE == undefined || this.jingfei.jinE == null) {
                        this.jingfei.jinE = 0;
                    }
                },
            }
        },
        mounted() {
            if (!this.jingfei.id) {
                this.jingfei.id = this.newGuid();
            }
        },
        computed: {
            //changdata() {
            //    this.changdata.mc = this.jingfei.mingCheng;
            //}
        },
        components: {

        },
        methods: {
            save() {

                this.$refs.jingfei.validate((valid) => {
                    if (valid) {
                        this.jingfei.jinE = this.numFilter(this.jingfei.jinE);
                        console.log(this.jingfei.jinE);
                        this.$emit('close', this.jingfei);
                        console.log(this.jingfei);
                        this.$Message.success('保存成功!');
                    } else {
                        this.$Message.error('请完成必填项!');
                    }
                })


            },
            newGuid() {
                var guid = "";
                for (var i = 1; i <= 32; i++) {
                    var n = Math.floor(Math.random() * 16.0).toString(16);
                    guid += n;
                    if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                        guid += "-";
                }
                return guid;
            },
            numFilter(value) {
                let tempVal = parseFloat(value).toFixed(3)
                let realVal = tempVal.substring(0, tempVal.length - 1)
                return realVal * 1
            }

        }
    };
</script>
<style>
</style>