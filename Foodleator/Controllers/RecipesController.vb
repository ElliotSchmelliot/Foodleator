Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Public Class RecipesController
    Inherits System.Web.Http.ApiController

    Private db As New DataContext

    ' GET api/Recipes
    Function GetRecipes() As IEnumerable(Of Recipe)
        Return db.Recipes.AsEnumerable()
    End Function

    ' GET api/Recipes/5
    Function GetRecipe(ByVal id As Integer) As Recipe
        Dim recipe As Recipe = db.Recipes.Find(id)
        If IsNothing(recipe) Then
            Throw New HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound))
        End If
        Return recipe
    End Function

    ' PUT api/Recipes/5
    Function PutRecipe(ByVal id As Integer, ByVal recipe As Recipe) As HttpResponseMessage
        If Not ModelState.IsValid Then
            Return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState)
        End If

        If Not id = recipe.RecipeID Then
            Return Request.CreateResponse(HttpStatusCode.BadRequest)
        End If

        db.Entry(recipe).State = EntityState.Modified

        Try
            db.SaveChanges()
        Catch ex As DbUpdateConcurrencyException
            Return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex)
        End Try

        Return Request.CreateResponse(HttpStatusCode.OK)
    End Function

    ' POST api/Recipes
    Function PostRecipe(ByVal recipe As Recipe) As HttpResponseMessage
        If ModelState.IsValid Then
            db.Recipes.Add(recipe)
            db.SaveChanges()

            Dim response As HttpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, recipe)
            response.Headers.Location = New Uri(Url.Link("DefaultApi", New With {.id = recipe.RecipeID}))
            Return response
        Else
            Return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState)
        End If
    End Function

    ' DELETE api/Recipes/5
    Function DeleteRecipe(ByVal id As Integer) As HttpResponseMessage
        Dim recipe As Recipe = db.Recipes.Find(id)
        If IsNothing(recipe) Then
            Return Request.CreateResponse(HttpStatusCode.NotFound)
        End If

        db.Recipes.Remove(recipe)

        Try
            db.SaveChanges()
        Catch ex As DbUpdateConcurrencyException
            Return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex)
        End Try

        Return Request.CreateResponse(HttpStatusCode.OK, recipe)
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub
End Class