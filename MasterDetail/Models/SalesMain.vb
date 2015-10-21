Imports System.ComponentModel.DataAnnotations

Public Class SalesMain


    <Key>
    Public Property SalesId As Integer

    Public Property ReferenceNo As String

    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property SalesDate As DateTime
    Public Property SalesPerson As String

    Public Overridable Property SalesSubs As ICollection(Of SalesSub) = New HashSet(Of SalesSub)

End Class
