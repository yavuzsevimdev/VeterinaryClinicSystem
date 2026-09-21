/**
 * components.js
 * Demo-only interactions for standalone UI components:
 * toasts, button loading-state simulation, alert dismissal,
 * skeleton/error/empty state toggles used on the playground page.
 */

(function () {
  const TOAST_ICONS = {
    success: 'bi-check-circle-fill',
    danger: 'bi-x-circle-fill',
    warning: 'bi-exclamation-triangle-fill',
    info: 'bi-info-circle-fill',
  };

  const TOAST_TITLES = {
    success: 'Success',
    danger: 'Something went wrong',
    warning: 'Heads up',
    info: 'Notice',
  };

  function ensureToastStack() {
    let stack = document.querySelector('[data-toast-stack]');
    if (!stack) {
      stack = document.createElement('div');
      stack.className = 'toast-stack';
      stack.setAttribute('data-toast-stack', '');
      stack.setAttribute('aria-live', 'polite');
      document.body.appendChild(stack);
    }
    return stack;
  }

  function showToast(type, message) {
    const stack = ensureToastStack();
    const toast = document.createElement('div');
    toast.className = `toast-ui is-${type}`;
    toast.setAttribute('role', 'status');
    toast.innerHTML = `
      <div class="alert-ui-icon" style="background-color: transparent; width:auto; height:auto; font-size:1.2rem;">
        <i class="bi ${TOAST_ICONS[type] || TOAST_ICONS.info}"></i>
      </div>
      <div class="alert-ui-body">
        <div class="alert-ui-title">${TOAST_TITLES[type] || TOAST_TITLES.info}</div>
        <div class="alert-ui-message">${message}</div>
      </div>
      <button type="button" class="alert-ui-close" aria-label="Dismiss notification">
        <i class="bi bi-x-lg"></i>
      </button>
    `;

    toast.querySelector('.alert-ui-close').addEventListener('click', () => dismissToast(toast));
    stack.appendChild(toast);

    const timer = setTimeout(() => dismissToast(toast), 4500);
    toast.dataset.timer = timer;
  }

  function dismissToast(toast) {
    if (!toast || toast.classList.contains('is-leaving')) return;
    clearTimeout(toast.dataset.timer);
    toast.classList.add('is-leaving');
    toast.addEventListener('animationend', () => toast.remove(), { once: true });
  }

  document.querySelectorAll('[data-toast-demo]').forEach((btn) => {
    btn.addEventListener('click', () => {
      const type = btn.getAttribute('data-toast-demo');
      const message = btn.getAttribute('data-toast-message') || 'This is a sample notification message.';
      showToast(type, message);
    });
  });

  // ---- Inline alert dismissal ----
  document.querySelectorAll('.alert-ui .alert-ui-close').forEach((btn) => {
    btn.addEventListener('click', () => {
      const alert = btn.closest('.alert-ui');
      alert.style.transition = 'opacity 180ms ease, transform 180ms ease';
      alert.style.opacity = '0';
      alert.style.transform = 'translateY(-4px)';
      setTimeout(() => alert.remove(), 180);
    });
  });

  // ---- Button loading-state simulation ----
  document.querySelectorAll('[data-loading-demo]').forEach((btn) => {
    btn.addEventListener('click', () => {
      if (btn.classList.contains('is-loading')) return;
      btn.classList.add('is-loading');
      setTimeout(() => btn.classList.remove('is-loading'), 1800);
    });
  });

  // ---- Toggle demo state panels (skeleton -> loaded / empty / error) ----
  document.querySelectorAll('[data-state-toggle]').forEach((btn) => {
    btn.addEventListener('click', () => {
      const targetSelector = btn.getAttribute('data-state-toggle');
      const group = document.querySelector(targetSelector);
      if (!group) return;
      const showState = btn.getAttribute('data-show-state');
      group.querySelectorAll('[data-state]').forEach((el) => {
        el.hidden = el.getAttribute('data-state') !== showState;
      });
      group.querySelectorAll('[data-state-toggle-btn]').forEach((b) => b.classList.remove('is-active'));
      btn.classList.add('is-active');
    });
  });

  window.VetCareToast = { showToast };
})();
