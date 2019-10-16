<template>
    <v-container fluid fill-height>
        <v-layout align-center justify-center>
            <v-flex xs12 sm8 md4>
                <v-card class="elevation-12">
                    <v-toolbar color="primary" dark flat>
                        <v-toolbar-title>Login form</v-toolbar-title>
                        <v-spacer></v-spacer>
                    </v-toolbar>
                    <v-card-text>
                        <v-form v-on:submit.prevent="login">
                            <v-text-field v-model="username" label="Login" name="login" prepend-icon="person" type="text"></v-text-field>
                            <v-text-field v-model="password" id="password" label="Password" name="password" prepend-icon="lock"
                                          type="password"></v-text-field>
                        </v-form>
                    </v-card-text>
                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn @click="login" color="primary">Login</v-btn>
                    </v-card-actions>
                </v-card>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script lang="ts">
    import {UserRestApiService} from "@/user-api-service";
    import Vue from "vue";
    import router from "@/router";

    export default Vue.extend ({
        props: {
            source: String,
        },
        data: () => ({
            drawer: null,
            isRequestingData: false,
            username: "",
            password: ""
        }),
        methods: {
            async login() {
                this.isRequestingData = true;
                await UserRestApiService.login({username: this.username, password: this.password}).then(() => router.push({path: '/'}));
            }
        }
    });
</script>

<style lang="scss">
    .align-center {
        align-items: first baseline;
    }
</style>