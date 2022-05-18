import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MainPageComponent} from "./components/main-page/main-page.component";
import {AddNoteComponent} from "./components/add-note/add-note.component";
import {NoteComponent} from "./components/note/note.component";

const routes: Routes = [
  {path: '', component: MainPageComponent},
  {path: 'add', component: AddNoteComponent},
  {path: 'notes', component: NoteComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
