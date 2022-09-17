<!-- Original:  CodeLifter.com (support@codelifter.com) -->

<!-- Web Site:  http://www.codelifter.com -->



<!-- This script and many more are available free online at -->

<!-- The JavaScript Source!! http://javascript.internet.com -->



<!-- Begin

// Set slideShowSpeed (milliseconds)

var slideShowSpeed = 5000;

// Duration of crossfade (seconds)

var crossFadeDuration = 10;

// Specify the image files

var Pic = new Array();

// to add more images, just continue

// the pattern, adding to the array below




Pic[0] = 'images/banner/1.jpg'
Pic[1] = 'images/banner/2.jpg'
Pic[2] = 'images/banner/3.jpg'
Pic[3] = 'images/banner/4.jpg'
Pic[4] = 'images/banner/5.jpg'
Pic[5] = 'images/banner/6.jpg'







// do not edit anything below this line

var t;

var j = 0;

var p = Pic.length;

var preLoad = new Array();

for (i = 0; i < p; i++) {

preLoad[i] = new Image();

preLoad[i].src = Pic[i];

}

function runSlideShow() {


if (document.all) {
//var folder=document.getElementById('lbl_imagefolder').innerText;
//alert('folder is '+folder);
document.images.SlideShow.style.filter="blendTrans(duration=2)";

document.images.SlideShow.style.filter="blendTrans(duration=crossFadeDuration)";

document.images.SlideShow.filters.blendTrans.Apply();

}

document.images.SlideShow.src = preLoad[j].src;

if (document.all) {

document.images.SlideShow.filters.blendTrans.Play();

}

j = j + 1;

if (j > (p - 1)) j = 0;

t = setTimeout('runSlideShow()', slideShowSpeed);

}

// 