
import { useForm } from 'react-hook-form'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { getTransacao, createTransacao, updateTransacao, getTipos } from '../../api/transacao.service'
import { getCategorias } from '../../api/categoria.service'
import { getPessoas } from '../../api/pessoa.service'
import type { Transacao } from '../../types/transacao'
import type { Categoria } from '../../types/categoria'
import type { Pessoa } from '../../types/pessoa'
import type { Tipo } from '../../types/tipo'

export default function TransacaoForm() {
  const { transacaoId } = useParams()
  const navigate = useNavigate()

  const { register, handleSubmit, reset } = useForm<Omit<Transacao, 'transacaoId'>>()

  const [categorias, setCategorias] = useState<Categoria[]>([])
  const [pessoas, setPessoas] = useState<Pessoa[]>([])
  const [tipos, setTipos] = useState<Tipo[]>([]);

  useEffect(() => {
    async function init() {
      const cats = await getCategorias()
      const pess = await getPessoas()
      const tipos = await getTipos()
  
      setCategorias(cats)
      setPessoas(pess)
      setTipos(tipos)
  
      if (transacaoId) {
        const data = await getTransacao(transacaoId)
  
        reset({
          ...data,
          tipo: Number(data.tipo) 
        })
      }
    }
  
    init()
  }, [transacaoId, reset])
  
 
  async function onSubmit(formData: Omit<Transacao, 'transacaoId'>) {
    if (transacaoId)
      await updateTransacao(transacaoId, formData)
    else
      await createTransacao(formData)

    navigate('/transacao')
  }

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="card shadow-sm">
      
      <div className="card-header">
        <h5 className="mb-0">
          {transacaoId ? 'Editar Transação' : 'Nova Transação'}
        </h5>
      </div>

      <div className="card-body">

        <div className="mb-3">
          <label className="form-label">Descrição</label>
          <input
            {...register('descricao')}
            className="form-control"
          />
        </div>

        <div className="mb-3">
          <label className="form-label">Valor</label>
          <input
            type="number"
            step="0.01"
            {...register('valor', { valueAsNumber: true })}
            className="form-control"
          />
        </div>       
        <div className="mb-3">
          <label className="form-label">Categoria</label>
          <select
            {...register('categoriaId')}
            className="form-select text-dark"
          >
            <option value="">Selecione</option>
            {categorias.map(c => (
              <option key={c.categoriaId} value={c.categoriaId}>
                {c.descricao}
              </option>
            ))}
          </select>
        </div>
        <div className="mb-3">
          <label className="form-label">Pessoa</label>
          <select
            {...register('pessoaId')}
            className="form-select"
          >
            <option value="">Selecione</option>
            {pessoas.map(p => (
              <option key={p.pessoaId} value={p.pessoaId}>
                {p.nome}
              </option>
            ))}
          </select>
        </div>
        <div className="mb-3">
          <label className="form-label">Tipo</label>
          <select
            {...register('tipo', {valueAsNumber:true})}
            className="form-select"
          >
            <option value="">Selecione</option>
            {tipos.map(p => (
              <option key={p.id} value={p.id}>
                {p.nome}
              </option>
            ))}
          </select>
        </div>
      </div>
      <div className="card-footer text-end">
        <button type="submit" className="btn btn-success">
          Salvar
        </button>
      </div>

    </form>
  )
}

















