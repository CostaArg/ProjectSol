(function($) {
  'use strict';

  var poca_window = $(window);

  // *******************************
  // :: 1.0 Preloader Active Code
  // *******************************

  poca_window.on('load', function() {
    $('#preloader').fadeOut('1000', function() {
      $(this).remove();
    });
  });

  // *******************************
  // :: 2.0 ClassyNav Active Code
  // *******************************

  if($.fn.classyNav) {
    $('#pocaNav').classyNav();
  }

  // ***********************************
  // :: 3.0 Welcome Carousel Active Code
  // ***********************************

  if($.fn.owlCarousel) {
    var welcomeSlider = $('.welcome-slides');
    welcomeSlider.owlCarousel({
      items: 1,
      loop: true,
      autoplay: false,
      smartSpeed: 1500,
      animateIn: 'fadeIn',
      animateOut: 'fadeOut'
    })
    welcomeSlider.on('translate.owl.carousel', function() {
      var layer = $("[data-animation]");
      layer.each(function() {
        var anim_name = $(this).data('animation');
        $(this).removeClass('animated ' + anim_name).css('opacity', '0');
      });
    });
    $("[data-delay]").each(function() {
      var anim_del = $(this).data('delay');
      $(this).css('animation-delay', anim_del);
    });
    $("[data-duration]").each(function() {
      var anim_dur = $(this).data('duration');
      $(this).css('animation-duration', anim_dur);
    });
    welcomeSlider.on('translated.owl.carousel', function() {
      var layer = welcomeSlider.find('.owl-item.active').find("[data-animation]");
      layer.each(function() {
        var anim_name = $(this).data('animation');
        $(this).addClass('animated ' + anim_name).css('opacity', '1');
      });
    });
  }

  // ***********************************
  // :: 4.0 Tooltip Active Code
  // ***********************************
  if($.fn.tooltip) {
    $('[data-toggle="tooltip"]').tooltip();
  }

  // ***********************************
  // :: 5.0 WOW Active Code
  // ***********************************
  if(poca_window.width() > 767) {
    new WOW().init();
  }

  // ***********************************
  // :: 8.0 ImagesLoaded Active Code
  // ***********************************
  if($.fn.imagesLoaded) {
    $('.poca-portfolio').imagesLoaded(function() {
      // filter items on button click
      $('.portfolio-menu').on('click', 'button', function() {
        var filterValue = $(this).attr('data-filter');
        $grid.isotope({
          filter: filterValue
        });
      });
      // init Isotope
      var $grid = $('.poca-portfolio').isotope({
        itemSelector: '.single_gallery_item',
        percentPosition: true,
        masonry: {
          columnWidth: '.single_gallery_item'
        }
      });
    });
  }
  $('.portfolio-menu button.btn').on('click', function() {
    $('.portfolio-menu button.btn').removeClass('active');
    $(this).addClass('active');
  })

  // ***********************************
  // :: 9.0 Jarallax Active Code
  // ***********************************
  if($.fn.jarallax) {
    $('.jarallax').jarallax({
      speed: 0.2
    });
  }

  // ***********************************
  // :: 10.0 Scrollup Active Code
  // ***********************************
  if($.fn.scrollUp) {
    poca_window.scrollUp({
      scrollSpeed: 2000,
      scrollText: '<i class="fa fa-angle-up"</i>'
    });
  }

  // ***********************************
  // :: 11.0 Sticky Active Code
  // ***********************************
  poca_window.on('scroll', function() {
    if(poca_window.scrollTop() > 0) {
      $('.main-header-area').addClass('sticky');
    } else {
      $('.main-header-area').removeClass('sticky');
    }
  });

  // ***********************************
  // :: 12.0 audioPlayer Active Code
  // ***********************************
   if ($.fn.audioPlayer) {
       $('audio').audioPlayer();
   }

})(jQuery);
