Imports System.Data.Entity
Imports MasterDetail.Models

Public Class SalesController
    Inherits System.Web.Mvc.Controller

    Private db As New MasterDetailContext

    '
    ' GET: /Sales/

    Function Index() As ActionResult
        Return View(db.SalesMains.ToList())
    End Function

    '
    ' GET: /Sales/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim salesmain As SalesMain = db.SalesMains.Find(id)
        If IsNothing(salesmain) Then
            Return HttpNotFound()
        End If
        Return View(salesmain)
    End Function

    '
    ' GET: /Sales/Create

    Function Create() As ActionResult
        ViewBag.Title = "Create"
        ViewBag.Operationtype = "Create"
        Return View()
    End Function

    '
    ' POST: /Sales/Create

    '<HttpPost()> _
    '<ValidateAntiForgeryToken()> _
    'Function Create(ByVal salesmain As SalesMain) As ActionResult
    '    If ModelState.IsValid Then
    '        db.SalesMains.Add(salesmain)
    '        db.SaveChanges()
    '        Return RedirectToAction("Index")
    '    End If

    '    Return View(salesmain)
    'End Function

    '
    ' POST: /Sales/Create
    '<ValidateAntiForgeryToken()>
    <HttpPost()>
    Function Create(salesmain As SalesMain) As JsonResult

        Try
            If ModelState.IsValid Then
                ''is sales main has salesID then we can undertand we have existing sales information
                '' so we need to perform update operation

                ''perform update

                If (salesmain.SalesId > 0) Then
                    Dim CurrentsalesSub = db.SalesSubs.Where(Function(p) p.SalesId = salesmain.SalesId)


                    For Each oldRec In CurrentsalesSub.ToList()
                        db.SalesSubs.Remove(oldRec)
                    Next

                    For Each newRec In salesmain.SalesSubs
                        db.SalesSubs.Add(newRec)
                    Next

                    db.Entry(salesmain).State = EntityState.Modified
                Else
                    db.SalesMains.Add(salesmain)
                End If

                db.SaveChanges()
                'If Sucess then Save/Update Successfull else there it has Exception

                Return Json(New With {.Success = 1, .SalesID = salesmain.SalesId, .ex = ""})

            End If

        Catch ex As Exception
            '' If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
            Return Json(New With {.Success = 0, .ex = ex.Message.ToString()})
        End Try

        Return Json(New With {.Success = 0, .ex = New Exception("unable to save").Message.ToString()})

    End Function

    '
    ' GET: /Sales/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult

        ViewBag.Title = "Edit"
        ViewBag.Operationtype = "Edit"
        Dim salesmain As SalesMain = db.SalesMains.Find(id)
        If IsNothing(salesmain) Then
            Return HttpNotFound()
        End If

        'Call Create View
        Return View("Create", salesmain)
    End Function

    ''
    '' POST: /Sales/Edit/5

    '<HttpPost()> _
    '<ValidateAntiForgeryToken()> _
    'Function Edit(ByVal salesmain As SalesMain) As ActionResult
    '    If ModelState.IsValid Then
    '        db.Entry(salesmain).State = EntityState.Modified
    '        db.SaveChanges()
    '        Return RedirectToAction("Index")
    '    End If

    '    Return View(salesmain)
    'End Function

    '
    ' GET: /Sales/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim salesmain As SalesMain = db.SalesMains.Find(id)
        If IsNothing(salesmain) Then
            Return HttpNotFound()
        End If
        Return View(salesmain)
    End Function

    '
    ' POST: /Sales/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim salesmain As SalesMain = db.SalesMains.Find(id)
        db.SalesMains.Remove(salesmain)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class