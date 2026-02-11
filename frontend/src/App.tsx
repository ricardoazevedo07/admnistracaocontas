import { Routes, Route } from 'react-router-dom'
import CategoriaList from './pages/Categoria/CategoriaList'
import CategoriaForm from './pages/Categoria/CategoriaForm'
import TransacaoList from './pages/Transacao/TransacaoList'
import TransacaoForm from './pages/Transacao/TransacaoForm'
import PessoaList from './pages/Pessoa/PessoaList'
import PessoaForm from './pages/Pessoa/PessoaForm'
import Layout from './components/Layout'
import CategoriaResumoList from './pages/Categoria/CategoriaResumoList'
import PessoasResumoList from './pages/Pessoa/PessoasResumoList'
import { useError } from './context/errorcontext'
import { useEffect } from 'react'
import { setErrorHandler } from './api/axios'

export default function App() {
  const { showError } = useError()

  useEffect(() => {
    setErrorHandler(showError)
  }, [showError])
  
  return (
    <Layout>
    <Routes>
      <Route path="/categoria" element={<CategoriaList />} />
      <Route path="/categoria/create" element={<CategoriaForm />} />
      <Route path="/categoria/edit/:categoriaId" element={<CategoriaForm />} />

      <Route path="/transacao" element={<TransacaoList />} />
      <Route path="/transacao/create" element={<TransacaoForm />} />
      <Route path="/transacao/edit/:transacaoId" element={<TransacaoForm />} />

      <Route path="/pessoa" element={<PessoaList />} />
      <Route path="/pessoa/create" element={<PessoaForm />} />
      <Route path="/pessoa/edit/:pessoaId" element={<PessoaForm />} />

      <Route path="/categoriasResumo" element={<CategoriaResumoList />} />
      <Route path="/pessoasResumo" element={<PessoasResumoList />} />
    </Routes>
    </Layout>
  )
}

