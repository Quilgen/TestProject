import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../shared/book.model';
import { LibraryService } from '../shared/library.service';
import { Category } from '../shared/category.model';
import { Author } from '../shared/author.model';

@Component({  // Routování
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent {
  public mBaseUrl: string;
  public author: Author;

  constructor(
    public service: LibraryService,
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private route: ActivatedRoute,
    private router: Router) {

    this.mBaseUrl = baseUrl;
    this.DataBind();
  }

  private async DataBind(): Promise<void> {  // Načtení dat z BE
    //if (this.author.authorId) {
    //  this.http.get<Book>(this.mBaseUrl + 'api/library/' + this.author.authorId).subscribe(result => {
    //            
    //  }, error => console.error(error));
    //} else {
    this.author = new Author();
    //}
  }

  edit() { // Odeslání dat editace do BE
    this.http.post<Author>(this.mBaseUrl + 'api/library/author/', this.author).subscribe(data => {
      this.router.navigate(['/library']);
    })
  }
}



