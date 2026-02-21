import { defineConfig, type PluginOption, type UserConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import vueDevTools from 'vite-plugin-vue-devtools'
import tailwindcss from '@tailwindcss/vite'
import { VitePWA } from 'vite-plugin-pwa'
import tsconfigPaths from 'vite-tsconfig-paths'
import path from 'node:path'

const vitePwaPlugin = VitePWA({
  registerType: 'prompt',
  injectRegister: false,

  pwaAssets: {
    disabled: false,
    config: './vite-pwa-assets.config.ts',
  },

  manifest: {
    id: 'ir.bahrami85.fanoos',
    name: 'فانوس',
    short_name: 'فانوس',
    description: 'یه برنامه کاربردی...',
    theme_color: '#0284C7',
  },

  workbox: {
    globPatterns: ['**/*.{js,css,html,svg,png,ico,woff,woff2,ttf}'],
    cleanupOutdatedCaches: true,
    clientsClaim: true,
  },

  devOptions: {
    enabled: false,
    navigateFallback: 'index.html',
    suppressWarnings: true,
    type: 'module',
  },
})

const plugins: PluginOption[] = [
  tsconfigPaths(),
  vue(),
  vueDevTools(),
  tailwindcss(),
  vitePwaPlugin,
  null,
  null,
  null,
  null,
  null,
  null,
  null,
]

const server: UserConfig['server'] = {
  proxy: {
    '/api': {
      target: 'http://localhost:5000',
      changeOrigin: true,
      secure: false,
    },
  },
}

const resolve: UserConfig['resolve'] = {
  alias: {
    '#': path.resolve(__dirname, 'src'),
  },
}

export default defineConfig({
  plugins,
  server,
  resolve,
})
