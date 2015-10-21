@ModelType MasterDetail.SalesMain

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>SalesMain</legend>

        @Html.HiddenFor(Function(model) model.SalesId)

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

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
