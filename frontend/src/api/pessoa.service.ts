import api from './axios'
import type { Pessoa } from '../types/pessoa';
import type { PessoaResumo } from '../types/pessoaResumo';

export const getPessoas = async () : Promise<Pessoa[]> => {
    const {data} = await api.get('Pessoa')
    return data;
}

export const getPessoa = async (pessoaId: string): Promise<Pessoa> => {
    const { data } = await api.get(`/pessoa/${pessoaId}`)
    return data
  } 
  
  export const createPessoa = async (pessoa: Omit<Pessoa, 'pessoaId'>) => { 
    return api.post('/Pessoa', pessoa);
  }
  
  export const updatePessoa = async (pessoaId: string, pessoa: Omit<Pessoa, 'pessoaId'>) => {
    return api.put(`/pessoa/${pessoaId}`, pessoa)
  }
  
  export const deletePessoa = async (pessoaId: string) => {
    return api.delete(`/pessoa/${pessoaId}`)
  }

    export const getPessoasResumo = async () : Promise<PessoaResumo[]> => {
      const {data} = await api.get('/Pessoa/GetPessoasResumo')
      return data;
  }