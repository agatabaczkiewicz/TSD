<template>
  <nav class="navbar navbar-expand-lg header navbar-light bg-light">
<MenuITems @about="aboutHandler"  :Item1="menuItem1" :Item2="menuItem2"></MenuITems>
  </nav>

</template>

<script>


import MenuITems from "@/components/MenuITems";

export default {
  name: "HeaderComponent",
  components: {
    MenuITems
  },
  data() {
    return {
      menuItem1 :"Home",
      menuItem2 :"About"
    }
  },
  methods: {
    aboutHandler(){
      this.$emit('fromHeader')
    }
  }
}
</script>

<style scoped>
.header{
  position:fixed; /* fixing the position takes it out of html flow - knows
                   nothing about where to locate itself except by browser
                   coordinates */
  left:0;           /* top left corner should start at leftmost spot */
  top:0;            /* top left corner should start at topmost spot */
  width:100vw;      /* take up the full browser width */
  z-index:200;  /* high z index so other content scrolls underneath */
  height:70px;     /* define height for content */
  padding-left: 2.5%;
  background-color:  #98BBC5 !important;
  color: aliceblue ;

}
</style>