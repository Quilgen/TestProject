import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Book } from '../shared/book.model';
import { LibraryService } from '../shared/library.service';
import { DataRequest } from '../shared/data-request.model';
import { DataResponse } from '../shared/data-response.model';
import { Category } from '../shared/category.model';
import { Author } from '../shared/author.model';



@Component({ // Routování
  selector: 'app-library',
  templateUrl: './library.component.html'
})
export class LibrariesComponent {
  public books: Book[];
  public id: number;
  public mBaseUrl: string;
  public pageCount: number;
  public mDataRequest: DataRequest = new DataRequest();
  //public mCurrentPage: number;
  //public mSearchPhrase: string;
  public mCategories: Category[];
  public mAuthors: Author[];


  constructor(public service: LibraryService, public http: HttpClient, @Inject('BASE_URL') baseUrl: string,
    private route: ActivatedRoute) {
    this.mBaseUrl = baseUrl;
    this.id = parseInt(this.route.snapshot.paramMap.get('id'));
        
    this.mDataRequest.currentPage = 0;  // Nastavení default stránky na 1.
    this.DataBind(); // Volání načtení dat z BE
  }

  delete(aId: number) { // Delete book => BE
    if (confirm("Are you sure to delete this book ?")) {
      this.http.delete<Book>(this.mBaseUrl + 'api/library/' + aId).subscribe(data => {
        //aId = data.id;
        //this.books = this.service.refreshList();
        this.DataBind();
      })
    }
  }

  DataBind(): void {  // Loading data from BackEnd
    this.http.get<DataResponse>(this.mBaseUrl + 'api/library/list-books/' + this.mDataRequest.currentPage + '/' + this.mDataRequest.searchPhrase).subscribe(result => {
      this.books = result.books;
      this.mCategories = result.categories;
      this.mAuthors = result.authors;
      this.pageCount = result.pageCount;
    }, error => console.error(error));
  }

  pageButtons(): number[] { // Výpočet stránkovacích butonů
    var data = [];
    var length = this.pageCount; // user defined length

    for (var i = 0; i < length; i++) {
      data.push(i);
    }
    return data;
  }

  goToPage(index: number) { // Překlikávání mezi stránkami
    this.mDataRequest.currentPage = index;
    this.DataBind();
  }

}


