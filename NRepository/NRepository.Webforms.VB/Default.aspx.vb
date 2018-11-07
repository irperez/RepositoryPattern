Imports System.ComponentModel.Composition
Imports NRepository.MyTestBL.BL

Public Class _Default
    Inherits Page

    <Import>
    Public Property TestProvider As TestProvider

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If (TestProvider Is Nothing) Then
            Throw New ArgumentNullException("TestProvider")
        End If
    End Sub
End Class