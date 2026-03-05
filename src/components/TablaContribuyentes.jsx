import React from 'react';

const TablaContribuyentes = ({ lista, alSeleccionar }) => { 
  return (
    <div style={{ padding: '20px' }}>

      <h2>Listado de Contribuyentes (DGII)</h2>

      <table border="1" style={{ width: '100%', borderCollapse: 'collapse', textAlign: 'left' }}>
        <thead style={{ backgroundColor: '#f2f2f2' }}>

          <tr>
            <th>RNC / Cédula</th>
            <th>Nombre</th>
            <th>Tipo</th>
            <th>Estatus</th>
            <th>Acción</th>
          </tr>

        </thead>
        <tbody>
          {lista.map((c) => (
            <tr key={c.rncCedula}>
              <td>{c.rncCedula}</td>
              <td>{c.nombre}</td>
              <td>{c.tipo}</td>
              <td>{c.estatus}</td>
              <td>

                <button onClick={() => alSeleccionar(c)}>Ver Comprobantes</button>

              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default TablaContribuyentes;