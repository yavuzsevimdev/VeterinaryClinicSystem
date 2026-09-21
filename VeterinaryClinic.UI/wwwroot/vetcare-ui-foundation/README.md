# VetCare OS — Global UI Foundation

A standalone, backend-free frontend prototype for the **Veterinary Clinic Management System**
(ASP.NET Core 8 + Razor Pages + REST API + JWT + role-based auth).

This stage delivers **only** the global design system and application shell — no real
application pages (Login, Dashboard, Animals, Appointments, etc.) are included yet. Those will
be designed individually in later prompts, reusing everything built here.

## Running the prototype

No build step, no dependencies to install. Just open the file:

```
index.html
```

directly in a browser (double-click it, or serve the folder with any static server, e.g.
`npx serve .` or VS Code's "Live Server" extension). Bootstrap 5, Bootstrap Icons and the
Poppins font are loaded from CDNs; everything else is local, static HTML/CSS/JS.

## Folder structure

```
vetcare-ui/
├── index.html                 # Component playground / design system showcase
│
├── css/
│   ├── variables.css          # Design tokens (colors, spacing, radius, shadows, motion)
│   ├── reset.css              # Minimal reset + focus ring + scrollbar theming
│   ├── typography.css         # Poppins type scale & text utility classes
│   ├── layout.css             # App shell grid, content containers, generic layout utilities
│   ├── sidebar.css            # Sidebar: expanded/collapsed/mobile-drawer states
│   ├── topbar.css             # Topbar, profile dropdown, notification dropdown, avatars
│   ├── components.css         # Cards, buttons, badges, alerts/toasts, loading/empty/error
│   │                            states, pagination, breadcrumbs, section headers
│   ├── forms.css              # Full form control system
│   ├── modals.css             # Modal dialogs
│   ├── responsive.css         # Cross-cutting responsive rules
│   └── main.css                # Single entry point — @imports the files above in order
│
├── js/
│   ├── sidebar.js              # Collapse/expand + mobile drawer, persisted via localStorage
│   ├── navigation.js           # Active nav-link state + demo table-of-contents scroll spy
│   ├── notifications.js        # Generic dropdown open/close (profile + notification panel)
│   ├── modals.js                # Modal open/close, focus handling, Esc-to-close
│   ├── components.js            # Toast demo, alert dismissal, button loading, state toggles
│   └── main.js                   # Entry point loaded last; small cross-cutting glue
│
├── images/
│   ├── logo/                   # Clinic logo placeholder — see logo/README.md
│   ├── avatars/                # User avatar placeholder — see avatars/README.md
│   └── placeholders/           # Animal/content image placeholders — see placeholders/README.md
│
└── README.md
```

## Reusable components in this foundation

**Shell**
- Application shell (sidebar + topbar + content grid), with expanded, collapsed and
  mobile-drawer states
- Collapsible sidebar with grouped navigation, active/hover states, badge counters, and
  hover tooltips in collapsed mode
- Topbar with page title, breadcrumb slot, search, notification bell and profile menu
- Profile dropdown (Profile / Settings / Logout)
- Notification dropdown (unread indicator, timestamps, mark-all-read, "View all")

**Dashboard building blocks**
- Statistic card, large statistic card, small statistic card, trend indicator
- Summary/activity card, appointment card, animal card placeholder, profile card,
  financial summary card, weather placeholder card, quick action card

**Core UI kit**
- Card variants: standard, elevated, interactive, status
- Buttons: primary/secondary/outline/ghost/success/warning/danger/info ×
  small/medium/large × default/hover/focus/disabled/loading, icon-only and icon+text
- Status badges (Scheduled, Completed, Cancelled, Paid, Pending, Debt, Active, Inactive)
- Form system: text/email/password/number/date/time/search inputs, textarea, select,
  checkbox, radio, file/image dropzone, all with default/hover/focus/valid/invalid/disabled
  states
- Modals: delete confirmation, status change, payment confirmation
- Alerts (success/warning/danger/info) and dismissible auto-expiring toasts
- Loading states: spinners (sm/md/lg), button loading, card & list skeletons, page loader
- Empty states (no animals / no appointments / no payments / no notifications)
- Error states (generic failure, unauthorized, not found, API error) with recovery actions
- Pagination, breadcrumbs, and section headers (title + description + badge + filters + action)

All of it is driven by the CSS custom properties in `css/variables.css` — no raw hex colors
are repeated throughout the other stylesheets.

## Converting this into ASP.NET Core Razor Pages

| Prototype file | Becomes |
|---|---|
| The `<div class="app-shell">` wrapper + `<head>` in `index.html` | `Pages/Shared/_Layout.cshtml` |
| The `<aside class="sidebar">` block | `Pages/Shared/_SidebarPartial.cshtml` |
| The `<header class="topbar">` block | `Pages/Shared/_TopbarPartial.cshtml` |
| The profile `.dropdown-panel` markup | `Pages/Shared/_UserMenuPartial.cshtml` |
| The notification `.dropdown-panel` markup | `Pages/Shared/_NotificationPartial.cshtml` |
| Statistic / stat-card markup | `_StatisticCard` ViewComponent |
| Animal card placeholder markup | `_AnimalCard` ViewComponent |
| Appointment card markup | `_AppointmentCard` ViewComponent |
| Financial summary card markup | `_PaymentCard` / financial summary ViewComponent |
| `.badge-ui` usages | `_StatusBadge` ViewComponent (status → CSS class mapping) |
| `.section-header` block | `_PageHeader` partial/ViewComponent |
| `.state-panel` (empty variant) | `_EmptyState` partial |
| Modal markup | `_ConfirmModal` partial, parameterized by title/body/action |
| `css/*.css` | Copied as-is into `wwwroot/css/`, referenced once from `_Layout.cshtml` |
| `js/*.js` | Copied as-is into `wwwroot/js/`, referenced once from `_Layout.cshtml` |
| `images/*` | Copied as-is into `wwwroot/images/` |

Sidebar navigation items are written as plain `<li>` entries so that, once ported to Razor,
each item can be wrapped in role checks (`@if (User.IsInRole("Manager"))`) or rendered from a
server-side navigation model without restructuring the markup or CSS.

## Explicitly out of scope at this stage

No Login, Register, Customer Dashboard, Manager Dashboard, Animals, Animal Detail,
Appointments, Treatments, Payments, Reports, or Weather pages are included. `index.html` is a
component playground only, meant to validate the design system before those pages are built.
