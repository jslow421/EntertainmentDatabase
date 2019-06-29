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
            <h3>Found {{ numberOfMovies }} movie(s)</h3>

            <v-data-table :items="movies" :headers="headers" class="elevation-1">
                <!--suppress XmlUnboundNsPrefix -->
                <template v-slot:items="props">
                    <td>{{ props.item.title }}</td>
                    <td class="text-xs-right">{{ props.item.ean }}</td>
                    <td class="text-xs-right">{{ props.item.upc }}</td>
                    <td class="text-xs-left">{{ props.item.description }}</td>

                </template>
            </v-data-table>
        </v-container>
    </div>
</template>

<script>
    import {MovieRestApiService} from "@/api-services";

    export default {
        name: "Movies",

        components: {},

        data() {
            return {
                movies: [],
                numberOfMovies: 0,
                inputUpc: "",
                headers: [
                    {
                        text: 'Title',
                        align: 'left',
                        sortable: false,
                        value: 'title'
                    },
                    {text: 'EAN', value: 'ean'},
                    {text: 'UPC', value: 'upc'},
                    {text: 'Description', value: 'description'}
                ],
            };
        },

        methods: {
            findMovies() {
                MovieRestApiService.getMovies().then(data => {
                    this.movies = data.items;
                    this.numberOfMovies = data.items.length;
                });
            },

            getMovieDataFromService() {
                MovieRestApiService.getMovieByUpc({upc: this.inputUpc}).then(data => {
                    this.movies = data.items;
                    this.numberOfMovies = data.items.length;
                });

                this.inputUpc = "";
            }
        },

        mounted() {
            // this.findMovies();
        }
    };
</script>

<style scoped></style>
