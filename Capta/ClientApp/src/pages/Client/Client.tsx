import React, { useEffect, useState } from 'react';

import {Container, Table} from './styles';

export function Client() {
  const [clients, setClients] = useState([]);

  useEffect(() => {
    fetch('https://localhost:44413/api/clients')
    .then(response => response.json())
    .then(data => setClients(data));
  }, []);

  return <Container>
    <Table></Table>
  </Container>
}