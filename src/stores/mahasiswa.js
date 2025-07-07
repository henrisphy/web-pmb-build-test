import { defineStore } from "pinia";
import api from "@/api";

export const useMahasiswaStore = defineStore("mahasiswa", () => {
  const pendingRegistrations = ref([]);

  const fetchPendingRegistrations = async () => {
    const response = await api.get("/mahasiswa/pending");
    pendingRegistrations.value = response.data;
  };

  const approveRegistration = async (id) => {
    await api.put(`/mahasiswa/${id}/approve`);
    await fetchPendingRegistrations();
  };

  const rejectRegistration = async (id) => {
    await api.put(`/mahasiswa/${id}/reject`);
    await fetchPendingRegistrations();
  };

  return {
    pendingRegistrations,
    fetchPendingRegistrations,
    approveRegistration,
    rejectRegistration,
  };
});
