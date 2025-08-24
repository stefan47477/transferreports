export type Credibility = 'Tier1' | 'Tier2' | 'Gossip';

export interface TransferRumor {
  id: string;
  player: string;
  fromClub: string;
  toClub: string;
  fee?: string;
  source: string;
  sourceUrl?: string;
  credibility: Credibility;     
  timestamp: string;        
  note?: string;
}
