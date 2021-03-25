import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranscriptRequestComponent } from './transcript-request.component';



@NgModule({
  declarations: [TranscriptRequestComponent],
  imports: [
    CommonModule
  ],
  exports: [TranscriptRequestComponent]
})
export class TranscriptRequestModule { }
