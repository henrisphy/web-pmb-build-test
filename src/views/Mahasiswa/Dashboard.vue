<template>
  <div class="dashboard">
    <h1>Welcome, {{ authStore.user.namaLengkap }}!</h1>

    <div v-if="authStore.user.fotoPath" class="photo-container">
      <img :src="authStore.user.fotoPath" alt="Foto Profil" />
    </div>

    <div class="profile-info">
      <p><strong>Email:</strong> {{ authStore.user.email }}</p>
      <p><strong>Status:</strong> {{ authStore.user.status }}</p>
    </div>
  </div>
</template>

<script setup>
import { useAuthStore } from "@/stores/auth";

const authStore = useAuthStore();
</script>
