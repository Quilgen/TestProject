import { Author } from "./author.model";
import { Book } from "./book.model";
import { Category } from "./category.model";

export class DataResponse {
  pageCount: number;
  books: Book[];
  categories: Category[];
  authors: Author[];
}
