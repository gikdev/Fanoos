import tailwindcss from "@tailwindcss/vite"
import { tanstackRouter } from "@tanstack/router-plugin/vite"
import react from "@vitejs/plugin-react"
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

const reactPlugin = react({
  babel: {
    plugins: [["babel-plugin-react-compiler"]],
  },
})

const tanstackRouterPlugin = tanstackRouter({
  target: "react",
  autoCodeSplitting: false,
  semicolons: false,
  quoteStyle: "double",
  generatedRouteTree: "./src/app/router/route-tree.gen.ts",
})

const plugins: PluginOption[] = [
  tanstackRouterPlugin,
  reactPlugin,
  tailwindcss(),
  tsconfigPaths(),
  vitePwaPlugin,
  null,
  null,
  null,
]

const server: UserConfig["server"] = {
  port: 4368,
  proxy: {
    "/api": {
      target: "http://localhost:5078",
      changeOrigin: true,
      secure: false,
    },
  },
}

export default defineConfig({
  plugins,
  server,
})
