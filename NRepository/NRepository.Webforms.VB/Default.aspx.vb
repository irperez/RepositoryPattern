Imports System.ComponentModel.Composition
Imports NRepository.UniversityBL.BL

Public Class _Default
    Inherits Page

    <Import>
    Public Property CourseProvider As CourseProvider

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If (CourseProvider Is Nothing) Then
            Throw New ArgumentNullException("CourseProvider")
        End If
    End Sub
End Class
