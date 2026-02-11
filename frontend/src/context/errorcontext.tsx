import React, { createContext, useContext, useState } from 'react'

type ErrorContextType = {
  showError: (message: string) => void
}

const ErrorContext = createContext<ErrorContextType | undefined>(undefined)

export function ErrorProvider({ children }: { children: React.ReactNode }) {
  const [error, setError] = useState<string | null>(null)

  function showError(message: string) {
    setError(message)
  }

  function close() {
    setError(null)
  }

  return (
    <ErrorContext.Provider value={{ showError }}>
      {children}

      {error && (
        <div className="modal fade show d-block" tabIndex={-1}>
          <div className="modal-dialog">
            <div className="modal-content border-danger">
              <div className="modal-header bg-danger text-white">
                <h5 className="modal-title">Erro</h5>
                <button className="btn-close btn-close-white" onClick={close}></button>
              </div>
              <div className="modal-body">
                <p>{error}</p>
              </div>
              <div className="modal-footer">
                <button className="btn btn-secondary" onClick={close}>
                  Fechar
                </button>
              </div>
            </div>
          </div>
        </div>
      )}
    </ErrorContext.Provider>
  )
}

export function useError() {
  const context = useContext(ErrorContext)
  if (!context) throw new Error("useError must be used inside ErrorProvider")
  return context
}
