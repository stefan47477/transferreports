import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { TransferRumor, Credibility } from '../models/transfer-rumor';

export interface RumorQuery {
  player?: string;
  club?: string;
  credibility?: Credibility; // If you prefer numeric: change API to numeric or map here
  take?: number;
  skip?: number;
}

@Injectable({ providedIn: 'root' })
export class TransferService {
  private base = `${environment.apiBaseUrl}/api/rumors`;

  constructor(private http: HttpClient) {}

  listRumors(q: RumorQuery = {}): Observable<TransferRumor[]> {
    let params = new HttpParams();
    if (q.player) params = params.set('player', q.player);
    if (q.club) params = params.set('club', q.club);
    if (q.credibility) params = params.set('credibility', q.credibility);
    if (q.take != null) params = params.set('take', q.take);
    if (q.skip != null) params = params.set('skip', q.skip);
    return this.http.get<TransferRumor[]>(this.base, { params });
  }
}
