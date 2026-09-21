/**
 * navigation.js
 * Active nav-link state + demo table-of-contents scroll spy.
 * In the real app, "active" will instead be driven server-side by
 * Razor Pages (e.g. comparing ViewContext.RouteData to each link).
 */

(function () {
  const navLinks = document.querySelectorAll('[data-sidebar-link]');

  navLinks.forEach((link) => {
    link.addEventListener('click', (e) => {
      // Demo-only: prevent real navigation since target pages don't exist yet.
      if (link.getAttribute('href') === '#') e.preventDefault();

      navLinks.forEach((l) => l.classList.remove('is-active'));
      link.classList.add('is-active');

      // Close mobile drawer after selecting a destination
      if (window.innerWidth <= 991.98 && window.VetCareSidebar) {
        window.VetCareSidebar.closeMobileNav();
      }
    });
  });

  // ---- Scroll-spy for the component playground's table of contents ----
  const tocLinks = document.querySelectorAll('[data-toc-link]');
  const sections = Array.from(tocLinks)
    .map((link) => document.querySelector(link.getAttribute('href')))
    .filter(Boolean);

  if ('IntersectionObserver' in window && sections.length) {
    const observer = new IntersectionObserver(
      (entries) => {
        entries.forEach((entry) => {
          const id = '#' + entry.target.id;
          const link = document.querySelector(`[data-toc-link][href="${id}"]`);
          if (!link) return;
          if (entry.isIntersecting) {
            tocLinks.forEach((l) => l.classList.remove('is-active'));
            link.classList.add('is-active');
          }
        });
      },
      { rootMargin: '-20% 0px -70% 0px', threshold: 0 }
    );

    sections.forEach((section) => observer.observe(section));
  }
})();
