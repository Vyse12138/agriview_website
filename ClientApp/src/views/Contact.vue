<template>
  <!-- contact page -->
  <div id="contact">
    <!-- contact detail section -->
    <div class="contact-section">
      <p>
        3 watt av,<br />
        Oak Park <br />
        Vic. 3046 <br />
        Australia
      </p>
      <a href="tel: +61393720645">Tel: (+61) 3 9070 9718</a>
      <br />
      <a href="mailto:info@agriview.com.au">info@agriview.com.au</a>
    </div>
    <!-- map section -->
    <div class="contact-section-map">
      <iframe
        id="map"
        src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3155.972994582442!2d144.92596731572732!3d-37.72031173647545!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x6ad65b0e1e87fd49%3A0xad5dce3e387b4c9a!2s3%20Watt%20Ave%2C%20Oak%20Park%20VIC%203046!5e0!3m2!1sen!2sau!4v1596589894388!5m2!1sen!2sau"
        aria-hidden="false"
      >
      </iframe>
    </div>
  </div>
</template>

<style scoped>
/* contact */

#contact {
  margin-top: 85px;
  padding-top: 45px;
  width: 88%;
  max-width: 980px;
  margin-left: auto;
  margin-right: auto;
}

/* contact detail */

.contact-section {
  padding-left: 0px;
  float: left;
  width: 25%;
  font-size: 20px;
}

/* map section */

.contact-section-map {
  position: relative;
  padding-top: 50%;
  display: block;
  float: left;
  width: 75%;
}

/* map */

#map {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  border: 0;
}

/* contact page responsive design */

@media (max-width: 940px) {
  .contact-section {
    float: none;
    width: 100%;
    font-size: 20px;
  }
  .contact-section-map {
    float: none;
    width: 100%;
    padding-top: 100%;
  }
}
</style>
