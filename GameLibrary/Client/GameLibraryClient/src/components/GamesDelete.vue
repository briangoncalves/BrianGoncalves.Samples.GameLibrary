<template>
  <div class="gamesDelete">
    <h1>Delete the game?</h1>
      <div class="well well-sm">
        <b>Name:</b> {{game.Name}}<br /><b>Publisher:</b> {{game.Publisher}}<br />

      </div> 
      <router-link to="/games">
        <button type="button" class="btn btn-primary btn-sm">
          Cancel Deletion
        </button>
      </router-link>
        <button type="button" class="btn btn-danger btn-sm" @click="Save">
          Delete Game
        </button>
  </div>  
</template>
<script>
import { HTTP } from '../http/http-common'
export default {
  name: 'gamesDelete',
  data () {
    HTTP.get('games/' + this.$route.params.Id)
      .then(response => {
        this.game = response.data
      })
      .catch(e => { this.$router.push('games') })
    return {
      game: []
    }
  },
  methods: {
    Save () {
      var vm = this
      HTTP.delete('games/' + this.game.Id)
        .then(response => {
          vm.$router.push('games')
        })
        .catch(e => { })
    }
  }
}
</script>