import { StrictMode } from "react"
import { createRoot } from "react-dom/client"
import { Providers } from "./providers"
import { Routes } from "./router/routes"
import "./styles/main.css"

const container = document.getElementById("root")
if (container == null) throw new Error(`App container (#root) is null!`)
createRoot(container).render(
  <StrictMode>
    <Providers>
      <Routes />
    </Providers>
  </StrictMode>,
)
