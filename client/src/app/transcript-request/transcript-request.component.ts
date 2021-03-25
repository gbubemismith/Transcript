import { TranscriptRequestService } from './transcript-request.service';
import { Component, OnInit } from '@angular/core';
import { School } from '../shared/models/school';

@Component({
  selector: 'app-transcript-request',
  templateUrl: './transcript-request.component.html',
  styleUrls: ['./transcript-request.component.scss']
})
export class TranscriptRequestComponent implements OnInit {
  schools: School[];

  constructor(private transService: TranscriptRequestService) { }

  ngOnInit(): void {
    this.transService.getSchools().subscribe(response => {
      this.schools = response;
      console.log(this.schools);
    }, error => {
      console.log(error);
    });
  }

}
