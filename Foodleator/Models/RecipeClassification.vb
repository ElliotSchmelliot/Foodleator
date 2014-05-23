Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class RecipeClassification
    <Column(Order:=0)>
    <Key()>
    Public Property RecipeID As Integer
    <Column(Order:=1)>
    <Key()>
    Public Property RecipeTypeID As Integer

    'Public Overridable Property Recipe As Recipe
    'Public Overridable Property RecipeType As RecipeType
End Class
