

import axios from 'axios'
import { useError } from '../context/errorcontext'


let showGlobalError: ((message: string) => void) | null = null

export function setErrorHandler(fn: (message: string) => void) {
  showGlobalError = fn
}

const api = axios.create({
  baseURL: 'https://localhost:7191/api'
})

api.interceptors.response.use(
  response => response,
  error => {
    const message =
      error.response?.data?.title ||
      error.response?.data?.message ||
      error.message ||
      'Erro inesperado'

    if (showGlobalError) {
      showGlobalError(message)
    }

    return Promise.reject(error)
  }
)

export default api
