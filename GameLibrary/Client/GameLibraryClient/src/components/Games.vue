<template>
  <div class="games">
    <h1>Check the games below:</h1>
    <router-link :to="{ name: 'GamesEdit', params: { Id: 0 }}">
      <button type="button" class="btn btn-success btn-sm">
        Add new game
      </button>      
    </router-link>
    <br /><br />
    <ul class="list-group">
      <li class="list-group-item" v-for="game in games">
        <div class="well well-sm"><b>Name:</b> {{game.Name}}<br/><b>Publisher:</b> {{game.Publisher}}<br/>
          
        </div>      
        <router-link :to="{ name: 'GamesEdit', params: { Id: game.Id }}">
          <button type="button" class="btn btn-primary btn-sm">
            Edit Game
          </button>
        </router-link>
        <router-link :to="{ name: 'GamesDelete', params: { Id: game.Id }}">
          <button type="button" class="btn btn-danger btn-sm">
            Delete Game
          </button>
        </router-link>
      </li>
    </ul>
  </div>
</template>
<script>
import { HTTP } from '../http/http-common'
export default {
  name: 'games',
  props: ['auth'],
  data () {
    this.authenticated = this.auth.isAuthenticated()
    if (!this.authenticated) this.$router.push('home')
    HTTP.get('games')
      .then(response => {
        this.games = response.data
      })
      .catch(e => { })
    return {
      games: []
    }
  }
}
</script>