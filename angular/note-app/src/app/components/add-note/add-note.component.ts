import { Component, OnInit } from '@angular/core';
import {NoteService} from "../../services/note.service";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.scss']
})
export class AddNoteComponent implements OnInit {

  constructor(
    private noteService: NoteService,
    private router: Router,
  ) { }
  noteDate:Date = new Date;
  noteText:string=''
  ngOnInit(): void {
  }

  addNoteClick(){
    const date = new Date(this.noteDate).toDateString()
    this.noteService.addNote({note: this.noteText,date: date});
    this.router.navigate(["/notes"])
  }

}
