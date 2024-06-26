import axios, { AxiosResponse } from "axios";
import { Activity } from "../models/activity";

// const sleep = (delay: number) => {
//     return new Promise((resolve) => {
//         setTimeout(resolve, delay)
//     })
// }

axios.defaults.baseURL = import.meta.env.VITE_API_BASE_URL
// axios.defaults.baseURL = 'http://localhost:5000/api';
//axios.defaults.baseURL = 'http://localhost:8000/api';

axios.interceptors.response.use(async responce => {
    try {
        //await sleep(1000);
        return responce;
    } catch (error) {
        console.log(error);
        return await Promise.reject(error);
    }
})

const responseBody = <T> (responce: AxiosResponse<T>) => responce.data;

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post: <T> (url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T> (url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    del: <T> (url: string) => axios.delete<T>(url).then(responseBody)
}

const Activities = {
    list: () => requests.get<Activity[]>('/activities'),
    details: (id: string) => requests.get<Activity>(`/activities/${id}`),
    create: (activity: Activity) => axios.post<void>('/activities', activity),
    update: (activity: Activity) => axios.put<void>(`/activities/${activity.id}`, activity),
    delete: (id: string) => axios.delete<void>(`/activities/${id}`)


    // details: (id: string) => requests.get<Activity>(`/activities/${id}`),
    // create: (activity: Activity) => requests.post<void>('/activities', activity),
    // update: (activity: Activity) => requests.put<void>(`/activity/${activity.id}`, activity),
    // delete:(id: string) => requests.del<void>(`/activities/${id}`)
}

const agent = {
    Activities
}

export default agent;