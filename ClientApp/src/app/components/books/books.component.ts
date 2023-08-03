import {Component} from '@angular/core';
import {Book} from "../../interfaces/book";
import {BookService} from "../../services/book.service";

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent {

  public books: Book[] = [];

  constructor(private service: BookService) {
    this.service.getAllBooks().subscribe(data => {
      this.books = data;
    })
  }
}
