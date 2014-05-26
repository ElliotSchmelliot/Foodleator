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


    Private Class TempRecipe
        Public Property RecipeID As Integer
        Public Property RecipeName As String
        Public Property EntryDate As String
    End Class

End Class
