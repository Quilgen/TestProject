import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../shared/book.model';
import { LibraryService } from '../shared/library.service';
import { Category } from '../shared/category.model';
import { Author } from '../shared/author.model';


@Component({ // Routování
  selector: 'app-edit',
  templateUrl: './edit.component.html'
})
export class EditComponent {
  public book: Book;
  public id: string;
  public mBaseUrl: string;
  public mCategories: Category[] = [];
  public mAuthors: Author[] = [];

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
    this.id = this.route.snapshot.paramMap.get('id');
    let lCategories = await this.service.getCategories();
    this.mAuthors = await this.service.getAuthors();

    if (this.id) {
      this.http.get<Book>(this.mBaseUrl + 'api/library/' + this.id).subscribe(result => {
        try {
          this.book = result;
          for (var i = 0; i < lCategories.length; i++) {
            //let lCategory = new Category();
            this.mCategories.push({ categoryId: lCategories[i].categoryId, categoryName: lCategories[i].categoryName, selected: this.book.categoryId ? this.book.categoryId.find(aR => aR == lCategories[i].categoryId) != undefined : false });
            //this.mCategories[i].selected = this.book.categoryId.find(aR => aR == this.mCategories[i].categoryId) != undefined;
          }
        }
        catch (e) {
          console.error(e);
        }
      }, error => console.error(error));
    } else {
      this.book = new Book();
      this.book.authorId = 0;
      this.mCategories = lCategories;
    }
  }

  edit() {  // Odeslaní dat editace do BE
    this.book.categories = this.mCategories.filter(aR => aR.selected);
    this.http.post<Book>(this.mBaseUrl + 'api/library/book/', this.book).subscribe(data => {
      this.router.navigate(['/library']);
    })
  }

  categories(): number[] {
    var data = [];
    var length = this.mCategories.length - 1; // user defined length

    for (var i = 0; i < length; i++) {
      data.push(i);
    }
    return data;
  }

}
