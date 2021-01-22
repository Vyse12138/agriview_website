<template>
  <!-- home page -->
  <div id="home" role="main">
    <!-- home section 1: 'Our Business', 'Mission Statement' and 'Vision Statement' -->
    <div id="home-section1">
      <!-- Our Business -->
      <div class="home-section1-item">
        <img src="@/assets/bg-default-1.jpg" alt="Placeholder" />
        <div class="home-section1-item-text">
          <h4>Our Business</h4>
          <p>
            Agriview ,founded in 1990, is a provider of market research and
            analysis systems to leading global, Australian and New Zealand
            manufacturers and distributors of agricultural and construction
            machinery and commercial grounds care equipment.
          </p>
        </div>
      </div>

      <!-- Mission Statement -->
      <div class="home-section1-item">
        <img src="@/assets/bg-about-us-1.jpg" alt="Placeholder" />
        <div class="home-section1-item-text">
          <h4>Mission Statement</h4>
          <p>
            To facilitate informed decision-making through the provision of high
            quality, relevant, user-oriented and dynamic statistical services by
            co-coordinating statistical activities and promoting the adherence
            to statistical standards.
          </p>
        </div>
      </div>

      <!-- Vision Statement -->
      <div class="home-section1-item item3">
        <img src="@/assets/bg-contact-us-1.jpg" alt="Placeholder" />
        <div class="home-section1-item-text">
          <h4>Vision Statement</h4>
          <p>
            To be a leading provider of statistical information and market
            research with a commitment to industry, learning, innovation, and
            staff development.
          </p>
        </div>
      </div>
    </div>

    <!-- home section 2: 'Key Clients', 'Services We Offer' and 'The Machinery Sectors that we cover' -->
    <ul id="home-section2">
      <!-- Key Clients -->
      <li class="home-section2-item">
        <!-- vertical dashes line -->
        <span class="home-section2-item-line"></span>
        <!-- icon -->
        <div class="home-section2-item-icon swing">
          <i class="home-section2-item-icon-img fas fa-child"></i>
        </div>
        <!-- text area -->
        <div class="home-section2-item-text">
          <h3>Key Clients</h3>
          <p>
            1. Leading global, Australian and New Zealand manufacturers and
            distributors including John Deere Limited, AGCO Australia, CNH
            Industrial and Kubota Australia.
          </p>
          <p>2. Agricultural, construction and grounds care dealers.</p>
          <p>
            3.Federal government departments including the Reserve Bank of
            Australia,(RBA) the Australian Bureau of Statistics (ABS) and the
            Australian Bureau of Agricultural and Resource Economics and
            Sciences (ABARES).
          </p>
        </div>
      </li>

      <!-- Services We Offer -->
      <li class="home-section2-item">
        <!-- vertical dashes line -->
        <span class="home-section2-item-line"></span>
        <!-- icon -->
        <div class="home-section2-item-icon swing delay1">
          <i class="home-section2-item-icon-img fas fa-wrench"></i>
        </div>
        <!-- text area -->
        <div class="home-section2-item-text">
          <h3>Services We Offer</h3>
          <p>
            1. Monthly industry retail sales data collection,
            processing,reporting and analysis at National, State, Regional or
            customized geographic area level.
          </p>
          <p>
            2. Specialised reporting based on key machinery variables such as
            engine power, drive and or transmission for Tractors. Machine Class
            for Combine Harvesters, Hay Balers by type and Commercial Out Front
            Mower by type.
          </p>
          <p>
            3.Creation of customised sales databases for incorporation into
            company own in-house reporting systems.
          </p>
          <p>
            4. Creation and maintenance of customised company web based portals
            for online access by company and dealer personal of market data and
            information.
          </p>
          <p>
            5. Interactive Google based mapping tools that allow interrogation
            of sales data by product type, specification and time period at
            geographic postcode level.
          </p>
          <p>
            6. Machinery specification databases for current and superseded
            product that has been sold in Australia since 1989.
          </p>
          <p>7. Annual sales survey for niche machinery sectors.</p>
          <p>
            8. Dealer distribution channel creation, monitoring and analysis.
          </p>
        </div>
      </li>

      <!-- The Machinery Sectors that we cover -->
      <li class="home-section2-item">
        <!-- icon -->
        <div class="home-section2-item-icon swing delay2">
          <i class="home-section2-item-icon-img fas fa-car"></i>
        </div>
        <!-- text area -->
        <div class="home-section2-item-text">
          <h3>The Machinery Sectors that we cover</h3>
          <p>
            Tractors, Combine Harvesters, Balers, Hay Tools, Windrowers,
            Commercial Out Front Mowers and Tyre equipment.
          </p>
        </div>
      </li>
    </ul>

    <!-- home section 3: 'Information we have', 'Annual sales data' and 'Latest technology embraced' -->
    <div id="home-section3">
      <!-- Information we have -->
      <div class="home-section3-item">
        <h5>
          <i class="home-section3-item-icon fas fa-university"></i>
          <span class="home-section3-item-head">Information we have</span>
        </h5>
        <p>
          We have over 28 years of machinery sales data by make, model,
          specification by month, for tractors, combine harvesters and balers.
          Moreover We also have over 20 years of commercial out front mowers
          sales data.
        </p>
      </div>

      <!-- Annual sales data -->
      <div class="home-section3-item">
        <h5>
          <i class="home-section3-item-icon fas fa-graduation-cap"></i>
          <span class="home-section3-item-head">Information we have</span>
        </h5>
        <p>
          Each year we collect sales for a range of machinery including Hay
          Tools and Windrowers sold in Australia. The information is collected
          based on agreed product segmentation with participating contributors.
        </p>
      </div>

      <!-- Latest technology embraced -->
      <div class="home-section3-item item3">
        <h5>
          <i class="home-section3-item-icon fas fa-gavel"></i>
          <span class="home-section3-item-head">Information we have</span>
        </h5>
        <p>
          In the last 5 years we have invested heavily in upgrading our systems
          and services to ensure that we continue to provide a high standard of
          customer service and support.
        </p>
      </div>
    </div>

    <!-- footer -->
    <footer role="contentinfo">Agriview copyright @2020</footer>
  </div>
</template>

<script>
export default {
  name: "Home",
  components: {},
};
</script>

<style scoped>
/* home */

#home {
  margin-top: 95px;
  max-width: 980px;
  margin-left: auto;
  margin-right: auto;
  width: 88%;
}

/* home section1*/

#home-section1 {
  padding-top: 45px;
}

.home-section1-item {
  overflow: hidden;
  height: 400px;
  float: left;
  margin-right: 4%;
  margin-bottom: 75px;
  width: 30.66666%;
  background-color: #fff;
  border: 1px solid rgba(0, 0, 0, 0.15);
  border-radius: 4px;
  box-shadow: 0 0.125em 0.275em 0 rgba(0, 0, 0, 0.125);
}

.home-section1-item.item3 {
  margin-right: 0%;
}

.home-section1-item-text {
  padding: 0.5em 1.5em;
}

/* home section1 responsive design*/

@media (max-width: 767px) {
  .home-section1-item {
    float: none;
    width: 100%;
    margin-bottom: 45px;
    height: auto;
  }
}

/* home section2*/

#home-section2 {
  clear: both;
  padding: 0;
  margin-left: 0%;
  margin: 0 0 1.313em;
  list-style: none;
}

.home-section2-item {
  position: relative;
  margin: 0 auto 1.313em;
  display: flex;
}

.home-section2-item-line {
  position: absolute;
  width: 0;
  margin: auto;
  z-index: 1;
  height: 100%;
  top: 0.5em;
  font-size: 60px;
  left: 0;
  right: calc(100% - 60px);
  border-left: 1px dashed #272727;
}

.home-section2-item-icon {
  border-radius: 100em;
  height: 1em;
  z-index: 2;
  color: #ffffff;
  background-color: #2ecc71;
  margin-right: 20px;
  font-size: 60px;
}

.home-section2-item-icon-img {
  transform: scale(0.45);
  display: block;
  width: 1em;
  text-align: center;
}

.home-section2-item-text {
  margin-top: -20px;
}

/* home section3*/

#home-section3 {
  margin: 0px auto;
  padding: 45px 0px;
  display: table;
}

.home-section3-item {
  display: table-cell;
  margin-right: 0;
  float: none;
  vertical-align: top;
  width: 35%;
  padding-right: 4%;
}

.home-section3-item.item3 {
  padding-right: 0%;
}

.home-section3-item-head {
  vertical-align: -2px;
}

.home-section3-item-icon {
  width: 2em;
  margin-right: 0.5em;
  font-size: 0.65em;
  line-height: 2em;
  text-align: center;
  color: hsl(84, 5%, 90%);
  background-color: hsl(255, 90%, 49%);
  border-radius: 100em;
}

/* footer */

footer {
  border-top: 1px solid #e0e0e0;
  box-shadow: inset 0 1px 0 0 rgba(255, 255, 255, 0.8);
  text-align: center;
  color: #333300;
  margin-bottom: 10px;
}

/* swing effect for the icons */

@-webkit-keyframes swing {
  20% {
    -webkit-transform: rotate(15deg);
    transform: rotate(15deg);
  }
  40% {
    -webkit-transform: rotate(-10deg);
    transform: rotate(-10deg);
  }
  60% {
    -webkit-transform: rotate(5deg);
    transform: rotate(5deg);
  }
  80% {
    -webkit-transform: rotate(-5deg);
    transform: rotate(-5deg);
  }
  to {
    -webkit-transform: rotate(0deg);
    transform: rotate(0deg);
  }
}
@keyframes swing {
  20% {
    -webkit-transform: rotate(15deg);
    transform: rotate(15deg);
  }
  40% {
    -webkit-transform: rotate(-10deg);
    transform: rotate(-10deg);
  }
  60% {
    -webkit-transform: rotate(5deg);
    transform: rotate(5deg);
  }
  80% {
    -webkit-transform: rotate(-5deg);
    transform: rotate(-5deg);
  }
  to {
    -webkit-transform: rotate(0deg);
    transform: rotate(0deg);
  }
}

.swing {
  -webkit-animation-duration: 1s;
  animation-duration: 1s;
  -webkit-animation-fill-mode: both;
  animation-fill-mode: both;
  -webkit-transform-origin: top center;
  transform-origin: top center;
  -webkit-animation-name: swing;
  animation-name: swing;
}

.delay1 {
  -webkit-animation-delay: 0.6s;
  animation-delay: 0.6s;
}

.delay2 {
  -webkit-animation-delay: 1.2s;
  animation-delay: 1.2s;
}
</style>
