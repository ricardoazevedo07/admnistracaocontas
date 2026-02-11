import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { useNavigate } from 'react-router-dom'
import { getPessoasResumo } from '../../api/pessoa.service'
import { Link } from 'react-router-dom'

export default function PessoasResumoList() {
  const queryClient = useQueryClient()
  const navigate = useNavigate()

  const { data, isLoading } = useQuery({
    queryKey: ['GetPessoasResumo'],
    queryFn: getPessoasResumo
  }) 

  if (isLoading) return <p>Loading...</p>
  const totalReceitas = data?.reduce(
    (acc, c) => acc + c.totalReceitas,
    0
  ) ?? 0
  
  const totalDespesas = data?.reduce(
    (acc, c) => acc + c.totalDespesas,
    0
  ) ?? 0
  
  const saldoGeral = totalReceitas - totalDespesas

  return (
    <div className="card shadow-sm">
  <div className="card-header d-flex justify-content-between">
    <h5 className="mb-0">Pessoa</h5>
    <Link to="/pessoa/create" className="btn btn-primary btn-sm">
      + Nova pessoa
    </Link>
  </div>

  <div className="card-body p-0">
    <table className="table table-hover mb-0">
      <thead className="table-light">
        <tr>
          <th>Nome</th>         
          <th>Receitas</th>
          <th>Despesas</th>
          <th>Saldo</th>
        </tr>
      </thead>
      <tbody>
        {data?.map(c => (
          <tr key={c.pessoaId}>
            <td>{c.nome}</td>         
            <td>{c.totalReceitas}</td>
            <td>{c.totalDespesas}</td>
            <td>{c.saldo}</td>
          </tr>
        ))}

<tr className="table-dark">
    <td colSpan={1}>
      <strong>Total Geral</strong>
    </td>
    <td className="text-success">
      <strong>R$ {totalReceitas.toFixed(2)}</strong>
    </td>
    <td className="text-danger">
      <strong>R$ {totalDespesas.toFixed(2)}</strong>
    </td>
    <td className={saldoGeral >= 0 ? "text-success fw-bold" : "text-danger fw-bold"}>
      <strong>R$ {saldoGeral.toFixed(2)}</strong>
    </td>
  </tr>
      </tbody>
    </table>
  </div>
</div>
  )
}
