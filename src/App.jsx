import { useState, useEffect } from 'react'
import axios from 'axios'
import TablaContribuyentes from './components/TablaContribuyentes'
import DetalleComprobantes from './components/DetalleComprobantes'

function App() {
  const [lista, setLista] = useState([]); 
  const [seleccionado, setSeleccionado] = useState(null);

  useEffect(() => {
    // Llamada real al Backend 
    axios.get('https://localhost:7269/api/Contribuyentes')
      .then(response => {
        setLista(response.data);
      })
      .catch(error => {
        console.error("Error conectando al API:", error);
      });
  }, []);

  return (
    <div className="App">
      <header style={{ backgroundColor: '#d32f2f', color: 'white', padding: '10px', marginBottom: '20px' }}>
        <h1>Sistema de Gestión Fiscal</h1>
      </header>

      <main style={{ maxWidth: '900px', margin: '0 auto' }}>
        <TablaContribuyentes 
          lista={lista} 
          alSeleccionar={(c) => setSeleccionado(c)} 
        />

        {seleccionado && (
          <DetalleComprobantes 
            rnc={seleccionado.rncCedula} 
            nombre={seleccionado.nombre} 
          />
        )}
      </main>
    </div>
  )
}

export default App