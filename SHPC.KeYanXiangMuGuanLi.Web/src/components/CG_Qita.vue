<template>
    <div style="padding:10px">
        <i-form :model="qita" :label-width="150" label-position="right" :rules="ruleValidate">
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
                <i-input v-model="qita.suoShuNianDu"
                         :maxlength="4"
                         :disabled="isview"
                         placeholder="请填写数字年份,例:2019"></i-input>
            </Form-item>
            <Form-item label="名称：" prop="mingCheng">
                <i-input v-model="qita.mingCheng"
                         :maxlength="50"
                         :disabled="isview"
                         placeholder="请填写名称"></i-input>
            </Form-item>

            <Form-item label="成果年度：" prop="chengGuoNianDu">
                <i-input v-model="qita.chengGuoNianDu"
                         :maxlength="50"
                         :disabled="isview"
                         placeholder="请填写成果年度"></i-input>
            </Form-item>

            <Form-item label="科研成果简介：" prop="keYanChengGuoJianJie">
                <i-input v-model="qita.keYanChengGuoJianJie"
                         :maxlength="100"
                         :disabled="isview"
                         placeholder="请填写科研成果简介"></i-input>
            </Form-item>

            <div>
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
                <Form-item label="文章页面" prop="articleList">
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
                    <div v-for="(item,index) in qita.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==0">封面</span>
                        <span v-if="item.wenJianLeiXing==1">目录</span>
                        <span v-if="item.wenJianLeiXing==2">文章页面</span>
                        <span v-if="item.wenJianLeiXing==3">文件附件</span>
                        <img v-if="item.wenJianLeiXing==0||item.wenJianLeiXing==1||item.wenJianLeiXing==2"
                             :src="item.luJing"
                             style="width:100%;" />
                        <a v-if="item.wenJianLeiXing!=0&&item.wenJianLeiXing!=1&&item.wenJianLeiXing!=2"
                           :href="item.luJing" target="_blank">{{item.wenJianMingCheng}}</a>
                    </div>

                </Form-item>
            </div>

            <div v-if="isshenhe&&shlx==3">
                <Form-item label="成果分值：" prop="KeYanKaoHeDeFen">
                    <i-input v-model="qita.keYanKaoHeDeFen"
                             :maxlength="10"
                             :disabled="isview"></i-input>
                </Form-item>
            </div>

            <Form-item>
                <i-button v-if="!isview" type="primary" @click="save(1)">提交</i-button>
                <i-button v-if="this.qita.status==0||!this.qita.status" type="primary" @click="save(0)">暂存</i-button>
            </Form-item>

            <table style="width:100%;">
                <tr>
                    <td v-if="issee" style="vertical-align:top;width:60%;text-align:center">
                        <div v-if="isshenhe">
                            <div v-if="shlx==3">
                                <Form-item label="科研处审核分：" prop="ShenHeJiaKouFen">
                                    <i-input v-model="qita.shenHeJiaKouFen"
                                             :maxlength="20"
                                             :disabled="!iswanjie"
                                             placeholder="请填写审核分"></i-input>
                                </Form-item>
                                <Form-item label="科研处审核分说明：" prop="JiaKouFenShuoMing">
                                    <i-input v-model="qita.jiaKouFenShuoMing"
                                             :maxlength="50"
                                             :disabled="!iswanjie"
                                             type="textarea"
                                             placeholder="请填写审核分说明"></i-input>
                                </Form-item>
                                <!--<Form-item label="科研处审核得分：" prop="ShenHeDeFen">
                                    <i-input v-model="qita.shenHeDeFen"
                                             :disabled="!iswanjie"
                                             :maxlength="20"
                                             placeholder="请填写审核得分"></i-input>
                                </Form-item>
                                <Form-item label="考核得分：" prop="ShiJiDeFen">
                                    <i-input v-model="qita.shiJiDeFen"
                                             :maxlength="10"
                                             :disabled="!iswanjie"
                                             placeholder="请填写考核得分"></i-input>
                                </Form-item>-->
                            </div>

                            <div v-if="iswanjie">
                                <Form-item label="审核(退回)意见：" prop="ShenHeYiJian">
                                    <i-input v-model="sh.shenHeYiJian"
                                             :maxlength="100"
                                             type="textarea"
                                             placeholder="请填写审核（退回）意见"></i-input>
                                </Form-item>

                                <Form-item>
                                    <i-button type="primary" @click="shenhe" style="margin-right:5px">审核</i-button>
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
                qita: {},
                fengmianList: [],
                fileList: [],
                articleList: [],
                wenjianList: [],
                ruleValidate: {
                    mingCheng: [
                        { required: true, message: '名称不能为空', trigger: 'blur' }
                    ],
                    suoShuNianDu: [
                        { required: true, message: '所属年度不能为空', trigger: 'blur' }
                    ],
                    chengGuoNianDu: [
                        { required: true, message: '成果年度不能为空', trigger: 'blur' }
                    ],
                    keYanChengGuoJianJie: [
                        { required: true, message: '科研成果简介不能为空', trigger: 'blur' }
                    ],
                    fengmianList: [
                        { required: true, message: '请上传', trigger: 'blur' }
                    ],
                    fileList: [
                        { required: true, message: '请上传', trigger: 'blur' }
                    ],
                },
            }
        },
        props: ['id', 'isview', 'isshenhe', 'istuihui', 'shlx', 'issee', 'iswanjie'],
        watch: {
            //qita: {
            //    deep: true,
            //    handler(newName, oldName) {
            //       // this.kyxm.keYanKaoHeDeFen = this.getdefen() + this.gethuojiangfen() + this.getcainafen();
            //        this.qita.shenHeDeFen = this.qita.keYanKaoHeDeFen + this.getjiakoufen();
            //    },
            //}
        },
        mounted() {
            //console.log(this.id, this.isview)
            if (this.id != null) {
                this.getqita();
                this.getjilu();
            }
            this.getuser();

        },
        computed: {},
        components: {
            UploadCtrl, shenhe
        },
        methods: {
            getqita() {
                axios.get('api/Cg_Qita/GetCgQitaById', {
                    params: {
                        id: this.id,
                    }
                })
                    .then(response => {
                        this.qita = response.data.result;

                        //附件
                        this.qita.fuJians.forEach(x => {
                            if (x.wenJianLeiXing == 0) {
                                this.fengmianList.push(x);
                            } else if (x.wenJianLeiXing == 1) {
                                this.fileList.push(x);
                            } else if (x.wenJianLeiXing == 2) {
                                this.articleList.push(x);
                            } else {
                                this.wenjianList.push(x);
                            }
                        })
                        // console.log(this.qita)
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

                axios.post('api/Cg_Qita/SaveCgQita', qs.stringify({
                    "entity": this.getbag(num),
                    status: num,
                })).then(response => {
                    if (!response.data.error) {
                        this.$Message.success('保存成功!');
                        //window.close();
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
                    cgQiTa: this.qita,
                    fengmianList: this.fengmianList,
                    fileList: this.fileList,
                    articleList: this.articleList,
                    wenjianList: this.wenjianList,
                    jilu: this.jilu
                };
                if (num == 0) {
                    return request_bag;
                } else {
                    if (this.qita.mingCheng == null || this.qita.mingCheng == undefined || this.qita.mingCheng.length == 0) {
                        this.$Message.error('名称不能为空');
                    }
                    else if (this.qita.suoShuNianDu == null || this.qita.suoShuNianDu == undefined || this.qita.suoShuNianDu.length == 0) {
                        this.$Message.error('所属年度不能为空');
                    } else if (this.qita.chengGuoNianDu == null || this.qita.chengGuoNianDu == undefined || this.qita.chengGuoNianDu.length == 0) {
                        this.$Message.error('成果年度不能为空');
                    } else if (this.qita.keYanChengGuoJianJie == null || this.qita.keYanChengGuoJianJie == undefined || this.qita.keYanChengGuoJianJie.length == 0) {
                        this.$Message.error('成果简介不能为空');
                    } else if (this.fengmianList.length == 0) {
                        this.$Message.error('请上传附件');
                    } else if (this.fileList.length == 0) {
                        this.$Message.error('请上传附件');
                    } else {
                        return request_bag;
                    }
                }
            },
            getjiakoufen() {
                var num = 0;
                if (this.qita.shenHeJiaKouFen != null || this.qita.shenHeJiaKouFen != undefined) {
                    num = parseInt(this.qita.shenHeJiaKouFen);
                }
                return num;
            },
            shenhe() {
                var request_bag = {
                    cgQiTa: this.qita,
                    CgShenHe: this.sh,
                };
                if (this.sh.shenHeYiJian == null || this.sh.shenHeYiJian == undefined || this.sh.shenHeYiJian.length == 0) {
                    // this.$Message.error('请填写意见!');
                    this.sh.shenHeYiJian = "已通过";
                }
                axios.post('api/Cg_ShenHe/shenhe', qs.stringify({
                    "entity": request_bag,
                    status: this.shlx
                })).then(response => {
                    if (!response.data.error) {
                        this.$Message.success('审核成功!');
                        //this.$router.push('bumenshenhe');
                        this.$emit('close')
                        //this.$router.push({ name: 'xiangmulistgeren' })
                    } else {
                        this.$Message.error('审核失败!');
                    }
                });

            },
            tuihui() {
                var request_bag = {
                    cgQiTa: this.qita,
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
                        //console.log(this.username)
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
    /*/deep/ .ivu-form .ivu-input {
        background-color: #ffffff;
        color: #b1b1b1;
    }

    /deep/ .ivu-select-selected-value {
        background-color: #ffffff;
        color: #b1b1b1;
    }*/
</style>