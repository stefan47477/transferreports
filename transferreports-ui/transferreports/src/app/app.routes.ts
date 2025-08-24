import { Routes } from '@angular/router';
import { TransferFeedComponent } from './pages/transfer-feed/transfer-feed.component';

export const routes: Routes = [
  { path: '', component: TransferFeedComponent },   // landing page
  { path: '**', redirectTo: '' }
];
