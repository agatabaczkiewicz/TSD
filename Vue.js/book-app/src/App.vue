<template>
  <div>
    <HeaderComponent @fromHeader = "headerHandler"></HeaderComponent>
    <div id="app">
      <h1>Books</h1>
      <div>
        <p>Title: <input type="text" v-model="title"  /></p>
        <p>Is book read: <select v-model="isReadOfNewBook">
          <option value="bookRead">Yes</option>
          <option value="bookNotRead">No</option>
        </select>
        </p>
        <button type="button" class="btn btn-primary" @click= "onAddClick">Add</button>
      </div>
      <ul class="list-group list-custom">
      <div v-for="b in books" :key="b._id" class="book">
        <li class="list-group-item">
        <p class="bookTitle">Title: {{ b.title }}</p>
        <p v-bind:class="b.isRead">Is Book Read: <span v-if="b.isRead == 'bookNotRead' " >No</span><span v-if="b.isRead == 'bookRead' " >Yes</span></p>
        </li></div>
      </ul>
    </div>
    <FooterComponent></FooterComponent>
  </div>
</template>

<script>

import HeaderComponent from "@/components/HeaderComponent";
import FooterComponent from "@/components/FooterComponent";

export default {
  name: 'App',
  components: {
    HeaderComponent,
    FooterComponent
  },
  data() {
    return {
      books: [
        { title: 'Thinking, fast and slow', isRead: 'bookRead' },
        { title: 'Scrum Guide', isRead: 'bookNotRead' },
      ],
      title : '',
      isReadOfNewBook: 'bookNotRead'
    }
  },
  methods:{
    headerHandler(){
      alert("Header click");
    },
    onAddClick() {
      this.books.push({title: this.title , isRead: this.isReadOfNewBook});
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  /*text-align: center;*/
  color: #2c3e50;
  margin-top: 5%;
  margin-left: 2.5%;
}
.list-custom{
  margin-top : 2%;
  width: 20%;

}
.book{
  background-color: blanchedalmond;
}
.bookTitle {
  font-weight: bold;

}
.bookRead {
  color: green;
}
.bookNotRead {
  color: red;
}
</style>
