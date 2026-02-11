import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { useNavigate, Link } from 'react-router-dom'
import { getTransacoes, deleteTransacao } from '../../api/transacao.service'

export default function TransacaoList() {
  const queryClient = useQueryClient()
  const navigate = useNavigate()

  const { data, isLoading } = useQuery({
    queryKey: ['transacoes'],
    queryFn: getTransacoes
  })

  const mutation = useMutation({
    mutationFn: deleteTransacao,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['transacoes'] })
    }
  })

  if (isLoading) return <p>Loading...</p>

  return (
    <div className="card shadow-sm">
    <div className="card-header d-flex justify-content-between">
      <h5 className="mb-0">Transações</h5>
      <Link to="/transacao/create" className="btn btn-primary btn-sm">
        + Nova Transação
      </Link>
    </div>
  
    <div className="card-body p-0">
      <table className="table table-hover mb-0">
        <thead className="table-light">
          <tr>
            <th>Descrição</th>
            <th>Valor</th>
        
            <th className="text-end">Ações</th>
          </tr>
        </thead>
        <tbody>
          {data?.map(t => (
            <tr key={t.transacaoId}>
              <td>{t.descricao}</td>
              <td>R$ {t.valor.toFixed(2)}</td>
             
              <td className="text-end">
              <button
                    className="btn btn-sm btn-warning me-2"
                    onClick={() => navigate(`/transacao/edit/${t.transacaoId}`)}
                  >
                    Editar
                  </button>

                  <button className="btn btn-sm btn-danger" onClick={() => mutation.mutate(t.transacaoId)}>
                    Excluir
                  </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  </div>
  )  
}
