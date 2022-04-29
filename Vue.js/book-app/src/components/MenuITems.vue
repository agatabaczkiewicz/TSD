<template>
  <div class="container-fluid">
    <a class="navbar-brand" href="#">Book App</a>
    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="#">{{ Item1 }}</a>
        </li>
        <li class="nav-item">
          <a class="nav-link active" @click = "onClickAbout" aria-current="page"  href="#">{{ Item2 }}</a>
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  name: "MenuITems",
  props:['Item1', 'Item2'],
  methods: {
    onClickAbout() {
      this.$emit('about')
    }
  }
}
</script>

<style scoped>
h1 {
  display: inline-block;
  margin-top: 0.321em;
}

#navWrap{
  position:absolute;
  top:50px; /*Change as needed*/
  right:0;
}

nav {
  display: inline-block;
  vertical-align: baseline;
}
</style>