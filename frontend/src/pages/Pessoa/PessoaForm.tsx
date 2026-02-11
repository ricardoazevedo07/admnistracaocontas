import { useForm } from 'react-hook-form'
import React from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { useQuery, useMutation } from '@tanstack/react-query'
import { getPessoa, createPessoa, updatePessoa } from '../../api/pessoa.service'
import type { Pessoa } from '../../types/pessoa'

export default function PessoaForm() {
  const { pessoaId } = useParams()
  const navigate = useNavigate()

  const { register, handleSubmit, reset } = useForm<Omit<Pessoa, 'pessoaId'>>()

  const { data } = useQuery({
    queryKey: ['pessoaId', pessoaId],
    queryFn: () => getPessoa(pessoaId!),
    enabled: !!pessoaId, 
    
  })

 
  const mutation = useMutation({
    mutationFn: (data: Omit<Pessoa, 'pessoaId'>) =>
        pessoaId ? updatePessoa(pessoaId, data) : createPessoa(data),
    onSuccess: () => navigate('/pessoa')
  })

  React.useEffect(() => {
    if (data) reset({...data, dataNascimento:data.dataNascimento?.toString().substring(0,10)})
  }, [data, reset])

  const onSubmit = (formData: Omit<Pessoa, 'pessoaId'>) => {
    mutation.mutate(formData)
  }

  return (
  
      <div className="row justify-content-center">
        <div className="col-md-6">
          <div className="card shadow">
            <div className="card-header bg-primary text-white">
              <h5 className="mb-0">
                {pessoaId ? 'Editar Pessoa' : 'Nova Pessoa'}
              </h5>
            </div>
    
            <div className="card-body">
              <form onSubmit={handleSubmit(onSubmit)}>
    
                <div className="mb-3">
                  <label className="form-label">Nome</label>
                  <input
                    className="form-control"
                    {...register('nome')}
                  />
                </div>
    
                <div className="mb-3">
                  <label className="form-label">Data de Nascimento</label>
                  <input
                    type="date"
                    className="form-control"
                    {...register('dataNascimento')}
                  />
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
