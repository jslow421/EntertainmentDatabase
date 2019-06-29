<template>
    <div>
        <form id="upc-input-form" v-on:submit.prevent="getMovieDataFromService">
            <input type="number" class="upc-input" v-model="inputUpc" placeholder="Enter UPC">
            <button type="submit">Search</button>
        </form>

        <h1>Movie Data</h1>
        <h3>Found {{numberOfMovies}} movie(s)</h3>
        <table class="table table-bordered table-hover">
            <thead>
            <tr>
                <th>Title</th>
                <th>EAN</th>
                <th>UPC</th>
                <th>Description</th>
            </tr>
            </thead>
            <tbody>
            <tr v-for="movie in movies">
                <th>{{ movie.title }}</th>
                <th>{{ movie.ean }}</th>
                <td>{{ movie.upc }}</td>
                <td>{{ movie.description }}</td>
                <td>
                    None Implemented
                </td>
            </tr>
            </tbody>
        </table>
        <div>
        </div>
    </div>
</template>

<script>
    import {MovieRestApiService} from '@/api-services';

    export default {

        name: 'Movies',

        components: {},

        data() {
            return {
                movies: [],
                numberOfMovies: 0,
                inputUpc: '',
            };
        },

        methods: {
            findMovies() {

                MovieRestApiService.getMovies().then((data) => {
                    this.movies = data.items;
                    this.numberOfMovies = data.items.length;
                });
            },

            getMovieDataFromService() {
                MovieRestApiService.getMovieByUpc({upc: this.inputUpc}).then((data) => {
                    this.movies = data.items;
                    this.numberOfMovies = data.items.length;
                });
            },
        },

        mounted() {
            // this.findMovies();
        },
    };
</script>

<style scoped>

</style>