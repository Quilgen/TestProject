import { Book } from "./book.model";

export class Author {
  authorId: number;
  firstName: string;
  lastName: string;
  fullName: string;
  books: Book[];
}
