<template>
  <div class="registration-page">
    <h1 class="form-title">FORMULIR PENDAFTARAN MAHASISWA BARU</h1>

    <form
      @submit.prevent="handleSubmit"
      class="registration-form"
      enctype="multipart/form-data"
    >
      <div class="form-section">
        <h2 class="section-title">DATA CALON MAHASISWA</h2>

        <div class="form-row">
          <div class="form-group">
            <label>NAMA LENGKAP <span class="required">*</span></label>
            <input v-model="form.namaLengkap" required type="text" />
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label>ALAMAT ASAL <span class="required">*</span></label>
            <textarea v-model="form.alamatAsal" required rows="3"></textarea>
          </div>
          <div class="form-group">
            <label>ALAMAT di SEMARANG <span class="required">*</span></label>
            <textarea
              v-model="form.alamatSemarang"
              required
              rows="3"
            ></textarea>
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label>TEMPAT/TGL LAHIR <span class="required">*</span></label>
            <input
              v-model="form.tempatLahir"
              required
              type="text"
              placeholder="Kota Lahir"
            />
            <input
              v-model="form.tanggalLahir"
              required
              type="date"
              class="date-input"
            />
          </div>
          <div class="form-group">
            <label>AGAMA <span class="required">*</span></label>
            <select v-model="form.agama" required>
              <option value="">Pilih Agama</option>
              <option value="Islam">Islam</option>
              <option value="Kristen">Kristen</option>
              <option value="Katolik">Katolik</option>
              <option value="Hindu">Hindu</option>
              <option value="Buddha">Buddha</option>
              <option value="Konghucu">Konghucu</option>
            </select>
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label>JENIS KELAMIN <span class="required">*</span></label>
            <div class="radio-group">
              <label>
                <input
                  v-model="form.jenisKelamin"
                  type="radio"
                  value="Laki-laki"
                  required
                />
                Laki-laki
              </label>
              <label>
                <input
                  v-model="form.jenisKelamin"
                  type="radio"
                  value="Perempuan"
                />
                Perempuan
              </label>
            </div>
          </div>
          <div class="form-group">
            <label>GOLONGAN DARAH</label>
            <select v-model="form.golonganDarah">
              <option value="">Pilih Golongan Darah</option>
              <option value="A">A</option>
              <option value="B">B</option>
              <option value="AB">AB</option>
              <option value="O">O</option>
            </select>
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label>ASAL SEKOLAH <span class="required">*</span></label>
            <input v-model="form.asalSekolah" required type="text" />
          </div>
          <div class="form-group">
            <label>JURUSAN SMA <span class="required">*</span></label>
            <input v-model="form.jurusanSma" required type="text" />
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label>TAHUN LULUS <span class="required">*</span></label>
            <input
              v-model="form.tahunLulus"
              required
              type="number"
              min="1900"
              :max="new Date().getFullYear()"
            />
          </div>
          <div class="form-group">
            <label
              >JURUSAN/FAKULTAS YANG DIPILIH
              <span class="required">*</span></label
            >
            <select v-model="form.jurusanFakultas" required>
              <option value="">Pilih Jurusan/Fakultas</option>
              <option value="Teknik Informatika">Teknik Informatika</option>
              <option value="Sistem Informasi">Sistem Informasi</option>
              <option value="Manajemen">Manajemen</option>
            </select>
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label>NOMOR TELEPON RUMAH</label>
            <input v-model="form.noTelpRumah" type="tel" />
          </div>
          <div class="form-group">
            <label>NOMOR HP <span class="required">*</span></label>
            <input v-model="form.noHp" required type="tel" />
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label>EMAIL <span class="required">*</span></label>
            <input v-model="form.email" required type="email" />
          </div>
          <div class="form-group">
            <label>PASSWORD <span class="required">*</span></label>
            <input v-model="form.password" required type="password" />
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label>KONFIRMASI PASSWORD <span class="required">*</span></label>
            <input v-model="form.confirmPassword" required type="password" />
          </div>
        </div>

        <div class="form-group">
          <label>FOTO 3X4 <span class="required">*</span></label>
          <input
            type="file"
            @change="handleFileUpload"
            accept="image/*"
            required
          />
          <small class="hint">Ukuran maksimal 2MB, format JPG/PNG</small>
          <div v-if="previewImage" class="image-preview">
            <img :src="previewImage" alt="Preview Foto" />
          </div>
        </div>
      </div>

      <div class="form-section">
        <h2 class="section-title">DATA ORANGTUA/WALI CALON MAHASISWA</h2>

        <div class="form-row">
          <div class="form-group">
            <label>NAMA LENGKAP <span class="required">*</span></label>
            <input v-model="form.ortuNama" required type="text" />
          </div>
        </div>

        <div class="form-group">
          <label>ALAMAT LENGKAP <span class="required">*</span></label>
          <textarea v-model="form.ortuAlamat" required rows="3"></textarea>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label>PEKERJAAN <span class="required">*</span></label>
            <input v-model="form.ortuPekerjaan" required type="text" />
          </div>
          <div class="form-group">
            <label>NO HP/TELEPON <span class="required">*</span></label>
            <input v-model="form.ortuNoHp" required type="tel" />
          </div>
        </div>
      </div>

      <div class="form-footer">
        <button type="submit" class="submit-button" :disabled="isSubmitting">
          {{ isSubmitting ? "Mengirim..." : "Kirim Pendaftaran" }}
        </button>
        <p class="form-note">Panitia PMB</p>
      </div>
    </form>
  </div>
</template>

<script setup>
import { ref } from "vue";
import { useAuthStore } from "@/stores/auth";
import { useRouter } from "vue-router";

const authStore = useAuthStore();
const router = useRouter();

const form = ref({
  namaLengkap: "",
  alamatAsal: "",
  alamatSemarang: "",
  tempatLahir: "",
  tanggalLahir: "",
  agama: "",
  jenisKelamin: "",
  golonganDarah: "",
  asalSekolah: "",
  jurusanSma: "",
  tahunLulus: new Date().getFullYear(),
  jurusanFakultas: "",
  noTelpRumah: "",
  noHp: "",
  email: "",
  password: "",
  confirmPassword: "",
  foto: null,

  ortuNama: "",
  ortuAlamat: "",
  ortuPekerjaan: "",
  ortuNoHp: "",
});

const previewImage = ref(null);
const isSubmitting = ref(false);

const handleFileUpload = (e) => {
  const file = e.target.files[0];
  if (file) {
    form.value.foto = file;

    const reader = new FileReader();
    reader.onload = (e) => {
      previewImage.value = e.target.result;
    };
    reader.readAsDataURL(file);
  }
};

const validateForm = () => {
  if (form.value.password !== form.value.confirmPassword) {
    alert("Password dan Konfirmasi Password tidak sama");
    return false;
  }
  return true;
};

const handleSubmit = async () => {
  if (!validateForm()) return;

  isSubmitting.value = true;

  try {
    const formData = new FormData();

    for (const key in form.value) {
      if (form.value[key] !== null) {
        formData.append(key, form.value[key]);
      }
    }

    await authStore.register(formData);
    alert("Pendaftaran berhasil! Silakan menunggu verifikasi admin.");
    router.push("/login");
  } catch (error) {
    alert("Pendaftaran gagal: " + error.message);
  } finally {
    isSubmitting.value = false;
  }
};
</script>

<style scoped>
.registration-page {
  max-width: 1000px;
  margin: 0 auto;
  padding: 20px;
  font-family: Arial, sans-serif;
}

.form-title {
  text-align: center;
  color: #2c3e50;
  margin-bottom: 30px;
  text-transform: uppercase;
  font-size: 1.5rem;
}

.registration-form {
  background-color: #fff;
  padding: 30px;
  border-radius: 8px;
  box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
}

.form-section {
  margin-bottom: 30px;
  padding-bottom: 20px;
  border-bottom: 1px solid #eee;
}

.section-title {
  color: #3498db;
  margin-bottom: 20px;
  font-size: 1.2rem;
}

.form-row {
  display: flex;
  gap: 20px;
  margin-bottom: 15px;
}

.form-group {
  flex: 1;
}

label {
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
  color: #555;
}

.required {
  color: #e74c3c;
}

input[type="text"],
input[type="email"],
input[type="password"],
input[type="tel"],
input[type="number"],
input[type="date"],
select,
textarea {
  width: 100%;
  padding: 10px;
  border: 1px solid #ddd;
  border-radius: 4px;
  font-size: 1rem;
}

.date-input {
  margin-top: 5px;
}

.radio-group {
  display: flex;
  gap: 15px;
  margin-top: 5px;
}

.radio-group label {
  display: flex;
  align-items: center;
  gap: 5px;
  font-weight: normal;
  cursor: pointer;
}

.hint {
  display: block;
  margin-top: 5px;
  color: #7f8c8d;
  font-size: 0.8rem;
}

.image-preview {
  margin-top: 10px;
  max-width: 150px;
}

.image-preview img {
  width: 100%;
  border: 1px solid #ddd;
  border-radius: 4px;
}

.submit-button {
  background-color: #2ecc71;
  color: white;
  border: none;
  padding: 12px 20px;
  border-radius: 4px;
  cursor: pointer;
  font-size: 1rem;
  transition: background-color 0.3s;
}

.submit-button:hover {
  background-color: #27ae60;
}

.submit-button:disabled {
  background-color: #95a5a6;
  cursor: not-allowed;
}

.form-footer {
  text-align: center;
  margin-top: 30px;
}

.form-note {
  margin-top: 20px;
  font-style: italic;
  color: #7f8c8d;
  text-align: right;
}
</style>
