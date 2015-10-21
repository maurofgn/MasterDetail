Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class SalesSub

    <Key>
    <Column(Order:=0)>
    Public Property SalesId As Integer

    <Key>
    <Column(Order:=1)>
    Public Property ItemName As String

    Public Property Qty As Integer
    Public Property UnitPrice As Decimal
    Public Property SalesPerson As String

    Public Overridable Property SalesMain As SalesMain


End Class
