import { Injectable } from '@angular/core';
import {NOTES} from "../data/notes";
import {NoteModel} from "../models/note.model";
import {BehaviorSubject, Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  notes = new BehaviorSubject<NoteModel[]>(NOTES);
  constructor() { }

  getNotes():Observable<NoteModel[]>{

    return this.notes
  }

  addNote(note:NoteModel){
    NOTES.push(note)
      this.notes.next(NOTES);
  }
}
