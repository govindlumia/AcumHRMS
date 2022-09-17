<%@ Page Language="VB" AutoEventWireup="false" CodeFile="empbulkdetailupload.aspx.vb" Inherits="Admin_Employee_empbulkdetailupload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <%-- <div>
       <input type="file" id="posteedfile" onchange="checkfile(this);" />
        <input type="button" id="bulkupload" value="Submit"/>
    </div>--%>
        <div class="panel panel-success" style="width:95% !important;margin: 30px;">
            <div class="panel-heading">
                <h3 class="panel-title">Import Excel File</h3>
            </div>
            <div class="panel-body">
                <table style="width:90%;">
                    <tr>
                        <td style="width:30%;">
                            <div class="form-group">
                                <input type="file" name="postedFile" id="postedFile" style="width:85%;" />
                            </div>
                        </td>
                        <td  style="width:30%;">
                            <div class="form-group">
                                <input type="button" value="Import" class="button" id="ImportFile" />
                                <input type="button" class="button" id="BackToInquiry" name="btn" value="Back To List" />
                                </div>
                        </td>
                        @*<td>
                            <div class="form-group">
                                <input type="button" class="button" id="BackToInqList" name="btn" value="Back To List" />
                                </div>
                        </td>*@
                   
                    </tr>
                </table>
              
                
            </div>
        </div>
    </form>
</body>
</html>

<script type="text/javascript">
//    function checkfile(sender) {
//        debugger;
//    var validExts = new Array(".xlsx", ".xls", ".csv");
//    var fileExt = sender.value;
//    fileExt = fileExt.substring(fileExt.lastIndexOf('.'));
//    if (validExts.indexOf(fileExt) < 0) {
//      alert("Invalid file selected, valid files are of " +
//               validExts.toString() + " types.");
//      return false;
//    }
//    else return true;
    //}

    $("#ImportFile").on("click", function () {
         
        //if (!(ApplicationNo.length < 15)) {
        //    $('#ApplicationNo').val('');
        //    alert("The phone number is the wrong length. \nPlease enter 15 digit no UpTo.");
        //}
            debugger;
        var formdata = false;
        if (window.FormData) {
            formdata = new FormData();
        }
        file = document.getElementById('postedFile').files;
        if (file.length > 0) {
            file = file[0];
            if (formdata) {
                formdata.append("fileData", file);
            }
        }
        //along with file append your additional input fields value like below
        //formdata.append("Name", jQuery('#txtName').val());
        if (formdata) {

            $.ajax({
                url : '@Url.Action("ExportExcelOfInquiryDetail", "Inquiry")',
                type: 'POST',
                data:  formdata ,
                processData: false,
                contentType: false,
                //beforeSend: function () {
                //},
                //complete: function () {
                //},
                success: function (data) {
                    if (data!=null) {                        
                        alert(data);
                        document.getElementById("postedFile").value = "";
                    }
                    //$("#sidebar").find("#InquiryList").click();
                    //output response from server.
                },
                error: function () {
                }
            });
        }
    });
</script>
