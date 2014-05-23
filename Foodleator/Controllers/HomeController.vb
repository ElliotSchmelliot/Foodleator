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
        'Return Json(db.Recipes, JsonRequestBehavior.AllowGet)

        Dim recs As List(Of TempRecipe) = New List(Of TempRecipe)
        For Each rec As Foodleator.Recipe In db.Recipes
            recs.Add(New TempRecipe With {.RecipeID = rec.RecipeID, .RecipeName = rec.RecipeName, .EntryDate = rec.EntryDate.Month & "/" & rec.EntryDate.Day & "/" & rec.EntryDate.Year})
        Next
        Return Json(recs, JsonRequestBehavior.AllowGet)

        'Return Json(From obj In db.Recipes Select temp = New With {.Id = obj.RecipeID, .Name = obj.RecipeName, .EntryDate = obj.EntryDate.ToShortDateString} _
        ', JsonRequestBehavior.AllowGet)

        'Dim results As System.Data.Entity.Infrastructure.DbSqlQuery(Of Foodleator.Recipe) = db.Recipes.SqlQuery("SELECT recipeID, recipeName, entryDate FROM Recipe")
        'Dim list As List(Of Foodleator.Recipe) = results.ToList
        'Return Json(list, JsonRequestBehavior.AllowGet)
    End Function

    Private Class TempRecipe
        Public Property RecipeID As Integer
        Public Property RecipeName As String
        Public Property EntryDate As String
    End Class

End Class
