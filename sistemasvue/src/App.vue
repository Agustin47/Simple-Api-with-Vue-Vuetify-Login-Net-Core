<template>
  <v-app id="inspire">
    <v-navigation-drawer
      :clipped="$vuetify.breakpoint.lgAndUp"
      v-model="drawer"
      fixed
      app
      v-if="logedin"
    >
      <v-list dense>
        <template v-if="isAdmin || isUser">
          <v-list-tile :to="{name: 'clients'}">
            <v-list-tile-action>
              <v-icon>account_box</v-icon>
            </v-list-tile-action>
            <v-list-tile-title>
              Clientes
            </v-list-tile-title>
          </v-list-tile>
          <v-list-tile :to="{name: 'policies'}">
            <v-list-tile-action>
              <v-icon>business_center</v-icon>
            </v-list-tile-action>
            <v-list-tile-title>
              Politicas
            </v-list-tile-title>
          </v-list-tile>
          <v-list-tile :to="{name: 'about'}">
            <v-list-tile-action>
              <v-icon>info</v-icon>
            </v-list-tile-action>
            <v-list-tile-title>
              Acerca
            </v-list-tile-title>
          </v-list-tile>
        </template>
      </v-list>
    </v-navigation-drawer>
    <v-toolbar
      :clipped-left="$vuetify.breakpoint.lgAndUp"
      color="blue darken-3"
      dark
      app
      fixed
    >
      <v-toolbar-title style="width: 300px" class="ml-0 pl-3">
        <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
        <span class="hidden-sm-and-down">{{name}}</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <template v-if="isAdmin || isUser">

        <v-speed-dial
          v-model="fab"
          :top="true"
          :right="true"
          :direction="direction"
          :open-on-hover="true"
          :transition="transition"
        >
          <v-btn
            slot="activator"
            v-model="fab"
            color="blue darken-2"
            dark
            fab
          >
            <v-icon>account_circle</v-icon>
            <v-icon>close</v-icon>
          </v-btn>
          <v-btn
            fab
            dark
            small
            color="green"
            @click="logout"
          >
            <v-icon>logout</v-icon>
          </v-btn>
        </v-speed-dial>
      </template>
    </v-toolbar>
    <v-content>
      <v-container fluid fill-height>
        <v-slide-y-transition mode="out-in">
          <router-view/>
        </v-slide-y-transition>
      </v-container>
    </v-content>
    <v-footer dark height="auto">
      <v-layout justify-center>
        <v-flex text-xs-right>
          <v-card flat tile color="primary" class="white--text">
            <v-card-text class="white--text pt-0">
              Nassiff &copy;2018
            </v-card-text>
          </v-card>
        </v-flex>
      </v-layout>
    </v-footer>
  </v-app>
</template>

<script>

export default {
  name: 'App',
  data () {
    return {
      name: 'Sistema de Gestion',
      drawer: null,
      direction: 'bottom',
      fab: false,
      transition: 'slide-y-reverse-transition'
    }
  },
  methods:{
    logout(){
      const self = this;
      self.$store.dispatch("logOut");
    }
  },
  computed:{
    logedin(){
      return this.$store.state.usuario;
    },
    isAdmin(){
      return this.$store.state.usuario 
          && this.$store.state.usuario.rol == 'admin'; 
    },
    isUser(){
      return this.$store.state.usuario 
          && this.$store.state.usuario.rol == 'user';
    }
  },
  created(){
    this.$store.dispatch("autoLogin");
  }
}
</script>
