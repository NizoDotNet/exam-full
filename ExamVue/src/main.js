import './assets/style.css'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap/dist/js/bootstrap.bundle.js'
import { createApp } from 'vue'
import App from './App.vue'

import router from './router'

const app = createApp(App)

app.use(router)

app.config.warnHandler = (msg, instance, trace) => {
  msg = ''
  instance = null
  trace = ''
}

app.mount('#app')
