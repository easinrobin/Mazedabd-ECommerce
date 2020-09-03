/*global jQuery:false */
jQuery(document).ready(function ($) {
  "use strict";

  (function () {

    var $menu = $('.navigation nav'),
      optionsList = '<option value="" selected>Go to..</option>';

    $menu.find('li').each(function () {
        var $this = $(this),
          $anchor = $this.children('a'),
          depth = $this.parents('ul').length - 1,
          indent = '';

        if (depth) {
          while (depth > 0) {
            indent += ' - ';
            depth--;
          }
        }

        $(".nav li").parent().addClass("bold");
        optionsList += '<option value="' + $anchor.attr('href') + '">' + indent + ' ' + $anchor.text() + '</option>';
      }).end()
      .after('<select class="selectmenu">' + optionsList + '</select>');

    $('select.selectmenu').on('change', function () {
      window.location = $(this).val();
    });

  })();

  //Navi hover
  $('ul.nav li.dropdown').hover(function () {
    $(this).find('.dropdown-menu').stop(true, true).delay(200).fadeIn();
  }, function () {
    $(this).find('.dropdown-menu').stop(true, true).delay(200).fadeOut();
  });

  //add some elements with animate effect

  var iOS = false,
    p = navigator.platform;

  if (p === 'iPad' || p === 'iPhone' || p === 'iPod') {
    iOS = true;
  }

  if (iOS === false) {

    $('.flyIn').bind('inview', function (event, visible) {
      if (visible === true) {
        $(this).addClass('animated fadeInUp');
      }
    });

    $('.flyLeft').bind('inview', function (event, visible) {
      if (visible === true) {
        $(this).addClass('animated fadeInLeftBig');
      }
    });

    $('.flyRight').bind('inview', function (event, visible) {
      if (visible === true) {
        $(this).addClass('animated fadeInRightBig');
      }
    });

  }

  $(".box").hover(
    function () {
      $(this).find('.ico').addClass("animated rotateIn");
      $(this).find('h4').addClass("animated fadeInUp");
    },
    function () {
      $(this).find('.ico').removeClass("animated rotateIn");
      $(this).find('h4').removeClass("animated fadeInUp");
    }
  );

  $('.accordion').on('show', function (e) {

    $(e.target).prev('.accordion-heading').find('.accordion-toggle').addClass('active');
    $(e.target).prev('.accordion-heading').find('.accordion-toggle i').removeClass('icon-plus');
    $(e.target).prev('.accordion-heading').find('.accordion-toggle i').addClass('icon-minus');
  });

  $('.accordion').on('hide', function (e) {
    $(this).find('.accordion-toggle').not($(e.target)).removeClass('active');
    $(this).find('.accordion-toggle i').not($(e.target)).removeClass('icon-minus');
    $(this).find('.accordion-toggle i').not($(e.target)).addClass('icon-plus');
  });

  // testimonial
  //var TestiSlide = $('.bxslider');
  //TestiSlide.bxSlider({
  //  auto: true,
  //  pager: false,
  //  controls: false,
  //  useCSS: false,
  //  speed: 2000,
  //  easing: 'easeOutElastic',
  //  mode: 'horizontal',
  //  controlDirections: true
  //});

  //prettyphoto
  //$("a[data-pretty^='prettyPhoto']").prettyPhoto({
  //  social_tools: ''
  //});

  // tooltip
  $('.social-network li a, .options_box .color a').tooltip();

  //scroll to top
  $(window).scroll(function () {
    if ($(this).scrollTop() > 100) {
      $('.scrollup').fadeIn();

    } else {
      $('.scrollup').fadeOut();

    }
  });

  $('.scrollup').click(function () {
    $("html, body").animate({
      scrollTop: 0
    }, 1000);
    return false;
  });

  //flexslider
//  $('.flexslider').flexslider({
//    animation: "fade",
//    directionNav: true,
//    controlNav: false,
//    pauseOnAction: true,
//    pauseOnHover: true,
//    slideshowSpeed: 5500
//  });

});

/* slider active */
$('.slider-active').owlCarousel({
    loop: true,
    nav: false,
    autoplay: false,
    autoplayTimeout: 5000,
    animateOut: 'fadeOut',
    animateIn: 'fadeIn',
    item: 1,
    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 1
        },
        1000: {
            items: 1
        }
    }
})

/* latest-product-slider active */
$('.latest-product-slider').owlCarousel({
    loop: true,
    autoplay: false,
    autoplayTimeout: 5000,
    animateOut: 'fadeOut',
    animateIn: 'fadeIn',
    navText: ['PRE', 'NEXT'],
    nav: true,
    item: 1,
    margin: 30,
    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 1
        },
        1000: {
            items: 1
        }
    }
})

/* product-dec-slider active */
$('.product-dec-slider').owlCarousel({
    loop: false,
    autoplay: false,
    autoplayTimeout: 5000,
    navText: ['<i class="icon-angle-left"></i>', '<i class="icon-angle-right"></i>'],
    nav: true,
    item: 4,
    margin: 12,
    responsive: {
        0: {
            items: 2
        },
        768: {
            items: 4
        },
        1000: {
            items: 4
        }
    }
})

// Instantiate EasyZoom instances
//var $easyzoom = $('.easyzoom').easyZoom();

/*--------------------------
tab active
---------------------------- */
var ProductDetailsSmall = $('.product-details-small a');

ProductDetailsSmall.on('click', function (e) {
    e.preventDefault();

    var $href = $(this).attr('href');

    ProductDetailsSmall.removeClass('active');
    $(this).addClass('active');

    $('.product-details-large .tab-pane').removeClass('active');
    $('.product-details-large ' + $href).addClass('active');
})

//navbar
// define all UI variable
var navToggler = document.querySelector('.nav-toggler');
var navMenu = document.querySelector('.site-navbar ul');
var navLinks = document.querySelectorAll('.site-navbar a');

// load all event listners
allEventListners();

// functions of all event listners
function allEventListners() {
    // toggler icon click event
    navToggler.addEventListener('click', togglerClick);
    // nav links click event
    navLinks.forEach(elem => elem.addEventListener('click', navLinkClick));
}

// togglerClick function
function togglerClick() {
    navToggler.classList.toggle('toggler-open');
    navMenu.classList.toggle('open');
}

// navLinkClick function
function navLinkClick() {
    if (navMenu.classList.contains('open')) {
        navToggler.click();
    }
}
