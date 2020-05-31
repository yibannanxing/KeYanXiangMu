<template>
    <div style="padding:10px;text-align:center">
        <table align="center" style="width:1000px" v-model="jiexiang">
            <tr class="tbe">
                <td style="width:100px" colspan="2">项目负责人姓名</td>
                <td>
                    <i-input v-model="jiexiang.fuZeRenMingCheng" :disabled="isView" :maxlength="20" size="large"></i-input>
                </td>
                <td>部门</td>
                <td>
                    <i-input v-model="jiexiang.buMenMingCheng" :disabled="isView" :maxlength="20" size="large"></i-input>
                </td>
                <td>职称职务</td>
                <td>
                    <i-input v-model="jiexiang.zhiWuMingCheng" :disabled="isView" :maxlength="20" size="large"></i-input>
                </td>
            </trclass="tbe">
            <!--结项项目组成员-->
            <tr class="tbe">
                <td colspan="7">
                    <JieXiangZuYuanList :lxid="id" :isstu="isstu" v-model="jxzuyuans"></JieXiangZuYuanList>
                </td>
            </tr>

            <tr class="tbe">
                <td style="width:100px" rowspan="2" colspan="2">最终成果名称</td>
                <td colspan="5">
                    <i-input v-model="jiexiang.zuiZhongChengGuo1" :maxlength="500" :disabled="isView" size="large" placeholder="1、" type="textarea"></i-input>
                </td>

            </tr>
            <tr class="tbe">
                <td colspan="5">
                    <i-input v-model="jiexiang.zuiZhongChengGuo2" :maxlength="500" :disabled="isView" size="large" placeholder="2、" type="textarea"></i-input>
                </td>
            </tr>
            <tr class="tbe">
                <td style="width:100px">完成状态</td>
                <td colspan="6">
                    <Radio-group v-model="jiexiang.wanChengZhuangTai" :disabled="isView">
                        <!--<Radio label="0" :disabled="isView">专著</Radio>-->
                        <Radio label="0">正常</Radio>
                        <Radio label="1">提前</Radio>
                        <Radio label="2">调整延期</Radio>
                    </Radio-group>

                </td>
            </tr>
            <tr class="tbe">
                <td colspan="2">最终成果字数（研究报告、论文、著作类）</td>
                <td colspan="5">
                    <i-input v-model="jiexiang.zuiZhongChengGuoZiShu" :maxlength="10" :disabled="isView" size="large" placeholder="单位（千字）"></i-input>
                </td>
            </tr>
            <tr class="tbe">
                <td colspan="2">最终成果发表、出版时间和单位</td>
                <td colspan="5">
                    <i-input v-model="jiexiang.faBiaoChuBan" :maxlength="1000" :disabled="isView" size="large"></i-input>
                </td>
            </tr>
            <tr class="tbe">
                <td style="width:50px;text-align:center" rowspan="9">经<br />费<br />使<br />用<br />情<br />况</td>
                <td>核准经费</td>
                <td>
                    <i-input v-model="jiexiang.heZunJingFei" :maxlength="5" :disabled="isView" size="large" placeholder="万元"></i-input>
                </td>

                <td>实际使用经费</td>
                <td>
                    <!--sjjf-->
                    <!--jiexiang.shiJiJingFei-->
                    <i-input v-model="sjjf" :maxlength="5" :disabled="isView" size="large" placeholder="万元"></i-input>
                </td>

                <td>结余</td>
                <td>
                    <!--jiexiang.jieYu-->
                    <i-input v-model="jieyu" :maxlength="5" :disabled="isView" size="large" placeholder="万元"></i-input>
                </td>
            </tr>
            <tr class="tbe">
                <td>经费开支名称</td>
                <td>金额（万元）</td>
                <td colspan="4"> 开支说明</td>
            </tr>
            <tr class="tbe">
                <td>资料费</td>
                <td>
                    <i-input v-model="jxjingfeis.ziliaofei" :maxlength="5" :disabled="isView" size="large"></i-input>
                </td>
                <td colspan="4">
                    <i-input v-model="jxjingfeis.ziliaokaizhi" :maxlength="50" :disabled="isView" size="large"></i-input>
                </td>

            </tr>
            <tr class="tbe">
                <td>调研差旅费</td>
                <td>
                    <i-input v-model="jxjingfeis.diaoyanchailvfei" :maxlength="5" :disabled="isView" size="large"></i-input>
                </td>
                <td colspan="4">
                    <i-input v-model="jxjingfeis.diaoyanchailvkaizhi" :maxlength="50" :disabled="isView" size="large"></i-input>
                </td>

            </tr>
            <tr class="tbe">
                <td>材料费</td>
                <td>
                    <i-input v-model="jxjingfeis.cailiaofei" :maxlength="5" :disabled="isView" size="large"></i-input>
                </td>
                <td colspan="4">
                    <i-input v-model="jxjingfeis.cailiaokaizhi" :maxlength="50" :disabled="isView" size="large"></i-input>
                </td>

            </tr>
            <tr class="tbe">
                <td>制作费</td>
                <td>
                    <i-input v-model="jxjingfeis.zhizuofei" :maxlength="5" :disabled="isView" size="large"></i-input>
                </td>
                <td colspan="4">
                    <i-input v-model="jxjingfeis.zhizuokaizhi" :maxlength="50" :disabled="isView" size="large"></i-input>
                </td>


            </tr>
            <tr class="tbe">
                <td>软件开发费</td>
                <td>
                    <i-input v-model="jxjingfeis.ruanjiankaifafei" :maxlength="5" :disabled="isView" size="large"></i-input>
                </td>
                <td colspan="4">
                    <i-input v-model="jxjingfeis.ruanjiankaifakaizhi" :maxlength="50" :disabled="isView" size="large"></i-input>
                </td>

            </tr>
            <tr class="tbe">
                <td>咨询费</td>
                <td>
                    <i-input v-model="jxjingfeis.zixunfei" :maxlength="5" :disabled="isView" size="large"></i-input>
                </td>
                <td colspan="4">
                    <i-input v-model="jxjingfeis.zixunkaizhi" :maxlength="50" :disabled="isView" size="large"></i-input>
                </td>
            </tr>
            <tr class="tbe">
                <td>其他</td>
                <td>
                    <i-input v-model="jxjingfeis.qita" :maxlength="5" :disabled="isView" size="large"></i-input>
                </td>
                <td colspan="4">
                    <i-input v-model="jxjingfeis.qitakaizhi" :maxlength="50" :disabled="isView" size="large"></i-input>
                </td>
            </tr>
            <tr class="tbe">
                <td colspan="7">

                    <Form ref="jiexiang" :model="jiexiang">
                        <FormItem label="工作总结1" prop="zongJie1" style="width:1045px">
                            <i-input v-model="jiexiang.zongJie1"
                                     type="textarea"
                                     :rows="12"
                                     :maxlength="2000"
                                     :disabled="isView"
                                     placeholder="项目研究过程、尚需深入研究的问题等" />
                        </FormItem>
                        <FormItem label="工作总结2"
                                  prop="zongJie2"
                                  style="width:1045px">
                            <i-input v-model="jiexiang.zongJie2"
                                     type="textarea"
                                     :rows="12"
                                     :maxlength="2000"
                                     :disabled="isView"
                                     placeholder="研究成果的创新程度、突出特色" />
                        </FormItem>
                        <FormItem label="工作总结3" prop="zongJie3" style="width:1045px">
                            <i-input v-model="jiexiang.zongJie3"
                                     type="textarea"
                                     :rows="12"
                                     :maxlength="1000"
                                     :disabled="isView"
                                     placeholder="研究成果在公安工作及公安教育训练中的应用价值及社会效应等" />
                        </FormItem>
                    </Form>

                </td>
            </tr>

        </table>

        <i-button @click="save"
                  style="width:200px;margin-top:5px"
                  v-if="!isView"
                  type="primary">保存</i-button>
    </div>
</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    import JieXiangZuYuanList from './JieXiangZuYuanList.vue';
import { unwatchFile } from "fs";
    const qs = require('qs');
    export default {
        data() {
            return {
                isstu: false,
                lxid: null,
                jiexiang: [],
                jxzuyuans: [],
                jxjfs: [],
                jxjingfeis: {
                    ziliaofei: null,
                    ziliaokaizhi: null,

                    diaoyanchailvfei: null,
                    diaoyanchailvkaizhi: null,

                    cailiaofei: null,
                    cailiaokaizhi: null,

                    zhizuofei: null,
                    zhizuokaizhi: null,

                    ruanjiankaifafei: null,
                    ruanjiankaifakaizhi: null,

                    zixunfei: null,
                    zixunkaizhi: null,

                    qita: null,
                    qitakaizhi: null,
                },
                request_jfs: [],
                sjjf: 0,
                jieyu: 0,
            }
        },
        props: ['id', 'jxid', 'isView'],
        watch: {
            sjjf: {
                deep: true,
                handler(newName, oldName) {
                    this.jieyu = this.jiexiang.heZunJingFei - this.sjjf
                }
            }

        },
        mounted() {
            //console.log(this.jxid)
            if (this.id != null) {
                this.getjx();
                this.getjfs();
                this.getjxzys();
            }
            if (this.jxid != null) {
                this.getjiexiang();
            }
            this.sum();

        },
        computed: {

        },
        components: {
            JieXiangZuYuanList
        },
        methods: {
            getjx() {
                axios.get('api/JieXiang/GetJieXiang', {
                    params: {
                        id: this.id,
                    }
                })
                    .then(response => {
                        this.jiexiang = response.data.result
                        this.jiexiang.wanChengZhuangTai = this.jiexiang.wanChengZhuangTai + ''
                        //console.log(this.jiexiang)
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            getjfs() {
                axios.get('api/JieXiang/GetJieXiangJingFeis', {
                    params: {
                        id: this.id,
                    }
                })
                    .then(response => {
                        this.jxjfs = response.data.results;
                        this.jxjfs.forEach(x => {
                            if (x.jingFeiMingCheng == "资料费") {
                                this.jxjingfeis.ziliaofei = x.jinE;
                            } else if (x.jingFeiMingCheng == "调研差旅费") {
                                this.jxjingfeis.diaoyanchailvfei = x.jinE;
                            } else if (x.jingFeiMingCheng == "材料费") {
                                this.jxjingfeis.cailiaofei = x.jinE;
                            } else if (x.jingFeiMingCheng == "制作费") {
                                this.jxjingfeis.zhizuofei = x.jinE;
                            } else if (x.jingFeiMingCheng == "软件开发费") {
                                this.jxjingfeis.ruanjiankaifafei = x.jinE;
                            } else if (x.jingFeiMingCheng == "咨询费") {
                                this.jxjingfeis.zixunfei = x.jinE;
                            } else if (x.jingFeiMingCheng == "其他") {
                                this.jxjingfeis.qita = x.jinE;
                            }
                        })
                        //console.log(this.jxjingfeis)
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            getjxzys() {
                this.tableLoading = true;
                axios.get('api/JieXiang/GetJieXiangZuYuans', {
                    params: {
                        id: this.id,
                    }
                })
                    .then(response => {
                        this.jxzuyuans = response.data.results
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            getjiexiang() {
                axios.get('api/JieXiang/GetJieXiangById', {
                    params: {
                        id: this.jxid,
                    }
                })
                    .then(response => {
                        this.jiexiang = response.data.result;
                        this.jiexiang.wanChengZhuangTai = this.jiexiang.wanChengZhuangTai + '';
                        this.jxzuyuans = this.jiexiang.jieXiangZuYuans;
                        this.jiexiang.jieXiangJingFeis.forEach(x => {
                            if (x.jingFeiMingCheng == "资料费") {
                                this.jxjingfeis.ziliaofei = x.jinE;
                                this.jxjingfeis.ziliaokaizhi = x.kaiZhiShuoMing;
                            } else if (x.jingFeiMingCheng == "调研差旅费") {
                                this.jxjingfeis.diaoyanchailvfei = x.jinE;
                                this.jxjingfeis.diaoyanchailvkaizhi = x.kaiZhiShuoMing;
                            } else if (x.jingFeiMingCheng == "材料费") {
                                this.jxjingfeis.cailiaofei = x.jinE;
                                this.jxjingfeis.cailiaokaizhi = x.kaiZhiShuoMing;
                            } else if (x.jingFeiMingCheng == "制作费") {
                                this.jxjingfeis.zhizuofei = x.jinE;
                                this.jxjingfeis.zhizuokaizhi = x.kaiZhiShuoMing;
                            } else if (x.jingFeiMingCheng == "软件开发费") {
                                this.jxjingfeis.ruanjiankaifafei = x.jinE;
                                this.jxjingfeis.ruanjiankaifakaizhi = x.kaiZhiShuoMing;
                            } else if (x.jingFeiMingCheng == "咨询费") {
                                this.jxjingfeis.zixunfei = x.jinE;
                                this.jxjingfeis.zixunkaizhi = x.kaiZhiShuoMing;
                            } else if (x.jingFeiMingCheng == "其他") {
                                this.jxjingfeis.qita = x.jinE;
                                this.jxjingfeis.qitakaizhi = x.kaiZhiShuoMing;
                            }
                        })
                        this.sjjf = this.jiexiang.shiJiJingFei;
                        this.jieyu = this.jiexiang.jieyu;
                        // console.log(this.jiexiang)
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            save() {
                var arr = [
                    {
                        name: '资料费',
                        jine: this.jxjingfeis.ziliaofei,
                        kaizhi: this.jxjingfeis.ziliaokaizhi,
                    },
                    {
                        name: '调研差旅费',
                        jine: this.jxjingfeis.diaoyanchailvfei,
                        kaizhi: this.jxjingfeis.diaoyanchailvkaizhi,
                    },
                    {
                        name: '材料费',
                        jine: this.jxjingfeis.cailiaofei,
                        kaizhi: this.jxjingfeis.cailiaokaizhi,
                    },
                    {
                        name: '制作费',
                        jine: this.jxjingfeis.zhizuofei,
                        kaizhi: this.jxjingfeis.zhizuokaizhi,
                    },
                    {
                        name: '软件开发费',
                        jine: this.jxjingfeis.ruanjiankaifafei,
                        kaizhi: this.jxjingfeis.ruanjiankaifakaizhi,
                    },
                    {
                        name: '咨询费',
                        jine: this.jxjingfeis.zixunfei,
                        kaizhi: this.jxjingfeis.zixunkaizhi,
                    },
                    {
                        name: '其他',
                        jine: this.jxjingfeis.qita,
                        kaizhi: this.jxjingfeis.qitakaizhi,
                    }
                ];
                console.log(this.request_jfs);
                this.request_jfs = [];
                arr.forEach(x => {
                    if (x.jine != null) {
                        this.request_jfs.push(x)
                    }
                });
                console.log(this.request_jfs);
                if (this.id != null) {
                    this.jiexiang.liXiangId = this.id;
                }
                var request_bag = {
                    JieXiang: this.jiexiang,
                    jiexiangzuyuans: this.jxzuyuans,
                    jxJingFeis: this.request_jfs
                };
                // this.xiangmu.xiangMuMingCheng == undefined || this.xiangmu.xiangMuMingCheng == null

                if (this.jiexiang.fuZeRenMingCheng == null || this.jiexiang.fuZeRenMingCheng == undefined || this.jiexiang.fuZeRenMingCheng.length == 0) {
                    this.$Message.error('负责人不能为空');
                } else if (this.jiexiang.buMenMingCheng == null || this.jiexiang.buMenMingCheng == undefined || this.jiexiang.buMenMingCheng.length == 0) {
                    this.$Message.error('请填写部门名称');
                } else if (this.jiexiang.zhiWuMingCheng == null || this.jiexiang.zhiWuMingCheng == undefined || this.jiexiang.zhiWuMingCheng.length == 0) {
                    this.$Message.error('请填写职务职称');
                } else if (this.jiexiang.zuiZhongChengGuoZiShu == null || this.jiexiang.zuiZhongChengGuoZiShu == undefined || this.jiexiang.zuiZhongChengGuoZiShu.length==0) {
                    this.$Message.error('请输入最终成果字数');
                } else if (this.jiexiang.faBiaoChuBan == null || this.jiexiang.faBiaoChuBan == undefined || this.jiexiang.faBiaoChuBan.length==0) {
                    this.$Message.error('最终成果发表、出版时间和单位不能为空');
                } else if (this.sjjf==0) {
                    this.$Message.error('实际经费不能为0');
                } else {
                    this.jiexiang.shiJiJingFei = this.sjjf;
                    this.jiexiang.jieYu = this.jieyu;
                    axios.post('api/JieXiang/SaveJieXiang', qs.stringify({
                        "entity": request_bag
                    })).then(response => {
                        if (!response.data.error) {
                            this.$Message.success('保存成功!');
                            this.$router.push('JieXianglist');
                            this.$emit('close')
                            //this.$router.push({ name: 'xiangmulistgeren' })
                        } else {
                            this.$Message.error('保存失败!');
                        }
                    });
                }
            },
            sum() {

            }
        }
    };
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

    /deep/ .ivu-input[disabled] {
        background: rgb(255, 255, 255);
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
    /*table, td {
        rgba(220,220,226,1)
        border: 1px solid rgba(220,220,226,1);
        height: 40px;
    }*/

</style>