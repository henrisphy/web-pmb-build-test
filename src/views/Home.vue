<template>
  <div class="home-page">
    <main class="main-content">
      <h1>Selamat Datang di PMB Universitas</h1>
      <p>Sistem Pendaftaran Mahasiswa Baru</p>

      <div class="action-buttons" v-if="!authStore.isAuthenticated">
        <router-link :to="{ name: 'Login' }" class="btn btn-primary">
          Login Admin/Mahasiswa
        </router-link>
        <router-link :to="{ name: 'Register' }" class="btn btn-secondary">
          Daftar Mahasiswa Baru
        </router-link>
      </div>
    </main>
  </div>
</template>

<script setup>
import { useAuthStore } from "@/stores/auth";

const authStore = useAuthStore();
</script>

<style scoped>
.home-page {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

.main-content {
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  text-align: center;
  padding: 2rem;
}

h1 {
  font-size: 2.5rem;
  color: #4361ee;
  margin-bottom: 1rem;
}

p {
  font-size: 1.2rem;
  color: #666;
  margin-bottom: 2rem;
}

.action-buttons {
  display: flex;
  gap: 1rem;
  margin-top: 2rem;
}

.btn {
  padding: 0.75rem 1.5rem;
  border-radius: 6px;
  font-size: 1rem;
  font-weight: 500;
  text-decoration: none;
  transition: all 0.3s ease;
}

.btn-primary {
  background-color: #4361ee;
  color: white;
}

.btn-primary:hover {
  background-color: #3a56d0;
}

.btn-secondary {
  background-color: white;
  color: #4361ee;
  border: 2px solid #4361ee;
}

.btn-secondary:hover {
  background-color: rgba(67, 97, 238, 0.1);
}
</style>
