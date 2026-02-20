import './styles.css'
import { createApp } from 'vue'
import { createPinia } from 'pinia'
import App from './app.vue'
import { router } from './router'
import { PiniaColada } from '@pinia/colada'

const app = createApp(App)

app.use(createPinia())
app.use(router)
app.use(PiniaColada, {
  queryOptions: {
    staleTime: 0,
  },
})

const TARGET = '#app'

if (document.querySelector(TARGET) == null)
  throw new Error(`The element '${TARGET}' was not found!`)

app.mount(TARGET)
