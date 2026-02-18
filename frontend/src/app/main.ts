import { mount } from "svelte"

import App from "./App.svelte"
import "./styles/main.css"

const target = document.getElementById("app")
if (target == null) throw new Error(`App container (#app) is null!`)

const app = mount(App, { target })

export default app
