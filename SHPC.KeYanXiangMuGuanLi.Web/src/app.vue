<template>
    <div class="layout">
        <Sider :style="{position: 'fixed', height: '100vh', left: 0, overflow: 'auto',background: '#fff','border-right':'1px solid #f5f7f9'}">
            <Menu :active-name="activeName" theme="light" width="auto" :open-names="['1','2','3','4','5']">
                <Submenu name="1">
                    <template slot="title">
                        <Icon type="ios-navigate"></Icon>
                        个人管理
                    </template>
                    <MenuItem name="xiangmulistgeren" to="xiangmulistgeren">我的立项</MenuItem>
                    <!--<MenuItem name="chengguolistgeren" to="chengguolistgeren">我的成果</MenuItem>-->
                    <MenuItem name="CG_MyList" to="CG_MyList">我的成果</MenuItem>

                    <MenuItem name="JieXianglist" to="JieXianglist">我的结项</MenuItem>

                </Submenu>

                <Submenu name="2">
                    <template slot="title">
                        <Icon type="ios-navigate"></Icon>
                        申请管理
                    </template>
                    <MenuItem name="jiaogongBase" to="jiaogongBase">教工申请</MenuItem>
                    <MenuItem name="studentBase" to="studentBase">学生申请</MenuItem>
                </Submenu>

                <Submenu name="3">
                    <template slot="title">
                        <Icon type="ios-navigate"></Icon>
                        项目管理
                    </template>
                    <MenuItem v-if="kyc" name="xiangmulist" to="xiangmulist">项目列表</MenuItem>
                </Submenu>

                <Submenu name="4">
                    <template slot="title">
                        <Icon type="ios-navigate"></Icon>
                        审核管理
                    </template>

                    <MenuItem v-if="kycs" name="chushen" to="chushen">初审</MenuItem>
                    <MenuItem v-if="bm" name="bumenshenhe" to="bumenshenhe">部门审核</MenuItem>
                    <MenuItem v-if="kyc" name="keyanchuShenHe" to="keyanchuShenHe">科研处审核</MenuItem>
                    <MenuItem v-if="kyc" name="kaizhiList" to="kaizhiList">开支详情</MenuItem>
                </Submenu>

                <Submenu name="5">
                    <template slot="title">
                        <Icon type="ios-navigate"></Icon>
                        成果统计
                    </template>
                    <!--<MenuItem name="ZiDian" to="ZiDian">字典</MenuItem>-->
                    <!--<MenuItem v-if="kyc" name="CG_List" to="CG_List">项目汇总</MenuItem>-->
                    <MenuItem v-if="kyc" name="Cg_TongJi" to="Cg_TongJi">人员分类统计</MenuItem>
                    <MenuItem v-if="kyc" name="Tab_Cgtongji" to="Tab_Cgtongji">成果分类统计</MenuItem>

                    <!--<MenuItem v-if="kyc" name="cheshi" to="cheshi">管理测试</MenuItem>-->
                </Submenu>


            </Menu>
        </Sider>
        <Layout :style="{'margin-left':'200px', minHeight: 'calc(100vh - 3px)', background: '#fff',padding:'20px',height:'100vh'}">
            <router-view style="overflow-y:auto;"></router-view>
        </Layout>
        <iframe ref="ifheartbeat" style="display:none;"></iframe>
    </div>
</template>
<script>
    import Vue from "vue";
    import axios from 'axios';

    export default {
        data() {
            return {
                activeName: 'xiangmulistgeren',
                bm: false,
                kyc: false,
                kycs: false,
            }
        },
        mounted() {
            this.getbumen();
            this.getkyc();
            this.getkycs();
            //this.getids();
            //this.getid();
            this.heartbeat();
            this.$router.push('xiangmulistgeren');

        },
        watch: {
            $route(newVal) {
                if (newVal.name == 'xiangmulistgeren' && this.activeName != 'xiangmulistgeren')
                    this.activeName = 'xiangmulistgeren'
            }
        },
        computed: {

        },
        components: {

        },
        methods: {
            getbumen() {
                axios.get('api/Cg_ShenHe/BumenShenHeQuanXian', {
                    params: {

                    }
                })
                    .then(response => {
                        this.bm = response.data;
                        console.log(this.bm)

                    }).catch(error => {
                        console.log(error);

                    });
            },
            getkyc() {
                axios.get('api/Cg_ShenHe/KeYanChuShenHeQuanXian', {
                    params: {

                    }
                })
                    .then(response => {
                        this.kyc = response.data;
                        console.log(this.kyc)
                    }).catch(error => {
                        console.log(error);

                    });

            },
            getkycs() {
                axios.get('api/Cg_ShenHe/ChuShen', {
                    params: {

                    }
                })
                    .then(response => {
                        this.kycs = response.data.result;
                        console.log(this.kycs)
                    }).catch(error => {
                        console.log(error);

                    });

            },
            getids() {
                //GetList
                axios.get('api/Cg_ShenHe/GetList', {
                    params: {

                    }
                })
                    .then(response => {
                        console.log(response.data.results)
                    }).catch(error => {
                        console.log(error);

                    });
            },
            getid() {
                axios.get('api/Cg_ShenHe/Getid', {
                    params: {

                    }
                })
                    .then(response => {
                        console.log(response.data.result)

                    }).catch(error => {
                        console.log(error);

                    });
            },
            heartbeat() {
                var that = this;
                setInterval(function () {
                    try {
                        var date = new Date();
                        console.log(date);
                        that.$refs.ifheartbeat.src = 'heartbeat.html';
                    } catch (error) {
                        console.log(error);
                    }
                }, 120000);
            }

        }
    };
</script>
<style lang="less">
    .layout {
        height: 100%;
        border: 1px solid #d7dde4;
        background: #f5f7f9;
        position: relative;
        border-radius: 4px;
        overflow: hidden;
    }

    .layout-header-bar {
        background: #fff;
        box-shadow: 0 1px 1px rgba(0,0,0,.1);
    }

    .moduleheader {
        padding: 5px 10px;
        box-shadow: rgba(0, 0, 0, 0.1) 0px 1px 2px 1px;
        font-size: 14px;
        font-weight: 700;
        color: #515a6e;
        position: fixed;
        width: 100%;
        z-index: 100;
        background-color: white;
        top: 0px;
    }

    .modulecontent {
        padding: 43px 10px 10px 10px;
    }

    .FAPDetail {
        width: 100%;
        border: 1px solid #D0D7E5;
        border-left: 0px;
        border-bottom: 0px;
        border-collapse: collapse;
    }

        .FAPDetail .tdTitle {
            font-weight: bolder;
            text-align: right;
            border-left: 1px solid #D0D7E5;
            border-bottom: 1px solid #D0D7E5;
            padding: 3px;
            vertical-align: middle;
        }

        .FAPDetail .tdContent {
            border-left: 1px solid #D0D7E5;
            border-bottom: 1px solid #D0D7E5;
            padding: 3px;
            vertical-align: middle;
            text-align: left;
        }

        .FAPDetail .tdFunctions {
            border-left: 1px solid #D0D7E5;
            border-bottom: 1px solid #D0D7E5;
            background-color: #F7FCFF;
            padding: 3px;
            vertical-align: middle;
        }

    .modalContainer {
        overflow-y: auto;
        overflow-x: hidden;
        margin: -15px;
        padding: 10px;
    }

    .vertical-center-modal {
        display: flex;
        align-items: center;
        justify-content: center;
    }
</style>