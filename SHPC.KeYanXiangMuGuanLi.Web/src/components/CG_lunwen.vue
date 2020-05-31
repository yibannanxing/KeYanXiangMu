<template>
    <div style="padding:10px">
        <i-form :model="lunwen" :label-width="120" label-position="right" :rules="ruleValidate">
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
                <i-input v-model="lunwen.suoShuNianDu"
                         :maxlength="4"
                         :disabled="isview"
                         placeholder="请填写数字年份,例:2019"></i-input>
            </Form-item>
            <Form-item label="论文名称：" prop="lunWenMingCheng">
                <i-input v-model="lunwen.lunWenMingCheng"
                         :maxlength="400"
                         :disabled="isview"
                         placeholder="请填写论文名称"></i-input>
            </Form-item>
            <div v-if="false">
                <Form-item label="发表期刊：" prop="faBiaoQiKan">
                    <i-input v-model="lunwen.faBiaoQiKan"
                             :maxlength="50"
                             :disabled="true"
                             placeholder="请填写发表期刊"></i-input>
                </Form-item>
            </div>
            <Row>
                <i-col span="5">
                    <Form-item label="论文类别：" prop="lunWenLeiBie">
                        <i-select v-model="lunwen.lunWenLeiBie" :disabled="isview" placeholder="请选择">
                            <i-option value="0">科研</i-option>
                            <i-option value="1">教学</i-option>
                        </i-select>
                    </Form-item>
                </i-col>
                <i-col span="5">
                    <Form-item label="论文载体：" prop="zaiTiLeiXing">
                        <i-select v-model="lunwen.zaiTiLeiXing" :disabled="isview" placeholder="请选择">
                            <i-option value="0">期刊</i-option>
                            <i-option value="1">报纸</i-option>
                            <i-option value="2">论文集</i-option>
                        </i-select>
                    </Form-item>
                </i-col>
            </Row>


            <div v-if="this.lunwen.zaiTiLeiXing==0">
                <Row>
                    <i-col span="6">
                        <Form-item label="期刊名称：" prop="zaiTiMingCheng">
                            <i-input v-model="lunwen.zaiTiMingCheng"
                                     :maxlength="50"
                                     :disabled="isview"
                                     placeholder="请填写期刊名称"></i-input>
                        </Form-item>
                    </i-col>
                    <i-col span="7">
                        <Form-item label="国际标准刊号：" prop="guoJiBiaoZhunHao">
                            <i-input v-model="lunwen.guoJiBiaoZhunHao"
                                     :maxlength="50"
                                     :disabled="isview"
                                     placeholder="请填写国际标准号"></i-input>
                        </Form-item>
                    </i-col>
                </Row>
                <Row>
                    <i-col span="6">
                        <Form-item label="当年期号：" prop="dangNianQiHao">
                            <i-input v-model="lunwen.dangNianQiHao"
                                     :maxlength="50"
                                     :disabled="isview"
                                     placeholder="请填写当年期号"></i-input>
                        </Form-item>
                    </i-col>
                    <i-col span="6">
                        <Form-item label="发表时间：" prop="faBiaoNianDu">
                            <Date-picker type="date" :disabled="isview" placeholder="选择日期" v-model="lunwen.faBiaoNianDu"></Date-picker>
                        </Form-item>
                    </i-col>
                </Row>

            </div>

            <div v-else-if="this.lunwen.zaiTiLeiXing==1">
                <Row>
                    <i-col span="6">
                        <Form-item label="报纸名称：" prop="zaiTiMingCheng">
                            <i-input v-model="lunwen.zaiTiMingCheng"
                                     :maxlength="50"
                                     :disabled="isview"
                                     placeholder="请填写报纸名称"></i-input>
                        </Form-item>
                    </i-col>
                    <i-col span="6">
                        <Form-item label="发表时间：" prop="faBiaoNianDu">
                            <Date-picker type="date" :disabled="isview" placeholder="选择日期" v-model="lunwen.faBiaoNianDu"></Date-picker>
                        </Form-item>
                    </i-col>
                </Row>
            </div>

            <div v-else-if="this.lunwen.zaiTiLeiXing==2">
                <Row>
                    <i-col span="6">
                        <Form-item label="论文集名称：" prop="zaiTiMingCheng">
                            <i-input v-model="lunwen.zaiTiMingCheng"
                                     :maxlength="50"
                                     :disabled="isview"
                                     placeholder="请填写论文集名称"></i-input>
                        </Form-item>
                    </i-col>
                    <i-col span="6">
                        <Form-item label="出版社：" prop="chuBanSe">
                            <i-input v-model="lunwen.chuBanSe"
                                     :maxlength="50"
                                     :disabled="isview"
                                     placeholder="请填写出版社"></i-input>
                        </Form-item>
                    </i-col>

                    <i-col span="6">
                        <Form-item label="出版时间：" prop="faBiaoNianDu">
                            <Date-picker type="date" :disabled="isview" placeholder="选择日期" v-model="lunwen.faBiaoNianDu"></Date-picker>
                        </Form-item>
                    </i-col>
                </Row>
            </div>

            <Form-item label="认定范围：" prop="lunWenRenDingJiFenLeiXing">
                <i-select v-model="lunwen.lunWenRenDingJiFenLeiXing" :disabled="isview" placeholder="请选择" style="width:500px">
                    <i-option value="0">刊登在《中国社会科学》和《中国科学》刊物上的论文</i-option>
                    <i-option value="1">刊登在《人民日报》等国家级报纸上的论文</i-option>
                    <i-option value="2">《新华文摘》收录的论文全文、“ＳＣＩ”和“ＥＩ”收录的论文</i-option>
                    <i-option value="3">刊登在CSSCI来源期刊上的论文、《中国人民大学报刊复印资料》全文收录的论文、刊登在《解放日报》等省部级报纸上的论文</i-option>
                    <i-option value="4">“ISTP”和“ISR”收录的学术论文</i-option>
                    <i-option value="5">刊登在全国中文核心期刊上的论文</i-option>
                    <i-option value="6">刊登在公安部主管及公安部部属院校正式出版期刊上的论文</i-option>
                    <i-option value="7">刊登在其他正式出版的期刊及公安部内部资料上的论文</i-option>
                    <i-option value="8">正式出版的论文集收录的论文，《新华文摘》、《高等学校文科学报文摘》和《中国社会科学文摘》收录的文摘、省部级单位内部编印的论文集收录的论文</i-option>
                    <i-option value="9">刊登在市局内部资料上的论文、局级单位内部编印的论文集收录的论文</i-option>
                    <i-option value="10">公安院校内部编印的论文集收录的论文</i-option>
                    <i-option value="11">其他正式出版的文摘期刊收录的文摘，正式出版的论文集收录的文摘</i-option>
                    <i-option value="12">正式出版的各类文摘收录的论文题录</i-option>
                    <i-option value="13">报科研处并经专家评审合格的结合本职工作的论文或报告</i-option>
                </i-select>
            </Form-item>

            <Form-item label="收录情况：" prop="shouLuQiangKuang">
                <i-select v-model="lunwen.shouLuQiangKuang" :disabled="isview" placeholder="请选择" style="width:500px">
                    <i-option value="0">SCI（科学引文索引）</i-option>
                    <i-option value="1">SSCI（社会科学引文索引）</i-option>
                    <i-option value="2">EI（工程索引）</i-option>
                    <i-option value="3">CPCI（国际会议录索引）</i-option>
                    <i-option value="4">A&HCI（艺术与人文科学索引）</i-option>
                    <i-option value="5">CSCD（中国科技期刊引证报告）</i-option>
                    <i-option value="6">CSSCI（中文社会科学引文索引）</i-option>
                    <i-option value="7">北大中文核心期刊</i-option>
                    <i-option value="8">无</i-option>
                </i-select>
            </Form-item>

            <Form-item prop="canyuzes">
                <span slot="label"><b style="font-size:16px;color:red;">*</b> 作者：</span>
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
                <i-select v-model="lunwen.benRenShuMingPaiXu" :disabled="isview" placeholder="请选择" style="width:200px">
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
                <i-select v-model="lunwen.isBiaoZhuXueYuan" :disabled="isview" placeholder="请选择" style="width:200px">
                    <i-option value="0">是</i-option>
                    <i-option value="1">否</i-option>
                </i-select>
            </Form-item>
            <Form-item label="论文字数：" prop="lunWenZiShu">
                <i-input v-model="lunwen.lunWenZiShu"
                         :maxlength="20"
                         :disabled="isview"
                         placeholder="请填写论文字数"></i-input>
            </Form-item>

            <Row>
                <i-col span="7">
                    <Form-item label="是否与行业联合发表：" prop="isYuHangYeLianHeFaBiao">
                        <i-select v-model="lunwen.isYuHangYeLianHeFaBiao" :disabled="isview" placeholder="请选择">
                            <i-option value="0">是</i-option>
                            <i-option value="1">否</i-option>
                        </i-select>
                    </Form-item>
                </i-col>
                <i-col span="7">
                    <Form-item label="是否与地方联合发表：" prop="isYuDiFangLianHeFaBiao">
                        <i-select v-model="lunwen.isYuDiFangLianHeFaBiao" :disabled="isview" placeholder="请选择">
                            <i-option value="0">是</i-option>
                            <i-option value="1">否</i-option>
                        </i-select>
                    </Form-item>
                </i-col>
            </Row>

            <Row>
                <i-col span="7">
                    <Form-item label="是否与境外联合发表：" prop="isYuGuoJiLianHeFaBiao">
                        <i-select v-model="lunwen.isYuGuoJiLianHeFaBiao" :disabled="isview" placeholder="请选择">
                            <i-option value="0">是</i-option>
                            <i-option value="1">否</i-option>
                        </i-select>
                    </Form-item>
                </i-col>
                <i-col span="7">
                    <Form-item label="是否跨学科论文：" prop="isKuaXueKeLunWen">
                        <i-select v-model="lunwen.isKuaXueKeLunWen" :disabled="isview" placeholder="请选择">
                            <i-option value="0">是</i-option>
                            <i-option value="1">否</i-option>
                        </i-select>
                    </Form-item>
                </i-col>
            </Row>

            <Form-item label="论文获奖级别：" prop="LunWenHuoJiangJiBie">
                <i-select v-model="lunwen.lunWenHuoJiangJiBie" :disabled="isview" placeholder="请选择" style="width:200px">
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

            <Form-item label="论文获奖称号：" prop="huoJiangMingCheng">
                <i-input v-model="lunwen.huoJiangMingCheng"
                         :disabled="isview"
                         :maxlength="50"
                         placeholder="请填写论文获奖称号"></i-input>
            </Form-item>

            <Form-item label="论文获奖时间：" prop="LunWenHuoJiangShiJian">
                <Date-picker type="date" placeholder="选择日期" :disabled="isview" v-model="lunwen.lunWenHuoJiangShiJian"></Date-picker>
            </Form-item>

            <div v-if="!issee&&!isshenhe&&!iswanjie">
                <Divider>佐证材料如果超过5张，请当做其他附件上传</Divider>
                <Form-item v-if="this.lunwen.zaiTiLeiXing!=1" label="封面" prop="fengmianList">
                    <UploadCtrl :type="0"
                                v-model="fengmianList"
                                :filelimit="5"
                                :disabled="isview"
                                :maxSize="10240"></UploadCtrl>
                </Form-item>

                <Form-item v-if="this.lunwen.zaiTiLeiXing!=1" label="目录" prop="fileList">
                    <UploadCtrl :type="0"
                                v-model="fileList"
                                :filelimit="5"
                                :disabled="isview"
                                :maxSize="10240"></UploadCtrl>
                </Form-item>

                <Form-item v-if="this.lunwen.zaiTiLeiXing!=1" label="版权页" prop="banquanlist">
                    <UploadCtrl :type="0"
                                v-model="banquanlist"
                                :filelimit="5"
                                :disabled="isview"
                                :maxSize="10240"></UploadCtrl>
                </Form-item>


                <Form-item v-if="this.lunwen.zaiTiLeiXing!=1" label="文章页面" prop="articleList">
                    <UploadCtrl :type="0"
                                v-model="articleList"
                                :filelimit="5"
                                :disabled="isview"
                                :maxSize="10240"></UploadCtrl>
                </Form-item>

                <Form-item v-if="this.lunwen.zaiTiLeiXing!=1" label="获奖证书" prop="zhengshulist">
                    <UploadCtrl :type="0"
                                v-model="zhengshulist"
                                :filelimit="5"
                                :disabled="isview"
                                :maxSize="10240"></UploadCtrl>
                </Form-item>

                <Form-item v-if="this.lunwen.zaiTiLeiXing==1" label="报纸页面" prop="baozhilist">
                    <UploadCtrl :type="0"
                                v-model="baozhilist"
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
                    <div v-for="(item,index) in lunwen.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==0">封面</span>
                        <img v-if="item.wenJianLeiXing==0"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in lunwen.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==4">版权页</span>
                        <img v-if="item.wenJianLeiXing==4"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in lunwen.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==1">目录</span>
                        <img v-if="item.wenJianLeiXing==1"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in lunwen.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==2">文章页面</span>
                        <img v-if="item.wenJianLeiXing==2"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in lunwen.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==5">证书</span>
                        <img v-if="item.wenJianLeiXing==5"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in lunwen.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==6">报纸</span>
                        <img v-if="item.wenJianLeiXing==6"
                             :src="item.luJing"
                             style="width:100%;" />
                    </div>

                    <div v-for="(item,index) in lunwen.fuJians" :key="item">
                        <span v-if="item.wenJianLeiXing==3">文件附件</span>
                        <a v-if="item.wenJianLeiXing==3"
                           :href="item.luJing" target="_blank">{{item.wenJianMingCheng}}</a>
                    </div>

                </Form-item>
            </div>

            <div v-if="isshenhe&&shlx==3">
                <Form-item label="成果分值：" prop="KeYanKaoHeDeFen">
                    <i-input v-model="lunwen.keYanKaoHeDeFen"
                             :maxlength="20"
                             :disabled="isview"></i-input>
                </Form-item>
                <span style="color:red;">
                    总分: {{getdefen()}}(认定范围分)  + {{gethuojiangfen()}}(获奖分)= {{getzongfen()}}
                </span>
                <br />
                <span style="color:red;">
                    成果分值：{{getzongfen()}}(总分) *  {{getbilv()}}（本人署名排序） = {{getjisuanfen()}}
                </span>

            </div>

            <Form-item>
                <i-button v-if="!isview" type="primary" @click="save(1)">提交</i-button>
                <i-button v-if="this.lunwen.status==0||!this.lunwen.status" type="primary" @click="save(0)">暂存</i-button>
            </Form-item>

            <table style="width:100%;">
                <tr>
                    <td v-if="issee" style="vertical-align:top;width:60%;text-align:center">
                        <div v-if="isshenhe">
                            <div v-if="shlx==3">
                                <Form-item label="科研处审核分：" prop="ShenHeJiaKouFen">
                                    <i-input v-model="lunwen.shenHeJiaKouFen"
                                             :maxlength="20"
                                             :disabled="!iswanjie"
                                             placeholder="请填写审核分"></i-input>
                                </Form-item>
                                <Form-item label="科研处审核分说明：" prop="JiaKouFenShuoMing">
                                    <i-input v-model="lunwen.jiaKouFenShuoMing"
                                             :maxlength="50"
                                             :disabled="!iswanjie"
                                             type="textarea"
                                             placeholder="请填写审核分说明"></i-input>
                                </Form-item>
                                <!--<Form-item label="科研处审核得分：" prop="ShenHeDeFen">
                                    <i-input v-model="lunwen.shenHeDeFen"
                                             :maxlength="20"
                                             :disabled="!iswanjie"
                                             placeholder="请填写审核得分"></i-input>
                                </Form-item>-->
                                <!--<Form-item label="考核得分：" prop="ShiJiDeFen">
                                    <i-input v-model="lunwen.shiJiDeFen"
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
                    <td style="vertical-align:top;width:40%;"> <shenhe :id="id"></shenhe></td>
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
                lunwen: {},
                fengmianList: [],
                fileList: [],
                articleList: [],
                wenjianList: [],
                banquanlist: [],
                zhengshulist: [],
                baozhilist: [],
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
                    lunWenMingCheng: [
                        { required: true, message: '论文名称不能为空', trigger: 'blur' }
                    ],
                    suoShuNianDu: [
                        { required: true, message: '所属年度不能为空', trigger: 'blur' }
                    ],
                    lunWenLeiBie: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                    faBiaoQiKan: [
                        { required: true, message: '发表期刊不能为空', trigger: 'blur' }
                    ],
                    dangNianQiHao: [
                        { required: true, message: '当年期号不能为空', trigger: 'blur' }
                    ],
                    lunWenRenDingJiFenLeiXing: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                    shouLuQiangKuang: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                    faBiaoNianDu: [
                        { required: true, type: 'date', message: '请选择日期', trigger: 'change' }
                    ],
                    benRenShuMingPaiXu: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                    isBiaoZhuXueYuan: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                    lunWenZiShu: [
                        { required: true, message: '请输入论文字数', trigger: 'blur' }
                    ],
                    isYuHangYeLianHeFaBiao: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                    isYuDiFangLianHeFaBiao: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                    isYuGuoJiLianHeFaBiao: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                    isKuaXueKeLunWen: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                    fengmianList: [
                        { required: true, message: '请上传', trigger: 'blur' }
                    ],
                    fileList: [
                        { required: true, message: '请上传', trigger: 'blur' }
                    ],
                    articleList: [
                        { required: true, message: '请上传', trigger: 'blur' }
                    ],
                    banquanlist: [
                        { required: true, message: '请上传', trigger: 'blur' }
                    ],
                    baozhilist: [
                        { required: true, message: '请上传', trigger: 'blur' }
                    ],
                    zaiTiMingCheng: [
                        { required: true, message: '请输入', trigger: 'blur' }
                    ],
                    guoJiBiaoZhunHao: [
                        { required: true, message: '请输入', trigger: 'blur' }
                    ],
                    chuBanSe: [
                        { required: true, message: '请输入', trigger: 'blur' }
                    ],
                    zaiTiLeiXing: [
                        { required: true, message: '请选择', trigger: 'change' }
                    ],
                },
            }
        },
        props: ['id', 'isview', 'isshenhe', 'istuihui', 'shlx', 'issee', 'iswanjie'],
        watch: {
            lunwen: {
                deep: true,
                handler(newName, oldName) {
                    this.lunwen.keYanKaoHeDeFen = this.getjisuanfen();
                    this.lunwen.shenHeDeFen = this.lunwen.keYanKaoHeDeFen + this.getjiakoufen();
                },
            }
        },
        mounted() {
            //console.log(this.id, this.isview)
            if (this.id != null) {
                this.getlunwen();
                this.getjilu();
            }
            this.getuser();
        },
        computed: {},
        components: {
            UploadCtrl, shenhe
        },
        methods: {
            getlunwen() {
                axios.get('api/Cg_LunWen/GetCgLunWenById', {
                    params: {
                        id: this.id,
                    }
                })
                    .then(response => {
                        this.lunwen = response.data.result;
                        // console.log(this.lunwen);
                        this.lunwen.lunWenLeiBie = this.lunwen.lunWenLeiBie + '';
                        this.lunwen.lunWenRenDingJiFenLeiXing = this.lunwen.lunWenRenDingJiFenLeiXing + '';
                        this.lunwen.shouLuQiangKuang = this.lunwen.shouLuQiangKuang + '';
                        this.lunwen.isBiaoZhuXueYuan = this.lunwen.isBiaoZhuXueYuan + '';
                        this.lunwen.isYuHangYeLianHeFaBiao = this.lunwen.isYuHangYeLianHeFaBiao + '';
                        this.lunwen.isYuDiFangLianHeFaBiao = this.lunwen.isYuDiFangLianHeFaBiao + '';
                        this.lunwen.isYuGuoJiLianHeFaBiao = this.lunwen.isYuGuoJiLianHeFaBiao + '';
                        this.lunwen.isKuaXueKeLunWen = this.lunwen.isKuaXueKeLunWen + '';
                        this.lunwen.lunWenHuoJiangJiBie = this.lunwen.lunWenHuoJiangJiBie + '';
                        this.lunwen.zaiTiLeiXing = this.lunwen.zaiTiLeiXing + '';

                        //附件
                        this.lunwen.fuJians.forEach(x => {
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
                            } else if (x.wenJianLeiXing == 5) {
                                this.zhengshulist.push(x);
                            } else if (x.wenJianLeiXing == 6) {
                                this.baozhilist.push(x);
                            }
                        })

                        //参与人员
                        for (var i = 0; i < this.lunwen.cgCanYuZhes.length; i++) {
                            if (this.lunwen.cgCanYuZhes[i].name != null || this.lunwen.cgCanYuZhes[i].name != undefined) {
                                this.canyuzes["ren" + (i + 1)] = this.lunwen.cgCanYuZhes[i].name;
                                if (this.lunwen.cgCanYuZhes[i].isBenYuan == 0) {
                                    this.canyuzes["is" + (i + 1)] = "是";
                                } else {
                                    this.canyuzes["is" + (i + 1)] = "否";
                                }
                            }

                        }
                        // console.log(this.lunwen)
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

                axios.post('api/Cg_LunWen/SaveCgLunWen', qs.stringify({
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
                    cgLunWen: this.lunwen,
                    canyuzes: this.request_canyuzes,
                    fengmianList: this.fengmianList,
                    fileList: this.fileList,
                    articleList: this.articleList,
                    wenjianList: this.wenjianList,
                    banquanlist: this.banquanlist,
                    zhengshulist: this.zhengshulist,
                    baozhilist: this.baozhilist,
                    jilu: this.jilu
                };
                if (num == 0) {
                    return request_bag;
                } else {
                    if (this.lunwen.lunWenMingCheng == null || this.lunwen.lunWenMingCheng == undefined || this.lunwen.lunWenMingCheng.length == 0) {
                        this.$Message.error('论文名称不能为空');
                    } else if (this.lunwen.suoShuNianDu == null || this.lunwen.suoShuNianDu == undefined || this.lunwen.suoShuNianDu.length == 0) {
                        this.$Message.error('所属年度不能为空');
                    }
                    else if (this.lunwen.lunWenLeiBie == null || this.lunwen.lunWenLeiBie == undefined) {
                        this.$Message.error('请选择论文类别');
                    } else if (this.lunwen.lunWenRenDingJiFenLeiXing == null || this.lunwen.lunWenRenDingJiFenLeiXing == undefined) {
                        this.$Message.error('请选择论文认定范围');
                    } else if (this.lunwen.shouLuQiangKuang == null || this.lunwen.shouLuQiangKuang == undefined) {
                        this.$Message.error('请选择收录情况');
                    } else if (this.lunwen.faBiaoNianDu == null || this.lunwen.faBiaoNianDu == undefined) {
                        this.$Message.error('请选择发表时间');
                    } else if (this.request_canyuzes.length <= 0) {
                        this.$Message.error('请添加作者');
                    } else if (this.lunwen.benRenShuMingPaiXu == null || this.lunwen.benRenShuMingPaiXu == undefined || this.lunwen.benRenShuMingPaiXu.length == 0) {
                        this.$Message.error('本人署名排序不能为空');
                    } else if (this.lunwen.isBiaoZhuXueYuan == null || this.lunwen.isBiaoZhuXueYuan == undefined) {
                        this.$Message.error('请选择是否标注上海公安学校');
                    } else if (this.lunwen.lunWenZiShu == null || this.lunwen.lunWenZiShu == undefined || this.lunwen.lunWenZiShu.length == 0) {
                        this.$Message.error('请输入全书字数');
                    } else if (this.lunwen.isYuHangYeLianHeFaBiao == null || this.lunwen.isYuHangYeLianHeFaBiao == undefined) {
                        this.$Message.error('请选择是否与行业联合发表');
                    } else if (this.lunwen.isYuDiFangLianHeFaBiao == null || this.lunwen.isYuDiFangLianHeFaBiao == undefined) {
                        this.$Message.error('请选择是否与地方联合发表');
                    } else if (this.lunwen.isYuGuoJiLianHeFaBiao == null || this.lunwen.isYuGuoJiLianHeFaBiao == undefined) {
                        this.$Message.error('请选择是否与国际联合发表');
                    } else if (this.lunwen.isKuaXueKeLunWen == null || this.lunwen.isKuaXueKeLunWen == undefined) {
                        this.$Message.error('请选择是否跨学科论文');
                    } else if (this.lunwen.zaiTiLeiXing != 1 && this.fengmianList.length == 0) {
                        this.$Message.error('请上传附件');
                    } else if (this.lunwen.zaiTiLeiXing != 1 && this.fileList.length == 0) {
                        this.$Message.error('请上传附件');
                    } else if (this.lunwen.zaiTiLeiXing != 1 && this.articleList.length == 0) {
                        this.$Message.error('请上传附件');
                    } else if (this.lunwen.zaiTiLeiXing != 1 && this.banquanlist.length == 0) {
                        this.$Message.error('请上传附件');
                    } else if (this.lunwen.zaiTiLeiXing == 1 && this.baozhilist.length == 0) {
                        this.$Message.error('请上传附件');
                    } else {
                        return request_bag;
                    }
                }
            },
            getdefen() {
                var num = 0;
                if (this.lunwen.lunWenRenDingJiFenLeiXing != null || this.lunwen.lunWenRenDingJiFenLeiXing != undefined) {
                    if (this.lunwen.lunWenRenDingJiFenLeiXing == 0) {
                        num += 500;
                    } else if (this.lunwen.lunWenRenDingJiFenLeiXing == 1) {
                        num += 300;
                    } else if (this.lunwen.lunWenRenDingJiFenLeiXing == 2) {
                        num += 200;
                    } else if (this.lunwen.lunWenRenDingJiFenLeiXing == 3) {
                        num += 150;
                    } else if (this.lunwen.lunWenRenDingJiFenLeiXing == 4) {
                        num += 100;
                    } else if (this.lunwen.lunWenRenDingJiFenLeiXing == 5) {
                        num += 80;
                    } else if (this.lunwen.lunWenRenDingJiFenLeiXing == 6) {
                        num += 70;
                    } else if (this.lunwen.lunWenRenDingJiFenLeiXing == 7) {
                        num += 50;
                    } else if (this.lunwen.lunWenRenDingJiFenLeiXing == 8) {
                        num += 40;
                    } else if (this.lunwen.lunWenRenDingJiFenLeiXing == 9) {
                        num += 30;
                    } else if (this.lunwen.lunWenRenDingJiFenLeiXing == 10 || this.lunwen.lunWenRenDingJiFenLeiXing == 11) {
                        num += 10;
                    } else if (this.lunwen.lunWenRenDingJiFenLeiXing == 12 || this.lunwen.lunWenRenDingJiFenLeiXing == 13) {
                        num += 5;
                    }
                }
                return num;
            },
            gethuojiangfen() {
                //zuzuo.zuZhuoHuoJiangJiBie
                var num = 0;
                if (this.lunwen.lunWenHuoJiangJiBie != null || this.lunwen.lunWenHuoJiangJiBie != undefined) {
                    if (this.lunwen.lunWenHuoJiangJiBie == 0) {
                        // num += 2500;
                    } else if (this.lunwen.lunWenHuoJiangJiBie == 1) {
                        //num += 2000;
                    } else if (this.lunwen.lunWenHuoJiangJiBie == 2) {
                        // num += 1500;
                    } else if (this.lunwen.lunWenHuoJiangJiBie == 3) {
                        //num += 1000;
                    } else if (this.lunwen.lunWenHuoJiangJiBie == 4) {
                        num += 300;
                    } else if (this.lunwen.lunWenHuoJiangJiBie == 5) {
                        num += 180;
                    } else if (this.lunwen.lunWenHuoJiangJiBie == 6) {
                        num += 90;
                    } else if (this.lunwen.lunWenHuoJiangJiBie == 7) {
                        num += 30;
                    } else if (this.lunwen.lunWenHuoJiangJiBie == 8) {
                        num += 150;
                    } else if (this.lunwen.lunWenHuoJiangJiBie == 9) {
                        num += 90;
                    } else if (this.lunwen.lunWenHuoJiangJiBie == 10) {
                        num += 45;
                    } else if (this.lunwen.lunWenHuoJiangJiBie == 11) {
                        num += 15;
                    } else if (this.lunwen.lunWenHuoJiangJiBie == 12) {
                        num += 30;
                    } else if (this.lunwen.lunWenHuoJiangJiBie == 13) {
                        num += 18;
                    } else if (this.lunwen.lunWenHuoJiangJiBie == 14) {
                        num += 9;
                    } else if (this.lunwen.lunWenHuoJiangJiBie == 15) {
                        num += 3;
                    }
                }
                return num;

            },
            getjiakoufen() {
                var num = 0;
                if (this.lunwen.shenHeJiaKouFen != null || this.lunwen.shenHeJiaKouFen != undefined) {
                    num = parseInt(this.lunwen.shenHeJiaKouFen);
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
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return zongfen * 1;
                    } else {
                        return zongfen * 0;
                    }
                } else if (ren == 2) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.6;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.4;
                    } else {
                        return 0;
                    }
                } else if (ren == 3) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.3;
                    } else if (this.lunwen.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.2;
                    } else {
                        return 0;
                    }
                } else if (ren == 4) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.25;
                    } else if (this.lunwen.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.15;
                    } else if (this.lunwen.benRenShuMingPaiXu == 4) {
                        return zongfen * 0.1;
                    } else {
                        return 0;
                    }
                } else if (ren == 5) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.25;
                    } else if (this.lunwen.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.15;
                    } else if (this.lunwen.benRenShuMingPaiXu == 4 || this.lunwen.benRenShuMingPaiXu == 5) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 6) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.2;
                    } else if (this.lunwen.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.15;
                    } else if (this.lunwen.benRenShuMingPaiXu == 4 || this.lunwen.benRenShuMingPaiXu == 5 || this.lunwen.benRenShuMingPaiXu == 6) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 7) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2 || this.lunwen.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.15;
                    } else if (this.lunwen.benRenShuMingPaiXu == 4 || this.lunwen.benRenShuMingPaiXu == 5 || this.lunwen.benRenShuMingPaiXu == 6 || this.lunwen.benRenShuMingPaiXu == 7) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 8) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.15;
                    } else if (this.lunwen.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.1;
                    } else if (this.lunwen.benRenShuMingPaiXu == 4 || this.lunwen.benRenShuMingPaiXu == 5 || this.lunwen.benRenShuMingPaiXu == 6 || this.lunwen.benRenShuMingPaiXu == 7 || this.lunwen.benRenShuMingPaiXu == 8) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 9) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2 || this.lunwen.benRenShuMingPaiXu == 3) {
                        return zongfen * 0.1;
                    } else if (this.lunwen.benRenShuMingPaiXu == 4 || this.lunwen.benRenShuMingPaiXu == 5 || this.lunwen.benRenShuMingPaiXu == 6 || this.lunwen.benRenShuMingPaiXu == 7 || this.lunwen.benRenShuMingPaiXu == 8 || this.lunwen.benRenShuMingPaiXu == 9) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 10) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2) {
                        return zongfen * 0.1;
                    } else if (this.lunwen.benRenShuMingPaiXu == 3 || this.lunwen.benRenShuMingPaiXu == 4 || this.lunwen.benRenShuMingPaiXu == 5 || this.lunwen.benRenShuMingPaiXu == 6 || this.lunwen.benRenShuMingPaiXu == 7 || this.lunwen.benRenShuMingPaiXu == 8 || this.lunwen.benRenShuMingPaiXu == 9 || this.lunwen.benRenShuMingPaiXu == 10) {
                        return zongfen * 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 11) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return zongfen * 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2 || this.lunwen.benRenShuMingPaiXu == 3 || this.lunwen.benRenShuMingPaiXu == 4 || this.lunwen.benRenShuMingPaiXu == 5 || this.lunwen.benRenShuMingPaiXu == 6 || this.lunwen.benRenShuMingPaiXu == 7 || this.lunwen.benRenShuMingPaiXu == 8 || this.lunwen.benRenShuMingPaiXu == 9 || this.lunwen.benRenShuMingPaiXu == 10) {
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
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return zongfen * 1;
                    } else {
                        return zongfen * 0;
                    }
                } else if (ren == 2) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return 0.6;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2) {
                        return 0.4;
                    } else {
                        return 0;
                    }
                } else if (ren == 3) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2) {
                        return 0.3;
                    } else if (this.lunwen.benRenShuMingPaiXu == 3) {
                        return 0.2;
                    } else {
                        return 0;
                    }
                } else if (ren == 4) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2) {
                        return 0.25;
                    } else if (this.lunwen.benRenShuMingPaiXu == 3) {
                        return 0.15;
                    } else if (this.lunwen.benRenShuMingPaiXu == 4) {
                        return 0.1;
                    } else {
                        return 0;
                    }
                } else if (ren == 5) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2) {
                        return 0.25;
                    } else if (this.lunwen.benRenShuMingPaiXu == 3) {
                        return 0.15;
                    } else if (this.lunwen.benRenShuMingPaiXu == 4 || this.lunwen.benRenShuMingPaiXu == 5) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 6) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2) {
                        return 0.2;
                    } else if (this.lunwen.benRenShuMingPaiXu == 3) {
                        return 0.15;
                    } else if (this.lunwen.benRenShuMingPaiXu == 4 || this.lunwen.benRenShuMingPaiXu == 5 || this.lunwen.benRenShuMingPaiXu == 6) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 7) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2 || this.lunwen.benRenShuMingPaiXu == 3) {
                        return 0.15;
                    } else if (this.lunwen.benRenShuMingPaiXu == 4 || this.lunwen.benRenShuMingPaiXu == 5 || this.lunwen.benRenShuMingPaiXu == 6 || this.lunwen.benRenShuMingPaiXu == 7) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 8) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2) {
                        return 0.15;
                    } else if (this.lunwen.benRenShuMingPaiXu == 3) {
                        return 0.1;
                    } else if (this.lunwen.benRenShuMingPaiXu == 4 || this.lunwen.benRenShuMingPaiXu == 5 || this.lunwen.benRenShuMingPaiXu == 6 || this.lunwen.benRenShuMingPaiXu == 7 || this.lunwen.benRenShuMingPaiXu == 8) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 9) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2 || this.lunwen.benRenShuMingPaiXu == 3) {
                        return 0.1;
                    } else if (this.lunwen.benRenShuMingPaiXu == 4 || this.lunwen.benRenShuMingPaiXu == 5 || this.lunwen.benRenShuMingPaiXu == 6 || this.lunwen.benRenShuMingPaiXu == 7 || this.lunwen.benRenShuMingPaiXu == 8 || this.lunwen.benRenShuMingPaiXu == 9) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 10) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2) {
                        return 0.1;
                    } else if (this.lunwen.benRenShuMingPaiXu == 3 || this.lunwen.benRenShuMingPaiXu == 4 || this.lunwen.benRenShuMingPaiXu == 5 || this.lunwen.benRenShuMingPaiXu == 6 || this.lunwen.benRenShuMingPaiXu == 7 || this.lunwen.benRenShuMingPaiXu == 8 || this.lunwen.benRenShuMingPaiXu == 9 || this.lunwen.benRenShuMingPaiXu == 10) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else if (ren == 11) {
                    if (this.lunwen.benRenShuMingPaiXu == 1) {
                        return 0.5;
                    } else if (this.lunwen.benRenShuMingPaiXu == 2 || this.lunwen.benRenShuMingPaiXu == 3 || this.lunwen.benRenShuMingPaiXu == 4 || this.lunwen.benRenShuMingPaiXu == 5 || this.lunwen.benRenShuMingPaiXu == 6 || this.lunwen.benRenShuMingPaiXu == 7 || this.lunwen.benRenShuMingPaiXu == 8 || this.lunwen.benRenShuMingPaiXu == 9 || this.lunwen.benRenShuMingPaiXu == 10) {
                        return 0.05;
                    } else {
                        return 0;
                    }
                } else {
                    return 0;
                }

            },
            shenhe() {
                var request_bag = {
                    cgLunWen: this.lunwen,
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
                    cgLunWen: this.lunwen,
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