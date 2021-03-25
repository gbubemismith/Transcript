import { CoreModule } from './core/core.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TranscriptRequestModule } from './transcript-request/transcript-request.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, 
    AppRoutingModule, 
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
    TranscriptRequestModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
