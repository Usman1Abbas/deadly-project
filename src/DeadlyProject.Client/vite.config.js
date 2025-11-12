import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    proxy: {
      '/products': {
        target: 'https://localhost:7000', // TODO: Change the port to your API port
        secure: false,
        changeOrigin: true
      }
    }
  }
})