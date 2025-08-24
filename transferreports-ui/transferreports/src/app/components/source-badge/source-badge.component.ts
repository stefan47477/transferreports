import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Credibility } from '../../models/transfer-rumor';

@Component({
  selector: 'app-source-badge',
  standalone: true,
  imports: [CommonModule],
  template: `
    <a *ngIf="url; else plain"
       class="badge"
       [ngClass]="(credibility | lowercase)"
       [href]="url" target="_blank" rel="noopener">
      {{ label }}
    </a>
    <ng-template #plain>
      <span class="badge" [ngClass]="(credibility | lowercase)">{{ label }}</span>
    </ng-template>
  `,
  styleUrls: ['./source-badge.component.scss']
})
export class SourceBadgeComponent {
  @Input() label = '';
  @Input() credibility: Credibility = 'Tier2';
  @Input() url?: string;
}
