import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import Leave from '../models/Leave';


@Component({
  selector: 'app-apply-leave-component',
  templateUrl: './apply-leave.component.html'
})
export class ApplyLeaveComponent {
  reasons: string[];
  model: Leave;
  submitted: boolean;
  userId: string;

  constructor(private authorizeService: AuthorizeService, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.model = new Leave();
    this.submitted = false;

    http.get<any>(baseUrl + 'LeaveReason').subscribe(result => {
      this.reasons = result.map(r => r.Value);
    }, error => console.error(error));

    this.authorizeService.getUser().pipe(map(u => u.sub)).subscribe(userId => {
      this.userId = userId;
      this.model.ApplicationUserId = userId;
    }, error => console.error(error));
  }

  onSubmit() {
    this.submitted = true;
    let _toDate = new Date(this.model.ToDate);
    let _fromDate = new Date(this.model.FromDate);
    this.model.Status = "Submitted";
    this.model.ToDate = _toDate;
    this.model.FromDate = _fromDate; 
    this.model.Duration = (_toDate.valueOf() - _fromDate.valueOf()) / (1000 * 3600 * 24); //in days
    this.model.UpdatedAt = new Date();

    console.log("model", this.model);
    this.http.post(this.baseUrl + 'UserLeave', this.model).subscribe(result => {
       console.log(result);
    }, error => console.error(error));
  }


}