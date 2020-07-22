Imports System.Text.RegularExpressions
Public Class frmUsuario
    Dim conexion As New conexion()
    Dim dt As New DataTable

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
        dgvUsuarios.Columns.Clear()

    End Sub

    Function convertirMayusMin(ByVal cambiatext As String) As String
        Dim a As String = StrConv(cambiatext, VbStrConv.ProperCase)
        Return a
    End Function

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim idUsuario As Integer
        Dim nombre, apellido, userName, psw, correo, minCorreo As String
        Dim rol, estado As Char

        idUsuario = txtCodigo.Text

        nombre = convertirMayusMin(Me.txtNombre.Text)
        apellido = convertirMayusMin(Me.txtApellido.Text)

        userName = txtUserName.Text
        psw = txtPsw.Text

        minCorreo = LCase(txtCorreo.Text)
        correo = minCorreo

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
        Dim rol As Char
        idUsuario = txtCodigo.Text
        rol = cmbRol.Text
        Try
            If (conexion.eliminarUsuario(idUsuario, rol)) Then
                MessageBox.Show("Usuario dado de baja", "Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("Error al dar de baja usuario", "Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BuscarUsuario()
        Dim userName As String
        userName = txtUserName.Text

        Try
            dt = conexion.buscarUsuario(dgvUsuarios, userName)

            If dt.Rows.Count <> 0 Then
                MessageBox.Show("Usuario encontrado", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conexion.conexion.Close()

            Else
                MessageBox.Show("Usuario no encontrado", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dgvUsuarios.DataSource = Nothing
                txtUserName.Text = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub actualizarUsuario()
        Dim idUsuario As Integer
        Dim nombre, apellido, userName, psw, correo, minCorreo As String
        Dim rol, estado As Char

        idUsuario = txtCodigo.Text

        nombre = convertirMayusMin(Me.txtNombre.Text)
        apellido = convertirMayusMin(Me.txtApellido.Text)

        userName = txtUserName.Text
        psw = txtPsw.Text

        minCorreo = LCase(txtCorreo.Text)
        correo = minCorreo

        estado = "activo"
        rol = cmbRol.Text

        Try
            If conexion.actualizarUsuario(idUsuario, nombre, apellido, userName, psw, correo, rol, estado) Then
                MessageBox.Show("Usuario actualizado correctamente", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiar()
            Else
                MessageBox.Show("Error al actualizar usuario", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conexion.conexion.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        eliminarUsuario()
    End Sub

    Private Sub btnLimpiar_Click_1(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        BuscarUsuario()

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        actualizarUsuario()

    End Sub

    Private Sub dgvUsuarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellContentClick
        txtUserName.Text = dgvUsuarios.CurrentRow.Cells(1).Value.ToString
        txtCorreo.Text = dgvUsuarios.CurrentRow.Cells(4).Value.ToString

    End Sub
End Class