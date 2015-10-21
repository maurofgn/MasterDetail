﻿@ModelType MasterDetail.SalesMain

@Code
'    Layout = Nothing
'    ViewData("Title") = "Create"
End Code

<h2>@ViewBag.Title</h2>

@section Scripts

@*This is for jquery*@
@*<script src="../../Scripts/jquery-1.8.2.js" type="text/javascript"></script>*@ 

@*This is for jquery UI, for Calender control*@
<script src="../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>

@*This is for JSON*@
<script src="../../Scripts/json2.js" type="text/javascript"></script>

@*These are for DataTables*@
@*<script src="~/Scripts/DataTables-1.8.1/media/js/jquery.dataTables.js" type="text/javascript"></script>*@
<script src="../../Scripts/DataTables-1.8.1/media/js/jquery.dataTables.js" type="text/javascript"></script>
<script src="../../Scripts/DataTables-1.8.1/extras/TableTools/media/js/TableTools.js" type="text/javascript"></script>
<script src="../../Scripts/DataTables-1.8.1/extras/TableTools/media/js/ZeroClipboard.js" type="text/javascript"></script>

@*These are for styling Control*@

<link href="../../Content/DataTables/extras/TableTools/media/css/TableTools.css" rel="stylesheet" type="text/css" />
<link href="../../Content/DataTables/extras/TableTools/media/css/TableTools_JUI.css" rel="stylesheet" type="text/css" />
<link href="../../Content/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">


    // This function is used fro
    // delete selected row from Detail Table
    // set deleted item to Edit text Boxes
    function DeleteRow() {

        // Here I have used DataTables.TableTools plugin for getting selected row items
        var oTT = TableTools.fnGetInstance('tbl'); // Get Table instance
        var sRow = oTT.fnGetSelected(); // Get Selected Item From Table


        // Set deleted row item to editable text boxes
        $('#ItemName').val($.trim(sRow[0].cells[0].innerHTML.toString()));
        $('#Qty').val(jQuery.trim(sRow[0].cells[1].innerHTML.toString()));
        $('#UnitPrice').val($.trim(sRow[0].cells[2].innerHTML.toString()));

        $('.tbl').dataTable().fnDeleteRow(sRow[0]);
    }

    $(document).ready(function () {

//        alert("ready inizio class -->" + $('.tbl').dataTable())

        // here i have used datatables.js (jQuery Data Table)
        $('.tbl').dataTable({
            "sDom": 'T<"clear">lfrtip',
            "oTableTools": {
                "aButtons": [],
                "sRowSelect": "single"
            },
            "bLengthChange": false,
            "bFilter": false,
            "bSort": false,
            "bInfo": false
            //"scrollY":        '10vh',
            //"scrollCollapse": true,
            //"paging":         false
        });

        var oTable = $('.tbl').dataTable();

        $('#SalesDate').datepicker({ dateFormat: 'dd/mm/yy' })
    });


    // this function is used to add item to list table
    function Add() {

//        alert(" add item to list table - prima di dataTable.addData")

        // Adding item to table
        $('.tbl').dataTable().fnAddData([$('#ItemName').val(), $('#Qty').val(), $('#UnitPrice').val()]);

        // Making Editable text empty
        $('#ItemName').val("")
        $('#Qty').val("")
        $('#UnitPrice').val("")
    }

    //This function is used for sending data(JSON Data) to SalesController
    function Sales_save() {

        // Step 1: Read View Data and Create JSON Object

        // Creating SalesSub Json Object
        var salessub = { "SalesId": "", "ItemName": "", "Qty": "", "UnitPrice": "" };

        // Creating SalesMain Json Object
        var salesmain = { "SalesId": "", "ReferenceNo": "", "SalesDate": "", "SalesPerson": "", "SalesSubs": [] };

        // Set Sales Main Value
        salesmain.SalesId = $("#SalesId").val();
        salesmain.ReferenceNo = $("#ReferenceNo").val();
        salesmain.SalesDate = $("#SalesDate").val();
        salesmain.SalesPerson = $("#SalesPerson").val();

        var headId = typeof salesmain.SalesId == "undefined" ? 0 : salesmain.SalesId;

        // Getting Table Data from where we will fetch Sales Sub Record
        var oTable = $('.tbl').dataTable().fnGetData();

        for (var i = 0; i < oTable.length; i++) {

            salessub.SalesId = headId;
            // Set SalesSub individual Value
            salessub.ItemName = oTable[i][0];
            salessub.Qty = oTable[i][1];
            salessub.UnitPrice = oTable[i][2];
            // adding to SalesMain.SalesSub List Item
            salesmain.SalesSubs.push(salessub);
            salessub = { "ItemName": "", "Qty": "", "UnitPrice": "" };
        }
        // Step 1: Ends Here

        //alert(JSON.stringify(salesmain))

        // Set 2: Ajax Post
        // Here i have used ajax post for saving/updating information
        // url: 'http://localhost:10524/Sales/Create'

        $.ajax({
url:                '/Sales/Create',
            data: JSON.stringify(salesmain),
type:               'POST',
contentType:        'application/json;',
dataType:           'json',
            success: function (result) {
                if (result.Success == "1") {
                    window.location.href = "/Sales/index";
                }
                else {
                    alert(result.ex);
                }
            },
            error: function(jqXHR, textStatus, errorThrown ) {
                alert(jqXHR.statusText);
            }
        });
    }

</script>

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>
end section


@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>SalesMain</legend>


        @If (Not IsNothing(Model)) Then
            @<input type="hidden" id = "SalesId" name ="SalesId" value = "@Model.SalesId" />
        End If

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.ReferenceNo)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.ReferenceNo)
            @Html.ValidationMessageFor(Function(model) model.ReferenceNo)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.SalesDate)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.SalesDate)
            @Html.ValidationMessageFor(Function(model) model.SalesDate)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.SalesPerson)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.SalesPerson)
            @Html.ValidationMessageFor(Function(model) model.SalesPerson)
        </div>

    </fieldset>

@<br/>
    @<fieldset>
        <legend>Add Item</legend>

        <label>ItemName :</label>
@*         @Html.TextBox("ItemName", "", New With {.class = "css-class", .onclick = "alert('demo')"})*@
            @Html.TextBox("ItemName")
        <label>Qty :</label>
            @Html.TextBox("Qty")
        <label>Sales Price :</label>
            @Html.TextBox("UnitPrice")
        <input type="button" value="Add" onclick="Add()" />
        <br />
        <br />

        <table class="tbl" id="tbl">
            <thead><tr><th>ItemName</th> <th>Quantity</th> <th>Unit Price</th></tr></thead>
            <tbody>
           @If (Not IsNothing(Model)) Then
                   @For Each item In Model.SalesSubs
                        @<tr>
                        <td>@Html.DisplayTextFor(Function(i) item.ItemName)</td>
                        <td>@Html.DisplayTextFor(Function(i) item.Qty)</td>
                        <td>@Html.DisplayTextFor(Function(i) item.UnitPrice)</td>
                        </tr>
                   Next
               End If
           </tbody>
       </table>
       <br/>
       <input type="button" value="Delete Selected Row" onclick="DeleteRow()" />
    </fieldset>

    @<input type="button" value="Salva Ordine" onclick="Sales_save()" />

    End Using

<div>    @Html.ActionLink("Back to List", "Index")  </div>
