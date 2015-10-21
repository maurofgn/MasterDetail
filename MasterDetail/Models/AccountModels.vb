Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization
Imports System.Data.Entity

Public Class UsersContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("DefaultConnection")
    End Sub

    Public Property UserProfiles As DbSet(Of UserProfile)
End Class

<Table("UserProfile")> _
Public Class UserProfile
    <Key()> _
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)> _
    Public Property UserId As Integer

    Public Property UserName As String
End Class

Public Class RegisterExternalLoginModel
    <Required()> _
    <Display(Name:="Nome utente")> _
    Public Property UserName As String

    Public Property ExternalLoginData As String
End Class

Public Class LocalPasswordModel
    <Required()> _
    <DataType(DataType.Password)> _
    <Display(Name:="Password corrente")> _
    Public Property OldPassword As String

    <Required()> _
    <StringLength(100, ErrorMessage:="La lunghezza di {0} deve essere di almeno {2} caratteri.", MinimumLength:=6)> _
    <DataType(DataType.Password)> _
    <Display(Name:="Nuova password")> _
    Public Property NewPassword As String

    <DataType(DataType.Password)> _
    <Display(Name:="Conferma nuova password")> _
    <Compare("NewPassword", ErrorMessage:="La nuova password e la password di conferma non corrispondono.")> _
    Public Property ConfirmPassword As String
End Class

Public Class LoginModel
    <Required()> _
    <Display(Name:="Nome utente")> _
    Public Property UserName As String

    <Required()> _
    <DataType(DataType.Password)> _
    <Display(Name:="Password")> _
    Public Property Password As String

    <Display(Name:="Memorizza account")> _
    Public Property RememberMe As Boolean
End Class

Public Class RegisterModel
    <Required()> _
    <Display(Name:="Nome utente")> _
    Public Property UserName As String

    <Required()> _
    <StringLength(100, ErrorMessage:="La lunghezza di {0} deve essere di almeno {2} caratteri.", MinimumLength:=6)> _
    <DataType(DataType.Password)> _
    <Display(Name:="Password")> _
    Public Property Password As String

    <DataType(DataType.Password)> _
    <Display(Name:="Conferma password")> _
    <Compare("Password", ErrorMessage:="La password e la password di conferma non corrispondono.")> _
    Public Property ConfirmPassword As String
End Class

Public Class ExternalLogin
    Public Property Provider As String
    Public Property ProviderDisplayName As String
    Public Property ProviderUserId As String
End Class
