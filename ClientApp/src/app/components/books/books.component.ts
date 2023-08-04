import {Component} from '@angular/core';
import {Book} from "../../interfaces/book";
import {BookService} from "../../services/book.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent {

  public books: Book[] = [];

  constructor(private service: BookService, private router: Router) {
  }

  ngOnInit() {
    this.service.getAllBooks().subscribe(data => {
      this.books = data;
    })
  }

  showBook(id: number) {
    this.router.navigate(["/show-book/" + id]);
  }

}
