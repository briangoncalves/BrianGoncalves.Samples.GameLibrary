<template>
  <div>
    <nav class="navbar navbar-default fixed-top">
      <div class="container-fluid">
        <div class="navbar-header">
          <a class="navbar-brand" href="#">Game Library App</a>
          <!--<router-link :to="'/'"
                       class="btn btn-primary btn-margin">
            Home
          </router-link>

          <button class="btn btn-primary btn-margin"
                  v-if="!authenticated"
                  @click="login()">
            Log In
          </button>
          <button class="btn btn-primary btn-margin"
                  v-if="authenticated"
                  :to="'/games'">
            Games
          </button>

          <button class="btn btn-primary btn-margin"
                  v-if="authenticated"
                  @click="logout()">
            Log Out
          </button>-->
          </div>
          <div class="collapse navbar-collapse">
            <ul class="navbar-nav nav">
              <li class="nav-item active">
                <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
              </li>
              <li class="nav-item">
                <a v-if="!authenticated" @click="login()">Login</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" v-if="authenticated" href="/games">Games</a>
              </li>
              <li class="nav-item">
                <span class="nav-link" v-if="authenticated" @click="logout()" href="#">Logout</span>
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
  import 'auth0-js'
  import 'bootstrap'
  import 'bootstrap/dist/css/bootstrap.min.css'
  import AuthService from './auth/AuthService'
  const auth = new AuthService()
  const { login, logout, authenticated, authNotifier } = auth
  export default {
    name: 'app',
    data () {
      authNotifier.on('authChange', authState => {
        this.authenticated = authState.authenticated
      })
      return {
        auth,
        authenticated
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