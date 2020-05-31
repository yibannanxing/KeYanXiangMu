<template>
    <div style="padding:10px">
        <i-form :model="zuzuo" :label-width="120" label-position="right" :rules="ruleValidate">

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
                <i-input v-model="zuzuo.suoShuNianDu"
                         :maxlength="4"
                         :disabled="isview"
                         placeholder="请填写数字年份,例:2019"></i-input>
            </Form-item>

            <Form-item label="著作名称：" prop="zuZuoMingCheng">
                <i-input v-model="zuzuo.zuZuoMingCheng"
                         :maxlength="50"
                         :disabled="isview"
                         placeholder="请填写著作名称"></i-input>
            </Form-item>

            <Form-item label="ISBN：" prop="isbn">
                <i-input v-model="zuzuo.isbn"
                         :maxlength="50"
                         :disabled="isview"
                         placeholder="请填写ISBN"></i-input>
            </Form-item>

            <Form-item label="类别：" prop="leiBie">
                <i-select v-model="zuzuo.leiBie" :disabled="isview" placeholder="请选择" style="width:200px">
                    <i-option value="0">专著</i-option>
                    <i-option value="1">编著</i-option>
                    <i-option value="2">译著</i-option>
                    <i-option value="3">译</i-option>
                </i-select>
            </Form-item>

            <Form-item label="出版社：" prop="chuBanSe">
                <i-input v-model="zuzuo.chuBanSe"
                         :maxlength="50"
                         :disabled="isview"
                         placeholder="请填写出版社"></i-input>
            </Form-item>
            <Row>
                <i-col span="5">
                    <Form-item label="出版社级别：" prop="chuBanSeJiBie">
                        <i-select v-model="zuzuo.chuBanSeJiBie" :disabled="isview" placeholder="请选择">
                            <i-option value="0">国家级</i-option>
                            <i-option value="1">省部级</i-option>

                        </i-select>
                    </Form-item>
                </i-col>
                <i-col span="5">
                    <Form-item label="出版时间：" prop="chuBanShiJian">
                        <Date-picker type="date" :disabled="isview" placeholder="选择日期" v-model="zuzuo.chuBanShiJian"></Date-picker>
                    </Form-item>
                </i-col>
            </Row>

            <Form-item prop="canyuzes">
                <span slot="label"><b style="font-size:16px;color:red;">*</b> 著作者：</span>
                <table>
                    <tr><th>排序</th> <th>姓名</th> <th>是否本院人员</th> </tr>
                    <tr>
                        <td>1</td>
                        <td>
                            <i-input v-model="canyuzes.ren1"
                                     :disabled="isview"
                                     :maxlength="10"></i-input>
                        </td>
                        <td>
                            <i-select v-model="canyuzes.is1"
                                      :disabled="isview" placeholder="请选择">
                                <i-option value="是">是</i-option>
                                <i-option value="否">否</i-option>
                            </i-select>
                        </td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>
                            <i-input v-model="canyuzes.ren2"
                                     :disabled="isview"
                                     :maxlength="10"></i-input>
                        </td>
                        <td>
                            <i-select v-model="canyuzes.is2"
                                      :disabled="isview" placeholder="请选择">
                                <i-option value="是">是</i-option>
                                <i-option value="否">否</i-option>
                            </i-select>
                        </td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td>
                            <i-input v-model="canyuzes.ren3"
                                     :disabled="isview"
                                     :maxlength="10"></i-input>
                        </td>
                        <td>
                            <i-select v-model="canyuzes.is3"
                                      :disabled="isview" placeholder="请选择">
                                <i-option value="是">是</i-option>
                                <i-option value="否">否</i-option>
                            </i-select>
                        </td>
                    </tr>
                    <tr>
                        <td>4</td>
                        <td>
                            <i-input v-model="canyuzes.ren4"
                                     :disabled="isview"
                                     :maxlength="10"></i-input>
                        </td>
                        <td>
                            <i-select v-model="canyuzes.is4"
                                      :disabled="isview" placeholder="请选择">
                                <i-option value="是">是</i-option>
                                <i-option value="否">否</i-option>
                            </i-select>
                        </td>
                    </tr>
                    <tr>
                        <td>5</td>
                        <td>
                            <i-input v-model="canyuzes.ren5"
                                     :disabled="isview"
                                     :maxlength="10"></i-input>
                        </td>
                        <td>
                            <i-select v-model="canyuzes.is5"
                                      :disabled="isview" placeholder="请选择">
                                <i-option value="是">是</i-option>
                                <i-option value="否">否</i-option>
                            </i-select>
                        </td>
                    </tr>
                    <tr>
                        <td>6</td>
                        <td>
                            <i-input v-model="canyuzes.ren6"
                                     :disabled="isview"
                                     :maxlength="10"></i-input>
                        </td>
                        <td>
                            <i-select v-model="canyuzes.is6"
                                      :disabled="isview" placeholder="请选择">
                                <i-option value="是">是</i-option>
                                <i-option value="否">否</i-option>
                            </i-select>
                        </td>
                    </tr>
                    <tr>
                        <td>7</td>
                        <td>
                            <i-input v-model="canyuzes.ren7"
                                     :disabled="isview"
                                     :maxlength="10"></i-input>
                        </td>
                        <td>
                            <i-select v-model="canyuzes.is7"
                                      :disabled="isview" placeholder="请选择">
                                <i-option value="是">是</i-option>
                                <i-option value="否">否</i-option>
                            </i-select>
                        </td>
                    </tr>
                    <tr>
                        <td>8</td>
                        <td>
                            <i-input v-model="canyuzes.ren8"
                                     :disabled="isview"
                                     :maxlength="10"></i-input>
                        </td>
                        <td>
                            <i-select v-model="canyuzes.is8"
                                      :disabled="isview" placeholder="请选择">
                                <i-option value="是">是</i-option>
                                <i-option value="否">否</i-option>
                            </i-select>
                        </td>
                    </tr>
                    <tr>
                        <td>9</td>
                        <td>
                            <i-input v-model="canyuzes.ren9"
                                     :disabled="isview"
                                     :maxlength="10"></i-input>
                        </td>
                        <td>
                            <i-select v-model="canyuzes.is9"
                                      :disabled="isview" placeholder="请选择">
                                <i-option value="是">是</i-option>
                                <i-option value="否">否</i-option>
                            </i-select>
                        </td>
                    </tr>
                    <tr>
                        <td>10</td>
                        <td>
                            <i-input v-model="canyuzes.ren10"
                                     :disabled="isview"
                                     :maxlength="10"></i-input>
                        </td>
                        <td>
                            <i-select v-model="canyuzes.is10"
                                      :disabled="isview" placeholder="请选择">
                                <i-option value="是">是</i-option>
                                <i-option value="否">否</i-option>
                            </i-select>
                        </td>
                    </tr>
                    <tr>
                        <td>11</td>
                        <td>
                            <i-input v-model="canyuzes.ren11"
                                     :disabled="isview"
                                     :maxlength="10"></i-input>
                        </td>
                        <td>
                            <i-select v-model="canyuzes.is11"
                                      :disabled="isview" placeholder="请选择">
                                <i-option value="是">是</i-option>
                                <i-option value="否">否</i-option>
                            </i-select>
                        </td>
                    </tr>
                </table>
            </Form-item>

            <Form-item label="封面本人署名排序：" prop="fengMianBenRenShuMingPaiXu">
                <i-select v-model="zuzuo.fengMianBenRenShuMingPaiXu" :disabled="isview" placeholder="请选择" style="width:200px">
                    <i-option value="1">1</i-option>
                    <i-option value="2">2</i-option>
                    <i-option value="3">3</i-option>
                    <i-option value="4">4</i-option>
                    <i-option value="5">5</i-option>
                    <i-option value="6">6</i-option>
                    <i-option value="7">7</i-option>
                    <i-option value="8">8</i-option>
                    <i-option value="9">9</i-option>
                    <i-option value="10">10</i-option>
                    <i-option value="11">11</i-option>
                    <i-option value="无署名">无署名</i-option>
                </i-select>
            </Form-item>

            <Form-item label="是否标注上海公安学院：" prop="isBiaoZhuXueYuan">
                <i-select v-model="zuzuo.isBiaoZhuXueYuan" :disabled="isview" placeholder="请选择" style="width:200px">
                    <i-option value="0">是</i-option>
                    <i-option value="1">否</i-option>
                </i-select>
            </Form-item>
            <Row>
                <i-col span="5">
                    <Form-item label="全书字数：" prop="quanShuZiShu">
                        <i-input v-model="zuzuo.quanShuZiShu"
                                 :maxlength="8"
                                 :disabled="isview"
                                 placeholder="请填写全书字数"></i-input>
                    </Form-item>
                </i-col>
                <i-col span="5">
                    <Form-item label="供稿章节：" prop="gongGaoZhangJie">
                        <i-input v-model="zuzuo.gongGaoZhangJie"
                                 :maxlength="10"
                                 :disabled="isview"
                                 placeholder="请填写供稿章节"></i-input>
                    </Form-item>
                </i-col>
                <i-col span="5">
                    <Form-item label="供稿字数：" prop="gongGaoZiShu">
                        <i-input v-model="zuzuo.gongGaoZiShu"
                                 :maxlength="8"
                                 :disabled="isview"
                                 placeholder="请填写供稿字数"></i-input>
                    </Form-item>
                </i-col>
            </Row>
            <Form-item label="著作获奖级别：" prop="ZuZhuoHuoJiangJiBie">
                <i-select v-model="zuzuo.zuZhuoHuoJiangJiBie" :disabled="isview" placeholder="请选择" style="width:200px">
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

            <Form-item label="著作获奖称号：" prop="HuoJiangMingCheng">
                <i-input v-model="zuzuo.huoJiangMingCheng"
                         :maxlength="50"
                         :disabled="isview"
                         placeholder="请填写著作获奖称号"></i-input>
            </Form-item>
            <Form-item label="著作获奖时间：" prop="ZuZhuoHuoJiangShiJian">
                <Date-picker type="date" placeholder="选择日期" :disabled="isview" v-model="zuzuo.zuZhuoHuoJiangShiJian"></Date-picker>
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

                <Form-item label="著作页面" prop="articleList">
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

                    <div v-for="(item,index) in zuzuo.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==0">封面</span>
                        <img v-if="item.wenJianLeiXing==0"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in zuzuo.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==1">目录</span>
                        <img v-if="item.wenJianLeiXing==1"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in zuzuo.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==2">著作页面</span>
                        <img v-if="item.wenJianLeiXing==2"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in zuzuo.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==4">版权页</span>
                        <img v-if="item.wenJianLeiXing==4"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in zuzuo.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==3">文件附件</span>
                        <a v-if="item.wenJianLeiXing==3"
                           :href="item.luJing" target="_blank">{{item.wenJianMingCheng}}</a>
                    </div>
                </Form-item>
            </div>

            <div v-if="isshenhe&&shlx==3">
                <Form-item label="成果分值：" prop="KeYanKaoHeDeFen">
                    <i-input v-model="zuzuo.keYanKaoHeDeFen"
                             :maxlength="10"
                             :disabled="isview"></i-input>
                </Form-item>
                <span style="color:red;">
                    总分： {{getdefen()}} （出版社级别分） +  {{gethuojiangfen()}}（获奖分）= {{getzongfen()}}
                </span>
                <br />
                <span style="color:red;">
                    成果分值：{{getzongfen()}} (总分) * {{getbilv()}} （本人署名排序） = {{getjisuanfen()}}
                </span>

            </div>

            <Form-item>
                <i-button v-if="!isview" type="primary" @click="save(1)">提交</i-button>
                <i-button v-if="this.zuzuo.status==0||!this.zuzuo.status" type="primary" @click="save(0)">暂存</i-button>
            </Form-item>

            <table style="width:100%;">
                <tr>
                    <td v-if="issee" style="vertical-align:top;width:60%;text-align:center">
                        <div v-if="isshenhe">
                            <div v-if="shlx==3">

                                <Form-item label="科研处审核分：" prop="ShenHeJiaKouFen">
                                    <i-input v-model="zuzuo.shenHeJiaKouFen"
                                             :maxlength="20"
                                             :disabled="!iswanjie"
                                             placeholder="请填写审核分"></i-input>
                                </Form-item>
                                <Form-item label="科研处审核分说明：" prop="JiaKouFenShuoMing">
                                    <i-input v-model="zuzuo.jiaKouFenShuoMing"
                                             :maxlength="50"
                                             type="textarea"
                                             :disabled="!iswanjie"
                                             placeholder="请填写审核分说明"></i-input>
                                </Form-item>
                                <!--<Form-item label="科研处审核得分：" prop="ShenHeDeFen">
                            <i-input v-model="zuzuo.shenHeDeFen"
                                     :maxlength="20"
                                     :disabled="!iswanjie"
                                     placeholder="请填写审核得分"></i-input>
                        </Form-item>-->
                                <!--<Form-item label="考核得分：" prop="ShiJiDeFen">
                            <i-input v-model="zuzuo.shiJiDeFen"
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
                bmshyj: [],
                sh: [],
                zuzuo: {},
                fengmianList: [],
                fileList: [],
                articleList: [],
                wenjianList: [],
                banquanlist: [],
                request_canyuzes: [],
                canyuzes: {
                    ren1: null,
                    is1: null,
                    ren2: null,
                    is2: null,
                    ren3: null,
                    is3: null,
                    ren4: null,
                    is4: null,
                    ren5: null,
                    is5: null,
                    ren6: null,
                    is6: null,
                    ren7: null,
                    is7: null,
                    ren8: null,
                    is8: null,
                    ren9: null,
                    is9: null,
                    ren10: null,
                    is10: null,
                    ren11: null,
                    is11: null,
                },
                ruleValidate: {
                    zuZuoMingCheng: [
                        { required: true, message: '著作不能为空', trigger: 'blur' }
                    ],
                    suoShuNianDu: [
                        { required: true, message: '所属年度不能为空', trigger: 'blur' }
                    ],
                    isbn: [
                        { required: true, message: 'isbn不能为空', trigger: 'blur' }
                    ],
                    leiBie: [
                        { required: true, message: '请选择类别', trigger: 'change' }
                    ],
                    chuBanSe: [
                        { required: true, message: '出版社不能为空', trigger: 'blur' }
                    ],
                    chuBanSeJiBie: [
                        { required: true, message: '请选择出版社级别', trigger: 'change' }
                    ],
                    chuBanShiJian: [
                        { required: true, type: 'date', message: '请选择日期', trigger: 'change' }
                    ],
                    fengMianBenRenShuMingPaiXu: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                    isBiaoZhuXueYuan: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                    quanShuZiShu: [
                        { required: true, message: '请输入全书字数', trigger: 'blur' }
                    ],
                    gongGaoZhangJie: [
                        { required: true, message: '请输入供稿章节', trigger: 'blur' }
                    ],
                    gongGaoZiShu: [
                        { required: true, message: '请输入供稿字数', trigger: 'blur' }
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
            zuzuo: {
                deep: true,
                handler(newName, oldName) {
                    this.zuzuo.keYanKaoHeDeFen = this.getjisuanfen();
                    this.zuzuo.shenHeDeFen = this.zuzuo.keYanKaoHeDeFen + this.getjiakoufen();
                },
            }
        },
        mounted() {
            //console.log(this.id, this.isview)
            if (this.id != null) {
                this.getzuzuo();
                this.getjilu();
            }
            this.getuser();
        },
        computed: {},
        components: {
            UploadCtrl, shenhe
        },
        methods: {
            getzuzuo() {
                axios.get('api/Cg_ZhuZuo/GetCgZhuZuoById', {
                    params: {
                        id: this.id,
                    }
                })
                    .then(response => {
                        this.zuzuo = response.data.result;
                        this.zuzuo.leiBie = this.zuzuo.leiBie + '';
                        this.zuzuo.chuBanSeJiBie = this.zuzuo.chuBanSeJiBie + '';
                        this.zuzuo.isBiaoZhuXueYuan = this.zuzuo.isBiaoZhuXueYuan + '';
                        this.zuzuo.zuZhuoHuoJiangJiBie = this.zuzuo.zuZhuoHuoJiangJiBie + '';

                        //附件
                        this.zuzuo.fuJians.forEach(x => {
                            if (x.wenJianLeiXing == 0) {
                                this.fengmianList.push(x);
                            } else if (x.wenJianLeiXing == 1) {
                                this.fileList.push(x);
                            } else if (x.wenJianLeiXing == 2) {
                                this.articleList.push(x);
                            } else if (x.wenJianLeiXing == 4) {
                                this.banquanlist.push(x);
                            } else if (x.wenJianLeiXing == 3) {
                                this.wenjianList.push(x);
                            }
                        })

                        //参与人员
                        for (var i = 0; i < this.zuzuo.cgCanYuZhes.length; i++) {
                            if (this.zuzuo.cgCanYuZhes[i].name != null || this.zuzuo.cgCanYuZhes[i].name != undefined) {
                                this.canyuzes["ren" + (i + 1)] = this.zuzuo.cgCanYuZhes[i].name;
                                if (this.zuzuo.cgCanYuZhes[i].isBenYuan == 0) {
                                    this.canyuzes["is" + (i + 1)] = "是";
                                } else {
                                    this.canyuzes["is" + (i + 1)] = "否";
                                }
                            }

                        }
                        // console.log(this.zuzuo)
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
                axios.post('api/Cg_ZhuZuo/SaveCgZhuzuo', qs.stringify({
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
                var arr = [
                    {
                        name: this.canyuzes.ren1,
                        isbenyuan: this.canyuzes.is1,
                    },
                    {
                        name: this.canyuzes.ren2,
                        isbenyuan: this.canyuzes.is2,
                    },
                    {
                        name: this.canyuzes.ren3,
                        isbenyuan: this.canyuzes.is3,
                    },
                    {
                        name: this.canyuzes.ren4,
                        isbenyuan: this.canyuzes.is4,
                    },
                    {
                        name: this.canyuzes.ren5,
                        isbenyuan: this.canyuzes.is5,
                    },
                    {
                        name: this.canyuzes.ren6,
                        isbenyuan: this.canyuzes.is6,
                    },
                    {
                        name: this.canyuzes.ren7,
                        isbenyuan: this.canyuzes.is7,
                    },
                    {
                        name: this.canyuzes.ren8,
                        isbenyuan: this.canyuzes.is8,
                    },
                    {
                        name: this.canyuzes.ren9,
                        isbenyuan: this.canyuzes.is9,
                    },
                    {
                        name: this.canyuzes.ren10,
                        isbenyuan: this.canyuzes.is10,
                    },
                    {
                        name: this.canyuzes.ren11,
                        isbenyuan: this.canyuzes.is11,
                    }
                ];
                this.request_canyuzes = [];
                arr.forEach(x => {
                    if (x.name != null && x.isbenyuan != null) {
                        this.request_canyuzes.push(x)
                    } else if (x.name != null && x.isbenyuan == null) {
                        this.$Message.error('请选择是否本院人员');
                    }
                });
                var request_bag = {
                    cgZuZhuo: this.zuzuo,
                    canyuzes: this.request_canyuzes,
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
                    if (this.zuzuo.zuZuoMingCheng == null || this.zuzuo.zuZuoMingCheng == undefined || this.zuzuo.zuZuoMingCheng.length == 0) {
                        this.$Message.error('著作名称不能为空');
                    } else if (this.zuzuo.suoShuNianDu == null || this.zuzuo.suoShuNianDu == undefined || this.zuzuo.suoShuNianDu.length == 0) {
                        this.$Message.error('所属年度不能为空');
                    }
                    else if (this.zuzuo.isbn == null || this.zuzuo.isbn == undefined || this.zuzuo.isbn.length == 0) {
                        this.$Message.error('ISBN不能为空');
                    } else if (this.zuzuo.leiBie == null || this.zuzuo.leiBie == undefined) {
                        this.$Message.error('请选择类别');
                    } else if (this.zuzuo.chuBanSe == null || this.zuzuo.chuBanSe == undefined || this.zuzuo.chuBanSe.length == 0) {
                        this.$Message.error('出版社不能为空');
                    } else if (this.zuzuo.chuBanSeJiBie == null || this.zuzuo.chuBanSeJiBie == undefined) {
                        this.$Message.error('请选择出版社级别');
                    } else if (this.zuzuo.chuBanShiJian == null || this.zuzuo.chuBanShiJian == undefined || this.zuzuo.chuBanShiJian.length == 0) {
                        this.$Message.error('请选择出版时间');
                    } else if (this.request_canyuzes.length <= 0) {
                        this.$Message.error('请添加著作者');
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == null || this.zuzuo.fengMianBenRenShuMingPaiXu == undefined || this.zuzuo.fengMianBenRenShuMingPaiXu.length == 0) {
                        this.$Message.error('封面本人署名排序不能为空');
                    } else if (this.zuzuo.isBiaoZhuXueYuan == null || this.zuzuo.isBiaoZhuXueYuan == undefined) {
                        this.$Message.error('请选择是否标注上海公安学校');
                    } else if (this.zuzuo.quanShuZiShu == null || this.zuzuo.quanShuZiShu == undefined || this.zuzuo.quanShuZiShu.length == 0) {
                        this.$Message.error('请输入全书字数');
                    } else if (this.zuzuo.gongGaoZhangJie == null || this.zuzuo.gongGaoZhangJie == undefined || this.zuzuo.gongGaoZhangJie.length == 0) {
                        this.$Message.error('请输入供稿章节');
                    } else if (this.zuzuo.gongGaoZiShu == null || this.zuzuo.gongGaoZiShu == undefined || this.zuzuo.gongGaoZiShu.length == 0) {
                        this.$Message.error('请输入供稿字数');
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

            shenhe() {
                var request_bag = {
                    cgZuZhuo: this.zuzuo,
                    CgShenHe: this.sh,
                };
                if (this.sh.shenHeYiJian == null || this.sh.shenHeYiJian == undefined || this.sh.shenHeYiJian.length == 0) {
                    //this.$Message.error('请填写意见!');
                    this.sh.shenHeYiJian = "已通过";
                }
                axios.post('api/Cg_ShenHe/shenhe', qs.stringify({
                    "entity": request_bag,
                    status: this.shlx
                })).then(response => {
                    if (!response.data.error) {
                        this.$Message.success('审核成功!');
                        // this.$router.push('bumenshenhe');
                        this.$emit('close')
                        //this.$router.push({ name: 'xiangmulistgeren' })
                    } else {
                        this.$Message.error('审核失败!');
                    }
                });

            },
            tuihui() {
                var request_bag = {
                    cgZuZhuo: this.zuzuo,
                    CgShenHe: this.sh,
                };
                if (this.sh.shenHeYiJian == null || this.sh.shenHeYiJian == undefined || this.sh.shenHeYiJian.length == 0) {
                    this.$Message.error('请填写意见!');
                    //this.sh.shenHeYiJian = "已退回";
                } else {
                    axios.post('api/Cg_ShenHe/tuihui', qs.stringify({
                        "entity": request_bag,
                        status: this.shlx
                    })).then(response => {
                        if (!response.data.error) {
                            this.$Message.success('退回成功!');
                            // this.$router.push('bumenshenhe');
                            this.$emit('close')
                            //this.$router.push({ name: 'xiangmulistgeren' })
                        } else {
                            this.$Message.error('退回失败!');
                        }
                    });
                }
            },
            getdefen() {
                var num = 0;
                if (this.zuzuo.chuBanSeJiBie != null || this.zuzuo.chuBanSeJiBie != undefined) {
                    if (this.zuzuo.chuBanSeJiBie == 0) {
                        if (this.zuzuo.leiBie == 0) {
                            num += 2000;
                        } else if (this.zuzuo.leiBie == 1 || this.zuzuo.leiBie == 2) {
                            num += 1500;
                        }
                    } else if (this.zuzuo.chuBanSeJiBie == 1) {
                        if (this.zuzuo.leiBie == 0) {
                            num += 700;
                        } else if (this.zuzuo.leiBie == 1 || this.zuzuo.leiBie == 2) {
                            num += 500;
                        }
                    }
                }
                return num;
            },
            gethuojiangfen() {
                //zuzuo.zuZhuoHuoJiangJiBie
                var num = 0;
                if (this.zuzuo.zuZhuoHuoJiangJiBie != null || this.zuzuo.zuZhuoHuoJiangJiBie != undefined) {
                    if (this.zuzuo.zuZhuoHuoJiangJiBie == 0) {
                        // num += 2500;
                    } else if (this.zuzuo.zuZhuoHuoJiangJiBie == 1) {
                        //num += 2000;
                    } else if (this.zuzuo.zuZhuoHuoJiangJiBie == 2) {
                        // num += 1500;
                    } else if (this.zuzuo.zuZhuoHuoJiangJiBie == 3) {
                        //num += 1000;
                    } else if (this.zuzuo.zuZhuoHuoJiangJiBie == 4) {
                        num += 600;
                    } else if (this.zuzuo.zuZhuoHuoJiangJiBie == 5) {
                        num += 360;
                    } else if (this.zuzuo.zuZhuoHuoJiangJiBie == 6) {
                        num += 180;
                    } else if (this.zuzuo.zuZhuoHuoJiangJiBie == 7) {
                        num += 60;
                    } else if (this.zuzuo.zuZhuoHuoJiangJiBie == 8) {
                        num += 300;
                    } else if (this.zuzuo.zuZhuoHuoJiangJiBie == 9) {
                        num += 180;
                    } else if (this.zuzuo.zuZhuoHuoJiangJiBie == 10) {
                        num += 90;
                    } else if (this.zuzuo.zuZhuoHuoJiangJiBie == 11) {
                        num += 30;
                    } else if (this.zuzuo.zuZhuoHuoJiangJiBie == 12) {
                        num += 100;
                    } else if (this.zuzuo.zuZhuoHuoJiangJiBie == 13) {
                        num += 60;
                    } else if (this.zuzuo.zuZhuoHuoJiangJiBie == 14) {
                        num += 30;
                    } else if (this.zuzuo.zuZhuoHuoJiangJiBie == 15) {
                        num += 10;
                    }
                }
                return num;

            },
            getjiakoufen() {
                var num = 0;
                if (this.zuzuo.shenHeJiaKouFen != null || this.zuzuo.shenHeJiaKouFen != undefined) {
                    num = parseInt(this.zuzuo.shenHeJiaKouFen);
                }
                return num;
            },

            getzongfen() {
                var num = 0;
                num = this.getdefen() + this.gethuojiangfen();
                return num;
            },
            getrensu() {
                var arr = [
                    {
                        name: this.canyuzes.ren1,
                        isbenyuan: this.canyuzes.is1,
                    },
                    {
                        name: this.canyuzes.ren2,
                        isbenyuan: this.canyuzes.is2,
                    },
                    {
                        name: this.canyuzes.ren3,
                        isbenyuan: this.canyuzes.is3,
                    },
                    {
                        name: this.canyuzes.ren4,
                        isbenyuan: this.canyuzes.is4,
                    },
                    {
                        name: this.canyuzes.ren5,
                        isbenyuan: this.canyuzes.is5,
                    },
                    {
                        name: this.canyuzes.ren6,
                        isbenyuan: this.canyuzes.is6,
                    },
                    {
                        name: this.canyuzes.ren7,
                        isbenyuan: this.canyuzes.is7,
                    },
                    {
                        name: this.canyuzes.ren8,
                        isbenyuan: this.canyuzes.is8,
                    },
                    {
                        name: this.canyuzes.ren9,
                        isbenyuan: this.canyuzes.is9,
                    },
                    {
                        name: this.canyuzes.ren10,
                        isbenyuan: this.canyuzes.is10,
                    },
                    {
                        name: this.canyuzes.ren11,
                        isbenyuan: this.canyuzes.is11,
                    }
                ];
                var rensu = 0;
                arr.forEach(x => {
                    if (x.name != null && x.isbenyuan != null) {
                        rensu++;
                    }
                });
                return rensu;
            },
            getjisuanfen() {
                var ren = this.getrensu();
                var zongfen = this.getzongfen();
                var num = 1;
                //1人
                if (ren == 1) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return zongfen * 1;
                    } else {
                        return zongfen * 0;
                    }
                } else if (ren == 2) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return zongfen * 0.6;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2) {
                        return zongfen * 0.4;
                    } else {
                        return 0;
                    }
                } else if (ren == 3) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2) {
                        return zongfen * 0.3;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 3) {
                        return zongfen * 0.2;
                    } else {
                        return 0;
                    }
                } else if (ren == 4) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2) {
                        return zongfen * 0.25;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 3) {
                        return zongfen * 0.15;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 4) {
                        return zongfen * 0.1;
                    } else {
                        return 0;
                    }
                } else if (ren == 5) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2) {
                        return zongfen * 0.25;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 3) {
                        return zongfen * 0.15;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 4 || this.zuzuo.fengMianBenRenShuMingPaiXu == 5) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 6) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2) {
                        return zongfen * 0.2;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 3) {
                        return zongfen * 0.15;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 4 || this.zuzuo.fengMianBenRenShuMingPaiXu == 5 || this.zuzuo.fengMianBenRenShuMingPaiXu == 6) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 7) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2 || this.zuzuo.fengMianBenRenShuMingPaiXu == 3) {
                        return zongfen * 0.15;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 4 || this.zuzuo.fengMianBenRenShuMingPaiXu == 5 || this.zuzuo.fengMianBenRenShuMingPaiXu == 6 || this.zuzuo.fengMianBenRenShuMingPaiXu == 7) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 8) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2) {
                        return zongfen * 0.15;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 3) {
                        return zongfen * 0.1;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 4 || this.zuzuo.fengMianBenRenShuMingPaiXu == 5 || this.zuzuo.fengMianBenRenShuMingPaiXu == 6 || this.zuzuo.fengMianBenRenShuMingPaiXu == 7 || this.zuzuo.fengMianBenRenShuMingPaiXu == 8) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 9) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2 || this.zuzuo.fengMianBenRenShuMingPaiXu == 3) {
                        return zongfen * 0.1;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 4 || this.zuzuo.fengMianBenRenShuMingPaiXu == 5 || this.zuzuo.fengMianBenRenShuMingPaiXu == 6 || this.zuzuo.fengMianBenRenShuMingPaiXu == 7 || this.zuzuo.fengMianBenRenShuMingPaiXu == 8 || this.zuzuo.fengMianBenRenShuMingPaiXu == 9) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 10) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2) {
                        return zongfen * 0.1;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 3 || this.zuzuo.fengMianBenRenShuMingPaiXu == 4 || this.zuzuo.fengMianBenRenShuMingPaiXu == 5 || this.zuzuo.fengMianBenRenShuMingPaiXu == 6 || this.zuzuo.fengMianBenRenShuMingPaiXu == 7 || this.zuzuo.fengMianBenRenShuMingPaiXu == 8 || this.zuzuo.fengMianBenRenShuMingPaiXu == 9 || this.zuzuo.fengMianBenRenShuMingPaiXu == 10) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 11) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2 || this.zuzuo.fengMianBenRenShuMingPaiXu == 3 || this.zuzuo.fengMianBenRenShuMingPaiXu == 4 || this.zuzuo.fengMianBenRenShuMingPaiXu == 5 || this.zuzuo.fengMianBenRenShuMingPaiXu == 6 || this.zuzuo.fengMianBenRenShuMingPaiXu == 7 || this.zuzuo.fengMianBenRenShuMingPaiXu == 8 || this.zuzuo.fengMianBenRenShuMingPaiXu == 9 || this.zuzuo.fengMianBenRenShuMingPaiXu == 10) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else {
                    return 0;
                }
            },
            getbilv() {
                var ren = this.getrensu();
                var zongfen = this.getzongfen();
                var num = 1;
                //1人
                if (ren == 1) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return 1;
                    } else {
                        return 0;
                    }
                } else if (ren == 2) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return 0.6;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2) {
                        return 0.4;
                    } else {
                        return 0;
                    }
                } else if (ren == 3) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2) {
                        return 0.3;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 3) {
                        return 0.2;
                    } else {
                        return 0;
                    }
                } else if (ren == 4) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2) {
                        return 0.25;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 3) {
                        return 0.15;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 4) {
                        return 0.1;
                    } else {
                        return 0;
                    }
                } else if (ren == 5) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2) {
                        return 0.25;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 3) {
                        return 0.15;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 4 || this.zuzuo.fengMianBenRenShuMingPaiXu == 5) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 6) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2) {
                        return 0.2;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 3) {
                        return 0.15;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 4 || this.zuzuo.fengMianBenRenShuMingPaiXu == 5 || this.zuzuo.fengMianBenRenShuMingPaiXu == 6) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 7) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2 || this.zuzuo.fengMianBenRenShuMingPaiXu == 3) {
                        return 0.15;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 4 || this.zuzuo.fengMianBenRenShuMingPaiXu == 5 || this.zuzuo.fengMianBenRenShuMingPaiXu == 6 || this.zuzuo.fengMianBenRenShuMingPaiXu == 7) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 8) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2) {
                        return 0.15;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 3) {
                        return 0.1;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 4 || this.zuzuo.fengMianBenRenShuMingPaiXu == 5 || this.zuzuo.fengMianBenRenShuMingPaiXu == 6 || this.zuzuo.fengMianBenRenShuMingPaiXu == 7 || this.zuzuo.fengMianBenRenShuMingPaiXu == 8) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 9) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2 || this.zuzuo.fengMianBenRenShuMingPaiXu == 3) {
                        return 0.1;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 4 || this.zuzuo.fengMianBenRenShuMingPaiXu == 5 || this.zuzuo.fengMianBenRenShuMingPaiXu == 6 || this.zuzuo.fengMianBenRenShuMingPaiXu == 7 || this.zuzuo.fengMianBenRenShuMingPaiXu == 8 || this.zuzuo.fengMianBenRenShuMingPaiXu == 9) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 10) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2) {
                        return 0.1;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 3 || this.zuzuo.fengMianBenRenShuMingPaiXu == 4 || this.zuzuo.fengMianBenRenShuMingPaiXu == 5 || this.zuzuo.fengMianBenRenShuMingPaiXu == 6 || this.zuzuo.fengMianBenRenShuMingPaiXu == 7 || this.zuzuo.fengMianBenRenShuMingPaiXu == 8 || this.zuzuo.fengMianBenRenShuMingPaiXu == 9 || this.zuzuo.fengMianBenRenShuMingPaiXu == 10) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 11) {
                    if (this.zuzuo.fengMianBenRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.zuzuo.fengMianBenRenShuMingPaiXu == 2 || this.zuzuo.fengMianBenRenShuMingPaiXu == 3 || this.zuzuo.fengMianBenRenShuMingPaiXu == 4 || this.zuzuo.fengMianBenRenShuMingPaiXu == 5 || this.zuzuo.fengMianBenRenShuMingPaiXu == 6 || this.zuzuo.fengMianBenRenShuMingPaiXu == 7 || this.zuzuo.fengMianBenRenShuMingPaiXu == 8 || this.zuzuo.fengMianBenRenShuMingPaiXu == 9 || this.zuzuo.fengMianBenRenShuMingPaiXu == 10) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else {
                    return 0;
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

    /deep/ .ivu-select-placeholder {
        background-color: #ffffff;
        color: #b1b1b1;
    }
</style>