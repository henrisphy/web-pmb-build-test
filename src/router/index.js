import { createRouter, createWebHistory } from "vue-router";

const routes = [
  {
    path: "/",
    name: "Home",
    component: () => import("@/views/Home.vue"),
    meta: {
      title: "Beranda PMB",
      transition: "fade",
      requiresAuth: false,
    },
  },
  {
    path: "/login",
    name: "Login",
    component: () => import("@/views/Auth/Login.vue"),
    meta: {
      title: "Login Sistem",
      transition: "slide-up",
      guestOnly: true,
      layout: "AuthLayout",
    },
  },
  {
    path: "/register",
    name: "Register",
    component: () => import("@/views/Auth/Register.vue"),
    meta: {
      title: "Pendaftaran Mahasiswa",
      transition: "slide-up",
      guestOnly: true,
      layout: "AuthLayout",
    },
  },
  {
    path: "/admin",
    name: "AdminDashboard",
    component: () => import("@/views/Admin/Dashboard.vue"),
    meta: {
      title: "Dashboard Admin",
      transition: "fade",
      requiresAuth: true,
      requiresAdmin: true,
      layout: "AdminLayout",
    },
  },

  {
    path: "/mahasiswa",
    name: "MahasiswaDashboard",
    component: () => import("@/views/Mahasiswa/Dashboard.vue"),
    meta: {
      title: "Dashboard Mahasiswa",
      transition: "fade",
      requiresAuth: true,
      layout: "MahasiswaLayout",
    },
  },
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
  scrollBehavior(to, from, savedPosition) {
    if (to.hash) {
      return {
        el: to.hash,
        behavior: "smooth",
        top: 100,
      };
    } else if (savedPosition) {
      return savedPosition;
    } else {
      return { top: 0, behavior: "smooth" };
    }
  },
});

router.beforeEach((to) => {
  document.title = to.meta.title
    ? `${to.meta.title} | PMB Universitas`
    : "PMB Universitas";
});

export default router;
