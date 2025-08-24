import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TransferRumor } from '../../models/transfer-rumor';
import { SourceBadgeComponent } from '../source-badge/source-badge.component';
import { TimeAgoPipe } from '../../shared/time-ago.pipe';

@Component({
  selector: 'app-transfer-card',
  standalone: true,
  imports: [CommonModule, SourceBadgeComponent, TimeAgoPipe],
  templateUrl: './transfer-card.component.html',
  styleUrls: ['./transfer-card.component.scss']
})
export class TransferCardComponent {
  @Input({ required: true }) rumor!: TransferRumor;
}
