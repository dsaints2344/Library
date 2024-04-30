import axios, { AxiosResponse } from "axios";
import { BookModel} from "./models/book.model";
import { LoanModel } from "./models/loan.model";

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
    list: () => axios.get<BookModel[]>('/Book', {})
        .then(responseBody),
    create: (book: BookModel) => requests.post<void>("/Book", book),
}

// Loan
const Loan = {
    create: (loan: LoanModel) => axios.post<void>('/Loan', loan),
    reurnLoan: (loan: LoanModel) => axios.post<void>('/return-loan', loan)
}


const agent ={
    Books,
    Loan
};

export default agent;