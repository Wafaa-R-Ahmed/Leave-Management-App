import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import Leave from '../models/Leave';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public loading: boolean;
  public leaves: Leave[];
  public userId: string;
  public leaveBalance: number;

  constructor(private authorizeService: AuthorizeService, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.loading = true;
    this.authorizeService.getUser().pipe(map(u => u.sub)).subscribe(userId => {
      this.userId = userId;
      http.get<Leave[]>(baseUrl + 'UserLeave/GetUserLeaves/' + this.userId).subscribe(LeavesResult => {
        this.leaves = LeavesResult;
      }, error => {
          if (error.status === 404) {
            this.loading = false
          }
          else
            console.error(error)
      });

      http.get<number>(baseUrl + 'UserLeave/GetUserLeaveBalance/' + this.userId).subscribe(result => {
        this.leaveBalance = result;
        this.loading = false;
      }, error => {
        if (error.status === 404) {
          this.loading = false
        }
        else
          console.error(error)
      });

    });
  }
}
