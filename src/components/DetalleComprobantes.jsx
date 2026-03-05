import React from 'react';
import { comprobantesMock } from '../api/data';

const DetalleComprobantes = ({ rnc, nombre }) => {
  
  const filtrados = comprobantesMock.filter(c => c.rncCedula === rnc);

  // Para Calcular el total de ITBIS 
  const totalItbis = filtrados.reduce((acc, curr) => acc + curr.itbis18, 0);

  return (
    <div style={{ marginTop: '30px', padding: '20px', backgroundColor: '#f9f9f9', borderRadius: '8px' }}>
      <h3>Comprobantes de: {nombre}</h3>
      <p>RNC: <strong>{rnc}</strong></p>
      
      <table border="1" style={{ width: '100%', borderCollapse: 'collapse', marginBottom: '15px' }}>
        <thead>
          <tr style={{ backgroundColor: '#eee' }}>
            <th>NCF</th>
            <th>Monto</th>
            <th>ITBIS (18%)</th>
          </tr>
        </thead>
        <tbody>
          {filtrados.map((comp, index) => (
            <tr key={index}>
              <td>{comp.NCF}</td>
              <td>${comp.monto.toFixed(2)}</td>
              <td>${comp.itbis18.toFixed(2)}</td>
            </tr>
          ))}
        </tbody>
      </table>

      <div style={{ textAlign: 'right', fontSize: '1.2em' }}>
        <strong>Total ITBIS Reportado: </strong>
        <span style={{ color: '#d32f2f', fontWeight: 'bold' }}>
          ${totalItbis.toFixed(2)}
        </span>
      </div>
    </div>
  );
};

export default DetalleComprobantes;