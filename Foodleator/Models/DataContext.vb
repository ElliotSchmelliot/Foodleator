Imports System.Data.Entity
Imports System.Web.Http
Imports System.Web.Optimization
Public Class DataContext
    Inherits DbContext

    Public Property RecipeTypes As DbSet(Of RecipeType)
    Public Property Recipes As DbSet(Of Recipe)
    Public Property RecipeClassifications As DbSet(Of RecipeClassification)

    Public Sub New()
        MyBase.New("Foodleator")
        System.Data.Entity.Database.SetInitializer(Of DataContext)(Nothing)
    End Sub

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As System.Data.Entity.DbModelBuilder)
        modelBuilder.Conventions.Remove(Of System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention)()
    End Sub

End Class
