/**
 * modals.js
 * Open/close behavior for [data-modal] overlays.
 * Trigger:  <button data-modal-open="modal-id">
 * Overlay:  <div data-modal="modal-id" class="modal-ui-overlay">
 * Close:    any [data-modal-close] inside the open overlay
 */

(function () {
  const openTriggers = document.querySelectorAll('[data-modal-open]');
  const closeTriggers = document.querySelectorAll('[data-modal-close]');
  let activeModal = null;
  let lastFocusedElement = null;

  function openModal(id) {
    const overlay = document.querySelector(`[data-modal="${id}"]`);
    if (!overlay) return;

    lastFocusedElement = document.activeElement;
    overlay.classList.add('is-open');
    document.body.style.overflow = 'hidden';
    activeModal = overlay;

    const focusable = overlay.querySelector('button, [href], input, select, textarea');
    focusable?.focus();
  }

  function closeModal(overlay) {
    if (!overlay) return;
    overlay.classList.remove('is-open');
    document.body.style.overflow = '';
    activeModal = null;
    lastFocusedElement?.focus();
  }

  openTriggers.forEach((btn) => {
    btn.addEventListener('click', () => openModal(btn.getAttribute('data-modal-open')));
  });

  closeTriggers.forEach((btn) => {
    btn.addEventListener('click', () => closeModal(btn.closest('[data-modal]')));
  });

  document.querySelectorAll('[data-modal]').forEach((overlay) => {
    overlay.addEventListener('click', (e) => {
      if (e.target === overlay) closeModal(overlay);
    });
  });

  document.addEventListener('keydown', (e) => {
    if (e.key === 'Escape' && activeModal) closeModal(activeModal);
  });

  window.VetCareModals = { openModal, closeModal };
})();
