<template>
    <div style="padding:30px;">
            <Form ref="xiangmu" :data="xiangmu" :label-width="120">
                <FormItem label="项目名称" prop="xiangMuMingCheng">
                    {{xiangmu.xiangMuMingCheng}}
                </FormItem>
                <FormItem label="项目类型" prop="xiangMuLeiXing">
                    {{xiangmu.xiangMuLeiXingName}}
                </FormItem>
                <FormItem label="申请人">
                    {{xiangmu.shenQingRenName}}
                </FormItem>
                <FormItem label="部门">
                    {{xiangmu.shenQingRenBuMenMingCheng}}
                </FormItem>
                <FormItem label="性别" prop="xingBie">
                    {{xiangmu.xingBie}}
                </FormItem>
                <FormItem label="民族" prop="minZu">
                    {{xiangmu.minZu}}
                </FormItem>
                <FormItem label="出生年月">
                    {{xiangmu.chuShengNianYue}}
                </FormItem>
                <FormItem label="联系电话" prop="lianXiDianHua">
                    {{xiangmu.lianXiDianHua}}
                </FormItem>
                <FormItem label="课题组成员" prop="keTiZuChengYuanRenSu">
                    {{xiangmu.keTiZuChengYuanRenSu}} 人
                    <div v-for="item in xiangmu.xiangMuZuYuans" key="item">
                        <!--{{item.xingBie}} {{item.chuShengNianYue}} {{item.zhiWuMingCheng}} {{item.yanJiuZhuanChang}} {{item.xueLi}}-->
                        <p> 姓名：{{item.xiangMuZuChengYuanXingMing}}  所属部门：{{item.suoSuBuMenMingCheng}} </p>
                    </div>
                </FormItem>
                <FormItem label="预期成果类型" prop="yuQiChengGuoLeiXing">
                    {{xiangmu.yuQiChengGuoLeiXingName}}
                </FormItem>
                <FormItem label="研究类型" prop="yanJiuLeiXing">
                    {{xiangmu.yuQiChengGuoLeiXingName}}
                </FormItem>
                <FormItem label="经费总额" prop="jingFeiZongE">
                    {{ xiangmu.jingFeiZongE}} 万元
                    <div v-for="item in xiangmu.jingFeis" key="item">
                        <p> 经费名称：{{item.mingCheng}}   金额：{{item.jinE}} </p> 
                    </div>
                </FormItem>
                <FormItem label="">
                    <Row>
                        <Col span="11">
                        <FormItem label="开始时间" prop="startDateTime">
                            {{xiangmu.startDateTime}}
                        </FormItem>
                        </Col>
                        <Col span="0" style="text-align: center">-</Col>
                        <Col span="11">
                        <FormItem label="结束时间" prop="endDateTime">
                            {{xiangmu.endDateTime}}
                        </FormItem>
                        </Col>
                    </Row>
                </FormItem>
            </Form>
            <Form ref="xiangMuFangAn" :model="xiangMuFangAn">

                <FormItem label="一、成果名称及形式" prop="zuiZhongChengGuo">
                    {{xiangMuFangAn.zuiZhongChengGuo}}
                </FormItem>
                <FormItem label="二、成果应用前景预测" prop="xiangMuChengGuo">
                    {{xiangMuFangAn.xiangMuChengGuo}}
                </FormItem>
                <FormItem label="三、项目设计"></FormItem>
                <FormItem label="1、选题" prop="xiangMuXuanTi">
                    {{xiangMuFangAn.xiangMuXuanTi}}
                </FormItem>
                <FormItem label="2、方案" prop="xiangMuFangAn1">
                    {{xiangMuFangAn.xiangMuFangAn1}}
                </FormItem>
                <FormItem label="3、研究类型" prop="yanJiuJiChu">
                    {{xiangMuFangAn.yanJiuJiChu}}
                </FormItem>
            </Form>
    </div>
</template>
<script lang="ts">
    import Vue from "vue";
    import axios from 'axios';
    const qs = require('qs');
    const moment = require('moment');
    export default {
        data() {
            return {
                xiangmu: {},
                xiangMuFangAn: {},
                xiangMuZuYuans: [],
                jingFeis: [],
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

        },
        computed: {

        },
        methods: {
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
                    }).catch(error => {
                        console.log(error);
                    });
            },
        }
    }
</script>
<style>
    .ivu-modal-body {
        padding: 0 !important;
        width: 100%;
        overflow-x: hidden !important;
        overflow-y: auto !important;
    }

    .vertical-center-modal {
        display: flex;
        align-items: center;
        justify-content: center;
    }
</style>
