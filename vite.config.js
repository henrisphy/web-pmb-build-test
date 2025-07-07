import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";
import path from "path";

export default defineConfig({
  plugins: [vue()],
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "./src"),

      "@assets": path.resolve(__dirname, "./src/assets"),
      "@components": path.resolve(__dirname, "./src/components"),
      "@stores": path.resolve(__dirname, "./src/stores"),
      "@router": path.resolve(__dirname, "./src/router"),

      "@views": path.resolve(__dirname, "./src/views"),
      "@authViews": path.resolve(__dirname, "./src/views/Auth"),
      "@adminViews": path.resolve(__dirname, "./src/views/Admin"),
      "@mahasiswaViews": path.resolve(__dirname, "./src/views/Mahasiswa"),

      "@api": path.resolve(__dirname, "./src/api.js"),
    },
  },
  server: {
    proxy: {
      "/api": {
        target: "http://localhost:5173",
        changeOrigin: true,
        secure: false,
      },
    },
  },
  build: {
    rollupOptions: {
      external: ["vue", "vue-router"],
    },
  },
});
