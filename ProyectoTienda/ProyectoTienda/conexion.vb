Imports System.Data.SqlClient
Public Class conexion
    Public conexion As SqlConnection = New SqlConnection("Data Source=DESKTOP-O55QRS2\MSSQLSERVERSAM;Initial Catalog=Tienda;Integrated Security=True")
    Public ds As DataSet = New DataSet()
    Public da As SqlDataAdapter
    Public cmb As SqlCommand
    Public dr As SqlDataReader

    Public Sub abrirConexion()
        Try
            conexion.Open()
        Catch ex As Exception
            MessageBox.Show("No se pudo Conectar: " + ex.ToString)
            End
        Finally
            conexion.Close()
        End Try
    End Sub

    Public Function insertarUsuario(idUsuario As Integer, nombre As String, apellido As String, userName As String,
                                    psw As String, rol As String, estado As String, correo As String)
        Try
            conexion.Open()

            cmb = New SqlCommand("insertarUsuario", conexion)
            cmb.CommandType = CommandType.StoredProcedure

            cmb.Parameters.AddWithValue("@idUsuario", idUsuario)
            cmb.Parameters.AddWithValue("@nombre", nombre)
            cmb.Parameters.AddWithValue("@apellido", apellido)
            cmb.Parameters.AddWithValue("@userName", userName)
            cmb.Parameters.AddWithValue("@psw", psw)
            cmb.Parameters.AddWithValue("@rol", rol)
            cmb.Parameters.AddWithValue("@estado", estado)
            cmb.Parameters.AddWithValue("@correo", correo)

            If cmb.ExecuteNonQuery <> 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function eliminarUsuario(idUsuario As Integer, rol As String)

        Try
            conexion.Open()
            cmb = New SqlCommand("eliminarUsuario", conexion)
            cmb.CommandType = CommandType.StoredProcedure
            cmb.Parameters.AddWithValue("@idUsuario", idUsuario)
            cmb.Parameters.AddWithValue("@rol", rol)

            If cmb.ExecuteNonQuery <> 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()

        End Try

    End Function

    Public Function buscarUsuario(userName As String) As Boolean

        Try
            conexion.Open()
            cmb = New SqlCommand("busquedaUsuario", conexion)
            cmb.CommandType = CommandType.StoredProcedure
            cmb.Parameters.AddWithValue("@userName", userName)

            If cmb.ExecuteNonQuery <> 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()

        End Try

    End Function


    Public Function actualizarUsuario(idUsuario As Integer, nombre As String, apellido As String, userName As String, psw As String, correo As String, rol As String) As Boolean

        Try
            conexion.Open()
            Dim cmd As New SqlCommand("modificarUsuario", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario)
            cmd.Parameters.AddWithValue("@nombre", nombre)
            cmd.Parameters.AddWithValue("@apellido", apellido)
            cmd.Parameters.AddWithValue("@userName", userName)
            cmd.Parameters.AddWithValue("@psw", psw)
            cmd.Parameters.AddWithValue("@correo", correo)
            cmd.Parameters.AddWithValue("@rol", rol)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()

        End Try

    End Function

End Class
