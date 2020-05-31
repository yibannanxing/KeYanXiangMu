<template>
    <div style="padding:10px">
        <Form :model="niandu" :label-width="80" label-position="right">
            <FormItem label="姓名">
                <i-input v-model="niandu.userName" disabled></i-input>
            </FormItem>
            <FormItem label="部门">
                <i-input v-model="niandu.buMenMingCheng" disabled></i-input>
            </FormItem>
            <FormItem label="年度">
                <i-input v-model="niandu.nianDu" disabled></i-input>
            </FormItem>
            <FormItem label="考核分">
                <i-input v-model="niandu.kaoHeFen"></i-input>
            </FormItem>
            <FormItem>
                <i-button type="primary" @click="submit">提交</i-button>
            </FormItem>
        </Form>
    </div>

</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    const qs = require('qs');
    export default {
        data() {
            return {
                niandu: [],
            }
        },
        props: ['id'],
        mounted() {
            //console.log(this.id);
            if (this.id != null) {
                this.getniandu();
            }

        },
        computed: {},
        components: {

        },
        methods: {
            submit() {
                axios.post('api/Cg_JiLu/UpdateNianDu', qs.stringify({
                    "entity": this.niandu
                })).then(response => {
                    if (!response.data.error) {
                        this.$Message.success('保存成功!');
                        this.$emit('close')
                    } else {
                        this.$Message.error('保存失败!');
                    }
                });
            },
            getniandu() {
                //GetNianDuById
                axios.get('api/Cg_JiLu/GetNianDuById', {
                    params: {
                        id: this.id,
                    }
                })
                    .then(response => {
                        this.niandu = response.data.result;
                    }).catch(error => {
                        console.log(error);
                    });
            },

        }
    };
</script>
<style>
</style>