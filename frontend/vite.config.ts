import tailwindcss from "@tailwindcss/vite"
import { tanstackRouter } from "@tanstack/router-plugin/vite"
import react from "@vitejs/plugin-react"
import { defineConfig, type UserConfig } from "vite"
import tsconfigPaths from "vite-tsconfig-paths"

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

const server: UserConfig["server"] = {
  port: 4368,
}

export default defineConfig({
  plugins: [tanstackRouterPlugin, reactPlugin, tailwindcss(), tsconfigPaths()],
  server,
})
