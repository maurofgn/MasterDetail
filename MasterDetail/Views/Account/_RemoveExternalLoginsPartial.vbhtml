@ModelType ICollection(Of MasterDetail.ExternalLogin)

@If Model.Count > 0 Then
    @<h3>Account di accesso esterni registrati</h3>
    @<table>
        <tbody>
        @For Each externalLogin As MasterDetail.ExternalLogin In Model
            @<tr>
                <td>@externalLogin.ProviderDisplayName</td>
                <td>
                    @If ViewData("ShowRemoveButton") Then
                            Using Html.BeginForm("Disassociate", "Account")
                            @Html.AntiForgeryToken()
                            @<div>
                                @Html.Hidden("provider", externalLogin.Provider)
                                @Html.Hidden("providerUserId", externalLogin.ProviderUserId)
                                <input type="submit" value="Rimuovi" title="Rimuovi credenziali @externalLogin.ProviderDisplayName dall'account" />
                            </div>
                        End Using
                    Else
                        @: &nbsp;
                    End If
                </td>
            </tr>
        Next
        </tbody>
    </table>
End If