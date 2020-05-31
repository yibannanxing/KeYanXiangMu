<template>
    <div>
        <div style="width:1002px;margin:0 auto;">
            <h1 style="width:100%;text-align:center;font-size:28px;font-weight:700;line-height:100px;">立项申请表</h1>
            <!--<span style="font-size:17px;font-weight:700;">数据表</span><br />-->
            <table align="center" style="border:1px solid rgba(220,220,226,1);width:1000px " ref="xiangmu" :model="xiangmu" :rules="rules">
                <tr style="text-align:center;" class="tbe">
                    <td width="200px">项目名称</td>
                    <td width="600px" colspan="9">
                        <i-input v-model="xiangmu.xiangMuMingCheng"
                                 :disabled="isView"
                                 placeholder="请输入项目名称"
                                 size="large"
                                 :maxlength="20"></i-input>
                    </td>
                </tr>

                <tr>
                    <td width="200px" style="text-align:center;">项目类别</td>
                    <td width="600px" colspan="9" style="padding-left:10px">
                        <RadioGroup v-model="xiangmu.xiangMuLeiXing" style="margin-right:600px">
                            <Radio label="0" :disabled="isView">重点项目</Radio>
                            <Radio label="1" :disabled="isView">一般项目</Radio>
                        </RadioGroup>
                    </td>
                </tr>
                <tr>
                    <td width="200px" style="text-align:center;">研究类型</td>
                    <td width="600px" colspan="9" style="padding-left:10px">
                        <RadioGroup v-model="xiangmu.yanJiuLeiXing" style="margin-right:472px">
                            <Radio label="0" :disabled="isView">基础研究</Radio>
                            <Radio label="1" :disabled="isView">应用研究</Radio>
                            <Radio label="2" :disabled="isView">综合研究</Radio>
                            <Radio label="3" :disabled="isView">其他</Radio>
                        </RadioGroup>
                    </td>
                </tr>

                <tr style="text-align:center;" class="tbe">
                    <td width="200px">申请人</td>
                    <td colspan="2" width="260px">
                        <i-input v-model="xiangmu.shenQingRenName"
                                 :disabled="isView"
                                 size="large"
                                 :maxlength="10"></i-input>
                    </td>
                    <td>性别</td>
                    <td>
                        <i-select v-model="xiangmu.xingBie">
                            <i-option value="男">男</i-option>
                            <i-option value="女">女</i-option>
                        </i-select>
                    </td>
                    <td>民族</td>
                    <td width="100px">
                        <i-input v-model="xiangmu.minZu"
                                 :disabled="isView"
                                 size="large"
                                 :maxlength="7"></i-input>
                    </td>
                    <td width="100px">出生年月</td>
                    <td width="200px">
                        <DatePicker type="date"
                                    :disabled="isView"
                                    placeholder="选择日期"
                                    style="width: 200px"
                                    v-model="xiangmu.chuShengNianYue"></DatePicker>
                    </td>
                </tr>
                <tr style="text-align:center;" class="tbe">
                    <td width="200px">所属区队</td>
                    <td width="100px" colspan="4">
                        <i-input v-model="xiangmu.suoShuQuDui"
                                 :disabled="isView"
                                 size="large"
                                 :maxlength="7"></i-input>
                    </td>
                    <td width="100px">联系电话</td>
                    <td width="100px" colspan="4">
                        <i-input v-model="xiangmu.xueShengLianXiDianHua"
                                 :disabled="isView"
                                 size="large"
                                 :maxlength="11"></i-input>
                    </td>
                </tr>
                <tr style="text-align:center;" class="tbe">
                    <td width="200px">研究专长</td>
                    <td width="600px" colspan="9">
                        <i-input v-model="xiangmu.yanJiuZhuanChang"
                                 :disabled="isView"
                                 placeholder="请输入研究专长"
                                 size="large"
                                 :maxlength="10"></i-input>
                    </td>
                </tr>
                <tr style="text-align:center;" class="tbe">
                    <td width="200px">指导老师</td>
                    <td width="150px" colspan="2">
                        <i-input v-model="xiangmu.zhiDaoLaoShi"
                                 :disabled="isView"
                                 placeholder="请输入指导老师"
                                 size="large"
                                 :maxlength="7"></i-input>
                    </td>
                    <td width="100px">所属部门</td>
                    <td width="100px" colspan="2">
                        <i-input v-model="xiangmu.shenQingRenBuMenMingCheng"
                                 :disabled="isView"
                                 placeholder="请输入所属部门"
                                 size="large"
                                 :maxlength="7"></i-input>
                    </td>
                    <td width="100px">联系电话</td>
                    <td width="150px" colspan="2">
                        <i-input v-model="xiangmu.lianXiDianHua"
                                 :disabled="isView"
                                 placeholder="请输入联系电话"
                                 size="large"
                                 :maxlength="11"></i-input>
                    </td>
                </tr>
                <tr>
                    <td colspan="10">
                        <span v-model="xiangmu.liXiangLeiXing"
                              hidden="hidden"></span>
                        <zuyuanlist :isView="isView"
                                    :xiangmuId="id"
                                    v-model="xiangmu.xiangMuZuYuans"></zuyuanlist>
                    </td>
                </tr>

                <tr>
                    <td width="100px" style="text-align:center;">预期成果类型</td>
                    <td colspan="9" style="padding-left:10px">
                        <RadioGroup v-model="xiangmu.yuQiChengGuoLeiXing"
                                    style="margin-right:300px">
                            <Radio label="0" :disabled="isView">专著</Radio>
                            <Radio label="1" :disabled="isView">论文</Radio>
                            <Radio label="2" :disabled="isView">研究报告</Radio>
                            <Radio label="3" :disabled="isView">软件</Radio>
                            <Radio label="4" :disabled="isView">技术产品</Radio>
                            <Radio label="5" :disabled="isView">期刊</Radio>
                            <Radio label="6" :disabled="isView">专利</Radio>
                            <Radio label="7" :disabled="isView">其他</Radio>
                        </RadioGroup>
                    </td>
                </tr>
                <tr style="text-align:center;" class="tbe">
                    <td width="100px">最终成果名称及其形式</td>
                    <td width="700px" colspan="9">
                        <Form ref="xiangmu.xiangMuFangAn" :model="xiangmu.xiangMuFangAn">
                            <FormItem label="" prop="zuiZhongChengGuo">
                                <i-input v-model="xiangmu.xiangMuFangAn.zuiZhongChengGuo"
                                         :maxlength="100"
                                         :disabled="isView"
                                         type="textarea"
                                         :autosize="false"
                                         :rows="3"
                                         size="large"
                                         placeholder="请输入最终成果名称及形式（专著、论文及研究报告类成果 100字）" />
                            </FormItem>
                        </Form>
                    </td>

                </tr>
                <tr style="text-align:center;" class="tbe">
                    <td width="100px">项目开始时间</td>
                    <td width="300px" colspan="4">
                        <DatePicker type="date"
                                    placeholder="选择日期"
                                    :disabled="isView"
                                    style="width: 200px"
                                    v-model="xiangmu.startDateTime"></DatePicker>
                    </td>
                    <td width="100px">预计完成时间</td>
                    <td width="300px" colspan="4">
                        <DatePicker type="date"
                                    placeholder="选择日期"
                                    :disabled="isView"
                                    style="width: 200px"
                                    v-model="xiangmu.endDateTime"></DatePicker>
                    </td>
                </tr>

            </table>
            <br />
            <span style="font-size:17px;font-weight:700;margin-top:7px">与本课题相关的前期研究成果</span>
            <Form ref="xiangmu.xiangMuFangAn" :model="xiangmu.xiangMuFangAn" style="width:1045px">
                <FormItem label=" " prop="xiangMuChengGuo">
                    <i-input v-model="xiangmu.xiangMuFangAn.xiangMuChengGuo"
                             :disabled="isView" type="textarea"
                             :rows="5"
                             :maxlength="100" placeholder="研究成果将应用于何处？将有怎样的应用的价值？限100字" />
                </FormItem>
            </Form>
            <p style="font-size:17px;font-weight:700;">项目设计</p>
            <Form ref="xiangMuFangAn" :model="xiangMuFangAn">
                <FormItem label="1、选题" prop="xiangMuXuanTi" style="width:1045px">
                    <i-input v-model="xiangmu.xiangMuFangAn.xiangMuXuanTi"
                             type="textarea"
                             :disabled="isView"
                             :rows="12"
                             :maxlength="1000"
                             placeholder="国内外研究现状述评，选题意义和价值。" />
                </FormItem>
                <FormItem label="2、方案" prop="xiangMuFangAn1" style="width:1045px">
                    <i-input v-model="xiangmu.xiangMuFangAn.xiangMuFangAn1"
                             type="textarea"
                             :disabled="isView"
                             :rows="12" 
                             :maxlength="2000"
                             placeholder="项目研究的主要内容、研究难点、拟创新点、研究方法、研究步骤（主要阶段性成果）。" />
                </FormItem>
                <FormItem label="3、研究基础" prop="yanJiuJiChu" style="width:1045px">
                    <i-input v-model="xiangmu.xiangMuFangAn.yanJiuJiChu"
                             type="textarea"
                             :disabled="isView"
                             :rows="12"
                             :maxlength="1000"
                             placeholder="研究人员自身已有的相关成果、主要参考文献（限填20项）。" />
                </FormItem>
            </Form>
            <p style="font-size:17px;font-weight:700;">经费预算</p><br />
            <span>总额：{{ xiangmu.jingFeiZongE}} 万元</span>
            <jingfeilist :isView="isView"
                         :xiangmuId="id"
                         @changeTotal="changeTotal"
                         v-model="xiangmu.jingFeis"
                         style="width:1045px;overflow:auto"></jingfeilist>
            <i-button @click="save"
                      style="width:200px;margin:0 400px"
                      v-if="!isView"
                      type="primary">保存</i-button>
        </div>
    </div>
</template>


<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    import zuyuanlist from '../pages/zuyuanlist.vue';
    import jingfeilist from '../pages/jingfeilist.vue';

    const qs = require('qs');
    export default {
        data() {
            return {
                xiangmu: {
                    xiangMuFangAn: {},
                    liXiangLeiXing: 0,
                    jingFeiZongE: 0,
                    jingFeis: [],
                    xiangMuZuYuans: []
                }

            }
        },
        props: ['id', 'isView', 'jumpType'],
        mounted() {
            if (this.id)
                this.getXiangMu();
        },
        computed: {
        },
        components: {
            zuyuanlist,
            jingfeilist
        },
        methods: {
            getXiangMu() {
                axios.get('api/XiangMu/GetXiangMuById', { params: { id: this.id } })
                    .then(response => {
                        this.xiangmu = response.data.result;
                        this.xiangmu.xiangMuLeiXing = this.xiangmu.xiangMuLeiXing + '';
                        this.xiangmu.yuQiChengGuoLeiXing = this.xiangmu.yuQiChengGuoLeiXing + '';
                        this.xiangmu.yanJiuLeiXing = this.xiangmu.yanJiuLeiXing + '';
                        this.xiangmu.xingBie = this.xiangmu.xingBie + '';
                    }).catch(error => {
                        console.log(error);
                    });
            },
            save() {

                if (this.xiangmu.xiangMuMingCheng == undefined || this.xiangmu.xiangMuMingCheng == null) {
                    this.$Message.error('项目名称不能为空');
                } else if (this.xiangmu.xiangMuLeiXing == undefined || this.xiangmu.xiangMuMingCheng == null) {
                    this.$Message.error('请选择项目类型');
                } else if (this.xiangmu.yanJiuLeiXing == undefined || this.xiangmu.yanJiuLeiXing == null) {
                    this.$Message.error('请选择研究类型');
                } else if (this.xiangmu.shenQingRenName == undefined || this.xiangmu.shenQingRenName == null) {
                    this.$Message.error('申请人不能为空');
                } else if (!(/^(男|女)$/).test(this.xiangmu.xingBie)) {
                    this.$Message.error('请选择性别');
                } else if (this.xiangmu.minZu == undefined || this.xiangmu.minZu == null) {
                    this.$Message.error('民族不能为空');
                } else if (this.xiangmu.chuShengNianYue == "" || this.xiangmu.chuShengNianYue == null) {
                    this.$Message.error('请选择出生年月');
                } else if (this.xiangmu.suoShuQuDui == undefined || this.xiangmu.suoShuQuDui == null) {
                    this.$Message.error('请填写所属区队');
                } else if (!(/^[1][3,4,5,7,8][0-9]{9}$/).test(this.xiangmu.xueShengLianXiDianHua)) {
                    this.$Message.error('手机号码有误，请重填');
                } else if (this.xiangmu.zhiDaoLaoShi == undefined || this.xiangmu.zhiDaoLaoShi == null || this.xiangmu.zhiDaoLaoShi.length==0) {
                    this.$Message.error('指导老师为必填');
                } else if (this.xiangmu.shenQingRenBuMenMingCheng == undefined || this.xiangmu.shenQingRenBuMenMingCheng == null || this.xiangmu.shenQingRenBuMenMingCheng.length==0) {
                    this.$Message.error('请填写所属部门');
                } else if (this.xiangmu.lianXiDianHua == undefined || this.xiangmu.lianXiDianHua == null || this.xiangmu.lianXiDianHua.length==0) {
                    this.$Message.error('请填写联系电话');
                }else if (this.xiangmu.yuQiChengGuoLeiXing == undefined || this.xiangmu.yuQiChengGuoLeiXing == null) {
                    this.$Message.error('请选择成果类型');
                } else if (this.xiangmu.xiangMuFangAn.zuiZhongChengGuo == undefined || this.xiangmu.xiangMuFangAn.zuiZhongChengGuo == null) {
                    this.$Message.error('请填写最终成果');
                } else if (!this.xiangmu.startDateTime) {
                    this.$Message.error('请选择项目开始时间');
                } else if (this.xiangmu.endDateTime == "" || this.xiangmu.endDateTime == null) {
                    this.$Message.error('请选择项目结束时间');
                } else if (this.xiangmu.endDateTime < this.xiangmu.startDateTime) {
                    this.$Message.error('结束时间必须大于开始时间');
                } else if (this.xiangmu.xiangMuFangAn.zuiZhongChengGuo == "" || this.xiangmu.xiangMuFangAn.zuiZhongChengGuo == undefined) {
                    this.$Message.error('请填写最终成果形式');
                } else if (this.xiangmu.xiangMuFangAn.xiangMuChengGuo == "" || this.xiangmu.xiangMuFangAn.xiangMuChengGuo == undefined) {
                    this.$Message.error('请填写研究成果');
                } else if (this.xiangmu.xiangMuFangAn.xiangMuXuanTi == "" || this.xiangmu.xiangMuFangAn.xiangMuXuanTi == undefined) {
                    this.$Message.error('请填写项目选题');
                } else if (this.xiangmu.xiangMuFangAn.xiangMuXuanTi.length < 500) {
                    this.$Message.error('项目选题字数低于500');
                } else if (this.xiangmu.xiangMuFangAn.xiangMuFangAn1 == "" || this.xiangmu.xiangMuFangAn.xiangMuFangAn1 == undefined) {
                    this.$Message.error('请填写方案');
                } else if (this.xiangmu.xiangMuFangAn.xiangMuFangAn1.length < 1000) {
                    this.$Message.error('方案字数低于1000');
                } else if (this.xiangmu.xiangMuFangAn.yanJiuJiChu == "" || this.xiangmu.xiangMuFangAn.yanJiuJiChu == undefined) {
                    this.$Message.error('请填写研究基础');
                } else if (this.xiangmu.xiangMuFangAn.yanJiuJiChu.length < 500) {
                    this.$Message.error('研究基础字数低于500');
                } else if (this.xiangmu.jingFeiZongE == 0 || this.xiangmu.jingFeiZongE == null) {
                    this.$Message.error('经费不能为0');
                } else {
                    axios.post('api/XiangMu/SaveXiangMu', qs.stringify({
                        "entity": this.xiangmu
                    })).then(response => {
                        if (!response.data.error) {
                            this.$Message.success('保存成功!');
                            if (this.jumpType == 0) {
                                //this.$router.push({name:'xiangmulist'})
                                this.$emit('close')
                            }
                            else
                                this.$router.push({ name: 'xiangmulistgeren' })

                        } else {
                            this.$Message.error('保存失败!');
                        }
                    });
                }
            },
            changeTotal(total) {
                this.xiangmu.jingFeiZongE = total;
            }
        }
    }
</script>
<style scoped>
    table {
        border-collapse: collapse;
    }

    .tabbiankuang {
        column-rule-style: none
    }

    /deep/ .tbe .ivu-input {
        border: none;
        font-size: 14px;
    }

        /deep/ .tbe .ivu-input:hover {
            border: none;
        }

        /deep/ .tbe .ivu-input:focus {
            border: none;
            box-shadow: none;
        }

    table, td {
        border: 1px solid rgba(220,220,226,1);
        height: 40px;
    }

    /deep/ .ivu-input[disabled] {
        background: rgb(255, 255, 255);
    }
</style>
