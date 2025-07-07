<template>
  <div class="login-page">
    <div class="login-card">
      <h1>PMB Universitas</h1>
      <form @submit.prevent="handleSubmit">
        <div class="form-group">
          <label>Email</label>
          <input
            v-model="email"
            type="email"
            required
            placeholder="user@example.com"
          />
        </div>
        <div class="form-group">
          <label>Password</label>
          <input
            v-model="password"
            type="password"
            required
            placeholder="••••••••"
          />
        </div>
        <button type="submit">Login</button>
      </form>
    </div>
    <footer class="login-footer">
      © 2025 Universitas Contoh. All rights reserved.
    </footer>
  </div>
</template>

<script setup>
import { ref } from "vue";
import { useAuthStore } from "@/stores/auth";
import { useRouter } from "vue-router";

const email = ref("");
const password = ref("");
const authStore = useAuthStore();
const router = useRouter();

const handleSubmit = async () => {
  try {
    await authStore.login(email.value, password.value);
    const redirect =
      router.currentRoute.value.query.redirect ||
      (authStore.user.isAdmin ? "/admin" : "/mahasiswa");
    router.push(redirect);
  } catch (error) {
    alert(error.message || "Login failed");
  }
};
</script>

<style scoped>
.login-page {
  min-height: 100vh;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.login-card {
  width: 100%;
  max-width: 400px;
  padding: 2rem;
  background: white;
  border-radius: 8px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  margin-bottom: 1rem;
}

h1 {
  color: #4361ee;
  text-align: center;
  margin-bottom: 1.5rem;
}

.form-group {
  margin-bottom: 1rem;
}

label {
  display: block;
  margin-bottom: 0.5rem;
  font-weight: 500;
}

input {
  width: 100%;
  padding: 0.75rem;
  border: 1px solid #ddd;
  border-radius: 4px;
  font-size: 1rem;
}

button {
  width: 100%;
  padding: 0.75rem;
  background-color: #4361ee;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 1rem;
  margin-top: 1rem;
}

.login-footer {
  color: #6c757d;
  text-align: center;
}
</style>
