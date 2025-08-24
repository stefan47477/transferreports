import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { routes } from './app.routes';

// Try this name first (newer Angular):
import { provideZonelessChangeDetection } from '@angular/core';
// If your version complains, use the older preview name instead:
// import { provideExperimentalZonelessChangeDetection as provideZonelessChangeDetection } from '@angular/core';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    provideZonelessChangeDetection(),
    provideHttpClient()
  ]
};
