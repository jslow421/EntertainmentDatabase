import axios from "axios";

export class UserRestApiService {

    public static login(dto: object) {
        const url = "../api/LoginApi/Login";
        return axios.post(url, dto).then(response => response.data).catch((error) => console.log(error));
    }
}