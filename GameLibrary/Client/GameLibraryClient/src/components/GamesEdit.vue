<template>
  <div class="gamesEdit">
    <h1 v-if="game.Id > 0">Edit the game:</h1>
    <h1 v-if="game.Id <= 0">Add a new game:</h1>

    <div class="well well-sm">
      <div class="form-group">
        <label for="txtName">Name:</label><input class="form-control" id="txtName" name="txtName" v-model="game.Name" type="text" />
      </div>
      <div class="form-group">
        <label for="txtPublisher">Publisher:</label><input class="form-control" id="txtPublisher" name="txtPublisher" v-model="game.Publisher" type="text" />
      </div> 
      <div class="form-group">
        <label for="txtCategory">Category:</label><input class="form-control" id="txtCategory" name="txtCategory" v-model="game.Category" type="text" />
      </div> 
    </div>
      <button type="button" class="btn btn-success btn-sm" @click="Save">
        Save
      </button>
    <router-link to="/games">
      <button type="button" class="btn btn-danger btn-sm">
        Cancel
      </button>
    </router-link>
  </div>
</template>
<script>
import {HTTP} from '../http/http-common'
export default {
  name: 'gamesEdit',
  data () {
    if (this.$route.params.Id > 0) {
      HTTP.get('games/' + this.$route.params.Id)
        .then(response => {
          this.game = response.data
        })
        .catch(e => { this.$router.push('games') })
    }
    return {
      game: []
    }
  },
  methods: {
    Save () {
      var vm = this
      var data = {}
      if (this.game.Id > 0) {
        data = {
          Name: this.game.Name,
          Publisher: this.game.Publisher,
          Category: this.game.Category,
          CreatedOn: this.game.CreatedOn,
          Id: this.game.Id
        }
        HTTP.put('games/' + this.game.Id, data)
          .then(response => {
            vm.$router.push('games')
          })
          .catch(e => {})
      } else {
        data = {
          Name: this.game.Name,
          Publisher: this.game.Publisher,
          Category: this.game.Category
        }
        HTTP.post('games', data)
          .then(response => {
            vm.$router.push('games')
          })
          .catch(e => {})
      }
    }
  }
}
</script>