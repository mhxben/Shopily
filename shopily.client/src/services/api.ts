import axios from "axios";

const API_URL = "https://localhost:7194/api";

const api = axios.create({
  baseURL: API_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

// Register user
export const registerUser = async (userData: any) => {
  return await api.post("/auth/register", userData);
};

// Login user
export const loginUser = async (userData: any) => {
  return await api.post("/auth/login", userData);
};

// Fetch user profile
export const getUserProfile = async (token: string) => {
  return await api.get("/auth/profile", {
    headers: { Authorization: `Bearer ${token}` },
  });
};
