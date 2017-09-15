<template>
  <div class="hello">
    <h1>Welcome to the Game Library</h1>
    <p>Here you can add all the game titles you want</p>
    <p v-if="!authenticated">Log in at the top to start using</p>
  </div>
</template>

<script>
export default {
  name: 'hello',
  data () {
    return {}
  }
}
</script>