Imports System.ComponentModel.Composition
Imports NRepository.UniversityBL.BL

Public Class SampleControl
    Inherits System.Web.UI.UserControl

    <Import>
    Public Property TestProvider As CourseProvider

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (TestProvider Is Nothing) Then
            Throw New ArgumentNullException("TestProvider")
        End If
    End Sub

End Class