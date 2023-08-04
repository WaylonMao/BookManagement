import {Component} from '@angular/core';
import {Book} from "../../interfaces/book";
import {BookService} from "../../services/book.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-show-book',
  templateUrl: './show-book.component.html',
  styleUrls: ['./show-book.component.css']
})
export class ShowBookComponent {

  book: Book = {} as Book;

  constructor(private service: BookService, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.service.getBookById(this.route.snapshot.params.id).subscribe(data => {
      this.book = data;
    })
  }

}
