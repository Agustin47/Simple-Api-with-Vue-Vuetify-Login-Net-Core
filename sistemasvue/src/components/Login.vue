<template>
    <v-layout align-center justify-center>
        <v-flex xs12 sm8 md6 lg5 xl4>
            <v-card>
                <v-toolbar dark color="blue darken-3">
                    <v-toolbar-title>
                        Acceso al Sistema
                    </v-toolbar-title>
                </v-toolbar>
                <template v-if="showError">
                    <v-alert
                        :value="true"
                        color="error"
                        icon="warning"
                        outline
                        >
                        Usuario o Contraseña incorrecta, reintente nuevamente
                        </v-alert>
                </template>
                <v-card-text>
                    <v-form ref="form">
                        <v-text-field prepend-icon="person" v-model="usuario.usuario" :rules="rules.usuario"
                            autofocus color="accent" type="email" label="Usuario" required>
                        </v-text-field>
                        <v-text-field prepend-icon="lock" v-model="usuario.password" :rules="rules.password"
                            type="password" color="accent" label="Password" required>
                        </v-text-field>
                    </v-form>
                </v-card-text>
                <v-card-actions class="px-3 pb-3">
                    <v-flex text-xs-right>
                        <v-btn @click="submit" color="primary">Ingresar</v-btn>
                    </v-flex>
                </v-card-actions>
            </v-card>
        </v-flex>
    </v-layout>
</template>
<script>

import LoginService from '../services/login.service.js'

export default {

     data: () => ({
        usuario: {
            usuario: '',
            password: ''
        },
        rules: {
            usuario :[
            v => !!v || 'El nombre de usuario es requerido',
            ],
            password:[
                v => !!v || 'Contraseña requerida',
                v => (v.length > 4 && v.length < 16) || 'La contraseña debe una longitud entre 4 y 16 '
            ],
        },
        showError: false,
    }),
    methods: {
      submit () {
            const self = this;
            if (self.$refs.form.validate()) {
                LoginService.login(self.usuario)
                    .then(r => {
                        if(r.data.isValid){
                            self.showError = false;
                            self.$store.dispatch("saveToken", r.data.token);
                            self.$router.push('clients');
                        }else{
                            self.showError= true;
                        }
                    })
                    .catch(e =>{
                        console.log(e);
                    })
             }
      },
    },
    computed:{
        
    }
}
</script>
