@ModelType MasterDetail.SalesMain

@Code
'    Layout = Nothing
'    ViewData("Title") = "Create"
End Code

<h2>@ViewBag.Title</h2>

@section Scripts


@*This is for jquery UI, for Calender control*@
@Scripts.Render("~/bundles/jqueryui")

@*This is for JSON*@
<script src="~/Scripts/json2.js" type="text/javascript"></script>

@*These are for styling Control*@
<link rel="stylesheet" type="text/css" href="~/Scripts/DataTables-1.10.9/css/jquery.dataTables.css" />

@*These are for DataTables*@
<script type="text/javascript" src="~/Scripts/DataTables-1.10.9/js/jquery.dataTables.js"></script>

<script type="text/javascript">

    function DeleteRow() {
        //sostituito da inner function
    }

    $(document).ready(
        function () {

            var table = $('#tblOrderLine').DataTable(
                {
                    "bLengthChange": false,
                    "bFilter": false,
                    "bSort": false,
                    "bInfo": false,
                    "language": {
                        "decimal": ",",
                        "thousands": ".",
                        "lengthMenu": "_MENU_ righe per pagina",
                        "zeroRecords": "Non ci sono righe",
                        "info": "pagina _PAGE_ di _PAGES_",
                        "infoEmpty": "Non ci sono righe disponibili",
                        "emptyTable": "Tabella vuota",
                        "infoFiltered": "(filtrati su _MAX_ righe totali)",
                        "loadingRecords": "Sto caricando...",
                        "processing": "Sto elaborando...",
                        "search": "Cerca:",
                        "paginate": {
                            "first": "Primo",
                            "last": "Ultimo",
                            "next": "Successivo",
                            "previous": "Precedente"
                        },
                        "aria": {
                            "sortAscending": ": ordine ascendente",
                            "sortDescending": ": ordine discendente"
                        }
                    }
                }
            );

            $('#tblOrderLine tbody').on('click', 'tr', function () {
                if ($(this).hasClass('selected')) {
                    $(this).removeClass('selected');
                }
                else {
                    table.$('tr.selected').removeClass('selected');
                    $(this).addClass('selected');
                }
            });

            $('#btnDelRow').click(function () {
                // prende i valori della riga selezionata e li assegna ai campi editabili prima di fare la delete della row, in modo che possa funzionare da update della riga

                var row = table.row('.selected')

                $('#ItemName').val(row.data()[0])
                $('#Qty').val(row.data()[1])
                $('#UnitPrice').val(row.data()[2])

                row.remove().draw(false);
            });

            $('#btnAddRow').click(function () {
                //todo: prendere i valori della riga ed assegnarli ai campi riga prima di fare la delete, in modo che possa funzionare da update della riga

                if (!$('#ItemName').val()) {
                    alert("itemName vuota o null o 0 o non definito");
                    return;
                }

                // Adding item to table
                table.row.add([
                    $('#ItemName').val(),
                    $('#Qty').val(),
                    $('#UnitPrice').val()
                ]).draw(false);

                // Making Editable text empty
                $('#ItemName').val("")
                $('#Qty').val("")
                $('#UnitPrice').val("")
            });

            $('#SalesDate').datepicker({
                dateFormat: "dd/mm/yy"
            });

        }
    );


    // this function is used to add item to list table
    function Add() {
        //sostituito da inner function

        //// Adding item to table
        //$('.tblOrderLine').dataTable().fnAddData([$('#ItemName').val(), $('#Qty').val(), $('#UnitPrice').val()]);

        //// Making Editable text empty
        //$('#ItemName').val("")
        //$('#Qty').val("")
        //$('#UnitPrice').val("")
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
        var oTable = $('#tblOrderLine').DataTable();
        var data = oTable.rows().data()  //matrice

        for (var i = 0; i < data.length; i++) {

            salessub.SalesId = headId;
            // Set SalesSub individual Value
            salessub.ItemName = data[i][0];
            salessub.Qty = data[i][1];
            salessub.UnitPrice = data[i][2];
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
            url: '/Sales/Create',
            data: JSON.stringify(salesmain),
            type: 'POST',
            contentType: 'application/json;',
            dataType: 'json',
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
            @Html.TextBox("ItemName")
        <label>Qty :</label>
            @Html.TextBox("Qty")
        <label>Sales Price :</label>
            @Html.TextBox("UnitPrice")
        <input type="button" id="btnAddRow" value="Add" onclick="Add()" />
        <br />
        <br />

         <table class="display" id="tblOrderLine">
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
         <input type="button" id="btnDelRow" value="Delete Selected Row" onclick="DeleteRow()" />
    </fieldset>

    @<input type="button" value="Salva Ordine" onclick="Sales_save()" />

    End Using

<div>    @Html.ActionLink("Back to List", "Index")  </div>
