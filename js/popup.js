function newPopup(url) {
popupWindow = window.open(
url,'popUpWindow','height=650,width=820,left=200,top=20,resizable=yes,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no,status=no')
}

function newPopup1(url) {
popupWindow = window.open(
url,'popUpWindow','height=450,width=820,left=200,top=20,resizable=yes,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no,status=no')
}

function newPopup2(url) {
popupWindow = window.open(
url,'popUpWindow','height=330,width=820,left=200,top=20,resizable=yes,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no,status=no')
}

function newPopup3(url) {
popupWindow = window.open(
url,'popUpWindow','height=500,width=500,left=200,top=20,resizable=yes,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no,status=no')
}

function OpenFAF(empcode) {

    var emplCode = document.getElementById(empcode);

    if (emplCode.value == "") {
        alert("Please enter employee code");
        emplCode.focus();
        return false;
    } else {
  //  alert('hello');
        window.open("FullAndFinal.aspx?&empcode=" + emplCode.value, 'MyWindow3', 'toolbar=no,height=500px,width=990px,location=no,top=100,left=180,directories=no, status=no,titlebar=no,menubar=no,scrollbars=yes,resizable=yes');
        return false;
    }

}

function OpenCTC(empcode, fyear) {
    //alert("sajgdkaj");

    var emplCode = document.getElementById(empcode);
    var finYear = document.getElementById(fyear);
    if (emplCode.value == "") {
        alert("Please enter employee code");
        emplCode.focus();
        return false;
    } else {
        window.open("reports/TaxDeclarationForm.aspx?&empcode=" + emplCode.value + "&fyear=" + finYear.value, 'MyWindow3', 'toolbar=no,height=500px,width=970px,location=no,top=100,left=180,directories=no, status=no,titlebar=no,menubar=no,scrollbars=yes,resizable=yes');
        return false;
    }
}


function OpenPerformanceIns(empcode, fyr, amt, incid, pid) {
    window.open("AddMonthWiseInsentive.aspx?&empcode=" + empcode + "&fyear=" + fyr + "&amount=" + amt + "&incid=" + incid + "&pid=" + pid, 'MyWindow3', 'toolbar=no,height=500px,width=930px,location=no,top=100,left=180,directories=no, status=no,titlebar=no,menubar=no,scrollbars=yes,resizable=yes');
    return false;
}

function OpenPickEmpWithData(hr, mss, emp) {
    alert('Hi');
    window.open(".../pickempwithdata.aspx?HR="+hr+"&MSS="+mss+"&Emp="+emp+"", 'newwindow', 'height=500,width=500,left=200,top=20,resizable=yes,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no,status=no');
}

function checkNumericValueForCntrl(cntl) {
    //alert('Hi');
    if (cntl != null) {
        if (isNaN(cntl.value) || cntl.value.trim() == '') {
            alert('Please enter only numeric value');
            cntl.value = "";
            return false;
        }
    }
    return true;
}