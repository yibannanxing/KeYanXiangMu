<template>
    <div style="padding:30px;">
        <Form ref="xiangmu" :model="xiangmu" :rules="ruleValidate" :label-width="120">
            <FormItem label="项目名称" prop="xiangMuMingCheng">
                <Input v-model="xiangmu.xiangMuMingCheng" placeholder="请输入项目名称..."></Input>
            </FormItem>
            <FormItem label="项目类型" prop="xiangMuLeiXing">
                <Select v-model="xiangmu.xiangMuLeiXing">
                    <Option value="0">重点项目 </Option>
                    <Option value="1">一般项目</Option>
                </Select>
            </FormItem>
            <FormItem label="申请人">
                {{xiangmu.shenQingRenName}}
            </FormItem>
            <FormItem label="部门">
                {{xiangmu.shenQingRenBuMenMingCheng}}
            </FormItem>
            <FormItem label="性别" prop="xingBie">
                <RadioGroup v-model="xiangmu.xingBie">
                    <Radio label="男"></Radio>
                    <Radio label="女"></Radio>
                </RadioGroup>
            </FormItem>
            <FormItem label="民族" prop="minZu">
                <Input v-model="xiangmu.minZu" placeholder="请输入民族"></Input>
            </FormItem>
            <FormItem label="出生年月">
                <Row>
                    <Col span="12">
                    <FormItem prop="chuShengNianYue">
                        <DatePicker type="date" placeholder="选择日期" style="width: 200px" v-model="xiangmu.chuShengNianYue"></DatePicker>
                    </FormItem>
                    </Col>
                </Row>
            </FormItem>
            <FormItem label="联系电话" prop="lianXiDianHua">
                <Input v-model="xiangmu.lianXiDianHua" placeholder="请输入联系电话..." />
            </FormItem>
            <FormItem label="课题组成员" prop="keTiZuChengYuanRenSu">
                {{xiangmu.keTiZuChengYuanRenSu}} 
                <!--<Input-number v-model="xiangmu.keTiZuChengYuanRenSu=xiangMuZuYuans.length" disabled="disabled" hidden="hidden"></Input-number>-->
                <zuyuanlist :xiangmuId="xiangmuId" v-model="xiangmu.xiangMuZuYuans"></zuyuanlist>
            </FormItem>
            <FormItem label="预期成果类型" prop="yuQiChengGuoLeiXing">
                <Select v-model="xiangmu.yuQiChengGuoLeiXing">
                    <Option value="0">专著</Option>
                    <Option value="1">论文</Option>
                    <Option value="2">研究报告</Option>
                    <Option value="3">软件</Option>
                    <Option value="4">技术产品</Option>
                    <Option value="5">期刊</Option>
                    <Option value="6">专利</Option>
                    <Option value="7">其他</Option>
                </Select>
            </FormItem>
            <FormItem label="研究类型" prop="yanJiuLeiXing">
                <Select v-model="xiangmu.yanJiuLeiXing">
                    <Option value="0">基础研究 </Option>
                    <Option value="1">应用研究 </Option>
                    <Option value="2">综合研究</Option>
                    <Option value="3">其他</Option>
                </Select>
            </FormItem>
            <FormItem label="经费总额" prop="jingFeiZongE">
                {{ xiangmu.jingFeiZongE=num}} 万元
                <jingfeilist :xiangmuId="xiangmuId" v-model="xiangmu.jingFeis"></jingfeilist>
            </FormItem>
            <FormItem label="项目开始时间">
                <Row>
                    <Col span="11">
                    <FormItem prop="startDateTime">
                        <DatePicker type="date" placeholder="项目开始时间" v-model="xiangmu.startDateTime"></DatePicker>
                    </FormItem>
                    </Col>
                    <Col span="0" style="text-align: center">-</Col>
                    <Col span="11">
                    <FormItem prop="endDateTime">
                        <DatePicker type="date" placeholder="项目预计结束时间" v-model="xiangmu.endDateTime"></DatePicker>
                    </FormItem>
                    </Col>
                </Row>
            </FormItem>
        </Form>
        <Form ref="xiangMuFangAn" :model="xiangMuFangAn">

        <FormItem label="一、成果名称及形式" prop="zuiZhongChengGuo">
            <i-input v-model="xiangMuFangAn.zuiZhongChengGuo" type="textarea" :autosize="true" :rows="10" placeholder="请输入最终成果名称及形式（专著、论文及研究报告类成果注明字数）" />
        </FormItem>
        <FormItem label="二、成果应用前景预测" prop="xiangMuChengGuo">
            <i-input v-model="xiangMuFangAn.xiangMuChengGuo" type="textarea" :autosize="true" :rows="3" :maxlength="100" placeholder="研究成果将应用于何处？将有怎样的应用的价值？限100字" />
        </FormItem>
        <FormItem label="三、项目设计"></FormItem>
        <FormItem label="1、选题" prop="xiangMuXuanTi">
            <i-input v-model="xiangMuFangAn.xiangMuXuanTi" type="textarea" :autosize="true" :rows="12" :maxlength="1000" placeholder="国内外研究现状述评，选题意义和价值。" />
        </FormItem>
        <FormItem label="2、方案" prop="xiangMuFangAn1">
            <i-input v-model="xiangMuFangAn.xiangMuFangAn1" type="textarea" :autosize="true" :rows="12" :maxlength="1000" placeholder="项目研究的主要内容、研究难点、拟创新点、研究方法、研究步骤（主要阶段性成果）。" />
        </FormItem>
        <FormItem label="3、研究类型" prop="yanJiuJiChu">
            <i-input v-model="xiangMuFangAn.yanJiuJiChu" type="textarea" :autosize="true" :rows="12" :maxlength="1000" placeholder="研究人员自身已有的相关成果、主要参考文献（限填20项）。" />
        </FormItem>
    </Form>
        <Button @click="save" type="primary">保存</Button>
    </div>




</template>
<script lang="ts">
    import Vue from "vue";
    import axios from 'axios';

    import zuyuanlist from './zuyuanlist.vue';
    import jingfeilist from './jingfeilist.vue';
    import fangan from './fangan.vue';

    const qs = require('qs');
    const moment = require('moment');

    export default {
        data() {
            const validateLianXiDianHua = (rule, value, callback, dhhuoqu) => {
                dhhuoqu = /^[1][3,4,5,7,8][0-9]{9}$/;
                if (!value) {
                    callback(new Error('请输入您的联系电话'));
                } else if (!dhhuoqu.test(value)) {
                    callback(new Error('请输入正确的电话号码'));
                } else {
                    callback();
                }
            };
            const validateXiangMuJieShuShiJian = (rule, value, callback) => {
                if (!value) {
                    callback(new Error('请填写项目预计结束时间'));
                } else if (value <= this.xiangmu.startDateTime) {
                    callback(new Error('请选择大于项目开始的时间'));
                } else {
                    callback();
                }
            };
            return {
                modalfangan: false,
                xiangmu: {},
                xiangMuFangAn: {},
                xiangMuZuYuans: [],
                jingFeis:[],
                xiangmuId: null,
                ruleValidate: {
                    xiangMuMingCheng: [
                        { required: true, message: '请输入项目名称', trigger: 'blur' }
                    ],
                    xiangMuLeiXing: [
                        { required: true, message: '请选择项目类型', trigger: 'change', type: 'string' }
                    ],
                    yanJiuLeiXing: [
                        { required: true, message: '请选择研究类型', trigger: 'change', type: 'string' }
                    ],
                    xingBie: [
                        { required: true, message: '请选择性别', trigger: 'change' }
                    ],
                    lianXiDianHua: [
                        { validator: validateLianXiDianHua, trigger: 'change' }
                    ],
                    yuQiChengGuoLeiXing: [
                        { required: true, message: '请选择预期成果类型', trigger: 'change', type: 'string' }
                    ],
                    startDateTime: [
                        { required: true, message: '请填写项目开始时间', trigger: 'change', type: 'date' }
                    ],
                    endDateTime: [
                        { validator: validateXiangMuJieShuShiJian, trigger: 'change', type: 'date' }
                    ],
                }
            }
        },
        watch: {
          
        },
        props: [
            'id'
        ],
        mounted() {
            this.getXiangMu(this.id == null)

        },
        components: {
            zuyuanlist,
            jingfeilist,
            fangan
        },
        computed: {
           // 计算经费总和
            num() {
                var _jf = 0;
                this.jingFeis.forEach((item, index) => {
                    _jf += item.jinE
                })
                console.log(jingfeilist);
                return _jf;
            },
        },
        methods: {
            close() {
                this.modalfangan = false;
            },
            getXiangMu(isIdEmpty) {
                var action = 'GetXiangMuSchema';
                var data = null
                if (!isIdEmpty) {
                    action = 'GetXiangMuById';
                    data = { params: { xiangmuId: this.id } };
                }
                axios.get('api/XiangMu/' + action, data)
                    .then(response => {
                        this.xiangmu = response.data.result;
                        this.xiangMuFangAn = this.xiangmu.xiangMuFangAn;
                        this.xiangmu.xiangMuLeiXing = this.xiangmu.xiangMuLeiXing + '';
                        this.xiangmu.yuQiChengGuoLeiXing = this.xiangmu.yuQiChengGuoLeiXing + '';
                        this.xiangmu.yanJiuLeiXing = this.xiangmu.yanJiuLeiXing + '';
                    }).catch(error => {
                        console.log(error);
                    });
            },
            save() {
                var xm_bag = {
                    xiangMu: this.xiangmu,
                    xiangMuFangAn: this.xiangMuFangAn,
                    xiangMuZuYuans: this.xiangmu.xiangMuZuYuans,
                    jingFeis: this.xiangmu.jingFeis
                };
                this.$refs.xiangmu.validate((valid) => {
                    if (valid) {
                        axios.post('api/XiangMu/SaveXiangMu1', qs.stringify({
                            "xiangmu_request_bag": xm_bag
                        })).then(response => {
                            this.$Message.success('保存成功!');
                            this.$emit('close')
                            this.$refs.xiangmu.resetFields();
                            this.xiangmu = { isYanQi: false }
                        });
                    } else {
                        this.$Message.error('请完成必填项!');
                    }
                })
            },


        }
    }
</script>
<style>
</style>
