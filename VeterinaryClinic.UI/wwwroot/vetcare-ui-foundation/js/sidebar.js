/**
 * sidebar.js
 * Sidebar collapse/expand (desktop) + drawer open/close (mobile).
 * Persists collapsed preference in localStorage so it survives reloads.
 */

(function () {
  const STORAGE_KEY = 'vetcare.sidebarCollapsed';

  const appShell = document.querySelector('[data-app-shell]');
  const collapseToggles = document.querySelectorAll('[data-sidebar-collapse-toggle]');
  const mobileToggles = document.querySelectorAll('[data-mobile-nav-toggle]');
  const overlay = document.querySelector('[data-app-overlay]');

  if (!appShell) return;

  function applyCollapsedFromStorage() {
    const saved = localStorage.getItem(STORAGE_KEY);
    if (saved === 'true') {
      appShell.classList.add('is-sidebar-collapsed');
    }
  }

  function toggleCollapsed() {
    const isCollapsed = appShell.classList.toggle('is-sidebar-collapsed');
    localStorage.setItem(STORAGE_KEY, String(isCollapsed));
  }

  function openMobileNav() {
    appShell.classList.add('is-mobile-nav-open');
    overlay?.classList.add('is-visible');
    document.body.style.overflow = 'hidden';
  }

  function closeMobileNav() {
    appShell.classList.remove('is-mobile-nav-open');
    overlay?.classList.remove('is-visible');
    document.body.style.overflow = '';
  }

  collapseToggles.forEach((btn) => {
    btn.addEventListener('click', toggleCollapsed);
  });

  mobileToggles.forEach((btn) => {
    btn.addEventListener('click', () => {
      if (appShell.classList.contains('is-mobile-nav-open')) {
        closeMobileNav();
      } else {
        openMobileNav();
      }
    });
  });

  overlay?.addEventListener('click', closeMobileNav);

  document.addEventListener('keydown', (e) => {
    if (e.key === 'Escape') closeMobileNav();
  });

  // Close the mobile drawer automatically if the viewport grows back to desktop
  window.addEventListener('resize', () => {
    if (window.innerWidth > 991.98) closeMobileNav();
  });

  applyCollapsedFromStorage();

  window.VetCareSidebar = { toggleCollapsed, openMobileNav, closeMobileNav };
})();
