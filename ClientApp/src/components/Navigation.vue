<template>
  <div id="nav-container" class="navbar-fixed-top">
    <nav class="navbar">
      <!-- Navigation brand -->
      <div class="navbar-header">
        <button
          type="button"
          class="navbar-toggle fa fa-bars"
          data-toggle="collapse"
          data-target=".navbar-collapse"
        ></button>
        <router-link to="/" class="navbar-brand">Agriview</router-link>
      </div>
      <!-- Navigation links -->
      <div class="collapse navbar-collapse">
        <ul class="nav navbar-nav">
          <li>
            <router-link
              to="/editor"
              data-toggle="collapse"
              data-target=".navbar-collapse.in"
            >
              EDITOR
            </router-link>
          </li>
          <li>
            <router-link
              to="/industry_insight"
              data-toggle="collapse"
              data-target=".navbar-collapse.in"
            >
              INDUSTRY INSIGHTS
            </router-link>
          </li>
          <li>
            <router-link
              to="/contact"
              data-toggle="collapse"
              data-target=".navbar-collapse.in"
            >
              CONTACT
            </router-link>
          </li>
          <li>
            <router-link
              to="/"
              data-toggle="collapse"
              data-target=".navbar-collapse.in"
            >
              HOME
            </router-link>
          </li>
        </ul>
      </div>
    </nav>
  </div>
</template>

<style scoped>
/* navigation bar */

#nav-container {
  box-shadow: 0 4px 4px;
  width: 100%;
  background-color: #f5f5f5;
}

.navbar {
  max-width: 980px;
  margin-left: auto;
  margin-right: auto;
  width: 88%;
}

.navbar-toggle {
  background-color: #f5f5f5;
  font-size: 30px;
  margin-top: 9px;
  margin-bottom: -30px;
  color: hsl(145, 63%, 63%);
}

.navbar-brand {
  margin-top: 11px;
  margin-bottom: -30px;
  padding-left: 0px;
  float: left;
  font-size: 42px;
  text-transform: uppercase;
  color: rgb(142, 175, 8);
}

.navbar-brand:hover,
.navbar-brand:focus {
  color: rgb(142, 175, 8);
}

.navbar-nav {
  margin-top: 12px;
  margin-bottom: -30px;
  float: right;
  font-size: 17px;
  font-weight: bold;
}

@media (max-width: 767px) {
  .navbar-nav {
    float: none;
    margin-top: 40px;
    margin-left: -29px;
    margin-bottom: 0px;
  }
}
</style>
