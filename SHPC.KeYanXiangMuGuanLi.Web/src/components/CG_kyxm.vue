<template>
    <div style="padding:10px;">
        <i-form :model="kyxm" :label-width="150" label-position="right" :rules="ruleValidate">
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
                <i-input v-model="kyxm.suoShuNianDu"
                         :maxlength="4"
                         :disabled="isview"
                         placeholder="请填写数字年份,例:2019"></i-input>
            </Form-item>

            <Form-item label="批准立项部门：" prop="piZunLiXiangBuMen">
                <i-input v-model="kyxm.piZunLiXiangBuMen"
                         :maxlength="50"
                         :disabled="isview"
                         placeholder="请填写批准立项部门"></i-input>
            </Form-item>

            <Form-item label="科研项目来源：" prop="xiangMuLaiYuan">
                <i-input v-model="kyxm.xiangMuLaiYuan"
                         :maxlength="50"
                         :disabled="isview"
                         placeholder="请填写科研项目来源"></i-input>
            </Form-item>


            <Row>
                <i-col span="6">
                    <Form-item label="批准立项时间：" prop="liXiangShiJian">
                        <Date-picker type="date" placeholder="选择日期" :disabled="isview" v-model="kyxm.liXiangShiJian"></Date-picker>
                    </Form-item>
                </i-col>
                <i-col span="6">
                    <Form-item label="计划完成时间：" prop="jiHuaWanChengShiJian">
                        <Date-picker type="date" :disabled="isview" placeholder="选择日期" v-model="kyxm.jiHuaWanChengShiJian"></Date-picker>
                    </Form-item>
                </i-col>
                <i-col span="6">
                    <Form-item label="批准结项时间：" prop="gongBuJieXiangShiJian">
                        <Date-picker type="date" :disabled="isview" placeholder="选择日期" v-model="kyxm.gongBuJieXiangShiJian"></Date-picker>
                    </Form-item>
                </i-col>
            </Row>

            <Row>
                <i-col span="5">
                    <Form-item label="项目级别：" prop="xiangMuJiBie" style="width:300px">
                        <i-select v-model="kyxm.xiangMuJiBie" :disabled="isview" placeholder="请选择">
                            <i-option value="0">国家级</i-option>
                            <i-option value="1">省（部）级</i-option>
                            <i-option value="2">局级</i-option>
                            <i-option value="3">院级</i-option>
                        </i-select>
                    </Form-item>
                </i-col>
                <i-col span="5">
                    <Form-item label="项目类别：" prop="xiangMuLeiBie" style="width:300px;">
                        <i-select v-model="kyxm.xiangMuLeiBie" :disabled="isview" placeholder="请选择">
                            <i-option value="0">重点项目</i-option>
                            <i-option value="1">一般项目</i-option>
                            <i-option value="2">青年项目</i-option>
                            <i-option value="3">学生项目</i-option>
                        </i-select>
                    </Form-item>
                </i-col>
                <i-col span="5" v-if="kyxm.xiangMuLeiBie==3">
                    <Form-item label="学生项目结项等级：" prop="xueShengJieXiangDengJi" style="width:300px">
                        <i-select v-model="kyxm.xueShengJieXiangDengJi" :disabled="isview" placeholder="请选择">
                            <i-option value="1">优秀</i-option>
                            <i-option value="2">良</i-option>
                            <i-option value="3">合格</i-option>
                            <i-option value="4">不合格</i-option>
                        </i-select>
                    </Form-item>
                </i-col>

            </Row>

            <Form-item label="项目名称：" prop="xiangMuMingCheng">
                <i-input v-model="kyxm.xiangMuMingCheng"
                         :disabled="isview"
                         :maxlength="50"
                         placeholder="请填写项目名称"></i-input>
            </Form-item>

            <Form-item label="院内项目编号：" prop="yuanNeiXiangMuBianHao">
                <i-input v-model="kyxm.yuanNeiXiangMuBianHao"
                         :disabled="isview"
                         :maxlength="50"
                         placeholder="请填写院内项目编号"></i-input>
            </Form-item>

            <Form-item label="院外项目编号：" prop="yuanWaiXiangMuBianHao">
                <i-input v-model="kyxm.yuanWaiXiangMuBianHao"
                         :disabled="isview"
                         :maxlength="50"
                         placeholder="请填写院外项目编号"></i-input>
            </Form-item>

            <Form-item label="项目经费总额：" prop="xiangMuZiZuZongE" style="width:350px">
                <i-input v-model="kyxm.xiangMuZiZuZongE"
                         :disabled="isview"
                         :maxlength="7"
                         placeholder="请填写项目经费总额（单位/万元）"></i-input>
            </Form-item>

            <Form-item prop="Canyuze">
                <span slot="label"><b style="font-size:16px;color:red;">*</b> 项目组成员：</span>
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

            <Form-item label="本人署名排序：" prop="benRenShuMingPaiXu">
                <i-select v-model="kyxm.benRenShuMingPaiXu" :disabled="isview" placeholder="请选择" style="width:200px">
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

            <Form-item label="院内本人署名排序：" prop="yuanNeiBenRenShuMingPaiXu">
                <i-select v-model="kyxm.yuanNeiBenRenShuMingPaiXu" :disabled="isview" placeholder="请选择" style="width:200px">
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

            <div v-if="this.id==null">
                <Form-item label="项目状态：" prop="xiangMuZhuangTai">
                    <CheckboxGroup v-model="xmzts">
                        <Checkbox label="0">立项</Checkbox>
                        <Checkbox label="1">已结项</Checkbox>
                        <Checkbox label="2">已结项（未按时上交材料）</Checkbox>
                        <Checkbox label="3">已结项（退回修改）</Checkbox>
                        <Checkbox label="4">撤项</Checkbox>
                        <Checkbox label="5">获奖</Checkbox>
                    </CheckboxGroup>
                </Form-item>
            </div>

            <div v-else-if="this.id!=null">
                <Form-item label="项目状态：" prop="xiangMuZhuangTai">
                    <i-select v-model="kyxm.xiangMuZhuangTai" :disabled="isview" placeholder="请选择" style="width:200px">
                        <i-option value="0">立项</i-option>
                        <i-option value="1">已结项</i-option>
                        <i-option value="2">已结项（未按时上交材料）</i-option>
                        <i-option value="3">已结项（退回修改）</i-option>
                        <i-option value="4">撤项</i-option>
                        <i-option value="5">获奖</i-option>
                    </i-select>
                </Form-item>
            </div>



            <Row>
                <i-col span="11">
                    <Form-item label="是否由院科研主管部门管理：" prop="isYuanKeYanZuGuanBmgl">
                        <i-select v-model="kyxm.isYuanKeYanZuGuanBmgl" :disabled="isview" placeholder="请选择" style="width:200px">
                            <i-option value="0">是</i-option>
                            <i-option value="1">否</i-option>
                        </i-select>
                    </Form-item>
                </i-col>

                <i-col span="11">
                    <Form-item label="是否为本人指导的学生科研项目：" prop="isBenRenZhiDao">
                        <i-select v-model="kyxm.isBenRenZhiDao" :disabled="isview" placeholder="请选择" style="width:200px">
                            <i-option value="0">是</i-option>
                            <i-option value="1">否</i-option>
                        </i-select>
                    </Form-item>
                </i-col>
            </Row>

            <Row>
                <i-col span="11">
                    <Form-item label="项目获奖级别：" prop="XiangMuHuoJiangJiBie">
                        <i-select v-model="kyxm.xiangMuHuoJiangJiBie" :disabled="isview" placeholder="请选择" style="width:200px">
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
                </i-col>
                <i-col span="11">
                    <Form-item label="项目获奖时间：" prop="XiangMuHuoJiangTime">
                        <Date-picker type="date" placeholder="选择日期" :disabled="isview" v-model="kyxm.xiangMuHuoJiangTime"></Date-picker>
                    </Form-item>
                </i-col>
            </Row>

            <Form-item label="项目获奖称号：" prop="XiangMuHuoJiangMingCheng">
                <i-input v-model="kyxm.xiangMuHuoJiangMingCheng"
                         :disabled="isview"
                         :maxlength="50"
                         placeholder="请填写项目获奖称号"></i-input>
            </Form-item>

            <Form-item label="项目获奖证书编号：" prop="XiangMuHuoJiangZhengShuId">
                <i-input v-model="kyxm.xiangMuHuoJiangZhengShuId"
                         :disabled="isview"
                         :maxlength="50"
                         placeholder="请填写项目获奖证书编号"></i-input>
            </Form-item>

            <Row>
                <i-col span="11">
                    <Form-item label="项目成果采纳级别：" prop="xiangMuChengGuoCaiNaJiBie">
                        <i-select v-model="kyxm.xiangMuChengGuoCaiNaJiBie" :disabled="isview" placeholder="请选择" style="width:200px">
                            <i-option value="0">国家采纳</i-option>
                            <i-option value="1">省（部）采纳</i-option>
                            <i-option value="2">局采纳</i-option>
                            <i-option value="3">本院采纳</i-option>
                            <i-option value="4">未采纳</i-option>
                        </i-select>
                    </Form-item>
                </i-col>
                <i-col span="11">
                    <Form-item label="项目成果采纳时间：" prop="XiangMuChengGuoCaiNaTime">
                        <Date-picker type="date" :disabled="isview" placeholder="选择日期" v-model="kyxm.xiangMuChengGuoCaiNaTime"></Date-picker>
                    </Form-item>
                </i-col>
            </Row>

            <div v-if="!issee&&!isshenhe&&!iswanjie">
                <Divider>佐证材料如果超过5张，请当做其他附件上传</Divider>
                <div v-if="this.kyxm.isYuanKeYanZuGuanBmgl==1">
                    <Form-item label="立项（结项）材料" prop="fengmianList">
                        <UploadCtrl :type="0"
                                    v-model="fengmianList"
                                    :filelimit="5"
                                    :disabled="isview"
                                    :maxSize="10240"></UploadCtrl>
                    </Form-item>
                </div>
                <Form-item label="获奖证书" prop="fileList">
                    <UploadCtrl :type="0"
                                v-model="fileList"
                                :filelimit="5"
                                :disabled="isview"
                                :maxSize="10240"></UploadCtrl>
                </Form-item>
                <Form-item label="采纳证明" prop="articleList">
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
                    <div v-for="(item,index) in kyxm.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==0">项目申报</span>
                        <img v-if="item.wenJianLeiXing==0"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in kyxm.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==1">获奖证书</span>
                        <img v-if="item.wenJianLeiXing==1"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in kyxm.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==2">采纳证明</span>
                        <img v-if="item.wenJianLeiXing==2"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in kyxm.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==3">文件附件</span>
                        <a v-if="item.wenJianLeiXing==3"
                           :href="item.luJing" target="_blank">{{item.wenJianMingCheng}}</a>
                    </div>

                </Form-item>
            </div>

            <div v-if="isshenhe&&shlx==3">
                <Form-item label="成果分值：" prop="KeYanKaoHeDeFen">
                    <i-input v-model="kyxm.keYanKaoHeDeFen"
                             :maxlength="10"
                             :disabled="isview"></i-input>
                </Form-item>
                <span style="color:red;">

                    总分:  {{getdefen()}}(项目级别分)  +  {{gethuojiangfen()}}(获奖分) + {{getcainafen()}}(采纳分 )={{getzongfen()}} (总分)
                </span>
                <br />
                <span style="color:red;">  成果分值：{{getzongfen()}} (总分) * {{getbilv()}}（本人署名排序） = {{getjisuanfen()}}  </span>
            </div>

            <Form-item>
                <i-button v-if="!isview" type="primary" @click="save(1)" style="margin-right:5px;">提交</i-button>

                <i-button v-if="this.kyxm.status==0||!this.kyxm.status" type="primary" @click="save(0)">暂存</i-button>
            </Form-item>

            <table style="width:100%;">
                <tr>
                    <td v-if="issee" style="vertical-align:top;width:60%;text-align:center">
                        <div v-if="isshenhe">
                            <div v-if="shlx==3">
                                <Form-item label="科研处审核分：" prop="ShenHeJiaKouFen">
                                    <i-input v-model="kyxm.shenHeJiaKouFen"
                                             :maxlength="20"
                                             :disabled="!iswanjie"
                                             placeholder="请填写审核分"></i-input>
                                </Form-item>
                                <Form-item label="科研处审核分说明：" prop="JiaKouFenShuoMing">
                                    <i-input v-model="kyxm.jiaKouFenShuoMing"
                                             :maxlength="50"
                                             type="textarea"
                                             :disabled="!iswanjie"
                                             placeholder="请填写审核分说明"></i-input>
                                </Form-item>
                                <!--<Form-item label="科研处审核得分：" prop="ShenHeDeFen">
                                    <i-input v-model="kyxm.shenHeDeFen"
                                             :maxlength="20"
                                             :disabled="!iswanjie"
                                             placeholder="请填写审核得分"></i-input>
                                </Form-item>-->
                                <!--<Form-item label="考核得分：" prop="ShiJiDeFen">
                                    <i-input v-model="kyxm.shiJiDeFen"
                                             :maxlength="10"
                                             :disabled="!iswanjie"
                                             placeholder="请填写科研考核得分"></i-input>
                                </Form-item>-->
                            </div>

                            <div v-if="iswanjie">
                                <Form-item label="审核(退回)意见：" prop="ShenHeYiJian">
                                    <i-input v-model="sh.shenHeYiJian"
                                             :maxlength="100"
                                             type="textarea"
                                             placeholder="请填写审核(退回)意见"></i-input>
                                </Form-item>
                                <Form-item>
                                    <i-button type="primary" @click="shenhe" style="margin-right:5px;">审核</i-button>
                                    <i-button type="error" @click="tuihui" style="margin-right:5px;">退回</i-button>
                                </Form-item>
                            </div>

                        </div>
                    </td>
                    <td style="vertical-align:top;width:40%;"><shenhe :id="id"></shenhe> </td>
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
                xmzts: [],
                jilu: {},
                sh: [],
                kyxm: {},
                fengmianList: [],
                fileList: [],
                articleList: [],
                wenjianList: [],
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
                    piZunLiXiangBuMen: [
                        { required: true, message: '批准立项部门不能为空', trigger: 'blur' }
                    ],
                    suoShuNianDu: [
                        { required: true, message: '年份不能为空', trigger: 'blur' }
                    ],
                    xiangMuLaiYuan: [
                        { required: true, message: '项目来源不能为空', trigger: 'blur' }
                    ],
                    liXiangShiJian: [
                        { required: true, type: 'date', message: '请选择日期', trigger: 'change' }
                    ],
                    jiHuaWanChengShiJian: [
                        { required: true, type: 'date', message: '请选择日期', trigger: 'change' }
                    ],
                    xiangMuJiBie: [
                        { required: true, message: '请选择项目级别', trigger: 'change' }
                    ],
                    xiangMuLeiBie: [
                        { required: true, message: '请选择项目类别', trigger: 'change' }
                    ],
                    xiangMuMingCheng: [
                        { required: true, message: '项目名称不能为空', trigger: 'blur' }
                    ],
                    yuanNeiXiangMuBianHao: [
                        { required: true, message: '请填写院内项目编号', trigger: 'blur' }
                    ],
                    xiangMuZiZuZongE: [
                        { required: true, message: '资助总额不能为空', trigger: 'blur' }
                    ],
                    benRenShuMingPaiXu: [
                        { required: true, message: '请选择本人署名排序', trigger: 'change' }
                    ],
                    yuanNeiBenRenShuMingPaiXu: [
                        { required: true, message: '请选择院内本人署名排序', trigger: 'change' }
                    ],
                    xiangMuZhuangTai: [
                        { required: true, message: ' ', trigger: 'change' }
                    ],
                    isYuanKeYanZuGuanBmgl: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                    fengmianList: [
                        { required: true, message: '请上传', trigger: 'blur' }
                    ],

                },
            }
        },
        props: ['id', 'isview', 'isshenhe', 'istuihui', 'shlx', 'issee', 'iswanjie'],
        watch: {
            kyxm: {
                deep: true,
                handler(newName, oldName) {

                    this.kyxm.keYanKaoHeDeFen = this.getjisuanfen();
                    // console.log(this.getzongfen(), this.getrensu(), this.kyxm.keYanKaoHeDeFen);
                    this.kyxm.shenHeDeFen = this.kyxm.keYanKaoHeDeFen + this.getjiakoufen();
                },
            },
            xmzts: {
                deep: true,
                handler(newName, oldName) {
                    if (this.xmzts.length > 2) {
                        this.$Message.error('项目状态最多两项');
                    }
                    // console.log(this.xmzts[0], this.xmzts[1]);
                },
            },

        },
        mounted() {
            //console.log(this.id, this.isview)
            if (this.id != null) {
                this.getkyxm();
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
            getkyxm() {
                axios.get('api/Cg_KeYanXiangMu/GetCgkyxmById', {
                    params: {
                        id: this.id,
                    }
                })
                    .then(response => {
                        this.kyxm = response.data.result;
                        this.kyxm.xiangMuJiBie = this.kyxm.xiangMuJiBie + '';
                        this.kyxm.xiangMuLeiBie = this.kyxm.xiangMuLeiBie + '';
                        this.kyxm.xiangMuZhuangTai = this.kyxm.xiangMuZhuangTai + '';
                        this.kyxm.isYuanKeYanZuGuanBmgl = this.kyxm.isYuanKeYanZuGuanBmgl + '';
                        this.kyxm.isBenRenZhiDao = this.kyxm.isBenRenZhiDao + '';
                        this.kyxm.xiangMuHuoJiangJiBie = this.kyxm.xiangMuHuoJiangJiBie + '';
                        this.kyxm.xiangMuChengGuoCaiNaJiBie = this.kyxm.xiangMuChengGuoCaiNaJiBie + '';
                        this.kyxm.xueShengJieXiangDengJi = this.kyxm.xueShengJieXiangDengJi + '';

                        //附件
                        this.kyxm.fuJians.forEach(x => {
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
                        //console.log(this.kyxm.cgCanYuZhes)
                        //参与人员
                        for (var i = 0; i < this.kyxm.cgCanYuZhes.length; i++) {
                            if (this.kyxm.cgCanYuZhes[i].name != null || this.kyxm.cgCanYuZhes[i].name != undefined) {
                                this.canyuzes["ren" + (i + 1)] = this.kyxm.cgCanYuZhes[i].name;
                                if (this.kyxm.cgCanYuZhes[i].isBenYuan == 0) {
                                    this.canyuzes["is" + (i + 1)] = "是";
                                } else {
                                    this.canyuzes["is" + (i + 1)] = "否";
                                }
                            }

                        }

                        //console.log(this.kyxm)
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
                var a = this.xmzts[0], b = -1;
                if (this.xmzts.length > 1) {
                    b = this.xmzts[1];
                }
                axios.post('api/Cg_KeYanXiangMu/SaveCGkyxm', qs.stringify({
                    "entity": this.getbag(num),
                    zhuangtai1: a,
                    zhuangtai2: b,
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
                    cgKeYanXiangMu: this.kyxm,
                    canyuzes: this.request_canyuzes,
                    fengmianList: this.fengmianList,
                    fileList: this.fileList,
                    articleList: this.articleList,
                    wenjianList: this.wenjianList,
                    jilu: this.jilu,
                };
                if (num == 0) {
                    return request_bag;
                } else {
                    if (this.kyxm.piZunLiXiangBuMen == null || this.kyxm.piZunLiXiangBuMen == undefined || this.kyxm.piZunLiXiangBuMen.length == 0) {
                        this.$Message.error('批准立项部门不能为空');
                    } else if (this.kyxm.suoShuNianDu == null || this.kyxm.suoShuNianDu == undefined || this.kyxm.suoShuNianDu.length == 0) {
                        this.$Message.error('所属年度不能为空');
                    } else if (this.kyxm.xiangMuLaiYuan == null || this.kyxm.xiangMuLaiYuan == undefined || this.kyxm.xiangMuLaiYuan.length == 0) {
                        this.$Message.error('科研项目来源不能为空');
                    } else if (this.kyxm.liXiangShiJian == null || this.kyxm.liXiangShiJian == undefined || this.kyxm.liXiangShiJian == "") {
                        this.$Message.error('立项时间不能为空');
                    } else if (this.kyxm.jiHuaWanChengShiJian == null || this.kyxm.jiHuaWanChengShiJian == undefined || this.kyxm.jiHuaWanChengShiJian == "") {
                        this.$Message.error('计划完成时间不能为空');
                    } else if (this.kyxm.xiangMuJiBie == null || this.kyxm.xiangMuJiBie == undefined) {
                        this.$Message.error('请选择项目级别');
                    } else if (this.kyxm.xiangMuLeiBie == null || this.kyxm.xiangMuLeiBie == undefined) {
                        this.$Message.error('请选择项目类别');
                    } else if (this.kyxm.xiangMuMingCheng == null || this.kyxm.xiangMuMingCheng == undefined || this.kyxm.xiangMuMingCheng.length == 0) {
                        this.$Message.error('项目名称不能为空');
                    } else if (this.kyxm.yuanNeiXiangMuBianHao == null || this.kyxm.yuanNeiXiangMuBianHao == undefined || this.kyxm.yuanNeiXiangMuBianHao.length == 0) {
                        this.$Message.error('院内项目编号不能为空');
                    } else if (this.kyxm.xiangMuZiZuZongE == null || this.kyxm.xiangMuZiZuZongE == undefined || this.kyxm.xiangMuZiZuZongE.length == 0) {
                        this.$Message.error('资助总额不能为空');
                    } else if (this.request_canyuzes.length <= 0) {
                        this.$Message.error('请添加项目组成员');
                    } else if (this.kyxm.benRenShuMingPaiXu == null || this.kyxm.benRenShuMingPaiXu == undefined || this.kyxm.benRenShuMingPaiXu.length == 0) {
                        this.$Message.error('本人署名排序不能为空');
                    } else if (this.kyxm.yuanNeiBenRenShuMingPaiXu == null || this.kyxm.yuanNeiBenRenShuMingPaiXu == undefined || this.kyxm.yuanNeiBenRenShuMingPaiXu.length == 0) {
                        this.$Message.error('院内本人署名排序不能为空');
                    } else if (this.xmzts.length < 1 && this.kyxm.xiangMuZhuangTai == undefined) {
                        this.$Message.error('请选择项目状态');
                    } else if (this.xmzts.length > 2) {
                        this.$Message.error('最多只能选择2种项目状态');
                    } else if (this.kyxm.isYuanKeYanZuGuanBmgl == null || this.kyxm.isYuanKeYanZuGuanBmgl == undefined) {
                        this.$Message.error('请选择是否由院科研主管部门管理');
                    } else if (this.fengmianList.length == 0 && this.kyxm.isYuanKeYanZuGuanBmgl == 1) {
                        this.$Message.error('请上传结项材料');
                    } else {
                        return request_bag;
                    }
                }

            },


            shenhe() {
                var request_bag = {
                    cgKeYanXiangMu: this.kyxm,
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
                    cgKeYanXiangMu: this.kyxm,
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
                var defen = 0;
                if (this.kyxm.xiangMuLeiBie != null || this.kyxm.xiangMuLeiBie != undefined) {
                    if (this.kyxm.xiangMuJiBie == 0) {
                        if (this.kyxm.xiangMuLeiBie == 0) {
                            defen += 2000;
                        } else if (this.kyxm.xiangMuLeiBie == 1) {
                            defen += 1500;
                        }
                    } else if (this.kyxm.xiangMuJiBie == 1) {
                        if (this.kyxm.xiangMuLeiBie == 0) {
                            defen += 700;
                        } else if (this.kyxm.xiangMuLeiBie == 1) {
                            defen += 500;
                        }
                    } else if (this.kyxm.xiangMuJiBie == 2) {
                        if (this.kyxm.xiangMuLeiBie == 0) {
                            defen += 340;
                        } else if (this.kyxm.xiangMuLeiBie == 1) {
                            defen += 260;
                        }
                    } else if (this.kyxm.xiangMuJiBie == 3) {
                        if (this.kyxm.xiangMuLeiBie == 0) {
                            defen += 200;
                        } else if (this.kyxm.xiangMuLeiBie == 1) {
                            defen += 150;
                        }
                    }
                }
                return defen;
            },
            gethuojiangfen() {
                var num = 0;
                if (this.kyxm.xiangMuHuoJiangJiBie != null || this.kyxm.xiangMuHuoJiangJiBie != undefined) {
                    if (this.kyxm.xiangMuHuoJiangJiBie == 0) {
                        num += 2500;
                    } else if (this.kyxm.xiangMuHuoJiangJiBie == 1) {
                        num += 2000;
                    } else if (this.kyxm.xiangMuHuoJiangJiBie == 2) {
                        num += 1500;
                    } else if (this.kyxm.xiangMuHuoJiangJiBie == 3) {
                        num += 1000;
                    } else if (this.kyxm.xiangMuHuoJiangJiBie == 4) {
                        num += 1500;
                    } else if (this.kyxm.xiangMuHuoJiangJiBie == 5) {
                        num += 1000;
                    } else if (this.kyxm.xiangMuHuoJiangJiBie == 6) {
                        num += 500;
                    } else if (this.kyxm.xiangMuHuoJiangJiBie == 7) {
                        num += 200;
                    } else if (this.kyxm.xiangMuHuoJiangJiBie == 8) {
                        num += 500;
                    } else if (this.kyxm.xiangMuHuoJiangJiBie == 9) {
                        num += 300;
                    } else if (this.kyxm.xiangMuHuoJiangJiBie == 10) {
                        num += 150;
                    } else if (this.kyxm.xiangMuHuoJiangJiBie == 11) {
                        num += 80;
                    } else if (this.kyxm.xiangMuHuoJiangJiBie == 12) {
                        num += 200;
                    } else if (this.kyxm.xiangMuHuoJiangJiBie == 13) {
                        num += 120;
                    } else if (this.kyxm.xiangMuHuoJiangJiBie == 14) {
                        num += 60;
                    } else if (this.kyxm.xiangMuHuoJiangJiBie == 15) {
                        num += 20;
                    }
                }
                return num;
            },
            getcainafen() {
                var num = 0;
                if (this.kyxm.xiangMuChengGuoCaiNaJiBie != null || this.kyxm.xiangMuChengGuoCaiNaJiBie != undefined) {
                    if (this.kyxm.xiangMuChengGuoCaiNaJiBie == 0) {
                        num += 500;
                    } else if (this.kyxm.xiangMuChengGuoCaiNaJiBie == 1) {
                        num += 200;
                    } else if (this.kyxm.xiangMuChengGuoCaiNaJiBie == 2) {
                        num += 100;
                    } else if (this.kyxm.xiangMuChengGuoCaiNaJiBie == 3) {
                        num += 50;
                    }
                }
                return num;
            },
            getjiakoufen() {
                var num = 0;
                if (this.kyxm.shenHeJiaKouFen != null || this.kyxm.shenHeJiaKouFen != undefined) {
                    num = parseInt(this.kyxm.shenHeJiaKouFen);
                }
                return num;
            },

            getzongfen() {
                var num = 0;
                num = this.getdefen() + this.gethuojiangfen() + this.getcainafen();
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
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return zongfen * 1;
                    } else {
                        return zongfen * 0;
                    }
                } else if (ren == 2) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.6;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.4;
                    } else {
                        return 0;
                    }
                } else if (ren == 3) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.3;
                    } else if (this.kyxm.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.2;
                    } else {
                        return 0;
                    }
                } else if (ren == 4) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.25;
                    } else if (this.kyxm.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.15;
                    } else if (this.kyxm.benRenShuMingPaiXu == 4) {
                        return zongfen * 0.1;
                    } else {
                        return 0;
                    }
                } else if (ren == 5) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.25;
                    } else if (this.kyxm.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.15;
                    } else if (this.kyxm.benRenShuMingPaiXu == 4 || this.kyxm.benRenShuMingPaiXu == 5) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 6) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.2;
                    } else if (this.kyxm.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.15;
                    } else if (this.kyxm.benRenShuMingPaiXu == 4 || this.kyxm.benRenShuMingPaiXu == 5 || this.kyxm.benRenShuMingPaiXu == 6) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 7) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2 || this.kyxm.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.15;
                    } else if (this.kyxm.benRenShuMingPaiXu == 4 || this.kyxm.benRenShuMingPaiXu == 5 || this.kyxm.benRenShuMingPaiXu == 6 || this.kyxm.benRenShuMingPaiXu == 7) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 8) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.15;
                    } else if (this.kyxm.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.1;
                    } else if (this.kyxm.benRenShuMingPaiXu == 4 || this.kyxm.benRenShuMingPaiXu == 5 || this.kyxm.benRenShuMingPaiXu == 6 || this.kyxm.benRenShuMingPaiXu == 7 || this.kyxm.benRenShuMingPaiXu == 8) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 9) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2 || this.kyxm.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.1;
                    } else if (this.kyxm.benRenShuMingPaiXu == 4 || this.kyxm.benRenShuMingPaiXu == 5 || this.kyxm.benRenShuMingPaiXu == 6 || this.kyxm.benRenShuMingPaiXu == 7 || this.kyxm.benRenShuMingPaiXu == 8 || this.kyxm.benRenShuMingPaiXu == 9) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 10) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.1;
                    } else if (this.kyxm.benRenShuMingPaiXu == 3 || this.kyxm.benRenShuMingPaiXu == 4 || this.kyxm.benRenShuMingPaiXu == 5 || this.kyxm.benRenShuMingPaiXu == 6 || this.kyxm.benRenShuMingPaiXu == 7 || this.kyxm.benRenShuMingPaiXu == 8 || this.kyxm.benRenShuMingPaiXu == 9 || this.kyxm.benRenShuMingPaiXu == 10) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 11) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2 || this.kyxm.benRenShuMingPaiXu == 3 || this.kyxm.benRenShuMingPaiXu == 4 || this.kyxm.benRenShuMingPaiXu == 5 || this.kyxm.benRenShuMingPaiXu == 6 || this.kyxm.benRenShuMingPaiXu == 7 || this.kyxm.benRenShuMingPaiXu == 8 || this.kyxm.benRenShuMingPaiXu == 9 || this.kyxm.benRenShuMingPaiXu == 10) {
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
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return 1;
                    } else {
                        return 0;
                    }
                } else if (ren == 2) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return 0.6;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2) {
                        return 0.4;
                    } else {
                        return 0;
                    }
                } else if (ren == 3) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2) {
                        return 0.3;
                    } else if (this.kyxm.benRenShuMingPaiXu == 3) {
                        return 0.2;
                    } else {
                        return 0;
                    }
                } else if (ren == 4) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2) {
                        return 0.25;
                    } else if (this.kyxm.benRenShuMingPaiXu == 3) {
                        return 0.15;
                    } else if (this.kyxm.benRenShuMingPaiXu == 4) {
                        return 0.1;
                    } else {
                        return 0;
                    }
                } else if (ren == 5) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2) {
                        return 0.25;
                    } else if (this.kyxm.benRenShuMingPaiXu == 3) {
                        return 0.15;
                    } else if (this.kyxm.benRenShuMingPaiXu == 4 || this.kyxm.benRenShuMingPaiXu == 5) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 6) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2) {
                        return 0.2;
                    } else if (this.kyxm.benRenShuMingPaiXu == 3) {
                        return 0.15;
                    } else if (this.kyxm.benRenShuMingPaiXu == 4 || this.kyxm.benRenShuMingPaiXu == 5 || this.kyxm.benRenShuMingPaiXu == 6) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 7) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2 || this.kyxm.benRenShuMingPaiXu == 3) {
                        return 0.15;
                    } else if (this.kyxm.benRenShuMingPaiXu == 4 || this.kyxm.benRenShuMingPaiXu == 5 || this.kyxm.benRenShuMingPaiXu == 6 || this.kyxm.benRenShuMingPaiXu == 7) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 8) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2) {
                        return 0.15;
                    } else if (this.kyxm.benRenShuMingPaiXu == 3) {
                        return 0.1;
                    } else if (this.kyxm.benRenShuMingPaiXu == 4 || this.kyxm.benRenShuMingPaiXu == 5 || this.kyxm.benRenShuMingPaiXu == 6 || this.kyxm.benRenShuMingPaiXu == 7 || this.kyxm.benRenShuMingPaiXu == 8) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 9) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2 || this.kyxm.benRenShuMingPaiXu == 3) {
                        return 0.1;
                    } else if (this.kyxm.benRenShuMingPaiXu == 4 || this.kyxm.benRenShuMingPaiXu == 5 || this.kyxm.benRenShuMingPaiXu == 6 || this.kyxm.benRenShuMingPaiXu == 7 || this.kyxm.benRenShuMingPaiXu == 8 || this.kyxm.benRenShuMingPaiXu == 9) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 10) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2) {
                        return 0.1;
                    } else if (this.kyxm.benRenShuMingPaiXu == 3 || this.kyxm.benRenShuMingPaiXu == 4 || this.kyxm.benRenShuMingPaiXu == 5 || this.kyxm.benRenShuMingPaiXu == 6 || this.kyxm.benRenShuMingPaiXu == 7 || this.kyxm.benRenShuMingPaiXu == 8 || this.kyxm.benRenShuMingPaiXu == 9 || this.kyxm.benRenShuMingPaiXu == 10) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 11) {
                    if (this.kyxm.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.kyxm.benRenShuMingPaiXu == 2 || this.kyxm.benRenShuMingPaiXu == 3 || this.kyxm.benRenShuMingPaiXu == 4 || this.kyxm.benRenShuMingPaiXu == 5 || this.kyxm.benRenShuMingPaiXu == 6 || this.kyxm.benRenShuMingPaiXu == 7 || this.kyxm.benRenShuMingPaiXu == 8 || this.kyxm.benRenShuMingPaiXu == 9 || this.kyxm.benRenShuMingPaiXu == 10) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else {
                    return 0;
                }

            },

            rowClassName(row, index) {
                var timenow = new Date();
                var time = new Date(row.endDateTime);
                // console.log(this.DateDifference(timenow, time))
                if (this.DateDifference(timenow, time) >= 0 && this.DateDifference(timenow, time) <= 30) {
                    return 'demo-table-error-row';
                }
                return '';
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

    /deep/ .ivu-select-selected-value {
        background-color: #ffffff;
        color: #b1b1b1;
    }

    /deep/ .ivu-select-placeholder {
        background-color: #ffffff;
        color: #b1b1b1;
    }
    /*/deep/ .ivu-form-item-required .ivu-form-item-label:before {
        content: '*';
        display: inline-block;
        margin-right: 4px;
        line-height: 1;
        font-family: SimSun;
        font-size: 12px;
        color: #f30
    }*/


</style>