import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { useNavigate } from 'react-router-dom'
import { getCategorias, deleteCategoria } from '../../api/categoria.service'
import { Link } from 'react-router-dom'

export default function CategoriaList() {
  const queryClient = useQueryClient()
  const navigate = useNavigate()

  const { data, isLoading } = useQuery({
    queryKey: ['categorias'],
    queryFn: getCategorias
  })

  const mutation = useMutation({
    mutationFn: deleteCategoria,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['categorias'] })
    }
  })

  if (isLoading) return <p>Loading...</p>


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
          <th className="text-end">Ações</th>
        </tr>
      </thead>
      <tbody>
        {data?.map(c => (
          <tr key={c.categoriaId}>
            <td>{c.descricao}</td>
            <td>{labelsFinalidade[c.finalidade]}</td>
            <td className="text-end">             
              <button
                    className="btn btn-sm btn-warning me-2"
                    onClick={() => navigate(`/categoria/edit/${c.categoriaId}`)}
                  >
                    Editar
                  </button>

                  <button className="btn btn-sm btn-danger" onClick={() => mutation.mutate(c.categoriaId)}>
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
