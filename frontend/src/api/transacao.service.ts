import api from './axios'
import type { Transacao } from '../types/transacao';
import type { Tipo } from '../types/tipo';

export const getTipos = async () : Promise<Tipo[]> => {
  const {data} = await api.get('Transacao/Tipos')
  return data;
}
export const getTransacoes = async () : Promise<Transacao[]> => {
    const {data} = await api.get('Transacao')
    return data;
}

export const getTransacao = async (transacaoId: string): Promise<Transacao> => {
    const { data } = await api.get(`/transacao/${transacaoId}`)
    return data
  } 
  
  export const createTransacao = async (transacao: Omit<Transacao, 'transacaoId'>) => { 
    return api.post('/Transacao', transacao);
  }
  
  export const updateTransacao = async (transacaoId: string, transacao: Omit<Transacao, 'transacaoId'>) => {
    return api.put(`/transacao/${transacaoId}`, transacao)
  }
  
  export const deleteTransacao = async (transacaoId: string) => {
    return api.delete(`/transacao/${transacaoId}`)
  }
