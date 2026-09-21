/**
 * main.js
 * Entry point loaded last. Wires up cross-cutting UI behavior that doesn't
 * belong to a single module: topbar page-title sync, current-year stamp,
 * and a light readiness log for debugging the standalone prototype.
 *
 * Module load order (see index.html):
 * sidebar.js -> navigation.js -> notifications.js -> modals.js
 * -> components.js -> main.js
 */

(function () {
  document.documentElement.classList.add('js-ready');

  const yearEls = document.querySelectorAll('[data-current-year]');
  yearEls.forEach((el) => (el.textContent = new Date().getFullYear()));

  // Keep the topbar page title in sync when a sidebar link is clicked (demo only)
  document.querySelectorAll('[data-sidebar-link]').forEach((link) => {
    link.addEventListener('click', () => {
      const title = link.getAttribute('data-page-title');
      const titleEl = document.querySelector('[data-topbar-title]');
      if (title && titleEl) titleEl.textContent = title;
    });
  });

  console.info('[VetCare OS] Global UI foundation loaded.');
})();
