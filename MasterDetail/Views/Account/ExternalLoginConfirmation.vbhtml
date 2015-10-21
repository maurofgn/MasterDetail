@ModelType MasterDetail.RegisterExternalLoginModel
@Code
    ViewData("Title") = "Registrazione"
End Code

<hgroup class="title">
    <h1>@ViewData("Title").</h1>
    <h2>Associare l'account @ViewData("ProviderDisplayName").</h2>
</hgroup>

@Using Html.BeginForm("ExternalLoginConfirmation", "Account", New With {.ReturnUrl = ViewData("ReturnUrl")})
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(true)

    @<fieldset>
        <legend>Form di associazione</legend>
        <p>
            L'utente ha eseguito l'autenticazione con <strong>@ViewData("ProviderDisplayName")</strong>.
            Immettere di seguito un nome utente per il sito corrente e fare clic sul pulsante Conferma per completare
            l'accesso.
        </p>
        <ol>
            <li class="name">
                @Html.LabelFor(Function(m) m.UserName)
                @Html.TextBoxFor(Function(m) m.UserName)
                @Html.ValidationMessageFor(Function(m) m.UserName)
            </li>
        </ol>
        @Html.HiddenFor(Function(m) m.ExternalLoginData)
        <input type="submit" value="Registrazione" />
    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
