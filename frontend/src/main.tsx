
import ReactDOM from 'react-dom/client'
import { QueryClient, QueryClientProvider } from '@tanstack/react-query'
import { BrowserRouter } from 'react-router-dom'
import App from './App'
import 'bootstrap/dist/css/bootstrap.min.css'
import { ErrorProvider } from './context/errorcontext'
const queryClient = new QueryClient()

ReactDOM.createRoot(document.getElementById('root')!).render(
  <QueryClientProvider client={queryClient}>
    <BrowserRouter>
    <ErrorProvider> 
       <App />
    </ErrorProvider>
    
    </BrowserRouter>
  </QueryClientProvider>
)
