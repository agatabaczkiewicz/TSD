import { Component, OnInit } from '@angular/core';
import {NOTES} from "../../data/notes";
import {NoteService} from "../../services/note.service";
import {NoteModel} from "../../models/note.model";

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {


  notes:NoteModel[]=[];
  constructor(private noteService: NoteService,
              ) { }

  ngOnInit(): void {
    this.noteService.getNotes().subscribe(notes => this.notes = notes);
  }

}
