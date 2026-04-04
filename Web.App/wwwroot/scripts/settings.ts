export function toggleTheme(): void {
  const app: Element | null = document.querySelector('#app');
  const currentTheme: string | null = localStorage.getItem('theme');

  const newTheme = (currentTheme && currentTheme == 'dark') ? 'light' : 'dark';

  app?.setAttribute('data-theme', newTheme);
  localStorage.setItem('theme', newTheme);
}

export function initTheme(): void {
  const theme: string = localStorage.getItem('theme') ?? 'dark';
  SetTheme(theme);
}

function SetTheme(theme: string): void {
  const app: Element | null = document.querySelector('#app');
  app?.setAttribute('data-theme', theme);
}
