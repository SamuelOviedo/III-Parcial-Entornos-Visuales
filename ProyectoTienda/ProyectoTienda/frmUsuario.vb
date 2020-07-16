Imports System.Text.RegularExpressions
Public Class frmUsuario
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validarCorreo(LCase(txtCorreo.Text)) = False Then
            MessageBox.Show("Correo invalido", "username@midominio.com", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)


        End If
    End Sub

    Private Function validarCorreo(ByVal esCorreo As String) As Boolean
        Return Regex.IsMatch(esCorreo, "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[_a-z0-9-]+)*(\.[a-z]{2,4})$")

    End Function


End Class
