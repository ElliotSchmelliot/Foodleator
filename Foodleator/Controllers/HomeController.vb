Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private db As New DataContext
    'Function Index() As ActionResult
    '    ViewData("Message") = "So you can foodleate your food..."

    '    Return View(db.RecipeTypes)
    'End Function

    Function Index() As ActionResult
        Dim FilePath As String = Server.MapPath("~/Views/Home/index.html")
        If System.IO.File.Exists(FilePath) Then
            Return File(FilePath, "text/html")
        End If
        Return View()
    End Function


    Function Recipes() As ActionResult
        Return Json(New With {
                    .RecipeName = "sd"
                    }, JsonRequestBehavior.AllowGet)
    End Function

    Function RecipeTypes() As ActionResult
        Return Json(db.RecipeTypes, JsonRequestBehavior.AllowGet)
    End Function

    Function RecipeClassifications() As ActionResult
        Return Json(db.RecipeClassifications, JsonRequestBehavior.AllowGet)
    End Function
End Class
