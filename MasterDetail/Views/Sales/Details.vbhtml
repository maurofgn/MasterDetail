@ModelType MasterDetail.SalesMain

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>SalesMain</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.ReferenceNo)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.ReferenceNo)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.SalesDate)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.SalesDate)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.SalesPerson)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.SalesPerson)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.SalesId}) |
    @Html.ActionLink("Back to List", "Index")
</p>
