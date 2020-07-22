Public Class Login
    Dim conexion As New conexion()
    Private Sub ingresarMenu()

        Dim userName, psw As String

        userName = txtUserName.Text
        psw = txtPsw.Text

        Try
            If (conexion.validarUsuario(userName, psw)) Then
                MessageBox.Show("Inicio realizado correctamente", "Inicio", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmUsuario.Show()
                Me.Hide()
            Else
                MessageBox.Show("Error usuario/contraseña invalido", "Inicio", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        ingresarMenu()

    End Sub
End Class