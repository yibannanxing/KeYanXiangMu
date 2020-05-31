<template>
    <div style="padding:10px">

        <i-form :model="jiaocai" :label-width="120" label-position="right" :rules="ruleValidate">
            <div>
                <Row>
                    <i-col span="4">
                        <Form-item label="姓名：" prop="userName">
                            {{jilu.userName==null?username:jilu.userName}}
                        </Form-item>
                    </i-col>
                    <i-col span="5">
                        <Form-item label="专技职务：" prop="zhuanJiZhiWu">
                            <i-select v-model="jilu.zhuanJiZhiWu" :disabled="isview" placeholder="请选择">
                                <i-option value="0">教授</i-option>
                                <i-option value="1">副教授</i-option>
                                <i-option value="2">讲师</i-option>
                                <i-option value="3">助教</i-option>
                                <i-option value="4">研究员</i-option>
                                <i-option value="5">副研究员</i-option>
                                <i-option value="6">助理研究员</i-option>
                                <i-option value="7">研究实习员</i-option>
                                <i-option value="8">其他正高</i-option>
                                <i-option value="9">其他副高</i-option>
                                <i-option value="10">其他中级</i-option>
                                <i-option value="11">其他初级</i-option>
                                <i-option value="12">无</i-option>
                            </i-select>
                        </Form-item>
                    </i-col>
                    <i-col span="5">
                        <Form-item label="教官职务：" prop="jiaoGuanZhiWu">
                            <i-select v-model="jilu.jiaoGuanZhiWu" :disabled="isview" placeholder="请选择">
                                <i-option value="0">特级教官</i-option>
                                <i-option value="1">高级教官</i-option>
                                <i-option value="2">中级教官</i-option>
                                <i-option value="3">初级教官</i-option>
                                <i-option value="4">无</i-option>
                            </i-select>
                        </Form-item>

                    </i-col>
                </Row>
            </div>
            <Form-item label="项目所属年度：" prop="suoShuNianDu">
                <i-input v-model="jiaocai.suoShuNianDu"
                         :maxlength="4"
                         :disabled="isview"
                         placeholder="请填写数字年份,例:2019"></i-input>
            </Form-item>

            <Form-item label="教材名称：" prop="jiaoCaiMingCheng">
                <i-input v-model="jiaocai.jiaoCaiMingCheng"
                         :maxlength="50"
                         :disabled="isview"
                         placeholder="请填写教材名称"></i-input>
            </Form-item>

            <Form-item label="ISBN：" prop="isbn">
                <i-input v-model="jiaocai.isbn"
                         :maxlength="50"
                         :disabled="isview"
                         placeholder="请填写ISBN"></i-input>
            </Form-item>

            <Form-item label="出版社：" prop="chuBanShe">
                <i-input v-model="jiaocai.chuBanShe"
                         :maxlength="50"
                         :disabled="isview"
                         placeholder="请填写出版社"></i-input>
            </Form-item>

            <Row>
                <i-col span="7">
                    <Form-item label="出版社级别：" prop="chuBanSheJiBie">
                        <i-select v-model="jiaocai.chuBanSheJiBie" :disabled="isview" placeholder="请选择" style="width:200px">
                            <i-option value="0">国家级</i-option>
                            <i-option value="1">省部级</i-option>

                        </i-select>
                    </Form-item>
                </i-col>
                <i-col span="5">
                    <Form-item label="出版时间：" prop="chuBanShiJian">
                        <Date-picker type="date" :disabled="isview" placeholder="选择日期" v-model="jiaocai.chuBanShiJian"></Date-picker>
                    </Form-item>
                </i-col>
            </Row>

            <Row>
                <i-col span="7">
                    <Form-item label="参编情况：" prop="canBianQingKuang">
                        <i-select v-model="jiaocai.canBianQingKuang" :disabled="isview" placeholder="请选择" style="width:200px">
                            <i-option value="0">主编</i-option>
                            <i-option value="1">副主编</i-option>
                            <i-option value="2">供稿人</i-option>
                        </i-select>
                    </Form-item>
                </i-col>
                <i-col span="6">
                    <Form-item label="是否标注上海公安学院：" prop="isBiaoZhuXueYuan">
                        <i-select v-model="jiaocai.isBiaoZhuXueYuan" :disabled="isview" placeholder="请选择" style="width:200px">
                            <i-option value="0">是</i-option>
                            <i-option value="1">否</i-option>
                        </i-select>
                    </Form-item>
                </i-col>
            </Row>

            <Row>
                <i-col span="6">
                    <Form-item label="全书字数：" prop="quanShuZiShu">
                        <i-input v-model="jiaocai.quanShuZiShu"
                                 :maxlength="20"
                                 :disabled="isview"
                                 placeholder="请填写全书字数"></i-input>
                    </Form-item>
                </i-col>
                <i-col span="6">
                    <Form-item label="参编章节：" prop="canBianZhangJie">
                        <i-input v-model="jiaocai.canBianZhangJie"
                                 :maxlength="20"
                                 :disabled="isview"
                                 placeholder="请填写参编章节"></i-input>
                    </Form-item>
                </i-col>
                <i-col span="6">
                    <Form-item label="参编字数：" prop="canBianZiShu">
                        <i-input v-model="jiaocai.canBianZiShu"
                                 :maxlength="20"
                                 :disabled="isview"
                                 placeholder="请填写参编字数"></i-input>
                    </Form-item>
                </i-col>
            </Row>

            <Form-item label="教材获奖级别：" prop="JiaoCaiHuoJiangJiBie">
                <i-select v-model="jiaocai.jiaoCaiHuoJiangJiBie" :disabled="isview" placeholder="请选择" style="width:200px">
                    <i-option value="0">国家级（一等奖）</i-option>
                    <i-option value="1">国家级（二等奖）</i-option>
                    <i-option value="2">国家级（三等奖）</i-option>
                    <i-option value="3">国家级（优秀奖）</i-option>
                    <i-option value="4">省（部）级（一等奖）</i-option>
                    <i-option value="5">省（部）级（二等奖）</i-option>
                    <i-option value="6">省（部）级（三等奖）</i-option>
                    <i-option value="7">省（部）级（优秀奖）</i-option>
                    <i-option value="8">局级（一等奖）</i-option>
                    <i-option value="9">局级（二等奖）</i-option>
                    <i-option value="10">局级（三等奖）</i-option>
                    <i-option value="11">局级（优秀奖）</i-option>
                    <i-option value="12">院级（一等奖）</i-option>
                    <i-option value="13">院级（二等奖）</i-option>
                    <i-option value="14">院级（三等奖）</i-option>
                    <i-option value="15">院级（优秀奖）</i-option>
                </i-select>
            </Form-item>

            <Form-item label="教材获奖称号：" prop="HuoJiangMingCheng">
                <i-input v-model="jiaocai.huoJiangMingCheng"
                         :maxlength="50"
                         :disabled="isview"
                         placeholder="请填写教材获奖称号"></i-input>
            </Form-item>

            <Form-item label="教材获奖时间：" prop="JiaoCaiHuoJiangShiJian">
                <Date-picker type="date" placeholder="选择日期" :disabled="isview" v-model="jiaocai.jiaoCaiHuoJiangShiJian"></Date-picker>
            </Form-item>

            <div v-if="!issee&&!isshenhe&&!iswanjie">
                <Divider>佐证材料如果超过5张，请当做其他附件上传</Divider>
                <Form-item label="封面" prop="fengmianList">
                    <UploadCtrl :type="0"
                                v-model="fengmianList"
                                :filelimit="5"
                                :disabled="isview"
                                :maxSize="10240"></UploadCtrl>
                </Form-item>
                <Form-item label="目录" prop="fileList">
                    <UploadCtrl :type="0"
                                v-model="fileList"
                                :filelimit="5"
                                :disabled="isview"
                                :maxSize="10240"></UploadCtrl>
                </Form-item>

                <Form-item label="版权页" prop="banquanlist">
                    <UploadCtrl :type="0"
                                v-model="banquanlist"
                                :filelimit="5"
                                :disabled="isview"
                                :maxSize="10240"></UploadCtrl>
                </Form-item>

                <Form-item label="教材页面" prop="articleList">
                    <UploadCtrl :type="0"
                                v-model="articleList"
                                :filelimit="5"
                                :disabled="isview"
                                :maxSize="10240"></UploadCtrl>
                </Form-item>
                <Form-item label="其他附件" prop="wenjianList">
                    <UploadCtrl :type="1"
                                v-model="wenjianList"
                                :filelimit="10"
                                :disabled="isview"
                                :maxSize="10240"></UploadCtrl>
                </Form-item>
            </div>

            <div v-if="issee&&isshenhe">
                <Form-item label="附件:">

                    <div v-for="(item,index) in jiaocai.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==0">封面</span>
                        <img v-if="item.wenJianLeiXing==0"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in jiaocai.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==1">目录</span>
                        <img v-if="item.wenJianLeiXing==1"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in jiaocai.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==2">教材页面</span>
                        <img v-if="item.wenJianLeiXing==2"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in jiaocai.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==4">版权页</span>
                        <img v-if="item.wenJianLeiXing==4"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in jiaocai.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==3">文件附件</span>
                        <a v-if="item.wenJianLeiXing==3"
                           :href="item.luJing" target="_blank">{{item.wenJianMingCheng}}</a>
                    </div>



                </Form-item>
            </div>
            <div v-if="isshenhe&&shlx==3">
                <Form-item label="成果分值：" prop="KeYanKaoHeDeFen">
                    <i-input v-model="jiaocai.keYanKaoHeDeFen"
                             :maxlength="20"
                             :disabled="isview"></i-input>
                </Form-item>
                <span style="color:red;">
                    成果分值: {{getdefen()}}(参编分)
                </span>


            </div>

            <Form-item>
                <i-button v-if="!isview" type="primary" @click="save(1)">提交</i-button>
                <i-button v-if="this.jiaocai.status==0||!this.jiaocai.status" type="primary" @click="save(0)">暂存</i-button>
            </Form-item>

            <table style="width:100%;">
                <tr>
                    <td v-if="issee" style="vertical-align:top;width:60%;text-align:center">
                        <div v-if="isshenhe">
                            <div v-if="shlx==3">
                                <Form-item label="科研处审核分：" prop="ShenHeJiaKouFen">
                                    <i-input v-model="jiaocai.shenHeJiaKouFen"
                                             :maxlength="20"
                                             :disabled="!iswanjie"
                                             placeholder="请填写审核分"></i-input>
                                </Form-item>
                                <Form-item label="科研处审核分说明：" prop="JiaKouFenShuoMing">
                                    <i-input v-model="jiaocai.jiaKouFenShuoMing"
                                             :maxlength="50"
                                             :disabled="!iswanjie"
                                             type="textarea"
                                             placeholder="请填写审核分说明"></i-input>
                                </Form-item>
                                <!--<Form-item label="科研处审核得分：" prop="ShenHeDeFen">
                                    <i-input v-model="jiaocai.shenHeDeFen"
                                             :disabled="!iswanjie"
                                             :maxlength="20"
                                             placeholder="请填写审核得分"></i-input>
                                </Form-item>-->
                                <!--<Form-item label="考核得分：" prop="ShiJiDeFen">
                                    <i-input v-model="jiaocai.shiJiDeFen"
                                             :maxlength="10"
                                             :disabled="!iswanjie"
                                             placeholder="请填写考核得分"></i-input>
                                </Form-item>-->
                            </div>
                            <div v-if="iswanjie">
                                <Form-item label="审核（退回）意见：" prop="ShenHeYiJian">
                                    <i-input v-model="sh.shenHeYiJian"
                                             :maxlength="100"
                                             type="textarea"
                                             placeholder="请填写审核(退回)意见"></i-input>
                                </Form-item>

                                <Form-item>
                                    <i-button type="primary" @click="shenhe" style="margin-right:5px;">审核</i-button>
                                    <i-button type="error" @click="tuihui">退回</i-button>
                                </Form-item>
                            </div>
                        </div>
                    </td>
                    <td style="vertical-align:top;width:40%;"><shenhe :id="id"></shenhe></td>
                </tr>
            </table>

        </i-form>



    </div>

</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    import UploadCtrl from '../components/UploadCtrl.vue';
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
                ruleValidate: {
                    jiaoCaiMingCheng: [
                        { required: true, message: '教材名称不能为空', trigger: 'blur' }
                    ],
                    suoShuNianDu: [
                        { required: true, message: '所属年度不能为空', trigger: 'blur' }
                    ],
                    isbn: [
                        { required: true, message: 'isbn不能为空', trigger: 'blur' }
                    ],
                    chuBanShe: [
                        { required: true, message: '出版社不能为空', trigger: 'blur' }
                    ],
                    chuBanSheJiBie: [
                        { required: true, message: '请选择级别', trigger: 'change' }
                    ],
                    chuBanShiJian: [
                        { required: true, type: 'date', message: '请选择日期', trigger: 'change' }
                    ],
                    canBianQingKuang: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                    isBiaoZhuXueYuan: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                    quanShuZiShu: [
                        { required: true, message: '请输入全书字数', trigger: 'blur' }
                    ],
                    canBianZhangJie: [
                        { required: true, message: '请输入参编章节', trigger: 'blur' }
                    ],
                    canBianZiShu: [
                        { required: true, message: '请输入参编字数', trigger: 'blur' }
                    ],
                    fengmianList: [
                        { required: true, message: '请上传', trigger: 'blur' }
                    ],
                    fileList: [
                        { required: true, message: '请上传', trigger: 'blur' }
                    ],
                    banquanlist: [
                        { required: true, message: '请上传', trigger: 'blur' }
                    ],
                },
            }
        },
        props: ['id', 'isview', 'isshenhe', 'istuihui', 'shlx', 'issee', 'iswanjie'],
        watch: {
            jiaocai: {
                deep: true,
                handler(newName, oldName) {
                    this.jiaocai.keYanKaoHeDeFen = this.getdefen();
                    this.jiaocai.shenHeDeFen = this.jiaocai.keYanKaoHeDeFen + this.getjiakoufen();
                },
            }
        },
        mounted() {
            //console.log(this.id, this.isview)
            if (this.id != null) {
                this.getjiaocai();
                this.getjilu();
            }
            this.getuser();

        },
        computed: {},
        components: {
            UploadCtrl,
            shenhe
        },
        methods: {
            getjiaocai() {
                axios.get('api/Cg_JiaoCai/GetJiaoCaiById', {
                    params: {
                        id: this.id,
                    }
                })
                    .then(response => {
                        this.jiaocai = response.data.result;
                        this.jiaocai.chuBanSheJiBie = this.jiaocai.chuBanSheJiBie + '';
                        this.jiaocai.canBianQingKuang = this.jiaocai.canBianQingKuang + '';
                        this.jiaocai.isBiaoZhuXueYuan = this.jiaocai.isBiaoZhuXueYuan + '';
                        this.jiaocai.jiaoCaiHuoJiangJiBie = this.jiaocai.jiaoCaiHuoJiangJiBie + '';
                        //附件
                        this.jiaocai.fuJians.forEach(x => {
                            if (x.wenJianLeiXing == 0) {
                                this.fengmianList.push(x);
                            } else if (x.wenJianLeiXing == 1) {
                                this.fileList.push(x);
                            } else if (x.wenJianLeiXing == 2) {
                                this.articleList.push(x);
                            } else if (x.wenJianLeiXing == 3) {
                                this.wenjianList.push(x);
                            } else if (x.wenJianLeiXing == 4) {
                                this.banquanlist.push(x);
                            }
                        })


                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });

            },
            save(num) {
                if (this.jilu.zhuanJiZhiWu == undefined || this.jilu.zhuanJiZhiWu == null) {
                    this.jilu.zhuanJiZhiWu = -1;
                }
                if (this.jilu.jiaoGuanZhiWu == undefined || this.jilu.jiaoGuanZhiWu == null) {
                    this.jilu.jiaoGuanZhiWu = -1;
                }
                axios.post('api/Cg_JiaoCai/SaveCgJiaoCai', qs.stringify({
                    "entity": this.getbag(num),
                    status: num,
                })).then(response => {
                    if (!response.data.error) {
                        this.$Message.success('保存成功!');
                        location.reload()
                        this.$router.push('CG_MyList');
                        this.$emit('close')
                        //this.$router.push({ name: 'xiangmulistgeren' })
                    } else {
                        this.$Message.error('保存失败!');
                    }
                });
            },
            getbag(num) {
                var request_bag = {
                    cgJiaoCai: this.jiaocai,
                    fengmianList: this.fengmianList,
                    fileList: this.fileList,
                    articleList: this.articleList,
                    wenjianList: this.wenjianList,
                    banquanlist: this.banquanlist,
                    jilu: this.jilu
                };
                if (num == 0) {
                    return request_bag;
                } else {
                    if (this.jiaocai.jiaoCaiMingCheng == null || this.jiaocai.jiaoCaiMingCheng == undefined || this.jiaocai.jiaoCaiMingCheng.length == 0) {
                        this.$Message.error('教材名称不能为空');
                    } else if (this.jiaocai.suoShuNianDu == null || this.jiaocai.suoShuNianDu == undefined || this.jiaocai.isbn.suoShuNianDu == 0) {
                        this.$Message.error('所属年度不能为空');
                    }else if (this.jiaocai.isbn == null || this.jiaocai.isbn == undefined || this.jiaocai.isbn.length == 0) {
                        this.$Message.error('ISBN不能为空');
                    } else if (this.jiaocai.chuBanShe == null || this.jiaocai.chuBanShe == undefined || this.jiaocai.chuBanShe.length == 0) {
                        this.$Message.error('出版社不能为空');
                    } else if (this.jiaocai.chuBanSheJiBie == null || this.jiaocai.chuBanSheJiBie == undefined) {
                        this.$Message.error('请选择出版社级别');
                    } else if (this.jiaocai.chuBanShiJian == null || this.jiaocai.chuBanShiJian == undefined) {
                        this.$Message.error('请选择出版时间');
                    } else if (this.jiaocai.canBianQingKuang == null || this.jiaocai.canBianQingKuang == undefined) {
                        this.$Message.error('请选择参编情况');
                    } else if (this.jiaocai.isBiaoZhuXueYuan == null || this.jiaocai.isBiaoZhuXueYuan == undefined) {
                        this.$Message.error('请选择是否标注上海公安学校');
                    } else if (this.jiaocai.quanShuZiShu == null || this.jiaocai.quanShuZiShu == undefined || this.jiaocai.quanShuZiShu.length == 0) {
                        this.$Message.error('请输入全书字数');
                    } else if (this.jiaocai.canBianZhangJie == null || this.jiaocai.canBianZhangJie == undefined || this.jiaocai.canBianZhangJie.length == 0) {
                        this.$Message.error('请输入参编章节');
                    } else if (this.jiaocai.canBianZiShu == null || this.jiaocai.canBianZiShu == undefined || this.jiaocai.canBianZiShu.length == 0) {
                        this.$Message.error('请输入参编字数');
                    } else if (this.fengmianList.length == 0) {
                        this.$Message.error('请上传附件');
                    } else if (this.fileList.length == 0) {
                        this.$Message.error('请上传附件');
                    } else if (this.banquanlist.length == 0) {
                        this.$Message.error('请上传附件');
                    } else {
                        return request_bag;
                    }
                }
            },
            getdefen() {
                var num = 0;
                if (this.jiaocai.canBianQingKuang != null || this.jiaocai.canBianQingKuang != undefined) {
                    if (this.jiaocai.canBianQingKuang == 0) {
                        num += 100;
                    } else if (this.jiaocai.canBianQingKuang == 1) {
                        num += 50;
                    }
                }
                return num;
            },
            shenhe() {
                var request_bag = {
                    cgJiaoCai: this.jiaocai,
                    CgShenHe: this.sh,
                };

                if (this.sh.shenHeYiJian == null || this.sh.shenHeYiJian == undefined || this.sh.shenHeYiJian.length == 0) {
                    this.sh.shenHeYiJian = "已通过";
                    //this.$Message.error('请填写意见!');
                }
                axios.post('api/Cg_ShenHe/shenhe', qs.stringify({
                    "entity": request_bag,
                    status: this.shlx
                })).then(response => {
                    if (!response.data.error) {
                        this.$Message.success('审核成功!');
                        //  this.$router.push('bumenshenhe');
                        this.$emit('close')
                        //this.$router.push({ name: 'xiangmulistgeren' })
                    } else {
                        this.$Message.error('审核失败!');
                    }
                });

            },
            tuihui() {
                var request_bag = {
                    cgJiaoCai: this.jiaocai,
                    CgShenHe: this.sh,
                };
                if (this.sh.shenHeYiJian == null || this.sh.shenHeYiJian == undefined || this.sh.shenHeYiJian.length == 0) {
                    //this.sh.shenHeYiJian = "已退回";
                    this.$Message.error('请填写意见!');
                } else {
                    axios.post('api/Cg_ShenHe/tuihui', qs.stringify({
                        "entity": request_bag,
                        status: this.shlx
                    })).then(response => {
                        if (!response.data.error) {
                            this.$Message.success('退回成功!');
                            //this.$router.push('bumenshenhe');
                            this.$emit('close')
                            //this.$router.push({ name: 'xiangmulistgeren' })
                        } else {
                            this.$Message.error('退回失败!');
                        }
                    });
                }
            },
            getjiakoufen() {
                var num = 0;
                if (this.jiaocai.shenHeJiaKouFen != null || this.jiaocai.shenHeJiaKouFen != undefined) {
                    num = parseInt(this.jiaocai.shenHeJiaKouFen);
                }
                return num;
            },
            getjilu() {
                axios.get('api/Cg_JiLu/GetJiLuByid', {
                    params: {
                        id: this.id,
                    }
                })
                    .then(response => {
                        this.jilu = response.data.result;
                        this.jilu.zhuanJiZhiWu = this.jilu.zhuanJiZhiWu + '';
                        this.jilu.jiaoGuanZhiWu = this.jilu.jiaoGuanZhiWu + '';

                    }).catch(error => {
                        console.log(error);

                    });

            },
            getuser() {
                axios.get('api/Cg_ShenHe/GetUserName', {
                    params: {

                    }
                })
                    .then(response => {
                        this.username = response.data;
                        // console.log(this.username)
                    }).catch(error => {
                        console.log(error);

                    });
            }
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