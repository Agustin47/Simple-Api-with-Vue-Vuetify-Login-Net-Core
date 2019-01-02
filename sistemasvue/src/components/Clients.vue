<template>
    <v-layout aling-start>
        <v-flex>
            <v-toolbar flat color="white">
            <v-toolbar-title>Clientes</v-toolbar-title>
            <v-divider
              class="mx-2"
              inset
              vertical
            ></v-divider>
            <v-spacer></v-spacer>
            <v-text-field class="text-xs-center" v-model="search" append-icon="search" label="Búsqueda" single-line hide-details></v-text-field>
          </v-toolbar>
          <v-data-table
            :headers="headers"
            :items="clientes"
            :search="search"
            class="elevation-1"
          >
            <template slot="items" slot-scope="props">
              <td>{{ props.item.name }}</td>
              <td>{{ props.item.role }}</td>
              <td>{{ props.item.email }}</td>
            </template>
            <template slot="no-data">
              <v-btn color="primary" @click="listar">Resetear</v-btn>
            </template>
          </v-data-table>
        </v-flex>
    </v-layout>
</template>
<script>
  import ClientService from '../services/client.service';
  export default {
    data(){
      return {
        headers: [
          { text: 'Nombre', value: 'name' },
          { text: 'Rol', value: 'role' },
          { text: 'Correo', value: 'email', sortable: false }
        ],
        search: '',
        clientes: [],
      }
    },
    methods:{
      listar (){
        const self = this;
        ClientService.get()
          .then( r => {
            self.clientes = Object.assign([],r);
          });
      },
    },
    computed: {
      isAdmin(){
        return this.$store.state.usuario 
            && this.$store.state.usuario.rol == 'admin'; 
      },
    },
    created () {
      this.listar();
    },
  }
</script>
