import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Callback from '@/components/Callback'
import Games from '@/components/Games'
import GamesEdit from '@/components/GamesEdit'
import GamesDelete from '@/components/GamesDelete'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/callback',
      name: 'Callback',
      component: Callback
    },
    {
      path: '/games',
      name: 'Games',
      component: Games
    },
    {
      path: '/game',
      name: 'GamesEdit',
      component: GamesEdit
    },
    {
      path: '/gameDelete',
      name: 'GamesDelete',
      component: GamesDelete
    },
    // catch all redirect
    { path: '*', redirect: '/' }
  ]
})
