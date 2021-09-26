import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Author } from './author.model';
import { Book } from './book.model';
import { Category } from './category.model';
import { ListAuthorResponse } from './list-author-response.model';
import { ListCategoryResponse } from './list-category-response.model';

@Injectable({
  providedIn: 'root'
})
export class LibraryService {  // Extension metory pro Library

  constructor(private http: HttpClient) { }

  readonly baseUrl = 'http://localhost:63349'
  formData: Book = new Book();
  books: Book[];
  categories: Category[];
  authors: Author[];
  
  public async getCategories(): Promise<Category[]> {  // Načtení kategorií
    this.categories = await (await this.http.get<ListCategoryResponse>(this.baseUrl + '/api/library/list-categories').toPromise()).categories;
    return this.categories;
  }

  public async getAuthors(): Promise<Author[]> {  // Načtení autorů
    this.authors = await (await this.http.get<ListAuthorResponse>(this.baseUrl + '/api/library/list-authors').toPromise()).authors;
    return this.authors;
  }
}
