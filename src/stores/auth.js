import { defineStore } from "pinia";
import { ref } from "vue";
import api from "@/api";
import { useRouter } from "vue-router";

export const useAuthStore = defineStore("auth", () => {
  const user = ref(null);
  const isAuthenticated = ref(false);
  const router = useRouter();

  const login = async (email, password) => {
    try {
      const response = await api.post("/auth/login", { email, password });
      user.value = response.data.user;
      isAuthenticated.value = true;
      localStorage.setItem("token", response.data.token);

      if (user.value.isAdmin) {
        router.push("/admin");
      } else {
        router.push("/mahasiswa");
      }
    } catch (error) {
      throw error.response?.data?.message || "Login failed";
    }
  };

  const register = async (formData) => {
    try {
      const form = new FormData();
      for (const key in formData) {
        if (formData[key] !== null && formData[key] !== undefined) {
          form.append(key, formData[key]);
        }
      }

      await api.post("/auth/register", form, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });
    } catch (error) {
      throw error.response?.data?.message || "Registration failed";
    }
  };

  const logout = () => {
    user.value = null;
    isAuthenticated.value = false;
    localStorage.removeItem("token");
    router.push("/login");
  };

  const checkAuth = async () => {
    const token = localStorage.getItem("token");
    if (token) {
      try {
        const response = await api.get("/auth/me");
        user.value = response.data;
        isAuthenticated.value = true;
      } catch {
        logout();
      }
    }
  };

  return { user, isAuthenticated, login, register, logout, checkAuth };
});
