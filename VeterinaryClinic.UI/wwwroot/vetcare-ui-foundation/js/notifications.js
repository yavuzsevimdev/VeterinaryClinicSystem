/**
 * notifications.js
 * Generic dropdown open/close for profile menu + notification panel.
 * Works for any element pair marked with [data-dropdown-trigger] /
 * [data-dropdown-panel] sharing the same [data-dropdown-id].
 */

(function () {
  const triggers = document.querySelectorAll('[data-dropdown-trigger]');

  function triggerFor(panel) {
    const id = panel.getAttribute('data-dropdown-panel');
    return document.querySelector(`[data-dropdown-trigger="${id}"]`);
  }

  function closeAllDropdowns(except) {
    document.querySelectorAll('.dropdown-panel.is-open').forEach((panel) => {
      if (panel === except) return;
      panel.classList.remove('is-open');
      triggerFor(panel)?.setAttribute('aria-expanded', 'false');
    });
  }

  triggers.forEach((trigger) => {
    const id = trigger.getAttribute('data-dropdown-trigger');
    const panel = document.querySelector(`[data-dropdown-panel="${id}"]`);
    if (!panel) return;

    trigger.setAttribute('aria-haspopup', 'true');
    trigger.setAttribute('aria-expanded', 'false');

    trigger.addEventListener('click', (e) => {
      e.stopPropagation();
      const willOpen = !panel.classList.contains('is-open');
      closeAllDropdowns(willOpen ? panel : null);
      panel.classList.toggle('is-open', willOpen);
      trigger.setAttribute('aria-expanded', String(willOpen));
    });
  });

  document.addEventListener('click', (e) => {
    if (!e.target.closest('.dropdown-anchor')) closeAllDropdowns();
  });

  document.addEventListener('keydown', (e) => {
    if (e.key === 'Escape') closeAllDropdowns();
  });

  // Demo: clicking "mark all as read" clears unread dots
  const markAllReadBtn = document.querySelector('[data-mark-all-read]');
  markAllReadBtn?.addEventListener('click', () => {
    document.querySelectorAll('.notif-item.is-unread').forEach((item) => {
      item.classList.remove('is-unread');
    });
    document.querySelector('[data-notif-dot]')?.remove();
    const badge = document.querySelector('[data-notif-count]');
    if (badge) badge.textContent = '0 new';
  });
})();
