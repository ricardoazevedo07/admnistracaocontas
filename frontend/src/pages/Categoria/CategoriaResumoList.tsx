import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { useNavigate } from 'react-router-dom'
import { getCategoriasResumo } from '../../api/categoria.service'
import { Link } from 'react-router-dom'

export default function CategoriaResumoList() {
  const queryClient = useQueryClient()
  const navigate = useNavigate()

  const { data, isLoading } = useQuery({
    queryKey: ['GetCategoriasResumo'],
    queryFn: getCategoriasResumo
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
  

const labelsFinalidade: Record<number, string> = {
  1: "Despesa",
  2: "Receita",
  3: "Ambos"
};

  return (
    <div className="card shadow-sm">
  <div className="card-header d-flex justify-content-between">
    <h5 className="mb-0">Categorias</h5>
    <Link to="/categoria/create" className="btn btn-primary btn-sm">
      + Nova Categoria
    </Link>
  </div>

  <div className="card-body p-0">
    <table className="table table-hover mb-0">
      <thead className="table-light">
        <tr>
          <th>Descrição</th>
          <th>Finalidade</th>
          <th>Receitas</th>
          <th>Despesas</th>
          <th>Saldo</th>
        </tr>
      </thead>
      <tbody>
        {data?.map(c => (
          <tr key={c.categoriaId}>
            <td>{c.nome}</td>
            <td>{labelsFinalidade[c.finalidade]}</td>
            <td>{c.totalReceitas}</td>
            <td>{c.totalDespesas}</td>
            <td>{c.saldo}</td>
          </tr>
        ))}

<tr className="table-dark">
    <td colSpan={2}>
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
