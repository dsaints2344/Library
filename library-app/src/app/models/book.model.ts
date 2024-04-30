export class Book {
    title: string = "";
    author: string = "";
    publishedDate: Date | null = new Date();
    isbn: string = "";
    categoryId: number | null = null;
    description?: string;
    imgUrl?: string;
}