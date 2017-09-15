<template>
  <div>
    <nav class="navbar navbar-default fixed-top">
      <div class="container-fluid">
        <div class="navbar-header">
          <a class="navbar-brand" href="#">Game Library App</a>
          </div>
          <div class="collapse navbar-collapse">
            <ul class="navbar-nav nav">
              <li class="nav-item active">
                <router-link to="/">Home</router-link>
              </li>
              <li class="nav-item">
                <router-link v-if="authenticated" to="/games">Games</router-link>
              </li>              
            </ul>            
            <ul class="nav navbar-nav navbar-right">
              <li class="nav-item" v-if="authenticated"><a>Welcome {{profileName}}</a></li>
              <li class="nav-item">
                <a class="nav-link" v-if="authenticated" style="cursor: pointer;font-weight:bold;" @click="logout()">Logout</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" v-if="!authenticated" style="cursor: pointer;font-weight:bold;" @click="login()">Login</a>
              </li>
            </ul>
          </div>          
        </div>
    </nav>

    <div class="container">
      <router-view :auth="auth"
                   :authenticated="authenticated">
      </router-view>
    </div>
  </div>
</template>

<script>
  import 'jquery'
  import 'bootstrap'
  import 'bootstrap/dist/css/bootstrap.min.css'
  import AuthService from './auth/AuthService'
  const auth = new AuthService()
  const { login, logout, authenticated, authNotifier, profileName } = auth
  export default {
    name: 'app',
    data () {
      this.profileName = profileName
      this.authenticated = authenticated
      authNotifier.on('authChange', authState => {
        this.profileName = authState.profileName
        this.authenticated = authState.authenticated
      })
      return {
        auth,
        authenticated,
        profileName
      }
    },
    methods: {
      login,
      logout
    }
  }
</script>

<style>
</style>