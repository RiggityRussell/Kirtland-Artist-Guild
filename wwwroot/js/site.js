// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    var images = $('.slider-image');
    var imageIndex = 0;

    // Set the first image as active
    images.first().addClass('active');

    // Function to loop through images
    function nextImage() {
        images.eq(imageIndex).removeClass('active');
        imageIndex = (imageIndex + 1) % images.length;
        images.eq(imageIndex).addClass('active');
    }

    // Loop through images every 5 seconds
    setInterval(nextImage, 5000);
});

