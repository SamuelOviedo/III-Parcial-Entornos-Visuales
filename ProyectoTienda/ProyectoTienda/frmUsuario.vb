Imports System.Text.RegularExpressions
Public Class frmUsuario
    Dim conexion As New conexion()
    Private Function validarCorreo(ByVal isCorreo As String) As Boolean
        Return Regex.IsMatch(isCorreo, "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$")
    End Function

    Private Sub limpiar()
        txtCodigo.Clear()
        txtNombre.Clear()
        txtApellido.Clear()
        txtUserName.Clear()
        txtPsw.Clear()
        txtCorreo.Clear()
        cmbRol.SelectedIndex = -1

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim idUsuario As Integer
        Dim nombre, apellido, userName, psw, correo, rol, estado As String
        idUsuario = txtCodigo.Text
        nombre = txtNombre.Text
        apellido = txtApellido.Text
        userName = txtUserName.Text
        psw = txtPsw.Text
        correo = txtCorreo.Text
        estado = "activo"
        rol = cmbRol.Text

        If validarCorreo(LCase(txtCorreo.Text)) = False Then
            MessageBox.Show("Correo invalido, *username@midominio.com*", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCorreo.Focus()
            txtCorreo.SelectAll()
        Else
            Try
                If conexion.insertarUsuario(idUsuario, nombre, apellido, userName, psw, rol, estado, correo) Then
                    MessageBox.Show("Usuario ingresado corectamente", "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    limpiar()
                Else
                    MessageBox.Show("Error al ingresar", "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            limpiar()
        End If
    End Sub

    Private Sub eliminarUsuario()
        Dim idUsuario As Integer
        Dim rol As String
        idUsuario = txtCodigo.Text
        rol = cmbRol.Text
        Try
            If (conexion.eliminarUsuario(idUsuario, rol)) Then
                MsgBox("Dado de baja")
            Else
                MsgBox("Error al dar de baja usuario")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub buscarUsuario()
        Dim userName As String
        userName = txtNombre.Text

        Try
            If (conexion.buscarUsuario(userName) = True) Then
                MsgBox("Usuario encontrado")
                limpiar()
            Else
                MsgBox("No se ha encontrado ningun usuario")
                limpiar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            limpiar()
        End Try

    End Sub

    Private Sub actualizarUsuario()
        Dim idUsuario As Integer
        Dim nombre, apellido, userName, psw, correo, rol As String
        idUsuario = txtCodigo.Text
        nombre = txtNombre.Text
        apellido = txtApellido.Text
        userName = txtUserName.Text

        psw = txtPsw.Text
        correo = txtCorreo.Text
        rol = cmbRol.Text

        Try
            If conexion.actualizarUsuario(idUsuario, nombre, apellido, userName, psw, correo, rol) = True Then
                MessageBox.Show("Actualizado correctamente", "Actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiar()
            Else
                MessageBox.Show("Algo salió mal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                limpiar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            limpiar()
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        eliminarUsuario()
    End Sub

    Private Sub btnLimpiar_Click_1(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        buscarUsuario()

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        actualizarUsuario()

    End Sub
End Class