<template>
    <div style="padding:10px">
        <i-form :model="ruanjian" :label-width="120" label-position="right"
                :rules="ruleValidate">
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
                <i-input v-model="ruanjian.suoShuNianDu"
                         :maxlength="4"
                         :disabled="isview"
                         placeholder="请填写数字年份,例:2019"></i-input>
            </Form-item>

            <Form-item label="软件（专利）名称：" prop="mingCheng">
                <i-input v-model="ruanjian.mingCheng"
                         :maxlength="50"
                         :disabled="isview"
                         placeholder="请填写软件或专利名称"></i-input>
            </Form-item>

            <Form-item label="类别：" prop="leiXing">
                <i-select v-model="ruanjian.leiXing" :disabled="isview" placeholder="请选择" style="width:200px">
                    <i-option value="0">发明专利</i-option>
                    <i-option value="1">实用新型专利</i-option>
                    <i-option value="2">外观设计专利</i-option>
                    <i-option value="3">软件著作权</i-option>
                </i-select>
            </Form-item>

            <div v-if="ruanjian.leiXing!=3">
                <Row>
                    <i-col span="6">
                        <Form-item label="专利号：" prop="zhuanLiHao">
                            <i-input v-model="ruanjian.zhuanLiHao"
                                     :maxlength="50"
                                     :disabled="isview"
                                     placeholder="请填写专利号"></i-input>
                        </Form-item>
                    </i-col>
                    <i-col span="6">
                        <Form-item label="专利申请日：" prop="zhuanLiShenQingRi">
                            <Date-picker type="date" placeholder="选择日期" :disabled="isview" v-model="ruanjian.zhuanLiShenQingRi"></Date-picker>
                        </Form-item>
                    </i-col>
                </Row>

                <Row>
                    <i-col span="6">
                        <Form-item label="授权公告日：" prop="shouQuanGongGaoRi">
                            <Date-picker type="date" placeholder="选择日期" :disabled="isview" v-model="ruanjian.shouQuanGongGaoRi"></Date-picker>
                        </Form-item>
                    </i-col>
                    <i-col span="6">
                        <Form-item label="证书号：" prop="zhengShuHao">
                            <i-input v-model="ruanjian.zhengShuHao"
                                     :maxlength="50"
                                     :disabled="isview"
                                     placeholder="请填写证书号"></i-input>
                        </Form-item>
                    </i-col>
                </Row>

            </div>

            <div v-else-if="ruanjian.leiXing==3">
                <Row>
                    <i-col span="6">
                        <Form-item label="开发完成日期：" prop="kaiFaWanChengRiQi">
                            <Date-picker type="date" placeholder="选择日期" :disabled="isview" v-model="ruanjian.kaiFaWanChengRiQi"></Date-picker>
                        </Form-item>
                    </i-col>
                    <i-col span="6">
                        <Form-item label="权利取得方式：" prop="quanLiQuDeFangShi">
                            <i-input v-model="ruanjian.quanLiQuDeFangShi"
                                     :maxlength="50"
                                     :disabled="isview"
                                     placeholder="请填写权利取得方式"></i-input>
                        </Form-item>
                    </i-col>
                    <i-col span="6">
                        <Form-item label="权利范围：" prop="quanLiFanWei">
                            <i-input v-model="ruanjian.quanLiFanWei"
                                     :maxlength="50"
                                     :disabled="isview"
                                     placeholder="请填写权利范围"></i-input>
                        </Form-item>

                    </i-col>
                </Row>

                <Row>
                    <i-col span="7">
                        <Form-item label="软件著作权登记号：" prop="dengJiHao">
                            <i-input v-model="ruanjian.dengJiHao"
                                     :maxlength="50"
                                     :disabled="isview"
                                     placeholder="请填写软件著作权登记号"></i-input>
                        </Form-item>
                    </i-col>
                    <i-col span="6">
                        <Form-item label="证书号：" prop="zhengShuHao">
                            <i-input v-model="ruanjian.zhengShuHao"
                                     :maxlength="50"
                                     :disabled="isview"
                                     placeholder="请填写证书号"></i-input>
                        </Form-item>
                    </i-col>
                </Row>

            </div>

            <div>
                <table>
                    <tr>
                        <td style="width:50%;">
                            <Form-item prop="canyuzes">
                                <span slot="label"><b style="font-size:16px;color:red;">*</b> 发明（著作权）人：</span>
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
                        </td>
                        <td style="width:50%;" v-if="ruanjian.leiXing!=3">
                            <Form-item prop="zhuanlis">
                                <span slot="label"><b style="font-size:16px;color:red;">*</b> 权利人：</span>
                                <table>
                                    <tr><th>排序</th> <th>姓名</th> <th>是否本院人员</th> </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>
                                            <i-input v-model="zhuanlis.ren1"
                                                     :disabled="isview"
                                                     :maxlength="10"></i-input>
                                        </td>
                                        <td>
                                            <i-select v-model="zhuanlis.is1"
                                                      :disabled="isview" placeholder="请选择">
                                                <i-option value="是">是</i-option>
                                                <i-option value="否">否</i-option>
                                            </i-select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>2</td>
                                        <td>
                                            <i-input v-model="zhuanlis.ren2"
                                                     :disabled="isview"
                                                     :maxlength="10"></i-input>
                                        </td>
                                        <td>
                                            <i-select v-model="zhuanlis.is2"
                                                      :disabled="isview" placeholder="请选择">
                                                <i-option value="是">是</i-option>
                                                <i-option value="否">否</i-option>
                                            </i-select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>3</td>
                                        <td>
                                            <i-input v-model="zhuanlis.ren3"
                                                     :disabled="isview"
                                                     :maxlength="10"></i-input>
                                        </td>
                                        <td>
                                            <i-select v-model="zhuanlis.is3"
                                                      :disabled="isview" placeholder="请选择">
                                                <i-option value="是">是</i-option>
                                                <i-option value="否">否</i-option>
                                            </i-select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>4</td>
                                        <td>
                                            <i-input v-model="zhuanlis.ren4"
                                                     :disabled="isview"
                                                     :maxlength="10"></i-input>
                                        </td>
                                        <td>
                                            <i-select v-model="zhuanlis.is4"
                                                      :disabled="isview" placeholder="请选择">
                                                <i-option value="是">是</i-option>
                                                <i-option value="否">否</i-option>
                                            </i-select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>5</td>
                                        <td>
                                            <i-input v-model="zhuanlis.ren5"
                                                     :disabled="isview"
                                                     :maxlength="10"></i-input>
                                        </td>
                                        <td>
                                            <i-select v-model="zhuanlis.is5"
                                                      :disabled="isview" placeholder="请选择">
                                                <i-option value="是">是</i-option>
                                                <i-option value="否">否</i-option>
                                            </i-select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>6</td>
                                        <td>
                                            <i-input v-model="zhuanlis.ren6"
                                                     :disabled="isview"
                                                     :maxlength="10"></i-input>
                                        </td>
                                        <td>
                                            <i-select v-model="zhuanlis.is6"
                                                      :disabled="isview" placeholder="请选择">
                                                <i-option value="是">是</i-option>
                                                <i-option value="否">否</i-option>
                                            </i-select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>7</td>
                                        <td>
                                            <i-input v-model="zhuanlis.ren7"
                                                     :disabled="isview"
                                                     :maxlength="10"></i-input>
                                        </td>
                                        <td>
                                            <i-select v-model="zhuanlis.is7"
                                                      :disabled="isview" placeholder="请选择">
                                                <i-option value="是">是</i-option>
                                                <i-option value="否">否</i-option>
                                            </i-select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>8</td>
                                        <td>
                                            <i-input v-model="zhuanlis.ren8"
                                                     :disabled="isview"
                                                     :maxlength="10"></i-input>
                                        </td>
                                        <td>
                                            <i-select v-model="zhuanlis.is8"
                                                      :disabled="isview" placeholder="请选择">
                                                <i-option value="是">是</i-option>
                                                <i-option value="否">否</i-option>
                                            </i-select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>9</td>
                                        <td>
                                            <i-input v-model="zhuanlis.ren9"
                                                     :disabled="isview"
                                                     :maxlength="10"></i-input>
                                        </td>
                                        <td>
                                            <i-select v-model="zhuanlis.is9"
                                                      :disabled="isview" placeholder="请选择">
                                                <i-option value="是">是</i-option>
                                                <i-option value="否">否</i-option>
                                            </i-select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>10</td>
                                        <td>
                                            <i-input v-model="zhuanlis.ren10"
                                                     :disabled="isview"
                                                     :maxlength="10"></i-input>
                                        </td>
                                        <td>
                                            <i-select v-model="zhuanlis.is10"
                                                      :disabled="isview" placeholder="请选择">
                                                <i-option value="是">是</i-option>
                                                <i-option value="否">否</i-option>
                                            </i-select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>11</td>
                                        <td>
                                            <i-input v-model="zhuanlis.ren11"
                                                     :disabled="isview"
                                                     :maxlength="10"></i-input>
                                        </td>
                                        <td>
                                            <i-select v-model="zhuanlis.is11"
                                                      :disabled="isview" placeholder="请选择">
                                                <i-option value="是">是</i-option>
                                                <i-option value="否">否</i-option>
                                            </i-select>
                                        </td>
                                    </tr>
                                </table>
                            </Form-item>
                        </td>
                    </tr>
                </table>
            </div>

            <Row>
                <i-col span="7">
                    <Form-item label="本人署名排序：" prop="benRenShuMingPaiXu">
                        <i-select v-model="ruanjian.benRenShuMingPaiXu" :disabled="isview" placeholder="请选择" style="width:200px">
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
                </i-col>
                <i-col span="7">
                    <Form-item label="院内本人署名排序：" prop="yuanNeiBenRenShuMingPaiXu">
                        <i-select v-model="ruanjian.yuanNeiBenRenShuMingPaiXu" :disabled="isview" placeholder="请选择" style="width:200px">
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
                </i-col>
            </Row>

            <Row>
                <i-col span="7">
                    <Form-item label="应用级别：" prop="YingYongJiBie">
                        <i-select v-model="ruanjian.yingYongJiBie" :disabled="isview" placeholder="请选择" style="width:200px">
                            <i-option value="0">国家应用</i-option>
                            <i-option value="1">省部应用</i-option>
                            <i-option value="2">局应用</i-option>
                            <i-option value="3">院应用</i-option>
                        </i-select>
                    </Form-item>
                </i-col>
                <i-col span="6">
                    <Form-item label="是否行业联合专利（著作权）：" prop="isHangYeLianHeZhuanLi">
                        <i-select v-model="ruanjian.isHangYeLianHeZhuanLi" :disabled="isview" placeholder="请选择" style="width:200px">
                            <i-option value="0">是</i-option>
                            <i-option value="1">否</i-option>
                        </i-select>
                    </Form-item>
                </i-col>
            </Row>

            <div v-if="!issee&&!isshenhe&&!iswanjie">
                <Divider>佐证材料如果超过5张，请当做其他附件上传</Divider>
                <Form-item label="证书" prop="fengmianList">
                    <UploadCtrl :type="0"
                                v-model="fengmianList"
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

                    <div v-for="(item,index) in ruanjian.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==0">证书</span>
                        <img v-if="item.wenJianLeiXing==0"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in ruanjian.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==3">文件附件</span>
                        <a v-if="item.wenJianLeiXing==3"
                           :href="item.luJing" target="_blank">{{item.wenJianMingCheng}}</a>
                    </div>
                </Form-item>
            </div>

            <div v-if="isshenhe&&shlx==3">
                <Form-item label="成果分值：" prop="KeYanKaoHeDeFen">
                    <i-input v-model="ruanjian.keYanKaoHeDeFen"
                             :maxlength="10"
                             :disabled="isview"></i-input>
                </Form-item>
                <span style="color:red;">
                    总分:  {{getdefen()}}(软件类型得分)
                </span>
                <br />
                <span style="color:red;">
                    成果分值：{{getzongfen()}} (总分) * {{getbilv()}}（本人署名排序） = {{getjisuanfen()}}
                </span>

            </div>
            <Form-item>
                <i-button v-if="!isview" type="primary" @click="save(1)">提交</i-button>
                <i-button v-if="this.ruanjian.status==0||!this.ruanjian.status" type="primary" @click="save(0)">暂存</i-button>
            </Form-item>

            <table style="width:100%;">
                <tr>
                    <td v-if="issee" style="vertical-align:top;width:60%;text-align:center">
                        <div v-if="isshenhe">
                            <div v-if="shlx==3">
                                <Form-item label="科研处审核分：" prop="ShenHeJiaKouFen">
                                    <i-input v-model="ruanjian.shenHeJiaKouFen"
                                             :maxlength="20"
                                             :disabled="!iswanjie"
                                             placeholder="请填写审核分"></i-input>
                                </Form-item>
                                <Form-item label="科研处审核分说明：" prop="JiaKouFenShuoMing">
                                    <i-input v-model="ruanjian.jiaKouFenShuoMing"
                                             :maxlength="50"
                                             :disabled="!iswanjie"
                                             type="textarea"
                                             placeholder="请填写审核分说明"></i-input>
                                </Form-item>
                                <!--<Form-item label="科研处审核得分：" prop="ShenHeDeFen">
                            <i-input v-model="ruanjian.shenHeDeFen"
                                     :disabled="!iswanjie"
                                     :maxlength="20"
                                     placeholder="请填写审核得分"></i-input>
                        </Form-item>-->
                                <!--<Form-item label="考核得分：" prop="ShiJiDeFen">
                            <i-input v-model="ruanjian.shiJiDeFen"
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
                                             placeholder="请填写审核意见"></i-input>
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
    import { request } from "https";
    const qs = require('qs');
    export default {
        data() {
            return {
                username: '',
                jilu: {},
                sh: [],
                ruanjian: {},
                fengmianList: [],
                fileList: [],
                articleList: [],
                wenjianList: [],
                zhengshulist: [],
                request_canyuzes: [],
                request_zhuanlis: [],
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
                zhuanlis: {
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
                    mingCheng: [
                        { required: true, message: '软件名称不能为空', trigger: 'blur' }
                    ],
                    suoShuNianDu: [
                        { required: true, message: '所属年度不能为空', trigger: 'blur' }
                    ],
                    huoPiShiJian: [
                        { required: true, type: 'date', message: '请选择日期', trigger: 'change' }
                    ],
                    leiXing: [
                        { required: true, message: '请选择类型', trigger: 'change' }
                    ],
                    dengJiHao: [
                        { required: true, message: '登记号不能为空', trigger: 'blur' }
                    ],
                    zhuanLiHao: [
                        { required: true, message: '专利号不能为空', trigger: 'blur' }
                    ],
                    zhengShuHao: [
                        { required: true, message: '证书号不能为空', trigger: 'blur' }
                    ],
                    quanLiQuDeFangShi: [
                        { required: true, message: '权利取得方式不能为空', trigger: 'blur' }
                    ],
                    quanLiFanWei: [
                        { required: true, message: '权利范围不能为空', trigger: 'blur' }
                    ],
                    zhuanLiShenQingRi: [
                        { required: true, type: 'date', message: '请选择日期', trigger: 'change' }],
                    shouQuanGongGaoRi: [
                        { required: true, type: 'date', message: '请选择日期', trigger: 'change' }],
                    kaiFaWanChengRiQi: [
                        { required: true, type: 'date', message: '请选择日期', trigger: 'change' }],
                    benRenShuMingPaiXu: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                    yuanNeiBenRenShuMingPaiXu: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                    isHangYeLianHeZhuanLi: [
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
            ruanjian: {
                deep: true,
                handler(newName, oldName) {
                    this.ruanjian.keYanKaoHeDeFen = this.getjisuanfen();
                    this.ruanjian.shenHeDeFen = this.ruanjian.keYanKaoHeDeFen + this.getjiakoufen();
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
                axios.get('api/Cg_RuanJian/GetCgRuanJianById', {
                    params: {
                        id: this.id,
                    }
                })
                    .then(response => {
                        this.ruanjian = response.data.result;
                        this.ruanjian.leiXing = this.ruanjian.leiXing + '';
                        this.ruanjian.yingYongJiBie = this.ruanjian.yingYongJiBie + '';
                        this.ruanjian.isHangYeLianHeZhuanLi = this.ruanjian.isHangYeLianHeZhuanLi + '';
                        //console.log(this.ruanjian)
                        //附件
                        this.ruanjian.fuJians.forEach(x => {
                            if (x.wenJianLeiXing == 0) {
                                this.fengmianList.push(x);
                            } else if (x.wenJianLeiXing == 1) {
                                this.fileList.push(x);
                            } else if (x.wenJianLeiXing == 2) {
                                this.articleList.push(x);
                            } else if (x.wenJianLeiXing == 5) {
                                this.zhengshulist.push(x);
                            } else if (x.wenJianLeiXing == 3) {
                                this.wenjianList.push(x);
                            }
                        })

                        //参与人员
                        for (var i = 0; i < this.ruanjian.cgCanYuZhes.length; i++) {
                            if (this.ruanjian.cgCanYuZhes[i].name != null || this.ruanjian.cgCanYuZhes[i].name != undefined || this.ruanjian.cgCanYuZhes[i].name != "") {
                                this.canyuzes["ren" + (i + 1)] = this.ruanjian.cgCanYuZhes[i].name;
                                if (this.ruanjian.cgCanYuZhes[i].isBenYuan == 0) {
                                    this.canyuzes["is" + (i + 1)] = "是";
                                } else {
                                    this.canyuzes["is" + (i + 1)] = "否";
                                }
                            }

                        }
                        //专利人员
                        for (var i = 0; i < this.ruanjian.cgzhuanlis.length; i++) {
                            if (this.ruanjian.cgzhuanlis[i].name != null || this.ruanjian.cgzhuanlis[i].name != undefined) {
                                this.zhuanlis["ren" + (i + 1)] = this.ruanjian.cgzhuanlis[i].name;
                                if (this.ruanjian.cgCanYuZhes[i].isBenYuan == 0) {
                                    this.zhuanlis["is" + (i + 1)] = "是";
                                } else {
                                    this.zhuanlis["is" + (i + 1)] = "否";
                                }
                            }
                        }

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

                axios.post('api/Cg_RuanJian/SaveCgRuanJian', qs.stringify({
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
                var arr2 = [
                    {
                        name: this.zhuanlis.ren1,
                        isbenyuan: this.zhuanlis.is1,
                    },
                    {
                        name: this.zhuanlis.ren2,
                        isbenyuan: this.zhuanlis.is2,
                    },
                    {
                        name: this.zhuanlis.ren3,
                        isbenyuan: this.zhuanlis.is3,
                    },
                    {
                        name: this.canyuzes.ren4,
                        isbenyuan: this.canyuzes.is4,
                    },
                    {
                        name: this.zhuanlis.ren5,
                        isbenyuan: this.zhuanlis.is5,
                    },
                    {
                        name: this.zhuanlis.ren6,
                        isbenyuan: this.zhuanlis.is6,
                    },
                    {
                        name: this.zhuanlis.ren7,
                        isbenyuan: this.zhuanlis.is7,
                    },
                    {
                        name: this.zhuanlis.ren8,
                        isbenyuan: this.zhuanlis.is8,
                    },
                    {
                        name: this.zhuanlis.ren9,
                        isbenyuan: this.zhuanlis.is9,
                    },
                    {
                        name: this.zhuanlis.ren10,
                        isbenyuan: this.zhuanlis.is10,
                    },
                    {
                        name: this.zhuanlis.ren11,
                        isbenyuan: this.zhuanlis.is11,
                    }
                ];
                this.request_canyuzes = [];
                this.request_zhuanlis = [];
                arr.forEach(x => {
                    if (x.name != null && x.isbenyuan != null) {
                        this.request_canyuzes.push(x)
                    } else if (x.name != null && x.isbenyuan == null) {
                        this.$Message.error('请选择是否本院人员');
                    }
                });
                arr2.forEach(x => {
                    if (x.name != null && x.isbenyuan != null) {
                        this.request_zhuanlis.push(x)
                    } else if (x.name != null && x.isbenyuan == null) {
                        this.$Message.error('请选择是否本院人员');
                    }
                });
                var request_bag = {
                    CgRuanJianYuZhuanLi: this.ruanjian,
                    canyuzes: this.request_canyuzes,
                    zhuanlis: this.request_zhuanlis,
                    fengmianList: this.fengmianList,
                    fileList: this.fileList,
                    articleList: this.articleList,
                    wenjianList: this.wenjianList,
                    zhengshulist: this.zhengshulist,
                    jilu: this.jilu
                };
                if (num == 0) {
                    return request_bag;
                } else {
                    if (this.ruanjian.mingCheng == null || this.ruanjian.mingCheng == undefined || this.ruanjian.mingCheng.length == 0) {
                        this.$Message.error('软件名称不能为空');
                    }else if (this.ruanjian.suoShuNianDu == null || this.ruanjian.suoShuNianDu == undefined|| this.ruanjian.suoShuNianDu.length == 0) {
                        this.$Message.error('所属年度不能为空');
                    }
                    else if (this.ruanjian.leiXing == null || this.ruanjian.leiXing == undefined) {
                        this.$Message.error('请选择类别');
                    } else if (this.request_canyuzes.length <= 0) {
                        this.$Message.error('请添加发明（著作权）人');
                    } else if (this.ruanjian.benRenShuMingPaiXu == null || this.ruanjian.benRenShuMingPaiXu == undefined || this.ruanjian.benRenShuMingPaiXu.length == 0) {
                        this.$Message.error('本人署名排序不能为空');
                    } else if (this.ruanjian.isHangYeLianHeZhuanLi == null || this.ruanjian.isHangYeLianHeZhuanLi == undefined) {
                        this.$Message.error('请选择是否行业联合专利');
                    } else if (this.fengmianList.length == 0) {
                        this.$Message.error('请上传附件');
                    } else {
                        return request_bag;
                    }
                }
            },

            getdefen() {
                var num = 0;
                if (this.ruanjian.leiXing != null || this.ruanjian.leiXing != undefined) {
                    if (this.ruanjian.leiXing == 0) {
                        num += 300;
                    } else if (this.ruanjian.leiXing == 1) {
                        num += 200;
                    } else if (this.ruanjian.leiXing == 2) {
                        num += 100;
                    } else if (this.ruanjian.leiXing == 3) {
                        num += 200;
                    }
                }
                return num;
            },
            getjiakoufen() {
                var num = 0;
                if (this.ruanjian.shenHeJiaKouFen != null || this.ruanjian.shenHeJiaKouFen != undefined) {
                    num = parseInt(this.ruanjian.shenHeJiaKouFen);
                }
                return num;
            },
            getzongfen() {
                var num = 0;
                num = this.getdefen()
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
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return zongfen * 1;
                    } else {
                        return zongfen * 0;
                    }
                } else if (ren == 2) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.6;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.4;
                    } else {
                        return 0;
                    }
                } else if (ren == 3) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.3;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.2;
                    } else {
                        return 0;
                    }
                } else if (ren == 4) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.25;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.15;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 4) {
                        return zongfen * 0.1;
                    } else {
                        return 0;
                    }
                } else if (ren == 5) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.25;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.15;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 4 || this.ruanjian.benRenShuMingPaiXu == 5) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 6) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.2;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.15;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 4 || this.ruanjian.benRenShuMingPaiXu == 5 || this.ruanjian.benRenShuMingPaiXu == 6) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 7) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2 || this.ruanjian.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.15;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 4 || this.ruanjian.benRenShuMingPaiXu == 5 || this.ruanjian.benRenShuMingPaiXu == 6 || this.ruanjian.benRenShuMingPaiXu == 7) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 8) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.15;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.1;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 4 || this.ruanjian.benRenShuMingPaiXu == 5 || this.ruanjian.benRenShuMingPaiXu == 6 || this.ruanjian.benRenShuMingPaiXu == 7 || this.ruanjian.benRenShuMingPaiXu == 8) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 9) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2 || this.ruanjian.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.1;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 4 || this.ruanjian.benRenShuMingPaiXu == 5 || this.ruanjian.benRenShuMingPaiXu == 6 || this.ruanjian.benRenShuMingPaiXu == 7 || this.ruanjian.benRenShuMingPaiXu == 8 || this.ruanjian.benRenShuMingPaiXu == 9) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 10) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.1;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 3 || this.ruanjian.benRenShuMingPaiXu == 4 || this.ruanjian.benRenShuMingPaiXu == 5 || this.ruanjian.benRenShuMingPaiXu == 6 || this.ruanjian.benRenShuMingPaiXu == 7 || this.ruanjian.benRenShuMingPaiXu == 8 || this.ruanjian.benRenShuMingPaiXu == 9 || this.ruanjian.benRenShuMingPaiXu == 10) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 11) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2 || this.ruanjian.benRenShuMingPaiXu == 3 || this.ruanjian.benRenShuMingPaiXu == 4 || this.ruanjian.benRenShuMingPaiXu == 5 || this.ruanjian.benRenShuMingPaiXu == 6 || this.ruanjian.benRenShuMingPaiXu == 7 || this.ruanjian.benRenShuMingPaiXu == 8 || this.ruanjian.benRenShuMingPaiXu == 9 || this.ruanjian.benRenShuMingPaiXu == 10) {
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
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return 1;
                    } else {
                        return 0;
                    }
                } else if (ren == 2) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return 0.6;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2) {
                        return 0.4;
                    } else {
                        return 0;
                    }
                } else if (ren == 3) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2) {
                        return 0.3;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 3) {
                        return 0.2;
                    } else {
                        return 0;
                    }
                } else if (ren == 4) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2) {
                        return 0.25;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 3) {
                        return 0.15;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 4) {
                        return 0.1;
                    } else {
                        return 0;
                    }
                } else if (ren == 5) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2) {
                        return 0.25;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 3) {
                        return 0.15;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 4 || this.ruanjian.benRenShuMingPaiXu == 5) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 6) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2) {
                        return 0.2;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 3) {
                        return 0.15;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 4 || this.ruanjian.benRenShuMingPaiXu == 5 || this.ruanjian.benRenShuMingPaiXu == 6) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 7) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2 || this.ruanjian.benRenShuMingPaiXu == 3) {
                        return 0.15;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 4 || this.ruanjian.benRenShuMingPaiXu == 5 || this.ruanjian.benRenShuMingPaiXu == 6 || this.ruanjian.benRenShuMingPaiXu == 7) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 8) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2) {
                        return 0.15;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 3) {
                        return 0.1;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 4 || this.ruanjian.benRenShuMingPaiXu == 5 || this.ruanjian.benRenShuMingPaiXu == 6 || this.ruanjian.benRenShuMingPaiXu == 7 || this.ruanjian.benRenShuMingPaiXu == 8) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 9) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2 || this.ruanjian.benRenShuMingPaiXu == 3) {
                        return 0.1;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 4 || this.ruanjian.benRenShuMingPaiXu == 5 || this.ruanjian.benRenShuMingPaiXu == 6 || this.ruanjian.benRenShuMingPaiXu == 7 || this.ruanjian.benRenShuMingPaiXu == 8 || this.ruanjian.benRenShuMingPaiXu == 9) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 10) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2) {
                        return 0.1;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 3 || this.ruanjian.benRenShuMingPaiXu == 4 || this.ruanjian.benRenShuMingPaiXu == 5 || this.ruanjian.benRenShuMingPaiXu == 6 || this.ruanjian.benRenShuMingPaiXu == 7 || this.ruanjian.benRenShuMingPaiXu == 8 || this.ruanjian.benRenShuMingPaiXu == 9 || this.ruanjian.benRenShuMingPaiXu == 10) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 11) {
                    if (this.ruanjian.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.ruanjian.benRenShuMingPaiXu == 2 || this.ruanjian.benRenShuMingPaiXu == 3 || this.ruanjian.benRenShuMingPaiXu == 4 || this.ruanjian.benRenShuMingPaiXu == 5 || this.ruanjian.benRenShuMingPaiXu == 6 || this.ruanjian.benRenShuMingPaiXu == 7 || this.ruanjian.benRenShuMingPaiXu == 8 || this.ruanjian.benRenShuMingPaiXu == 9 || this.ruanjian.benRenShuMingPaiXu == 10) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else {
                    return 0;
                }

            },
            tuihui() {
                var request_bag = {
                    CgRuanJianYuZhuanLi: this.ruanjian,
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
                            //this.$router.push('bumenshenhe');
                            this.$emit('close')
                            //this.$router.push({ name: 'xiangmulistgeren' })
                        } else {
                            this.$Message.error('退回失败!');
                        }
                    });
                }
            },
            shenhe() {
                var request_bag = {
                    CgRuanJianYuZhuanLi: this.ruanjian,
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
                        //this.$router.push('bumenshenhe');
                        this.$emit('close')
                        //this.$router.push({ name: 'xiangmulistgeren' })
                    } else {
                        this.$Message.error('审核失败!');
                    }
                });

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