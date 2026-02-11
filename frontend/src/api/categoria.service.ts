import api from './axios'
import type { Categoria } from '../types/categoria'
import type { CategoriaResumo } from '../types/categoriaResumo'
import type { Tipo } from '../types/tipo'

export const getCategorias = async () : Promise<Categoria[]> => {
    const {data} = await api.get('Categoria')
    return data;
}

export const getFinalidades = async () : Promise<Tipo[]> => {
  const {data} = await api.get('Categoria/Finalidades')
  return data;
}

export const getCategoria = async (categoriaId: string): Promise<Categoria> => {
    const { data } = await api.get(`/categoria/${categoriaId}`)
    return data
  }
  
  
  export const createCategoria = async (categoria: Omit<Categoria, 'categoriaId'>) => {
    console.log(categoria)
   
    return api.post('/Categoria', categoria)
  }
  
  export const updateCategoria = async (categoriaId: string, categoria: Omit<Categoria, 'categoriaId'>) => {
    return api.put(`/categoria/${categoriaId}`, categoria)
  }
  
  export const deleteCategoria = async (categoriaId: string) => {
    return api.delete(`/categoria/${categoriaId}`)
  }

  export const getCategoriasResumo = async () : Promise<CategoriaResumo[]> => {
    const {data} = await api.get('/categoria/GetCategoriasResumo')
    return data;
}