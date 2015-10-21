Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http

Public Class WebApiConfig
    Public Shared Sub Register(ByVal config As HttpConfiguration)
        config.Routes.MapHttpRoute( _
            name:="DefaultApi", _
            routeTemplate:="api/{controller}/{id}", _
            defaults:=New With {.id = RouteParameter.Optional} _
        )
        
        'Per abilitare il supporto query per le azioni con tipo restituito IQueryable o IQueryable(Of T), rimuovere il commento dalla seguente riga di codice.
        'Per evitare l'elaborazione di query dannose o impreviste, utilizzare le impostazioni di convalida definite in QueryableAttribute per convalidare le query in ingresso.
        'Per ulteriori informazioni, visitare il sito Web all'indirizzo http://go.microsoft.com/fwlink/?LinkId=279712.
        'config.EnableQuerySupport()
    End Sub
End Class