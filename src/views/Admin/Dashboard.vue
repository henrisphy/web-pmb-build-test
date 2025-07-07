<template>
  <div class="dashboard">
    <h1 class="page-title">Admin Dashboard</h1>

    <div v-if="pendingRegistrations.length" class="registrations-container">
      <h2>Pending Registrations</h2>
      <div class="registrations-grid">
        <div
          v-for="mahasiswa in pendingRegistrations"
          :key="mahasiswa.id"
          class="registration-card"
        >
          <div class="card-header">
            <h3>{{ mahasiswa.namaLengkap }}</h3>
            <span class="email">{{ mahasiswa.email }}</span>
          </div>
          <div class="card-actions">
            <button @click="approve(mahasiswa.id)" class="btn btn-success">
              Approve
            </button>
            <button @click="reject(mahasiswa.id)" class="btn btn-danger">
              Reject
            </button>
          </div>
        </div>
      </div>
    </div>
    <div v-else class="empty-state">
      <p>Tidak ada pendaftaran yang menunggu approval</p>
    </div>
  </div>
</template>

<style scoped>
.dashboard {
  padding: 2rem;
}

.page-title {
  color: var(--primary);
  margin-bottom: 2rem;
}

.registrations-container {
  margin-top: 2rem;
}

.registrations-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
  gap: 1.5rem;
  margin-top: 1rem;
}

.registration-card {
  background: white;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  padding: 1.5rem;
}

.card-header {
  margin-bottom: 1rem;
}

.card-header h3 {
  color: var(--dark);
}

.card-header .email {
  color: #666;
  font-size: 0.9rem;
}

.card-actions {
  display: flex;
  gap: 0.5rem;
}

.btn-success {
  background-color: var(--success);
  color: white;
}

.btn-danger {
  background-color: var(--danger);
  color: white;
}

.empty-state {
  background: white;
  padding: 2rem;
  border-radius: 8px;
  text-align: center;
  color: #666;
}
</style>
