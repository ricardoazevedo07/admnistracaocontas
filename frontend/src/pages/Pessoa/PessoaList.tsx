import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { useNavigate } from 'react-router-dom'
import { getPessoas, deletePessoa } from '../../api/pessoa.service'

export default function PessoaList() {
  const queryClient = useQueryClient()
  const navigate = useNavigate()

  const { data, isLoading } = useQuery({
    queryKey: ['pessoas'],
    queryFn: getPessoas
  })

  const mutation = useMutation({
    mutationFn: deletePessoa,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['pessoas'] })
    }
  })

  if (isLoading) return <p>Loading...</p>

  return (
    <div className="card shadow">
      <div className="card-header d-flex justify-content-between align-items-center">
        <h4 className="mb-0">Pessoas</h4>
        <button
          className="btn btn-primary"
          onClick={() => navigate('/pessoa/create')}
        >
          Nova Pessoa
        </button>
      </div>

      <div className="card-body">
        <table className="table table-striped table-hover">
          <thead className="table-dark">
            <tr>
              <th>Nome</th>
              <th>Data Nascimento</th>
              <th>Idade</th>
              <th width="200">Ações</th>
            </tr>
          </thead>
          <tbody>
            {data?.map(p => (
              <tr key={p.pessoaId}>
                <td>{p.nome}</td>
                <td>
                  {new Date(p.dataNascimento).toLocaleDateString('pt-BR')}
                </td>
                <td>{p.idade}</td>
                <td>
                  <button
                    className="btn btn-sm btn-warning me-2"
                    onClick={() => navigate(`/pessoa/edit/${p.pessoaId}`)}
                  >
                    Editar
                  </button>

                  <button className="btn btn-sm btn-danger" onClick={() => mutation.mutate(p.pessoaId)}>
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
