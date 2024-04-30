import axios, { AxiosResponse } from "axios";

const responseBody = <T>(response: AxiosResponse<T>) => response.data; // * Returns data from the request

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    post: <T>(url: string, body: {}) =>
        axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};

// API operations objects

// Books

const Books = {
    list: (params: URLSearchParams) => axios.get<any>('/Book', {})
        .then(responseBody),
    create: (book: any) => requests.post<void>("/Book", book)
}


const agent ={
    Books
};

export default agent;