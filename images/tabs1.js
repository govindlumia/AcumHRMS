function tab (id, imgId)
{

	objA1=document.getElementById('A1');
	objA2=document.getElementById('A2');
for (var i=1;i<=2;i++)
{
var e= document.getElementById("tbl"+i);
e.style.display = 'none';
}
var t = document.getElementById(id);
t.style.display = 'block';

fImg1=document.getElementById("imgWhats");
fImg2=document.getElementById("imgFeatured");
//alert(imgId);
	
	if(imgId == "imgWhats")
	{
		fImg1.src="images/tab_FeaturedArticles_r.gif";
		fImg2.src="images/tab_Sendmeanadvisor_n.gif";
		objA1.removeAttribute('href');
		objA2.setAttribute('href', 'javascript: tab(\'tbl2\',\'imgFeatured\');');
	}
	if(imgId == "imgFeatured")
	{
		fImg1.src="images/tab_FeaturedArticles_n.gif";
		fImg2.src="images/tab_Sendmeanadvisor_r.gif";
		objA2.removeAttribute('href');
		objA1.setAttribute('href', 'javascript: tab(\'tbl1\',\'imgWhats\');');
	}
}

