<template>
    <div style="padding:30px">
       
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
                xiangmufangan: {}
            }
        },
        props: [],
        mounted() {

        },
        computed: {},
        components: {

        },
        methods: {
            save() {
                this.$Message.success('保存成功!');
                this.$emit('close', this.xiangmufangan);
            }
        }
    };
</script>
<style>
</style>