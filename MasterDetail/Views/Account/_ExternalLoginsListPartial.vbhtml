@ModelType ICollection(Of AuthenticationClientData)

@If Model.Count = 0 Then
    @<div class="message-info">
        <p>Non sono configurati servizi di autenticazione esterni. Vedere <a href="http://go.microsoft.com/fwlink/?LinkId=252166">questo articolo</a>
        per informazioni su come configurare l'applicazione ASP.NET per il supporto dell'accesso tramite servizi esterni.</p>
    </div>
Else
    Using Html.BeginForm("ExternalLogin", "Account", New With { .ReturnUrl = ViewData("ReturnUrl") })
    @Html.AntiForgeryToken()
    @<fieldset id="socialLoginList">
        <legend>Accedi tramite un altro servizio</legend>
        <p>
        @For Each p as AuthenticationClientData in Model
            @<button type="submit" name="provider" value="@p.AuthenticationClient.ProviderName" title="Accedi con l'account @p.DisplayName">@p.DisplayName</button>
        Next
        </p>
    </fieldset>
    End Using
End If
