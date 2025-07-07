<template>
  <nav class="navbar">
    <div class="container">
      <!-- Logo dengan link ke Home -->
      <router-link
        to="/"
        class="logo"
        exact-active-class="active-link"
        @click.native="refreshPage('/')"
      >
        PMB Universitas
      </router-link>

      <div class="nav-links">
        <template v-if="authStore.isAuthenticated">
          <span class="welcome-msg">
            Selamat datang, {{ authStore.user.namaLengkap }}
          </span>
          <button @click="handleLogout" class="btn btn-logout">Logout</button>
        </template>

        <template v-else>
          <!-- Link ke Login -->
          <router-link
            to="/login"
            class="btn btn-login"
            active-class="active-link"
            @click.native="refreshPage('/login')"
          >
            Login
          </router-link>

          <!-- Link ke Register -->
          <router-link
            to="/register"
            class="btn btn-primary"
            active-class="active-link"
            @click.native="refreshPage('/register')"
          >
            Daftar
          </router-link>
        </template>
      </div>
    </div>
  </nav>
</template>

<script setup>
import { useAuthStore } from "@/stores/auth";
import { useRouter } from "vue-router";
import { ref } from "vue";

const authStore = useAuthStore();
const router = useRouter();
const componentKey = ref(0);

const refreshPage = (path) => {
  if (router.currentRoute.path === path) {
    componentKey.value++;
    router.replace(path).then(() => {
      window.location.reload();
    });
  }
};

const handleLogout = async () => {
  try {
    await authStore.logout();
    router.push("/login").then(() => {
      window.location.reload();
    });
  } catch (error) {
    console.error("Logout error:", error);
  }
};
</script>

<style scoped>
.navbar {
  background-color: white;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  padding: 1rem 0;
  position: sticky;
  top: 0;
  z-index: 1000;
}

.container {
  display: flex;
  justify-content: space-between;
  align-items: center;
  max-width: 1200px;
  margin: 0 auto;
  padding: 0 1rem;
}

.logo {
  font-size: 1.5rem;
  font-weight: bold;
  color: var(--primary);
  text-decoration: none;
  cursor: pointer;
  transition: color 0.3s;
}

.logo:hover {
  color: var(--secondary);
}

.nav-links {
  display: flex;
  gap: 1rem;
  align-items: center;
}

.welcome-msg {
  font-weight: 500;
  color: var(--dark);
  margin-right: 1rem;
}

.btn {
  padding: 0.5rem 1rem;
  border-radius: 4px;
  text-decoration: none;
  font-size: 0.9rem;
  transition: all 0.3s ease;
  cursor: pointer;
}

.btn-login {
  background-color: transparent;
  color: var(--primary);
  border: 1px solid var(--primary);
}

.btn-login:hover {
  background-color: rgba(67, 97, 238, 0.1);
}

.btn-primary {
  background-color: var(--primary);
  color: white;
  border: none;
}

.btn-primary:hover {
  background-color: var(--secondary);
}

.btn-logout {
  background-color: var(--danger);
  color: white;
  border: none;
}

.btn-logout:hover {
  background-color: #d31642;
}

.active-link {
  font-weight: bold;
  position: relative;
}

.active-link::after {
  content: "";
  position: absolute;
  bottom: -5px;
  left: 0;
  width: 100%;
  height: 2px;
  background-color: var(--primary);
}
</style>
