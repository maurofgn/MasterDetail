@ModelType IEnumerable(Of MasterDetail.SalesMain)

@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.ReferenceNo)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SalesDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SalesPerson)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.ReferenceNo)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.SalesDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.SalesPerson)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.SalesId}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.SalesId}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.SalesId})
        </td>
    </tr>
Next

</table>
