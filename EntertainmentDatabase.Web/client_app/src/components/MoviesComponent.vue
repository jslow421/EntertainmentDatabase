<template>
    <div>
        <v-container grid-list-xl>
            <v-layout wrap justify-space-between>
                <v-flex xs12 md4 offset-md4>
                    <v-form ref="form" v-on:submit.prevent="getMovieDataFromService">
                        <v-text-field v-model="inputUpc" label="Upc"></v-text-field>
                    </v-form>
                </v-flex>
            </v-layout>

            <h1>Movie Data</h1>
            <h3>Found {{numberOfMovies}} movie(s)</h3>

            <div class="text-xs-center" v-if="isRequestingData">
                <v-progress-circular indeterminate color="primary"></v-progress-circular>
            </div>
            <div class="text-xs-center">
                <span>{{apiMessage}}</span>
            </div>
            <v-data-table :items="movies" :headers="headers" class="elevation-1" v-if="numberOfMovies > 0">
                <!--suppress XmlUnboundNsPrefix -->
                <template v-slot:items="props">
                    <tr @click="selectMovie(props.item)">
                        <td><img :src="props.item.images[0]" height="100px"></td>
                        <td>{{props.item.title}}</td>
                        <td class="text-xs-right">{{props.item.upc}}</td>
                        <td class="text-xs-right">{{props.item.ean}}</td>
                        <td class="text-xs-left">{{props.item.description}}</td>
                    </tr>
                </template>
            </v-data-table>
            <v-layout wrap justify-space-between v-if="newMovieUpc">
                <v-flex xs12 md4 offset-md4>
                    <v-form ref="form" v-on:submit.prevent="saveMovieData">
                        <v-text-field v-model="newMovieTitle" label="Title"></v-text-field>
                        <v-text-field v-model="newMovieUpc" label="Upc"></v-text-field>
                        <v-text-field v-model="newMovieEan" label="Ean"></v-text-field>
                        <v-textarea
                                name="input-7-1"
                                label="Description"
                                v-model="newMovieDescription"
                        ></v-textarea>
                        <v-btn @click="saveMovieData">submit</v-btn>
                    </v-form>
                </v-flex>
            </v-layout>
        </v-container>
    </div>
</template>

<script>
    import {MovieRestApiService} from "@/api-services";
    import Vue from "vue";

    export default {
        name: "Movies",

        components: {},

        data() {
            return {
                movies: [],
                numberOfMovies: 0,
                inputUpc: "",
                // set value to show spinner while waiting for data
                isRequestingData: false,
                apiMessage: "",
                code: "",
                headers: [
                    {text: 'Image', value: 'image', sortable: false},
                    {
                        text: 'Title',
                        align: 'left',
                        sortable: false,
                        value: 'title'
                    },
                    {text: 'UPC', value: 'upc'},
                    {text: 'EAN', value: 'ean'},
                    {text: 'Description', value: 'description'}
                ],
                newMovieUpc: "",
                newMovieEan: "",
                newMovieTitle: "",
                newMovieDescription: "",
                newMovieImages: [],
            };
        },

        methods: {
            getMovieDataFromService() {
                this.isRequestingData = true;
                // empty object array on search
                this.movies.pop();
                MovieRestApiService.getMovieByUpc({upc: this.inputUpc}).then((data) => {
                    if (data.items) {
                        this.movies = data.items;
                    }
                    this.numberOfMovies = data.total;
                    this.apiMessage = data.message;
                    this.code = data.code;
                }).catch((error) => this.apiMessage = error).finally(() => {
                    // clear input
                    this.inputUpc = "";
                    this.isRequestingData = false;
                });
            },

            selectMovie(item) {
                this.newMovieUpc = item.upc;
                this.newMovieEan = item.ean;
                this.newMovieDescription = item.description;
                this.newMovieImages = item.images;
                this.newMovieTitle = item.title;
            },
            
            saveMovieData() {
                console.log("attempting to save");
                MovieRestApiService.saveMovie({
                    upc: this.newMovieUpc,
                    ean: this.newMovieEan,
                    title: this.newMovieTitle,
                    description: this.newMovieDescription,
                    images: this.newMovieImages
                }).then((data) => console.log(data));
            },
        },

        mounted() {
            // this.findMovies();
        }
    };
</script>

<style scoped lang="scss"></style>
