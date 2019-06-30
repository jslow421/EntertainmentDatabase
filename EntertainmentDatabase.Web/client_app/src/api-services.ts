import axios from "axios";

const API_URL = "https://localhost:5001";

export class MovieRestApiService {
  
  public static getMovieByUpc(dto: object) {
    const url = API_URL + "/api/UpcApi/GetDetailsByUpc";
    return axios.post(url, dto).then(response => response.data).catch((error) => console.log(error));
  }
}
