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

    ' Get individual recipe information
    Function Recipe(ByVal id As Integer) As ActionResult
        Dim rec As Recipe = db.Recipes.Find(id)
        If rec IsNot Nothing Then
            Return Json(rec, JsonRequestBehavior.AllowGet)
        Else
            Return New HttpStatusCodeResult(422)
        End If
    End Function

    ' Add a new recipe (return GET of that item)
    <HttpPost()>
    Function Recipe(ByVal rec As Recipe) As ActionResult
        If ModelState.IsValid Then
            db.Recipes.Add(rec)
            db.SaveChanges()
            Return Recipe(rec.RecipeID)
        Else
            Return New HttpStatusCodeResult(422)
        End If
    End Function

    ' Update recipe
    <HttpPut()>
    Function Recipe(Rec As Recipe) As ActionResult
        Dim old As Recipe = db.Recipes.Find(Rec.RecipeID)
        If old IsNot Nothing Then
            old = Rec
            db.Entry(old).State = Entity.EntityState.Modified
            db.SaveChanges()
        Else
            Return New HttpStatusCodeResult(422)
        End If
    End Function

    ' Deletes recipe, returns 200 good or 500 bad
    '<HttpDelete()>
    'Function Recipe(id As Integer) As ActionResult

    'End Function

    Private Class TempRecipe
        Public Property RecipeID As Integer
        Public Property RecipeName As String
        Public Property EntryDate As String
    End Class

End Class
