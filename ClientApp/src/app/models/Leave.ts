
export default class Leave {
  constructor() {
    this.FromDate = null;
    this.ToDate = null;
    this.Duration = 0;
    this.Reason = "";
    this.Status = "";
    this.ApplicationUserId = "";
    this.CreatedAt = new Date();
    this.UpdatedAt = null;
    this.RemainingLeaveBalance = 0;
    this.IsActive = 1;
  }

  FromDate: Date;
  ToDate: Date;
  Duration: number;
  Reason: string;
  Status: string;
  ApplicationUserId: string;
  CreatedAt: Date;
  UpdatedAt?: Date;
  RemainingLeaveBalance: number;
  IsActive: number;
}
