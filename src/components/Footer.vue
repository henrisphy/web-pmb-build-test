<template>
  <footer class="footer">
    <div class="container">
      <p>&copy; {{ currentYear }} Universitas Contoh. All rights reserved.</p>
    </div>
  </footer>
</template>

<script setup>
import { ref } from "vue";
const currentYear = ref(new Date().getFullYear());
</script>

<style scoped>
.footer {
  background-color: var(--dark);
  color: white;
  padding: 1.5rem 0;
  margin-top: auto;
}

.footer p {
  text-align: center;
  margin: 0;
}
</style>
