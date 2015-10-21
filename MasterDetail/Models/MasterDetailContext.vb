Imports System.Data.Entity
Namespace Models
    Public Class MasterDetailContext
        Inherits DbContext
        ' È possibile aggiungere codice personalizzato a questo file. Le modifiche non verranno sovrascritte.
        ' 
        ' Per utilizzare Entity Framework per rimuovere e rigenerare il database
        ' automaticamente ogni volta che si modifica lo schema di modello, aggiungere il seguente
        ' codice al metodo Application_Start nel file Global.asax.
        ' Nota: il database verrà eliminato in modo permanente e ricreato a ogni modifica del modello.
        ' 
        ' System.Data.Entity.Database.SetInitializer(New System.Data.Entity.DropCreateDatabaseIfModelChanges(Of Models.MasterDetailContext)())

        Public Sub New()
            MyBase.New("name=MasterDetailContext")
        End Sub

        Public Property SalesMains As DbSet(Of SalesMain)
        Public Property SalesSubs As DbSet(Of SalesSub)
    End Class


End Namespace


