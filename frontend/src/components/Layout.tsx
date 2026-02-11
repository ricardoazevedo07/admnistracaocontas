import { Link } from 'react-router-dom'
import type { ReactNode } from 'react'

type Props = {
  children: ReactNode
}

export default function Layout({ children }: Props) {
  return (
    <>
      <nav className="navbar navbar-expand-lg navbar-dark bg-dark shadow">
        <div className="container">
          <Link className="navbar-brand fw-bold" to="/">
            Sistema Financeiro
          </Link>

          <div className="collapse navbar-collapse show">
            <ul className="navbar-nav ms-auto">
              <li className="nav-item">
                <Link className="nav-link" to="/pessoa">Pessoa</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/categoria">Categoria</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/transacao">Transação</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/categoriasResumo">Resumo das Categorias</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/pessoasResumo">Resumo Pessoas</Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>

      <div className="container mt-5">
        {children}
      </div>
    </>
  )
}
