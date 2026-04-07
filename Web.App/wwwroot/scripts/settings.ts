export function toggleTheme(): void {
  const app: Element | null = document.querySelector('#app');
  const currentTheme: string = localStorage.getItem('theme') ?? 'dark';

  const newTheme = currentTheme == 'dark' ? 'light' : 'dark';

  SetTheme(newTheme);
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
