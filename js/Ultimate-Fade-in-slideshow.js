/***********************************************
* Ultimate Fade-In Slideshow (v1.51): ? Dynamic Drive (http://www.dynamicdrive.com)
* This notice MUST stay intact for legal use
* Visit http://www.dynamicdrive.com/ for this script and 100s more.
***********************************************/


var fadeimages = new Array()
//SET IMAGE PATHS. Extend or contract array as needed
//fadeimages[0]=["image path", "open link ../www.india-tourism.info/", " open in new window"]
fadeimages[0] = ["images/login/1.jpg", " ", " "]
fadeimages[1] = ["images/login/2.jpg", " ", " "]
fadeimages[2] = ["images/login/3.jpg", " ", " "]
fadeimages[3] = ["images/login/4.jpg", " ", " "]
fadeimages[4] = ["images/login/5.jpg", " ", " "]
fadeimages[5] = ["images/login/6.jpg", " ", " "]
fadeimages[6] = ["images/login/7.jpg", " ", " "]
fadeimages[7] = ["images/login/8.jpg", " ", " "]
fadeimages[8] = ["images/login/9.jpg", " ", " "]
fadeimages[9] = ["images/login/10.jpg", " ", " "]
fadeimages[10] = ["images/login/11.jpg", " ", " "]
fadeimages[11] = ["images/login/12.jpg", " ", " "]
fadeimages[12] = ["images/login/13.jpg", " ", " "]
fadeimages[13] = ["images/login/14.jpg", " ", " "]
fadeimages[14] = ["images/login/15.jpg", " ", " "]
fadeimages[15] = ["images/login/16.jpg", " ", " "]
fadeimages[16] = ["images/login/17.jpg", " ", " "]
fadeimages[17] = ["images/login/18.jpg", " ", " "]
fadeimages[18] = ["images/login/19.jpg", " ", " "]
fadeimages[19] = ["images/login/20.jpg", " ", " "]
fadeimages[20] = ["images/login/21.jpg", " ", " "]
fadeimages[21] = ["images/login/22.jpg", " ", " "]
fadeimages[22] = ["images/login/23.jpg", " ", " "]
fadeimages[23] = ["images/login/24.jpg", " ", " "]
fadeimages[24] = ["images/login/25.jpg", " ", " "]
fadeimages[25] = ["images/login/26.jpg", " ", " "]
fadeimages[26] = ["images/login/27.jpg", " ", " "]
fadeimages[27] = ["images/login/28.jpg", " ", " "]
fadeimages[28] = ["images/login/29.jpg", " ", " "]
fadeimages[29] = ["images/login/30.jpg", " ", " "]
fadeimages[30] = ["images/login/31.jpg", " ", " "]
fadeimages[31] = ["images/login/32.jpg", " ", " "]
fadeimages[32] = ["images/login/33.jpg", " ", " "]
fadeimages[33] = ["images/login/34.jpg", " ", " "]
fadeimages[34] = ["images/login/35.jpg", " ", " "]
fadeimages[35] = ["images/login/36.jpg", " ", " "]
fadeimages[36] = ["images/login/37.jpg", " ", " "]
fadeimages[37] = ["images/login/38.jpg", " ", " "]
fadeimages[38] = ["images/login/39.jpg", " ", " "]
fadeimages[39] = ["images/login/40.jpg", " ", " "]




var fadebgcolor = "white" // "none/ white"

////NO need to edit beyond here/////////////
var fadearray = new Array() //array to cache fadeshow instances
var fadeclear = new Array() //array to cache corresponding clearinterval pointers
var dom = (document.getElementById) //modern dom browsers
var iebrowser = document.all

function fadeshow(theimages, fadewidth, fadeheight, borderwidth, delay, pause, displayorder) {


    this.pausecheck = pause
    this.mouseovercheck = 0
    this.delay = delay
    this.degree = 10 //initial opacity degree (10%)
    this.curimageindex = 0
    this.nextimageindex = 1
    fadearray[fadearray.length] = this
    this.slideshowid = fadearray.length - 1
    this.canvasbase = "canvas" + this.slideshowid
    this.curcanvas = this.canvasbase + "_0"
    if (typeof displayorder != "undefined")
        theimages.sort(function () { return 0.5 - Math.random(); }) //thanks to Mike (aka Mwinter) :)
    this.theimages = theimages
    this.imageborder = parseInt(borderwidth)
    this.postimages = new Array() //preload images
    for (p = 0; p < theimages.length; p++) {
        this.postimages[p] = new Image()
        this.postimages[p].src = theimages[p][0]
    }

    var fadewidth = fadewidth + this.imageborder * 2
    var fadeheight = fadeheight + this.imageborder * 2

    if (iebrowser && dom || dom) //if IE5+ or modern browsers (ie: Firefox)

        document.write('<div id="master' + this.slideshowid + '" style="position:relative;width:' + fadewidth + 'px;height:' + fadeheight + 'px;overflow:hidden;"><div id="' + this.canvasbase + '_0" style="position:absolute;width:' + fadewidth + 'px;height:' + fadeheight + 'px;top:0;left:0;filter:progid:DXImageTransform.Microsoft.alpha(opacity=10);opacity:0.1;-moz-opacity:0.1;-khtml-opacity:0.1;background-color:' + fadebgcolor + '"></div><div id="' + this.canvasbase + '_1" style="position:absolute;width:' + fadewidth + 'px;height:' + fadeheight + 'px;top:0;left:0;filter:progid:DXImageTransform.Microsoft.alpha(opacity=10);opacity:0.1;-moz-opacity:0.1;-khtml-opacity:0.1;background-color:' + fadebgcolor + '"></div></div>')

    else

        document.write('<div><img name="defaultslide' + this.slideshowid + '" src="' + this.postimages[0].src + '"></div>')

    if (iebrowser && dom || dom) //if IE5+ or modern browsers such as Firefox
        this.startit()
    else {
        this.curimageindex++
        setInterval("fadearray[" + this.slideshowid + "].rotateimage()", this.delay)
    }
}

function fadepic(obj) {
    if (obj.degree < 100) {
        obj.degree += 10
        if (obj.tempobj.filters && obj.tempobj.filters[0]) {
            if (typeof obj.tempobj.filters[0].opacity == "number") //if IE6+
                obj.tempobj.filters[0].opacity = obj.degree

            else //else if IE5.5-

                obj.tempobj.style.filter = "alpha(opacity=" + obj.degree + ")"

        }

        else if (obj.tempobj.style.MozOpacity)

            obj.tempobj.style.MozOpacity = obj.degree / 101

        else if (obj.tempobj.style.KhtmlOpacity)

            obj.tempobj.style.KhtmlOpacity = obj.degree / 100

        else if (obj.tempobj.style.opacity && !obj.tempobj.filters)

            obj.tempobj.style.opacity = obj.degree / 101

    }

    else {

        clearInterval(fadeclear[obj.slideshowid])

        obj.nextcanvas = (obj.curcanvas == obj.canvasbase + "_0") ? obj.canvasbase + "_0" : obj.canvasbase + "_1"

        obj.tempobj = iebrowser ? iebrowser[obj.nextcanvas] : document.getElementById(obj.nextcanvas)

        obj.populateslide(obj.tempobj, obj.nextimageindex)

        obj.nextimageindex = (obj.nextimageindex < obj.postimages.length - 1) ? obj.nextimageindex + 1 : 0

        setTimeout("fadearray[" + obj.slideshowid + "].rotateimage()", obj.delay)

    }

}



fadeshow.prototype.populateslide = function (picobj, picindex) {

    var slideHTML = ""

    if (this.theimages[picindex][1] != "") //if associated link exists for image

        slideHTML = '<a href="' + this.theimages[picindex][1] + '" target="' + this.theimages[picindex][2] + '">'

    slideHTML += '<img src="' + this.postimages[picindex].src + '" border="' + this.imageborder + 'px">'

    if (this.theimages[picindex][1] != "") //if associated link exists for image

        slideHTML += '</a>'

    picobj.innerHTML = slideHTML

}





fadeshow.prototype.rotateimage = function () {

    if (this.pausecheck == 1) //if pause onMouseover enabled, cache object

        var cacheobj = this

    if (this.mouseovercheck == 1)

        setTimeout(function () { cacheobj.rotateimage() }, 100)

    else if (iebrowser && dom || dom) {

        this.resetit()

        var crossobj = this.tempobj = iebrowser ? iebrowser[this.curcanvas] : document.getElementById(this.curcanvas)

        crossobj.style.zIndex++

        fadeclear[this.slideshowid] = setInterval("fadepic(fadearray[" + this.slideshowid + "])", 50)

        this.curcanvas = (this.curcanvas == this.canvasbase + "_0") ? this.canvasbase + "_1" : this.canvasbase + "_0"

    }

    else {

        var ns4imgobj = document.images['defaultslide' + this.slideshowid]

        ns4imgobj.src = this.postimages[this.curimageindex].src

    }

    this.curimageindex = (this.curimageindex < this.postimages.length - 1) ? this.curimageindex + 1 : 0

}



fadeshow.prototype.resetit = function () {

    this.degree = 10

    var crossobj = iebrowser ? iebrowser[this.curcanvas] : document.getElementById(this.curcanvas)

    if (crossobj.filters && crossobj.filters[0]) {

        if (typeof crossobj.filters[0].opacity == "number") //if IE6+

            crossobj.filters(0).opacity = this.degree

        else //else if IE5.5-

            crossobj.style.filter = "alpha(opacity=" + this.degree + ")"

    }

    else if (crossobj.style.MozOpacity)

        crossobj.style.MozOpacity = this.degree / 101

    else if (crossobj.style.KhtmlOpacity)

        crossobj.style.KhtmlOpacity = this.degree / 100

    else if (crossobj.style.opacity && !crossobj.filters)

        crossobj.style.opacity = this.degree / 101

}





fadeshow.prototype.startit = function () {

    var crossobj = iebrowser ? iebrowser[this.curcanvas] : document.getElementById(this.curcanvas)

    this.populateslide(crossobj, this.curimageindex)

    if (this.pausecheck == 1) { //IF SLIDESHOW SHOULD PAUSE ONMOUSEOVER

        var cacheobj = this

        var crossobjcontainer = iebrowser ? iebrowser["master" + this.slideshowid] : document.getElementById("master" + this.slideshowid)

        crossobjcontainer.onmouseover = function () { cacheobj.mouseovercheck = 1 }

        crossobjcontainer.onmouseout = function () { cacheobj.mouseovercheck = 0 }

    }

    this.rotateimage()

}