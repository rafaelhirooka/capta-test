import React, { useCallback, useEffect, useMemo, useState } from 'react';

import { DataGrid, Column, Editing, Lookup } from 'devextreme-react/data-grid';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

import {Container} from './styles';

interface IClient {
  id: number;
  name: string;
  cpf: string;
  gender: string;
  idClientType: number;
  idClientSituation: number;
}

export function Client() {
  const [clientsSource, setClientsSource] = useState<DataSource>(
    {} as DataSource,
  );

  const [typeSource, setTypeSource] = useState<any>();
  const [situationSource, setSituationSource] = useState<any>();

  const fetchData = useCallback(() => {
    const clientsStore = new CustomStore({
      key: 'id',
      loadMode: 'raw',
      load: async () => {
        const response = await fetch('https://localhost:44413/api/clients');
        return await response.json();
      },
      insert: async data => {
        const response = await fetch('https://localhost:44413/api/clients', {
          method: 'post',
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({
            ...data,
            document: data.document?.toString(),
          })
        });
        return await response.json();
      },
      update: async (id, data) => {
        const response = await fetch(`https://localhost:44413/api/clients/${id}`, {
          method: 'put',
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({
            ...data,
            document: data.document?.toString(),
          })
        });
        return await response.json();
      },
      remove: async id => {
        await fetch(`https://localhost:44413/api/clients/${id}`, {
          method: 'delete',
        });
      },
    });
  
    setClientsSource(
      new DataSource({
        store: clientsStore,
        paginate: true,
        reshapeOnPush: true,
      }),
    );

    setTypeSource({
      store: new CustomStore({
        key: 'ID',
        loadMode: 'raw',
        load: async () => {
          const response = await fetch('https://localhost:44413/api/client-types');
          return await response.json();
        },
      }),
      paginate: true,
    });

    setSituationSource({
      store: new CustomStore({
        key: 'ID',
        loadMode: 'raw',
        load: async () => {
          const response = await fetch('https://localhost:44413/api/client-situations');
          return await response.json();
        },
      }),
      paginate: true,
    });
  }, []);

  useEffect(() => {
    fetchData();
  }, [fetchData]);

  const genders = useMemo(() => [
    'Female', 'Male'
  ], [])

  return <Container>
    <DataGrid
      dataSource={clientsSource}
    >
      <Editing allowAdding allowUpdating allowDeleting />
      <Column dataField="name" />
      <Column dataField="document" dataType="number" />
      <Column dataField="gender">
        <Lookup
          dataSource={genders}
        />
      </Column>
      <Column dataField="idClientType" caption="Type">
        <Lookup
          dataSource={typeSource}
          displayExpr="name"
          valueExpr="id"
        />
      </Column>
      <Column dataField="idClientSituation" caption="Situation">
        <Lookup
          dataSource={situationSource}
          displayExpr="name"
          valueExpr="id"
        />
      </Column>
    </DataGrid>
  </Container>
}