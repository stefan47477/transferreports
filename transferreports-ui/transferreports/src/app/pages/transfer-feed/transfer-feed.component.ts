import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { TransferService } from '../../services/transfer.service';
import { TransferRumor } from '../../models/transfer-rumor';
import { TransferCardComponent } from '../../components/transfer-card/transfer-card.component';

@Component({
  selector: 'app-transfer-feed',
  standalone: true,
  imports: [CommonModule, TransferCardComponent],
  templateUrl: './transfer-feed.component.html',
  styleUrls: ['./transfer-feed.component.scss']
})
export class TransferFeedComponent implements OnInit {   // <-- named export
  rumors$!: Observable<TransferRumor[]>;
  constructor(private service: TransferService) {}
  ngOnInit(): void { this.rumors$ = this.service.listRumors({ take: 100 }); }
  trackById = (_: number, r: TransferRumor) => r.id;
}
