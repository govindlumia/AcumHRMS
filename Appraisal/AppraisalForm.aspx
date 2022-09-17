<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppraisalForm.aspx.cs" Inherits="Appraisal_AppraisalForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Appraisal</title>
    <link href="../Theme/css/theme-default.css" rel="stylesheet" />


</head>
<body>
    <form id="form1" runat="server">
         <%--  PAGE CONTENT WRAPPER --%>
        <div class="page-content-wrap">

         <div class="row">
                <div class="col-md-12">

                    <form class="form-horizontal">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><strong>Employee Information</strong></h3>
                                <%--<ul class="panel-controls">
                                    <li><a href="#" class="panel-remove"><span class="fa fa-times"></span></a></li>
                                </ul>--%>
                            </div>
                           
                            <div class="panel-body">

                                <div class="row">

                                    <div class="col-md-6">

                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Employee Name: </label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                                                    <input type="text" class="form-control" />
                                                </div>
                                                <span class="help-block"></span>
                                            </div>
                                        </div>
                                         <div class="form-group">
                                            <label class="col-md-3 control-label">Designation: </label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                                                    <input type="text" class="form-control" />
                                                </div>
                                                  <span class="help-block"></span>
                                            </div>
                                        </div>
                                         <div class="form-group">
                                            <label class="col-md-3 control-label">Department: </label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                                                    <input type="text" class="form-control" />
                                                </div>  <span class="help-block"></span>
                                            </div>
                                        </div>
                                         <div class="form-group">
                                            <label class="col-md-3 control-label">Appraiser Name:</label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                                                    <input type="text" class="form-control" />
                                                </div>  <span class="help-block"></span>
                                            </div>
                                        </div>
                                       
                                    </div>
                                    <div class="col-md-6">

                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Date of Joining: </label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><span class="fa fa-calendar"></span></span>
                                                    <input type="text" class="form-control datepicker" value="2014-11-01">
                                                </div>
                                                <span class="help-block"></span>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Date of Last Review: </label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><span class="fa fa-calendar"></span></span>
                                                    <input type="text" class="form-control datepicker" value="2014-11-01">
                                                </div>
                                                <span class="help-block"></span>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Appraisal Period From: </label>
                                            <div class="col-md-4">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><span class="fa fa-calendar"></span></span>
                                                    <input type="text" class="form-control datepicker" value="2014-11-01">
                                                </div>
                                                <span class="help-block"></span>
                                            </div>
                                        </div>
                                         <div class="form-group">
                                            <label class="col-md-1 control-label">To: </label>
                                            <div class="col-md-4">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><span class="fa fa-calendar"></span></span>
                                                    <input type="text" class="form-control datepicker" value="2014-11-01">
                                                </div>
                                                <span class="help-block"></span>
                                            </div>
                                        </div>

                                       

                                    </div>

                                </div>

                            </div>

                          <%--  2nd form--%>

                              <div class="panel-heading">
                                <h3 class="panel-title"><strong>Rating on the basis of (Poor/Fair/Satisfactor/Good/Excellent)</strong></h3>
                                <%--<ul class="panel-controls">
                                    <li><a href="#" class="panel-remove"><span class="fa fa-times"></span></a></li>
                                </ul>--%>
                            </div>
                           
                            <div class="panel-body">

                                <div class="row">

                                    <div class="col-md-6">

                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Job Knowledge: </label>
                                           <div class="col-md-9">                                                                                            
                                                    <select class="form-control select">
                                                        <option>Option 1</option>
                                                        <option>Option 2</option>
                                                        <option>Option 3</option>
                                                        <option>Option 4</option>
                                                        <option>Option 5</option>
                                                    </select>
                                                    <span class="help-block"></span>
                                                </div>
                                        </div>
                                         <div class="form-group">
                                            <label class="col-md-3 control-label">Work quality : </label>
                                             <div class="col-md-9">                                                                                            
                                                    <select class="form-control select">
                                                        <option>Option 1</option>
                                                        <option>Option 2</option>
                                                        <option>Option 3</option>
                                                        <option>Option 4</option>
                                                        <option>Option 5</option>
                                                    </select>
                                                    <span class="help-block"></span>
                                                </div>
                                        </div>
                                         <div class="form-group">
                                            <label class="col-md-3 control-label">Attendance: </label>
                                            <div class="col-md-9">                                                                                            
                                                    <select class="form-control select">
                                                        <option>Option 1</option>
                                                        <option>Option 2</option>
                                                        <option>Option 3</option>
                                                        <option>Option 4</option>
                                                        <option>Option 5</option>
                                                    </select>
                                                    <span class="help-block"></span>
                                                </div>
                                        </div>
                                                                                
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Initiative:</label>
                                             <div class="col-md-9">                                                                                            
                                                    <select class="form-control select">
                                                        <option>Option 1</option>
                                                        <option>Option 2</option>
                                                        <option>Option 3</option>
                                                        <option>Option 4</option>
                                                        <option>Option 5</option>
                                                    </select>
                                                    <span class="help-block"></span>
                                                </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Depandability:</label>
                                            <div class="col-md-9">                                                                                            
                                                    <select class="form-control select">
                                                        <option>Option 1</option>
                                                        <option>Option 2</option>
                                                        <option>Option 3</option>
                                                        <option>Option 4</option>
                                                        <option>Option 5</option>
                                                    </select>
                                                    <span class="help-block"></span>
                                                </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Work Attitude & Cooperation:</label>
                                            <div class="col-md-9">                                                                                            
                                                    <select class="form-control select">
                                                        <option>Option 1</option>
                                                        <option>Option 2</option>
                                                        <option>Option 3</option>
                                                        <option>Option 4</option>
                                                        <option>Option 5</option>
                                                    </select>
                                                    <span class="help-block"></span>
                                                </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                          <div class="form-group">
                                            <label class="col-md-4 control-label">Do you have a proposition to help people to contribute?:</label>
                                             <div class="col-md-8 col-xs-12">                                            
                                                    <textarea class="form-control" rows="5"></textarea>
                                                    <span class="help-block"></span>
                                                </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-4 control-label">Objectives for Comming Six Months:</label>
                                             <div class="col-md-8 col-xs-12">                                            
                                                    <textarea class="form-control" rows="5"></textarea>
                                                    <span class="help-block"></span>
                                                </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-4 control-label">How do you contribute or plan to contribute to Acuminous?:</label>
                                            <div class="col-md-8 col-xs-12">                                            
                                                    <textarea class="form-control" rows="5"></textarea>
                                                    <span class="help-block"></span>
                                                </div>
                                        </div>
                                          
                                    </div>
                                </div>

                            </div>

                            <div class="panel-footer">
                                <button class="btn btn-default">Clear Form</button>
                                <button class="btn btn-primary pull-right">Submit</button>
                            </div>
                        </div>
                    </form>

                </div>
            </div>

    </div>
       <%--  END PAGE CONTENT WRAPPER --%>
    </form>

     <!-- START SCRIPTS -->
        <!-- START PLUGINS -->
        <script type="text/javascript" src="../Theme/js/plugins/jquery/jquery.min.js"></script>
        <script type="text/javascript" src="../Theme/js/plugins/jquery/jquery-ui.min.js"></script>
        <script type="text/javascript" src="../Theme/js/plugins/bootstrap/bootstrap.min.js"></script>                
        <!-- END PLUGINS -->
        
        <!-- THIS PAGE PLUGINS -->
        <script type='text/javascript' src='js/plugins/icheck/icheck.min.js'></script>
        <script type="text/javascript" src="../Theme/js/plugins/mcustomscrollbar/jquery.mCustomScrollbar.min.js"></script>
        
        <script type="text/javascript" src="../Theme/js/plugins/bootstrap/bootstrap-datepicker.js"></script>                
        <script type="text/javascript" src="../Theme/js/plugins/bootstrap/bootstrap-file-input.js"></script>
        <script type="text/javascript" src="../Theme/js/plugins/bootstrap/bootstrap-select.js"></script>
        <script type="text/javascript" src="../Theme/js/plugins/tagsinput/jquery.tagsinput.min.js"></script>
        <!-- END THIS PAGE PLUGINS -->       
        
        <!-- START TEMPLATE -->
     <%--   <script type="text/javascript" src="../Theme/js/settings.js"></script>--%>
        
        <script type="text/javascript" src="../Theme/js/plugins.js"></script>        
        <script type="text/javascript" src="../Theme/js/actions.js"></script>        
        <!-- END TEMPLATE -->
    <!-- END SCRIPTS -->     
</body>
</html>
