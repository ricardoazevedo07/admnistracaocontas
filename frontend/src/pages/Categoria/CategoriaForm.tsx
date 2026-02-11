import { useForm } from 'react-hook-form'
import React, { useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { useQuery, useMutation } from '@tanstack/react-query'
import { getCategoria, createCategoria, updateCategoria, getFinalidades } from '../../api/categoria.service'
import type { Categoria } from '../../types/categoria'
import type { Tipo } from '../../types/tipo'



export default function CategoriaForm() {
  const { categoriaId } = useParams()
  const navigate = useNavigate()

  const { register, handleSubmit, reset } = useForm<Omit<Categoria, 'categoriaId'>>()

   const [finalidades, setFinalidades] = useState<Tipo[]>([]);

  const loadAuxiliares = async function(){
    const fin = await getFinalidades();
    setFinalidades(fin);
  }
  const { data } = useQuery({
    queryKey: ['categoriaId', categoriaId],
    queryFn: () => getCategoria(categoriaId!),
    enabled: !!categoriaId
  })

  const mutation = useMutation({
    mutationFn: (data: Omit<Categoria, 'categoriaId'>) =>
      categoriaId ? updateCategoria(categoriaId, data) : createCategoria(data),
    onSuccess: () => navigate('/categoria')
  })

  React.useEffect(() => {
    loadAuxiliares();
    if (data) {reset({...data, finalidade:Number(data.finalidade)}); }
  }, [data, reset])

  const onSubmit = (formData: Omit<Categoria, 'categoriaId'>) => {
    mutation.mutate(formData)
  }

  return (   

    <div className="row justify-content-center">
    <div className="col-md-6">
      <div className="card shadow">
        <div className="card-header bg-primary text-white">
          <h5 className="mb-0">
            {categoriaId ? 'Editar Categoria' : 'Nova Categoria'}
          </h5>
        </div>

        <div className="card-body">
          <form onSubmit={handleSubmit(onSubmit)}>

            <div className="mb-3">
              <label className="form-label">Nome</label>
              <input
                className="form-control"
                {...register('descricao')}
              />
            </div>

            <div className="mb-3">
          <label className="form-label">Finalidade</label>
          <select
            {...register('finalidade',{ valueAsNumber: true })}
            className="form-select text-dark"
          >
            <option value="">Selecione</option>
            {finalidades.map(c => (
              <option key={c.id} value={c.id}>
                {c.nome}
              </option>
            ))}
          </select>
        </div>

            <div className="d-flex justify-content-end">
              <button className="btn btn-success">
                Salvar
              </button>
            </div>

          </form>
        </div>
      </div>
    </div>
  </div>
  )
}
