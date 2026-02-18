import { svelte } from "@sveltejs/vite-plugin-svelte"
import tailwindcss from "@tailwindcss/vite"
import { sveltePhosphorOptimize } from "phosphor-svelte/vite"
import { router } from "sv-router/vite-plugin"
import { defineConfig, type PluginOption, type UserConfig } from "vite"
import { VitePWA } from "vite-plugin-pwa"
import tsconfigPaths from "vite-tsconfig-paths"

const vitePwaPlugin = VitePWA({
  registerType: "prompt",
  injectRegister: false,

  pwaAssets: {
    disabled: false,
    config: "./vite-pwa-assets.config.ts",
  },

  manifest: {
    id: "ir.bahrami85.fanoos",
    name: "فانوس",
    short_name: "فانوس",
    description: "یه برنامه کاربردی...",
    theme_color: "#0284C7",
  },

  workbox: {
    globPatterns: ["**/*.{js,css,html,svg,png,ico,woff,woff2,ttf}"],
    cleanupOutdatedCaches: true,
    clientsClaim: true,
  },

  devOptions: {
    enabled: false,
    navigateFallback: "index.html",
    suppressWarnings: true,
    type: "module",
  },
})

const plugins: PluginOption[] = [
  tsconfigPaths(),
  svelte(),
  router(),
  sveltePhosphorOptimize(),
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

const server: UserConfig["server"] = {
  port: 4368,
  proxy: {
    "/api": {
      target: "http://localhost:5368",
      changeOrigin: true,
      secure: false,
    },
  },
}

export default defineConfig({
  plugins,
  server,
})
