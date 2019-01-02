<template>
     <v-layout aling-start>
        <v-flex>
            <v-toolbar flat color="white">
            <v-toolbar-title>Politicas</v-toolbar-title>
            <v-divider
              class="mx-2"
              inset
              vertical
            ></v-divider>
            <v-spacer></v-spacer>
            <v-text-field class="text-xs-center" v-model="name" append-icon="search" label="Búsqueda" single-line hide-details></v-text-field>
          </v-toolbar>
          <v-data-table
            :headers="headers"
            :items="politics"
            class="elevation-1"
          >
            <template slot="items" slot-scope="props">
              <td>{{ props.item.email }}</td>
              <td>{{ props.item.amountInsured }}</td>
              <td>{{ props.item.inceptionDate }}</td>
              <td> 
                <template v-if="props.item.installmentPayment">
                  <span class="green--text"> Pagado </span>
                </template>
                <template v-else>
                  <span class="red--text"> En deuda </span>
                </template>
                </td>
            </template>
          </v-data-table>
        </v-flex>
    </v-layout>
</template>
<script>
  import PolicyService from '../services/policies.service';
  export default {
    data(){
      return {
        politics: [],
        name:'',
        headers:[
          { text: 'Correo', value: 'email' },
          { text: 'Valor asegurado', value: 'amountInsured' },
          { text: 'Fecha Inspeccion', value: 'inceptionDate' },
          { text: 'Pagado', value: 'installmentPayment' },
        ],
      }
    },
    methods:{
      getPolicies(){
        const self = this;
        PolicyService.get(self.name)
          .then(r => {
            self.politics = r;
            console.log(self.politics);
          });
      }
    },
    computed: {
      
    },
    watch: {
      name (val) {
        const self = this;
        if(val.length > 2)
          self.getPolicies();
      }
    },
    created () {
    },
  }
</script>
