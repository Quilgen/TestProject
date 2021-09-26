import { Author } from "./author.model";
import { Category } from "./category.model";

export class Book {
  bookId: number;
  title: string;
  authorId: number;
  authorFullName: string;
  categories: Category[];
  categoryId: number[];
  categoryNames: string;
  releaseDate: number;
}


