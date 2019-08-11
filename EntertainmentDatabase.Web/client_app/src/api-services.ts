import axios from "axios";

export class MovieRestApiService {
  
  public static getMovieByUpc(dto: object) {
    const url = "../api/UpcApi/GetDetailsByUpc";
    return axios.post(url, dto).then(response => response.data).catch((error) => console.log(error));
  }
  
  public static saveMovie(dto: object) {
    const url = "../api/UpcApi/SaveNewMovie";
    return axios.post(url, dto).then(response => response.data);
  }
}
